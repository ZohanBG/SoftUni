namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
        }

        //1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var goldenBook in goldenBooks)
            {
                sb.AppendLine(goldenBook);
            }

            return sb.ToString().TrimEnd();

        }

        //3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksPrices = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            foreach (var bookPrice in booksPrices)
            {
                sb.AppendLine($"{bookPrice.Title} - ${bookPrice.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            string[] bookTitles = context.Books
                .Where(b => b.ReleaseDate.HasValue
                && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var item in bookTitles)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();

        }

        //5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bookTitles = context.Books
                .Where(b => b.BookCategories
                .Any(a => input.Contains(a.Category.Name)))
                .OrderBy(b => b.Title)
                .ToArray();
                
            foreach (var item in bookTitles)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var releasedBefore = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var result = context.Books
                .Where(b => b.ReleaseDate < releasedBefore)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        //7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(b => b.FirstName.EndsWith(input))
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName
                })
                .OrderBy(b => b.FullName)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        //8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var item in bookTitles)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksByAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToArray();

            foreach (var item in booksByAuthors)
            {
                sb.AppendLine($"{item.Title} ({item.FullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var autorCopies = context.Authors
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName,
                    Count = b.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.Count)
                .ToArray();

            foreach (var item in autorCopies)
            {
                sb.AppendLine($"{item.FullName} - {item.Count}");
            }

            return sb.ToString().TrimEnd();

        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoryProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var item in categoryProfit)
            {
                sb.AppendLine($"{item.Name} ${item.Profit:f2}");
            }
             
            return sb.ToString().TrimEnd();
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var recentBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks                  
                    .Select(b => b.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Select(b => new 
                    { 
                        b.Title,
                        b.ReleaseDate.Value.Year
                    })
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var item in recentBooks)
            {
                sb.AppendLine($"--{item.CategoryName}");
                foreach (var book in item.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToArray();

            foreach (var item in books)
            {
                item.Price += 5M;
            }

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToArray();

            int count = books.Count();

            foreach (var item in books)
            {
                context.Books.Remove(item);
            }

            context.SaveChanges();

            return count;

        }
    }
}
