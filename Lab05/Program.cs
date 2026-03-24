namespace Lab05;

public record StudentDegree(Degree degree, string StudentName);

public record Point
{
    public required double X { get; init; }
    public required double Y { get; init; }

    public Point MoveX(int delta)
    {
        return new Point()
        {
            X = X + delta,
            Y = Y
        };
    }
    
    public Point MoveY(int delta)
    {
        return new Point()
        {
            X = X,
            Y = Y + delta
        };
    }
}

class Program
{
    public static void RecordDemo()
    {
        StudentDegree sd1 = new StudentDegree(Degree.BARDZO_DOBRY, "Adam");
        StudentDegree sd2 = new StudentDegree(Degree.DOBRY, "Ewa");
        Console.WriteLine(sd1);
        Console.WriteLine(sd1 == sd2);
        Console.WriteLine(sd1 == new StudentDegree(Degree.BARDZO_DOBRY, "Adam"));
        Point p1 = new Point
        {
            X = 6,
            Y = 7
        };
        Point p2 = new Point
        {
            X = 21,
            Y = 37
        };
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p1.MoveX(2));
    }
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
        Console.WriteLine($"Średnia ocen: {(d.Value() + degree.Value()) / 2}");
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
            Degree.NIEDOSTATECZNY => "F",
            Degree.DOSTATECZNY => "E",
            Degree.DOSTATECZNY_PLUS => "D",
            Degree.DOBRY => "C",
            Degree.DOBRY_PLUS => "B",
            Degree.BARDZO_DOBRY => "A",
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

public static class DegreeExtension
{
    public static double Value(this Degree degree)
    {
        return degree switch
        {
            Degree.NIEDOSTATECZNY => 2.0,
            Degree.DOSTATECZNY => 3.0,
            Degree.DOSTATECZNY_PLUS => 3.5,
            Degree.DOBRY => 4.0,
            Degree.DOBRY_PLUS => 4.5,
            Degree.BARDZO_DOBRY => 5.0,
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
    }

    public static string ToEnglish(this Degree degree)
    {
        return degree switch
        {
            Degree.NIEDOSTATECZNY => "F",
            Degree.DOSTATECZNY => "E",
            Degree.DOSTATECZNY_PLUS => "D",
            Degree.DOBRY => "C",
            Degree.DOBRY_PLUS => "B",
            Degree.BARDZO_DOBRY => "A",
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
    }
}

