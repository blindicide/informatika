using System;
using System.Net;
using System.Runtime.CompilerServices;

class WrittenMedia
{
    public int Price;
    private string ParentFrequency;

    public WrittenMedia()
    {
        this.Price = 200;
        this.ParentFrequency = "раз в месяц";
    }
    public WrittenMedia(int Price)
    {
        this.Price = Price;
        this.ParentFrequency = "раз в месяц";
    }

    public virtual void ShowInfo()
    {
        Console.Write("Цена издания, выпускаемого ");
        Console.Write(ParentFrequency);
        Console.Write(", составляет ");
        Console.Write(Price);
        Console.WriteLine(" рублей. ");
    }
    public string GetParentFrequency
    {
        get { return ParentFrequency; }
        set { if (ParentFrequency != value) { ParentFrequency = value; } }
    }
}

class Magazine : WrittenMedia
{
    private string City;

    public Magazine()
    {
        this.City = "Тест-Сити";
        this.Price = 201;
    }
    public Magazine(string cityname)
    {
        this.City = cityname;
        this.Price = 201;
    }
    public override void ShowInfo()
    {
        Console.Write("Цена журнала, выпускаемого в городе ");
        Console.Write(City);
        Console.Write(", составляет ");
        Console.Write(Price);
        Console.WriteLine(" рублей. ");
    }
    public string GetCity
    {
        get { return City; }
        set { if (City != value) { City = value; } }
    }
}

class Book : WrittenMedia
{
    private string Author;
    public Book()
    {
        this.Author = "А. С. Пушкин";
        this.Price = 202;
    }
    public Book(string author)
    {
        this.Author = author;
        this.Price = 202;
    }
    public override void ShowInfo()
    {
        Console.Write("Цена книги, автор которой - ");
        Console.Write(Author);
        Console.Write(", составляет ");
        Console.Write(Price);
        Console.WriteLine(" рублей. ");
    }
    public string GetAuthor
    {
        get { return Author; }
        set { if (Author != value) { Author = value; } }
    }
}

class Newspaper : WrittenMedia
{
    private string Name;
    public Newspaper()
    {
        this.Name = "Курьер Тест-Сити";
        this.Price = 203;
    }
    public Newspaper(string name)
    {
        this.Name = name;
        this.Price = 203;
    }
    public override void ShowInfo()
    {
        Console.Write("Цена газеты под названием ");
        Console.Write(Name);
        Console.Write(", составляет ");
        Console.Write(Price);
        Console.WriteLine(" рублей. ");
    }
    public string GetName
    {
        get { return Name; }
        set { if (Name != value) { Name = value; } }
    }
}

class HelloWorld1
{
    static void Main()
    {
        WrittenMedia WM1 = new WrittenMedia(400);
        Magazine MoscowMagazine = new Magazine("Москва");
        Book WarAndPeace = new Book("Л. Толстой");
        Newspaper MosKom = new Newspaper("\"Московский комсомолец\"");
        WrittenMedia[] writtenMedias = new WrittenMedia[] { WM1, MoscowMagazine, WarAndPeace, MosKom };
        for (int a = 0; a < 4; a++)
        {
            writtenMedias[a].ShowInfo();
        }
    }
}