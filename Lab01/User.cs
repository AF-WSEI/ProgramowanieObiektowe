namespace Lab01;

public class User
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    private string _password;
    private Money _amount;

    public Money Amount
    {
        get
        {
            return _amount;
        }
    }

    public void Add(Money amount)
    {
        _amount = _amount + amount;
    }

    public User(string password)
    {
        _password = password;
    }

    public bool IsPasswordValid(string password)
    {
        return _password.Equals(password);
    }
    
    
}