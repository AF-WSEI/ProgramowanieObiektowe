namespace Lab02;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void MoneyDemoAdd()
    {
        Money a = new Money()
        {
            Currency = Currency.EUR,
            Value = 100
        };
        Money b = new Money()
        {
            Currency = Currency.EUR,
            Value = 250
        };
        Console.WriteLine(a + b);
    }
    
    public static void MoneyDemoSubtract()
    {
        Money a = new Money()
        {
            Currency = Currency.EUR,
            Value = 100
        };
        Money b = new Money()
        {
            Currency = Currency.EUR,
            Value = 250
        };
        Console.WriteLine(a - b);
    }
    
    public static void MoneyDemoMultiply()
    {
        Money a = new Money()
        {
            Currency = Currency.EUR,
            Value = 100
        };
        Console.WriteLine(a * 3);
    }
    
    public static void MoneyDemoCompare()
    {
        Money a = new Money()
        {
            Currency = Currency.EUR,
            Value = 100
        };
        Money b = new Money()
        {
            Currency = Currency.EUR,
            Value = 250
        };
        if (a < b)
        {
            Console.WriteLine("Kwota a jest mniejsza od kwoty b.");
        }
        else
        {
            Console.WriteLine("Kwota a nie jest mniejsza od kwoty b.");
        }
    }

    public static void MoneyDemoEqual()
    {
        Money a = new Money()
        {
            Currency = Currency.EUR,
            Value = 100
        };
        Money b = new Money()
        {
            Currency = Currency.EUR,
            Value = 250
        };
        Console.WriteLine(a == b);
        Console.WriteLine(a != b);
        decimal sum = a + b;
        Console.WriteLine(sum);
    }

    public static void Task01()
    {
        List<Money> list = new List<Money>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(new Money()
            {
                Value = Random.Shared.Next(0, 10_000),
                Currency = Random.Shared.Next(2) == 1 ? Currency.EUR : Currency.PLN,
            });
        }
        
        // oblicz podatek 23% z sumy kwot w PLN i EUR, każda suma osobno!!!

        Money sumPLN = new Money()
        {
            Currency = Currency.PLN,
            Value = 0
        };

        Money sumEUR = new Money()
        {
            Currency = Currency.EUR,
            Value = 0
        };

        foreach (var value in list)
        {
            if (value.Currency == Currency.PLN)
            {
                sumPLN += value;
            }
            else
            {
                sumEUR += value;
            }
        }

        Console.WriteLine($"Podatek dla pieniędzy zebranych w PLN wynosi {sumPLN * 0.23m}");
        Console.WriteLine($"Podatek dla pieniędzy zebranych w EUR wynosi {sumEUR * 0.23m}");
    }

    public static void StringExtensionDemo()
    {
        Console.WriteLine("Hello World!\n".Repeat(5));
        Console.WriteLine("abc".Encode('#'));
    }
    
}