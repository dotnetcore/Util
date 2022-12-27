using BenchmarkDotNet.Running;
using Util.Helpers;

namespace Util {
    /// <summary>
    /// Util基础库性能测试
    /// </summary>
    class Program {
        /// <summary>
        /// 入口
        /// </summary>
        static void Main( string[] args ) {
            BenchmarkRunner.Run<StringBenchmark>();
        }
    }
}
