﻿namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            ImportPlayDto[] playDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(sr);
            }

            StringBuilder sb = new StringBuilder();

            List<Play> plays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object genre;
                bool isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre, out genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration, "c",
                    CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            ImportCastDto[] castDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                castDtos = (ImportCastDto[])xmlSerializer.Deserialize(sr);
            }

            StringBuilder sb = new StringBuilder();

            List<Cast> casts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Theatre> theatres = new List<Theatre>();

            foreach (var theatreDto in theatreDtos)
            {

                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                List<Ticket> tickets = new List<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }               

                    tickets.Add(new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    });
                }

                theatre.Tickets = tickets;

                theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
