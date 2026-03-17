namespace Lab04;

class Program
{
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