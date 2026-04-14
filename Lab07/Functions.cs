namespace Lab07;

public class Functions
{
    public static void FuncDemo()
    {
        Func<double, double, double> func1 = Add;
        Func<double, double> func2 = Square;
        Func<IEnumerable<string>, int> func3 = Count;
    }

    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Square(double x)
    {
        return x * x;
    }

    public static int Count(IEnumerable<string> strings)
    {
        return strings.Count();
    }
}