using BenchmarkDotNet.Attributes;
using Util.Data.Sql.Samples;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 列项性能测试
    /// </summary>
    [MemoryDiagnoser]
    public class ColumnItemBenchmark {
        /// <summary>
        /// 测试拆分列
        /// </summary>
        [Benchmark]
        public void Test() {
            var item = new ColumnItem( TestDialect.Instance, "abc.abc as abc" );
        }
    }
}
