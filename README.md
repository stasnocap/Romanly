# Romanly

Easy roman numerals management

## Parsing

```csharp
bool parseResult = Roman.TryParse("MCMXCIV", out Roman roman);

if (parseResult) 
{
    Console.WriteLine(roman.Str);
    Console.WriteLine(roman.Num);
}
```