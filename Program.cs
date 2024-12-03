using Dolgozat20241203;

string[] hunTitles = new string[]
{
    "A titkok kertje",
    "Az elfeledett város",
    "A fény útján",
    "A magányos fák alatt",
    "Az idő kereke",
    "Tükrök és árnyak",
    "Az utolsó remény",
    "A sivatag csendje",
    "A fehér lovas",
    "Harmadik felvonás",
    "A csillagok háborúja",
    "Egyetlen nap, egy örökkévalóság",
    "A szél mesteri tánca",
    "Az elveszett hangjegy",
    "Az alvilág titkai",
    "A kék sziget varázsa",
    "Hozzám tartozol",
    "A fagyott tenger",
    "A vihar szíve",
    "A fényszóró árnyéka",
};
string[] engTitles = new string[] {
    "Whispers of the Night",
    "The Shadow's Embrace",
    "Beneath the Crimson Sky",
    "The Last Dreamer",
    "Tales of the Forgotten Kingdom",
    "Echoes from the Abyss",
    "The Silent Witness",
    "Through the Mist",
    "The Starry Path",
    "Waves of Eternity"};
string[] hunAuthors = new string[]
{
    "Kertész Imre",
    "Károlyi Mihály",
    "Móricz Zsigmond",
    "Jókai Mór",
    "Kosztolányi Dezső",
    "Szabó Magda",
    "Pilinszky János",
    "Nádas Péter",
    "Tóth Krisztina",
    "Vásárhelyi Anna",
    "Kundera Milan",
    "Kiss Anna",
    "Cziffra György",
    "Bán Zsófia",
    "Bodrogi László",
    "Váci Mihály",
    "Heltai Jenő",
    "Szerb Antal",
    "Fekete István",
    "Szentkuthy Miklós",
};
string[] engAuthors = new string[]
{
    "George Orwell",
    "Virginia Woolf",
    "J.K. Rowling",
    "Mark Twain",
    "Ernest Hemingway",
    "Scott Fitzgerald",
    "Jane Austen",
    "Oscar Wilde",
    "Agatha Christie",
    "H.P. Lovecraft"
};
List<Book> books = new();

for (int i = 0; i < 15; i++)
{
    string isbn = new Random().NextInt64(1000000000, 9999999999).ToString();
    while (books.Any(x => x.Isbn == isbn))
    {
        isbn = new Random().NextInt64(1000000000, 9999999999).ToString();
    }

    int year = Random.Shared.Next(2017, DateTime.Now.Year);
    uint stock = (uint)Random.Shared.Next(5, 11);
    double temp = Random.Shared.NextInt64(1000, 10000);
    int price = (int)Math.Round(temp / 100, 0) * 100;
    if (Random.Shared.Next(0, 10) <= 2) stock = 0;

    string title = hunTitles[Random.Shared.Next(0, hunTitles.Length)];
    string language = "magyar";
    List<string> authorList = new();

    if (Random.Shared.Next(0, 10) <= 2)
    {
        title = engTitles[Random.Shared.Next(0, engTitles.Length)];
        int authorCount = Random.Shared.Next(1, 4); 
        for (int j = 0; j < authorCount; j++)
        {
            authorList.Add(PickAuthor(engAuthors));
        }
        language = "angol";
    }
    else
    {
        int authorCount = Random.Shared.Next(1, 4);
        for (int j = 0; j < authorCount; j++)
        {
            authorList.Add(PickAuthor(hunAuthors));
        }
    }

    books.Add(new Book(isbn, title, year, language, stock, price, authorList.ToArray()));
}

int moneySpent = 0;
int booksRemoved = 0;
int originalBookCount = books.Count();

for (int i = 0; i < 100; i++)
{
    if (books.Count == 0) break;
    Book randomBook = books[Random.Shared.Next(0, books.Count)];

    if (randomBook.Stock > 0)
    {
        moneySpent += randomBook.Price;
        randomBook.Stock--;
    }
    else
    {
        if (Random.Shared.Next(0, 2) == 0)
        {
            randomBook.Stock += (uint)Random.Shared.Next(1, 11);
        }
        else
        {
            books.Remove(randomBook);
            booksRemoved++;
        }
    }
}

Console.WriteLine($"Bevétel: {moneySpent} Ft");
Console.WriteLine($"Nagykertől eltávolított könyvek: {booksRemoved}");
Console.WriteLine($"Eredeti könyvek száma: {originalBookCount} db");
Console.WriteLine($"Jelenlegi könyvek száma: {books.Count} db");
Console.WriteLine($"Eltűnt könyvek: {originalBookCount - books.Count} db");

static string PickAuthor(string[] authors)
{
    return authors[Random.Shared.Next(0, authors.Length)];
}
