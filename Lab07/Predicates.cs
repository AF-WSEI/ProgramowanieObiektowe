namespace Lab07;

public class Predicates
{
    public static void PredicatesDemo()
    {
        // Tylko jeden argument!!!
        Predicate<string> isValid1 = IsValid;
        Func<string, bool> isValid2 = IsValid;
        
        Func<IEnumerable<int>, int, bool> test = Test;
    }

    public static bool IsValid(string s)
    {
        return s.Length > 5 && s.Contains("!");
    }

    public static bool Test(IEnumerable<int> values, int count)
    {
        return values.Count() == count;
    }
}