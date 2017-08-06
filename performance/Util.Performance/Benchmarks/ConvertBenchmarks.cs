using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Jobs;

namespace Util.Performance.Benchmarks
{
    [MemoryDiagnoser]
    [AllStatisticsColumn]
    public class ConvertBenchmarks
    {
        [Benchmark(Description = "Util.Helpers.Convert.ToInt")]
        public int ToInt()
        {
            return Util.Helpers.Convert.ToInt("1A");
        }
    }
}
