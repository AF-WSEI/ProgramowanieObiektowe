namespace Lab07;

public class Delegates
{
    delegate double Func(double a, double b);

    public delegate bool StringPredicate(string s);

    public static bool LongerThanFive(string s)
    {
        return s.Length > 5;
    }

    public static IEnumerable<string> Filter(IEnumerable<string> strings, StringPredicate predicate)
    {
        foreach (var str in strings)
        {
            if (predicate(str))
            {
                yield return str;
            }
        }
    }

    public static void FilterDemo()
    {
        List<string> names = ["adam", "robert", "ewa", "alina", "piotr"];
        var result = Filter(names, LongerThanFive);
        Console.WriteLine(string.Join(" ", result));
        result = Filter(names, delegate(string s) { return s.Length < 5; });

        result = Filter(names, delegate(string s) { return s.ToLower().EndsWith("a"); });
        Console.WriteLine(String.Join(" ", result));
    }

    public static void Run()
    {
        Func op = Add;
        Console.WriteLine(op(2, 4));
        op = Multiply;
        Console.WriteLine(op(3, 4.5));
        Func[] operations = [Add, Subtract, Multiply];

        foreach (var opr in operations)
        {
            Console.WriteLine(opr(2, 3));
        }
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }
}