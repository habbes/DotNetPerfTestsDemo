using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileProcessor
{
    [MemoryDiagnoser]
    public class FileProcessorBenchmark
    {

        [Params("SmallData.txt", "LargeData.txt")]
        public string path;
        public Stream inputStream;
        public FileProcessor processor = new FileProcessor();

        [GlobalSetup]
        public void SetupStream()
        {
            inputStream = File.OpenRead(path);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            inputStream.Dispose();
        }

        [Benchmark]
        public string TestProcessor()
        {
            return processor.GetNamesList(inputStream);
        }
    }
}
