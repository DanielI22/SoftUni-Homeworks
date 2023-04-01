namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;
    using Theatre.Utilities;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls)
                .Where(t => t.Tickets.Count >= 20)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Sum(ti => ti.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new
                        {
                            Price = ti.Price,
                            RowNumber = ti.RowNumber
                        })
                        .OrderByDescending(ti => ti.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        private static XmlHelper xmlHelper;

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            xmlHelper = new XmlHelper();

            ExportPlayDto[] plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .OrderByDescending(c => c.FullName)
                        .Select(c => new ExportActorDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{c.Play.Title}'.",
                        })
                        .ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(plays, "Plays");
        }
    }
}
