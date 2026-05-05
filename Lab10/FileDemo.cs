namespace Lab10;

public class FileDemo
{
    public static void Run()
    {
        var t = Load(@"AF-WSEI\ProgramowanieObiektowe\Lab10\data.txt");
        Console.WriteLine(t.Result);
    }

    public static async Task<string> Load(string path)
    {
        var text = await File.ReadAllTextAsync(path);
        return text.ToUpper();
    }
}