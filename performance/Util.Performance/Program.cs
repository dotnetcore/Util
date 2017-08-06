using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Running;
using Util.Performance.Benchmarks;

namespace Util.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConvertBenchmarks>();
            Console.ReadKey();
        }
    }
}