using System.Text;
using Util.Data.Sql.Builders.Core;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Core {
    /// <summary>
    /// Sql生成器项测试
    /// </summary>
    public class SqlBuilderItemTest {
        /// <summary>
        /// 测试带别名
        /// </summary>
        [Fact]
        public void Test_1() {
            var result = new StringBuilder();
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            var item = new SqlBuilderItem( TestDialect.Instance, builder, "c" );
            var sql = new StringBuilder();
            item.AppendTo( sql );
            Assert.Equal( result.ToString(), sql.ToString() );
        }

        /// <summary>
        /// 测试不带别名
        /// </summary>
        [Fact]
        public void Test_2() {
            var result = new StringBuilder();
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b])" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            var item = new SqlBuilderItem( TestDialect.Instance, builder );
            var sql = new StringBuilder();
            item.AppendTo( sql );
            Assert.Equal( result.ToString(), sql.ToString() );
        }
    }
}
