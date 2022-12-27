using BenchmarkDotNet.Attributes;
using Util.Data.Sql.Samples;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Select子句性能测试
    /// </summary>
    [MemoryDiagnoser]
    public class SelectClauseBenchmark {
        /// <summary>
        /// 测试设置Select
        /// </summary>
        [Benchmark]
        public void TestSelect() {
            var clause = new SelectClause( new TestSqlBuilder() );
            clause.Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" );
        }
    }
}
