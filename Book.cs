using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat20241203
{
    internal class Book
    {
        private string isbn;
        private List<Author> authorList = [];
        private string title;
        private int releaseYear;
        private string language;
        private int price;
        public uint Stock { get; set; }

        private enum LanguageEnum
        {
            angol,
            német,
            magyar
        }

        public string Isbn { 
            get => isbn; 
            set
            {
                if (value is null)
                    throw new Exception("You didn't specify the ISBN identifier.");
                if (value.Length != 10) 
                    throw new Exception("ISBN identifier must be 10 characters long.");
                isbn = value;
            } 
        }
        public List<Author> AuthorList {
            get => authorList;
            set => authorList = value;
        }
        public string Title {
            get => title;
            set
            {
                if (value is null)
                    throw new Exception("You didn't specify the title.");
                if (value.Length < 3 || value.Length > 64)
                    throw new Exception("The title length must be between 3 and 64 characters.");
                title = value;
            }
        }
        public int ReleaseYear { 
            get => releaseYear;
            set {
                if(value < 2007 || value > DateTime.Now.Year)
                    throw new Exception("The release year must be between 2007 and the current year.");
                releaseYear = value;
            } 
        }
        public string Language { 
            get => language;
            set 
            {
                if (value is null)
                    throw new Exception("You didn't specify the language.");
                if (!Enum.TryParse<LanguageEnum>(value, true, out var parsedLanguage))
                    throw new Exception("The language must be either 'angol', 'német' or 'magyar'.");
                language = parsedLanguage.ToString().ToLower();
            }
        }
        public int Price { 
            get => price;
            set
            {
                if (value < 1000 || value > 10000)
                    throw new Exception("The price must be between 1000 and 10000.");
                if (value % 100 != 0)
                    throw new Exception("The price must be dividable by 100.");
            }
        }

        public Book(string isbn, string title, int releaseYear, string language, uint stock, int price, params string[] authors)
        {
            authorList = [];

            Isbn = isbn;
            Title = title;
            ReleaseYear = releaseYear;
            Language = language;
            Stock = stock;
            Price = price;

            foreach (var author in authors)
            {
                authorList.Add(new Author(author));
            }
        }

        public Book(string title, string author)
        {
            authorList = [];

            isbn = Random.Shared.NextInt64(1000000000, 9999999999).ToString();
            Title = title;
            ReleaseYear = 2024;
            Language = "magyar";
            Stock = 0;
            Price = 4500;

            authorList.Add(new Author(author));
        }

        public override string ToString()
        {
            if(authorList.Count == 1)
            {
                if (Stock == 0)
                {
                    return $"Szerző: {authorList[0].ToString()}, Cím: {title}, Készlet: Beszerzés alatt.";
                }
                return $"Szerző: {authorList[0].ToString()}, Cím: {title}, Készlet: {Stock}";
            }
            else
            {
                if (Stock == 0)
                {
                    return $"Szerzők: {string.Join(", ", authorList)}, Cím: {title}, Készlet: Beszerzés alatt.";
                }
                return $"Szerzők: {string.Join(", ", authorList)}, Cím: {title}, Készlet: {Stock}";
            }
        }
    }
}
