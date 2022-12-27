using BenchmarkDotNet.Attributes;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 名称项性能测试
    /// </summary>
    [MemoryDiagnoser]
    public class NameItemBenchmark {
        /// <summary>
        /// 测试拆分名称
        /// </summary>
        [Benchmark]
        public void Test() {
            var item = new NameItem( "abc.abc as abc" );
        }
    }
}
