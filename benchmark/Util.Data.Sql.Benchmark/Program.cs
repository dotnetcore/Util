using BenchmarkDotNet.Running;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Clauses;

namespace Util.Data.Sql {
    /// <summary>
    /// Util SqlBuilder 相关性能测试
    /// </summary>
    class Program {
        static void Main( string[] args ) {
            //BenchmarkRunner.Run<NameItemBenchmark>();
            //BenchmarkRunner.Run<ColumnItemBenchmark>();
            //BenchmarkRunner.Run<SelectClauseBenchmark>();
            BenchmarkRunner.Run<SqlBuilderBenchmark>();
        }
    }
}
