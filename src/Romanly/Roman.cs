namespace Romanly;

public struct Roman
{
    private static readonly (Roman Roman, string BasicForm)[] ComposeRomans =
    {
        (new Roman("IV", 4), "IIII"),
        (new Roman("IX", 9), "VIIII"),
        (new Roman("XL", 40), "XXXX"),
        (new Roman("XC", 90), "LXXXX"),
        (new Roman("CD", 400), "CCCC"),
        (new Roman("CM", 900), "DCCCC"),
    };
    
    private static readonly Roman[] BasicRomans =
    {
        new("I", 1),
        new("V", 5),
        new("X", 10),
        new("L", 50),
        new("C", 100),
        new("D", 500),
        new("M", 1000),
    };
    
    private readonly string _str;
    public string Str => _str;

    private int? _num;
    public int Num => _num ??= ConvertStrToInt(_str);

    public Roman(string str)
    {
        _str = str;
    }

    public Roman(string str, int num)
    {
        _str = str;
        _num = num;
    }

    public override string ToString() => _str;

    private static int ConvertStrToInt(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return -1;
        }

        int result = 0;

        foreach (var (roman, basicForm) in ComposeRomans)
        {
            str = str.Replace(roman.Str, basicForm);
        }

        foreach (var ch in str)
        {
            Roman? roman = BasicRomans.FirstOrDefault(x=> x.Str == ch.ToString());
            
            if (roman == null)
            {
                return -1;
            }

            result += roman.Value.Num;
        }

        return result;
    }

    public static Roman Parse(string value) =>
        TryParse(value, out Roman result)
            ? result
            : throw new FormatException("Bad roman format");

    public static bool TryParse(string value, out Roman result)
    {
        int num = ConvertStrToInt(value);

        if (num <= 0)
        {
            result = new Roman();
            return false;
        }

        result = new Roman(value, num);

        return true;
    }
}