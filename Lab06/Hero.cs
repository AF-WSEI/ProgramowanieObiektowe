using System.Collections;

namespace Lab06;

public partial class Hero: IEnumerable<string>
{

    public string this[string name]
    {
        get
        {
            name = name.ToLower();
            return name switch
            {
                "head" => Head,
                "body" => Body,
                "legs" => Legs,
                "righthand" => RightHand,
                "lefthand" => LeftHand,
                _ => throw new IndexOutOfRangeException(),
            };
        }
    }
    
    public string Name { get; set; }
    public string Head { get; set; }
    public IHead HeadTyped { get; set; }
    public string Body { get; set; }
    public string Legs { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
    public string[] Items { get; set; }
    
    public IEnumerator<string> GetEnumerator()
    {
        if(Head != null)
            yield return Head;
        if(Body != null)
            yield return Body;
        if(Legs != null)
            yield return Legs;
        if(RightHand != null)
            yield return RightHand;
        if(LeftHand != null)
            yield return LeftHand;
        foreach (var item in Items)
        {
            if(item != null)
                yield return item;
        }
    
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}