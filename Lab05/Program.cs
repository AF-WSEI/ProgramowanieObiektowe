namespace Lab05;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wpisz jedną z poniższych ocen: ");
        var names = Enum.GetNames<Degree>();
        Console.WriteLine(string.Join(", ", names));
        // ^ works like:
        // foreach (var ocena in names)
        // {
        //     Console.Write(ocena + " ");
        // }
        string? degreeStr = Console.ReadLine();
        Degree degree;
        while (!Enum.TryParse<Degree>(degreeStr?.ToUpper() ?? "", out degree))
        {
            Console.WriteLine("Nieznana ocena, wpisz jeszcze raz.");
            degreeStr = Console.ReadLine();
        }
        Degree d = Degree.BARDZO_DOBRY;
        Console.WriteLine((int)d);
        Console.WriteLine((int)degree);
        int d1 = (int)d;
        int d2 = (int)degree;
        Console.WriteLine($"Średnia ocen: {(d1 + d2) / 20.0}");
    }

    public static void SwitchDemo()
    {
        Console.WriteLine("Wpisz jedną z poniższych ocen: ");
        var names = Enum.GetNames<Degree>();
        Console.WriteLine(string.Join(", ", names));
        string? degreeStr = Console.ReadLine();
        Degree degree;
        while (!Enum.TryParse<Degree>(degreeStr?.ToUpper() ?? "", out degree))
        {
            Console.WriteLine("Nieznana ocena, wpisz jeszcze raz.");
            degreeStr = Console.ReadLine();
        }
        string englishDegree = degree switch
        {
            Degree.BARDZO_DOBRY => "A",
            Degree.DOBRY_PLUS => "B",
            Degree.DOBRY => "C",
            Degree.DOSTATECZNY_PLUS => "D",
            Degree.DOSTATECZNY => "E",
            Degree.NIEDOSTATECZNY => "F",
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
        Console.WriteLine(englishDegree);
    }

    public static void Task01()
    {
        Console.WriteLine("Wpisz nr miesiąca: ");
        int month = int.Parse(Console.ReadLine());
        string poraRoku = month switch
        {
            12 or 1 or 2 => "zima",
            3 or 4 or 5 => "wiosna",
            6 or 7 or 8 => "lato",
            9 or 10 or 11 => "jesień",
            _ => throw new ArgumentOutOfRangeException(nameof(month), month, null)
        };
        Console.WriteLine(poraRoku);
    }
}

public enum Degree
{
    NIEDOSTATECZNY = 20,
    DOSTATECZNY = 30,
    DOSTATECZNY_PLUS = 35,
    DOBRY = 40,
    DOBRY_PLUS = 45,
    BARDZO_DOBRY = 50
}