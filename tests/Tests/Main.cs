using Romanly;
using Xunit;

namespace Tests;

public class Main
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void should_convert_from_str_to_int(string str, int result)
    {
        Roman roman = Roman.Parse(str);
        
        Assert.Equal(result, roman.Num); 
    }
}