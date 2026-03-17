namespace Lab01;

public class Money
{
    public decimal Value { get; init; }
    public Currency Currency { get; init; }

    public override string ToString()
    {
        return $"{Value:N2} {Currency}";
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            return new Money() { Value = a.Value + b.Value, Currency = a.Currency };
        }

        throw new ArgumentException("Niezgodne waluty kwot!");
    }
}

public enum Currency
{
    PLN,
    EUR,
    USD
}