using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkingSample
{
    [MeanColumn, MaxColumn, AllStatisticsColumn]
    [MemoryDiagnoser]
    public class SimpleBenchmark
    {

        public int[] test = new int[100];

        [GlobalSetup]
        public void InitArray()
        {
           for (int i = 0; i < test.Length; i++)
           {
               test[i] = test.Length - i;
           }
        }

        [Benchmark]
        public void TestSort()
        {
            Array.Sort(test);
        }
    }
}
