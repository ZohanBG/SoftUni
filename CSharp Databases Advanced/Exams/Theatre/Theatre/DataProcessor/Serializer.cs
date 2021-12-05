namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(r => r.RowNumber >= 1 && r.RowNumber <= 5)
                    .Sum(p => p.Price),
                    Tickets = t.Tickets
                    .Where(r => r.RowNumber >= 1 && r.RowNumber <= 5)
                    .Select(i => new
                    {
                        Price = Math.Round(i.Price, 2),
                        RowNumber = i.RowNumber
                    })
                    .OrderByDescending(i => i.Price)
                    .ToArray()

                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            ExportPlayDto[] plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter == true)
                    .Select(c => new ActorDto() 
                    { 
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Plays");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, plays, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
