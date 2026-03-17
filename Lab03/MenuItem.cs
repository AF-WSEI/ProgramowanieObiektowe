namespace Lab03;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}, {nameof(Name)}, {nameof(Price)}";
    }
}