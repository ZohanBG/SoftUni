namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

			StringBuilder sb = new StringBuilder();

			List<Game> games = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isReleaseDateValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Game game = new Game()
				{
					Name = gameDto.Name,
					Price = gameDto.Price,
					ReleaseDate = releaseDate
				};

				Developer developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);
				if(developer == null)
                {
					developer = new Developer() { Name = gameDto.Developer };
					developers.Add(developer);
				}
				game.Developer = developer;

				Genre genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);
				if(genre == null)
                {
					genre = new Genre() { Name = gameDto.Genre };
					genres.Add(genre);
                }
				game.Genre = genre;

                foreach (var tagName in gameDto.Tags)
                {
					Tag tag = tags.FirstOrDefault(x => x.Name == tagName);
					if(tag == null)
                    {
						tag = new Tag() { Name = tagName };
						tags.Add(tag);
                    }
					game.GameTags.Add(new GameTag() { Tag = tag });
                }

				games.Add(game);
				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags"!);
            }

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

			StringBuilder sb = new StringBuilder();

			List<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
				bool hasInvalidCard = false;

                if (!IsValid(userDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				User user = new User()
				{
					FullName = userDto.FullName,
					Username = userDto.Username,
					Email = userDto.Email,
					Age = userDto.Age
				};

				List<Card> cards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
					string[] cardTypes = new string[] { "Debit", "Credit" };
					if (!IsValid(cardDto) || cardTypes.Any(t => t == cardDto.Type) == false)
                    {
						sb.AppendLine("Invalid Data");
						hasInvalidCard = true;
						break;
                    }

					Card card = new Card()
					{
						Number = cardDto.Number,
						Cvc = cardDto.Cvc,
						Type = cardDto.Type == "Debit" ? CardType.Debit : CardType.Credit
					};

					cards.Add(card);
                }

                if (!hasInvalidCard)
                {
					user.Cards = cards;
					users.Add(user);
					sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards"!);
                }
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

			ImportPurchaseDto[] purchaseDtos;

			using (StringReader sr = new StringReader(xmlString))
			{
				purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(sr);
			}

			StringBuilder sb = new StringBuilder();

			List<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				string[] types = new string[] { "Retail", "Digital" };

				if(types.Any(t => t == purchaseDto.Type) == false)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				PurchaseType type = purchaseDto.Type == "Retail" ? PurchaseType.Retail : PurchaseType.Digital;

				bool isDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Game game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

				if(game == null)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Card card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

				if (card == null)
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				Purchase purchase = new Purchase()
				{
					Type = type,
					ProductKey = purchaseDto.Key,
					Date = date,
					Card = card,
					Game = game
				};

				purchases.Add(purchase);

				sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
			}

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}