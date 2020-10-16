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

        [Params("LargeData.txt")]
        public string path;
        public Stream inputStream;
        public FileProcessor processor = new FileProcessor();

        [IterationSetup]
        public void SetupStream()
        {
            inputStream = File.OpenRead(path);
        }

        [IterationCleanup]
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
