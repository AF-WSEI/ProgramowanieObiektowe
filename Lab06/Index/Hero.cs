namespace Lab06;

public partial class Hero
{
    public int Lenght => 5;
    public string this[int i]
    {
        get
        {
            switch (i)
            {
                case 0:
                    return Head;
                case 1:
                    return Body;
                case 2:
                    return Legs;
                case 3:
                    return RightHand;
                case 4:
                    return LeftHand;
                case 5:
                    return Items.ToString();
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}