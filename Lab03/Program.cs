namespace Lab03;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu(
            [
                new MenuItem() { Id = 1, Name = "Zupa z Trupa", Price = 10.5m },
                new MenuItem() { Id = 3, Name = "Pizza z Cytryną i Karmelem", Price = 36.5m },
                new MenuItem() { Id = 7, Name = "Brownie Buraczane", Price = 23.4m }
            ]
        );
        Order order = new Order();
        while (true)
        {
            menu.Print();
            Console.WriteLine("Wpisz wybraną pozycję: ");
            int id = int.Parse(Console.ReadLine());
            var item = menu.FindById(id);
            Console.WriteLine("Wpisz liczbę zamawianych przedmiotów: ");
            int quantity = int.Parse(Console.ReadLine());
            
        }
    }
}