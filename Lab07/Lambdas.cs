namespace Lab07;

public class Lambdas
{
    public static void LambdasDemo()
    {
        Predicate<string> isLongerThan5 = s => s.Length > 5;
        
        Predicate<int> isEven = x => x % 2 == 0;
        
        Func<double, double> square = y => y * y;
        
        Action<int, int> sum = (z, n) => Console.WriteLine(z + n);

        Console.WriteLine(isLongerThan5("Virtuoso"));
        Console.WriteLine(isEven(4));
        Console.WriteLine(square(2.0));
        sum(1, 3);
    }

    public static bool IsLonger(string s)
    {
        return s.Length > 5;
    }
}