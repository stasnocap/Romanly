using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Romanly;

BenchmarkRunner.Run<Simple>();

[MemoryDiagnoser]
public class Simple
{
    [Benchmark]
    public Roman Parse() => Roman.Parse("MCMXCIV");
}
