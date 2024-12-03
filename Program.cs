using Dolgozat20241203;
using System.Diagnostics;

//Book book1 = new Book( "Harry Potter", "Kurva Anyád");
//Console.WriteLine(book1);

//Book book2 = new Book("1234567891", "Harry Potter", 2019, "angol", 3, 2100, ["Fasz Fej", "Kurva Anyád"]);
//Console.WriteLine(book2);

//string[] authors = ["Fasz Fej", "Kurva Anyád"];
//Book book3 = new Book("1234567891", "Harry Potter", 2019, "angol", 3, 2100, authors);
//Console.WriteLine(book2);

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
string[] engTitle = new string[] {
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
    // Magyar szerzők
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
    int lang = Random.Shared.Next(0, 10);
    string isbn = new Random().NextInt64(1000000000, 9999999999).ToString();
    string author = "";
    string title = "";
    if (lang <= 1)
    {
        author = engAuthors[Random.Shared.Next(0, engAuthors.Length)];
        title = engTitle[Random.Shared.Next(0, engTitle.Length)];
    }
    else
    {
        author = hunAuthors[Random.Shared.Next(0, hunAuthors.Length)];
        title = hunTitles[Random.Shared.Next(0, hunTitles.Length)];
    }
    //ellenőrizd isbn





    books.Add(new Book(isbn,))
}