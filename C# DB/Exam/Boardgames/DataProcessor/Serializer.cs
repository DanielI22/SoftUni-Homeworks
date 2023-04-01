namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        private static XmlHelper xmlHelper;
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            xmlHelper = new XmlHelper();

            ExportCreatorDto[] creators = context
                .Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count(),
                    CreatorName = c.FirstName + " " + c.LastName,
                    Boardgames = c.Boardgames
                    .ToArray()
                        .Select(b => new ExportBoardgameDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .OrderBy(b => b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .ToArray()
                .Where(c => c.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year
                && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year
                        && bs.Boardgame.Rating <= rating)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            //var sellers = context.Sellers
            //    .ToArray()
            //    .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            //    .Select(s => new
            //    {
            //        Name = s.Name,
            //        Website = s.Website,
            //        Boardgames = s.BoardgamesSellers
            //            .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
            //            .Select(b => new
            //            {
            //                Name = b.Boardgame.Name,
            //                Rating = b.Boardgame.Rating,
            //                Mechanics = b.Boardgame.Mechanics,
            //                Category = b.Boardgame.CategoryType.ToString()
            //            })
            //            .OrderByDescending(b => b.Rating)
            //            .ThenBy(b => b.Name)

            //    })
            //    .OrderByDescending(s => s.Boardgames.Count())
            //    .ThenBy(s => s.Name)
            //    .Take(5)
            //    .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);

        }
    }
}