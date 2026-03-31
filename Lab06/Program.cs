namespace Lab06;

class Program
{
    static void Main(string[] args)
    {
        IEnumerableDemo([3, 5, 7]);
    }

    public static void HeroDemo()
    {
        Hero hero = new Hero()
        {
            Name = "Hero",
            Head = "Kapelusz",
            Body = "Zbroja",
            LeftHand = "Miecz",
            RightHand = "Tarcza",
            Items = ["Kamień", "10 sztuk złota"]
        };
        
        for (int i = 0; i < hero.Lenght; i++)
        {
            Console.WriteLine(hero[i]);
        }
        
        hero.Hello();
    }

    public static IEnumerable<string> hello(IEnumerable<string> names)
    {
        foreach (var name in names)
        {
            if (name.EndsWith("a"))
            {
                yield return $"Pani {name}";
            }
            else
            {
                yield return $"Pan {name}";
            }
        }
    }

    public static IEnumerable<string> GetNames()
    {
        yield return "Ed";
        yield return "Edd";
        yield return "Eddy";
    }

    public static IEnumerable<int> Evens(int limit)
    {
        for (int i = 0; i < limit/2; i++)
        {
            yield return i * 2;
        }
    }

    public static void IEnumerableDemo(IEnumerable<int> numbers)
    {
        var iterator = numbers.GetEnumerator();
        Console.WriteLine("Iterator");
        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current);
        }
        
        Console.WriteLine("Foreach");
        foreach (var current in numbers)
        {
            Console.WriteLine(current);
        }
    }
}