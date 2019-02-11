using Util.Datas.Dapper.PgSql;
using Util.Datas.Sql;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Datas.Tests.Sql.Builders.PgSql {
    /// <summary>
    /// PgSql Sql生成器测试
    /// </summary>
    public class PgSqlBuilderTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// PgSql Sql生成器
        /// </summary>
        private readonly PgSqlBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PgSqlBuilderTest( ITestOutputHelper output ) {
            _output = output;
            _builder = new PgSqlBuilder();
        }

        /// <summary>
        /// 测试输出的调试SQL - 布尔值输出false，而不是0
        /// </summary>
        [Fact]
        public void Test_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From \"Test\" " );
            result.Append( "Where \"A\"=1 And \"B\"=2 And \"C\"=false And \"D\"=true And \"E\"=5 And \"F\"=6 And " );
            result.Append( "\"G\"=7 And \"H\"=8 And \"I\"=9 And \"J\"=10 And \"K\"=11 And \"L\"=12" );

            //执行
            _builder.Select( "*" )
                .From( "Test" )
                .Where( "A", 1 )
                .Where( "B", 2 )
                .Where( "C", false )
                .Where( "D", true )
                .Where( "E", 5 )
                .Where( "F", 6 )
                .Where( "G", 7 )
                .Where( "H", 8 )
                .Where( "I", 9 )
                .Where( "J", 10 )
                .Where( "K", 11 )
                .Where( "L", 12 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToDebugSql() );
        }
    }
}
