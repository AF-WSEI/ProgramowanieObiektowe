namespace Lab10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void Task01()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        var task = Task.Run(() =>
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            Console.WriteLine("Hello, World!");
        });
        Console.WriteLine("End");
        task.Wait();
    }

    public static void Task02()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run(() =>
        {
            var r = Fib(50, token);
            if (!token.IsCancellationRequested)
            {
                Console.WriteLine();
                Console.WriteLine($"50 wyraz Ciągu Fibonnaciego wynosi: {r}");
            }
            
        });
        var end = Task.Run(() =>
        {
            Console.Write("Press Q to quit: ");
            while (Console.ReadKey().Key != ConsoleKey.Q)
            { }
            cts.Cancel();
            Console.WriteLine();
            Console.WriteLine("Obliczanie zostało anulowane");
        });
        Task.WaitAny(task, end);
    }

    public static long Fib(int n, CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            return -1;
        }

        if (n == 0 || n == 1)
        {
            return n;
        }

        return Fib(n - 1, token) + Fib(n - 2, token);
    }

    public static void Task03()
    {
        var timeout = Task.Run(() =>
        {
            for (int i = 0; i < 6; i++)
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.WriteLine($"Time left: {5 - i} seconds");
            }
        });

        int counter = 0;
        var loop = Task.Run(() =>
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            while (true)
            {
                var key = Console.ReadKey(true);
                Console.Write(key.KeyChar);
                counter++;
            }
        });
        Task.WaitAny(loop, timeout);
        Console.WriteLine($"Wpisałaś {counter} znaków");
    }
    
    public static void Task04()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run(() =>
        {
            var r = Fib(50, token);
            if (!token.IsCancellationRequested)
            {
                return r;
            }

            return -1;

        });
        task.GetAwaiter().OnCompleted(() =>
        {
            Console.WriteLine($"Obliczony wyraz ciągu Fibonnaciego: {task.Result}");
            var task2 = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
            });
            task.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("Zadanie 2 wykonane.");
            });
        });
        Console.WriteLine("Last line.");
    }

    public static async Task<long> TaskFib(int n, CancellationToken token)
    {
        var a = await Task.FromResult(Fib(n, token));
        var b = await Task.FromResult(Fib(n - 5, token));
        return await Task.FromResult(a + b);
    }

    public static void Task5()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run(() =>
        {
            Console.WriteLine("Obliczam");
            var r = Fib(45, token);
            if (!token.IsCancellationRequested)
            {
                return r;
            }

            return -1;
        });
    }
}