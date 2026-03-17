using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Lab04;

class Program
{

    public static T Max<T>(T a, T b) where T : IComparable<T>
    {
        int compare = a.CompareTo(b);
        if (compare < 0)
        {
            return a;
        }
        else if (compare > 0)
        {
            return b;
        }
        else
        {
            Console.WriteLine("Wartości są równe!");
            return default;
        }
    }
    
    // dodaj interfejs IComparable do Person
    // wywołaj Max dla dwóch obiektów Person

    class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) return firstNameComparison;
            return string.Compare(LastName, other.LastName, StringComparison.Ordinal);
        }
    }

    public static void MaxDemo()
    {
        Console.WriteLine(Max(2, 4));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(Max(new Person(), new Person()));
    }
    
    static void Main(string[] args)
    {
        Node<int> intNode = new Node<int>()
        {
            Value = 10,
            Next = new Node<int>()
            {
                Value = 5,
                Next = new Node<int>()
                {
                    Value = 50,
                    Next = null
                }
            }
        };
        Node<int>.Print(intNode);

        Console.WriteLine();

        Node<string> stringNode = new Node<string>()
        {
            Value = "Grace",
            Next = new Node<string>()
            {
                Value = "Ada",
                Next = new Node<string>()
                {
                    Value = "Leon",
                    Next = null
                }
            }
        };
        Node<string>.Print(stringNode);
    }

    public static void RepositoryDemo()
    {
        IRepository<string> repo = new MemoryRepository<string>();
        repo.Add("Peter");
        repo.Add("Chris");
        repo.Add("Brian");
        // pobierz za pomocą GetAll
        // wyświetl elementy pobrane z GetAll
    }

    public static void TupleDemo()
    {
        var (a, b) = (3, "hello");
        Console.WriteLine(a);
        Console.WriteLine(b);
        var tuple = (3, "hello");
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
        (int a, string b) t = (3, "hello");
        Console.WriteLine(t);
        float x = 5.5f;
        float y = 10.5f;
        (x, y) = (y, x);
        Console.WriteLine(x);
        Console.WriteLine(y);
    }
    
    public static (int max, int min) MaxMin(int[] arr)
    {
        int max = arr.Max();
        int min = arr.Min();
        return (max, min);
    }

    public static void MaxMinDemo()
    {
        var result = MaxMin(new[] { 1, 2, 3, 8, 4 });
        Console.WriteLine(result);
    }
}

public class IntNode
{
    public int Value { get; set; }
    public IntNode? Next { get; set; }

    public static void Print(IntNode head)
    {
        IntNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.Value);
            temp = temp.Next;
        }
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public static void Print(Node<T> head)
    {
        Node<T>? temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.Value);
            temp = temp.Next;
        }
    }
}