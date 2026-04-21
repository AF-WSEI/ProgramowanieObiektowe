using System.Globalization;

namespace Lab08;

public record Product
{
    public int Index { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    
}

public record Student(int Id, string Name, int Ects);



class Program
{
    
    public static IEnumerable<Student> ReadStudents(string fileName)
    {
        return File
            .ReadAllLines(fileName)
            .ToList()
            .Select(l =>
            {
                var tokens = l.Split('\t');
                return new Student(
                    int.Parse(tokens[0]),
                    tokens[1],
                    int.Parse(tokens[2])
                );
            });
    }

    public static void StudentDemo()
    {
        var students = ReadStudents(@"AF-WSEI\ProgramowanieObiektowe\Lab08\data.txt");
        Console.WriteLine($"Suma ECTS: {students.Sum(s => s.Ects)}");

        Console.WriteLine($"Największa ilość ECTS jednego ucznia: {students.Max(s => s.Ects)}");
        Console.WriteLine($"Najmniejsza ilość ECTS jednego ucznia: {students.Min(s => s.Ects)}");
        students
            .GroupBy(s => s.Name)
            .Select(s => $"{s.Key}: {s.Count()}")
            .OrderBy(s => s)
            .ToList()
            .ForEach(s => Console.WriteLine(s));
    }
    
    static void Main(string[] args)
    {
        var products = ReadFromFile(@"AF-WSEI\ProgramowanieObiektowe\Lab08\products-100000.csv");
        
        var filtered = products.Where(p => p.Name.ToLower().Contains("speaker"));
        Console.WriteLine(filtered.Count());

        var fiveCharacters = products.Where(p => p.Name.Length == 5);
        Console.WriteLine(fiveCharacters.Count());

        var noDescription = products.Where(p => p.Description.Contains(","));
        Console.WriteLine(noDescription.Count());

        var names = products.Select(p => p.Name.ToUpper());
        names = names.Skip(200).Take(100);
        names.ToList().ForEach(n => Console.WriteLine(n));

        var index = products.Select(i => i.Index);
        index = index.Skip(499).Take(201);
        index.ToList().ForEach(i => Console.WriteLine(i));

        var product = products.FirstOrDefault(p => p.Index == 456);
        Console.WriteLine("Znaleziony produkt: " + product);

        bool all =  products.All(p => p.Name.Length > 3);
        Console.WriteLine("Czy wszystkie mają co najmniej 3 znaki: " + all);

        bool any = products.Any(p => p.Name.Length > 50);
        Console.WriteLine("Czy jakiś ma ponad 50 znaków: " + any);
        
        products.OrderBy(p => p.Name).ThenByDescending(p => p.Index).Take(100).ToList().ForEach(p=>Console.WriteLine(p));
    }

    public static IEnumerable<Product> ReadFromFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
            if (line.StartsWith("Index"))
            {
                continue;
            }
            var tokens = line.Split(',');
            var product = new Product()
            {
                Index = int.Parse(tokens[0]),
                Name = tokens[1],
                Description = tokens[2].Contains('"')?line.Substring(line.IndexOf('"') + 1, Math.Max(0, line.LastIndexOf('"') - line.IndexOf('"') - 1)): tokens[2]
            };
            yield return product;
        }
    }
}