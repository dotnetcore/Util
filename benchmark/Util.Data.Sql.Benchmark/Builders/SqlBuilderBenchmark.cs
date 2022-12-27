using BenchmarkDotNet.Attributes;
using Util.Data.Sql.Samples;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql生成器性能测试
    /// </summary>
    [MemoryDiagnoser]
    public class SqlBuilderBenchmark {
        /// <summary>
        /// 测试
        /// </summary>
        [Benchmark]
        public void Test_1() {
            var builder = new TestSqlBuilder()
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .AppendSelect( "a.b as c" )
                .From( "t " )
                .AppendFrom( "as t1" )
                .LeftJoin( "a as a1" ).On( "t.id", "a.id" )
                .LeftJoin( "b as b1" ).On( "t.id", "b.id" )
                .AppendJoin( "a as a1" )
                .AppendOn( "a.id=b.id" )
                .Where( "a.id", 1 )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .AppendWhere( "[a].id=[b].id" )
                .GroupBy( "a.b,c.d,e.ffdsfdsf" )
                .Having( "count(b.id)", 1234 )
                .OrderBy( "a.b,c.d desc" )
                .GetSql();
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Benchmark]
        public void Test_2() {
            var builder = new TestSqlBuilder()
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .From( "t as t1" )
                .LeftJoin( "a as a1" ).On( "t.id", "a.id" )
                .LeftJoin( "b as b1" ).On( "t.id", "b.id" )
                .Where( "a.id", 1 )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .GroupBy( "a.b,c.d,e.ffdsfdsf" )
                .Having( "count(b.id)", 1234 )
                .OrderBy( "a.b,c.d desc" )
                .GetSql();

            var builder2 = new TestSqlBuilder()
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .From( "t as t1" )
                .LeftJoin( "a as a1" ).On( "t.id", "a.id" )
                .LeftJoin( "b as b1" ).On( "t.id", "b.id" )
                .Where( "a.id", 1 )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .GroupBy( "a.b,c.d,e.ffdsfdsf" )
                .Having( "count(b.id)", 1234 )
                .OrderBy( "a.b,c.d desc" )
                .GetSql();

            var builder3 = new TestSqlBuilder()
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .Select( "a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F],a.b as c,[d].[e] [F]" )
                .From( "t as t1" )
                .LeftJoin( "a as a1" ).On( "t.id", "a.id" )
                .LeftJoin( "b as b1" ).On( "t.id", "b.id" )
                .Where( "a.id", 1 )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .Where( "b.id", "2" )
                .GroupBy( "a.b,c.d,e.ffdsfdsf" )
                .Having( "count(b.id)", 1234 )
                .OrderBy( "a.b,c.d desc" )
                .GetSql();
        }
    }
}
