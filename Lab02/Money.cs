using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Lab02;

public class Money
{
    public decimal Value { get; init; }
    public Currency Currency { get; init; }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            return new Money()
            {
                Value = a.Value + b.Value,
                Currency = a.Currency
            };
        }
        throw new ArgumentException("Cannot add money with different currencies!");
    }

    public static Money operator -(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            return new Money()
            {
                Value = a.Value - b.Value,
                Currency = a.Currency
            };
        }
        throw new ArgumentException("Cannot subtract money with different currencies!");
    }

    public static Money operator *(Money a, decimal factor)
    {
        return new Money()
        {
            Value = a.Value * factor,
            Currency = a.Currency
        };
    }

    public static bool operator >(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            return a.Value > b.Value;
        }
        throw new ArgumentException("Cannot compare money with different currencies!");
    }
    
    public static bool operator <(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            return a.Value > b.Value;
        }
        throw new ArgumentException("Cannot compare money with different currencies!");
    }

    public static bool operator ==(Money a, Money b)
    {
        return Equals(a, b);
    }
    
    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }
    
    public bool Equals(Money? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value && Currency == other.Currency;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Money)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)Currency);
    }

    public static implicit operator decimal(Money money)
    {
        return money.Value;
    }

    public override string ToString()
    {
        return $"{Value:N2} {Currency}";
    }
}

public enum Currency
{
    PLN,
    EUR,
    USD
}