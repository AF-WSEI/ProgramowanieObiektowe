using System.Diagnostics;
using Lab01;

int count = 0;
count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    Console.WriteLine("Hello, World!");
}


Console.WriteLine("Klasa User");
User user = new User("1234")
{
    Id = Guid.NewGuid(),
    FirstName = "John",
    LastName = "Cena"
};

Console.WriteLine("Klasa Money");
var amount = new Money
{
    Value = 34.6m,
    Currency = Currency.EUR
};
Console.WriteLine(amount);