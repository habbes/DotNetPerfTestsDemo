using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;

namespace FileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProcessor();
            RunBenchmarks();
        }

        /// <summary>
        /// Test that the FileProcessor implementation works as expected
        /// </summary>
        static void TestProcessor()
        {
            var stream = File.OpenRead("SmallData.txt");
            var processor = new FileProcessor();
            // replace this with your own implementation to test correctness
            var names = processor.GetNamesList(stream);
            var expectedOutput = "James Maina John Gathogo Mike Richard Joseph James Maina";
            Debug.Assert(names == expectedOutput);
            if (names != expectedOutput)
            {
                throw new Exception($"Implementation Incorrect.{Environment.NewLine}Expected {expectedOutput}{Environment.NewLine}Got: {names}");
            }
            Console.WriteLine(names);
        }

        static void RunBenchmarks()
        {
            BenchmarkRunner.Run<FileProcessorBenchmark>();
        }
    }
}
