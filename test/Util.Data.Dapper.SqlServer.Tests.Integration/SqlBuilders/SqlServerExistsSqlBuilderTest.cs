using System.Text;
using Util.Data.Sql;
using Util.Data.Sql.Builders;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.Dapper.Tests.SqlBuilders {
    /// <summary>
    /// 测试判断是否存在的Sql生成器
    /// </summary>
    public class SqlServerExistsSqlBuilderTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlServerExistsSqlBuilderTest( ITestOutputHelper output ) {
            _output = output;
        }

        /// <summary>
        /// 测试生成的Sql
        /// </summary>
        [Fact]
        public void TestToSql() {
            var sql = new StringBuilder();
            sql.AppendLine( "Select Case" );
            sql.AppendLine( "  When Exists (" );
            sql.AppendLine( "Select 1 " );
            sql.Append( "From [b]" );
            sql.AppendLine( ")" );
            sql.AppendLine( "  Then Cast(1 As Bit)" );
            sql.AppendLine( "  Else Cast(0 As Bit) " );
            sql.Append( "End" );

            var subQuery = new SqlServerBuilder()
                .Select("a")
                .From( "b" );
            var sqlBuilder = new SqlServerExistsSqlBuilder( subQuery );
            var result = sqlBuilder.GetSql();
            _output.WriteLine( result );
            Assert.Equal( sql.ToString(),result );
        }
    }
}
