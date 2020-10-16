# Benchmarking Demo with BenchmarkDotNet

## Run Sample benchmarks

Navigate to the `BenchmarkingSample`
```
cd BenchmarkingSample
```

- `SimpleBenchmark` (simple benchmark to show how the framework works):
```
dotnet run -c Release -- --filter SimpleBenchmark
```

- `ArraySumBenchmarks` (demonstrates effects of CPU cache on performance):
```
dotnet run -c Release -- --filter ArraySumBenchmarks
```

- `BranchPredictionBenchmarks`
```
dotnet run -c Release -- --filter BranchPredictorBenchmarks
```

## Performance tuning challenge

The `FileProcessor` project contains a class that reads a text-based data file and extracts
all the names found in the file then returns the list of names as a string.
Check the `SmallData.txt` file to see what the input file should look like.
And check the `Program.TestProcessor` method to see what the expected output should be.

```
cd FileProcessor
dotnet run -c Release
```

The current implementation is suboptimal. The challenge is for you to create an alternative
implementation that's faster and minimizes heap allocations.