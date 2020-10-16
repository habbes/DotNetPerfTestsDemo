using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[HardwareCounters(HardwareCounter.CacheMisses)]
public class ArraySumBenchmark
{
    private int n = 512;
    private long[,] a;
    [GlobalSetup]
    public void Setup()
    {
        a = new long[n, n];
    }
    [Benchmark(Baseline = true)]
    public long RowWiseLoop()
    {
        long sum = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                sum += a[i, j];
        return sum;
    }
    [Benchmark]
    public long ColumnWiseLoop()
    {
        long sum = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                sum += a[j, i];
        return sum;
    }
}