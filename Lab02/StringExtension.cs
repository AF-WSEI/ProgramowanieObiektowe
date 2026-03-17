using System.Text;

namespace Lab02;

public static class StringExtension
{
    public static string Repeat(this string str, int count)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(str);
        }

        return sb.ToString();
    }
    
    //dodaj metodę rozszerzeń, która zamienia każdy znak na znak w drugim argumencie
    //"abc".Encode('#') => "###"

    public static string Encode(this string str, char symbol)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            sb.Append(symbol);
        }

        return sb.ToString();
    }
}