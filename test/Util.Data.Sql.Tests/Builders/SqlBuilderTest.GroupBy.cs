using System.Text;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - GroupBy子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region GroupBy

        /// <summary>
        /// 测试分组
        /// </summary>
        [Fact]
        public void TestGroupBy_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] As [c] " );
            result.AppendLine( "From [t] " );
            result.Append( "Group By [t].[x] " );
            result.Append( "Having Count([a].[x])=10" );

            //执行
            _builder.Select( "a.b as c" )
                .From( "t" )
                .GroupBy( "t.x" )
                .Having( "Count([a].[x])", 10, Operator.Equal, false );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendGroupBy

        /// <summary>
        /// 测试添加到Group By子句
        /// </summary>
        [Fact]
        public void TestAppendGroupBy() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] As [c] " );
            result.AppendLine( "From [t] " );
            result.Append( "Group By [t].[x] " );
            result.Append( "Having Count([a].[x])=10" );

            //执行
            _builder.Select( "a.b as c" )
                .From( "t" )
                .AppendGroupBy( "[t].[x]" )
                .AppendHaving( "Count([a].[x])=10" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearGroupBy

        /// <summary>
        /// 测试清空GroupBy子句
        /// </summary>
        [Fact]
        public void TestClearGroupBy() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] As [c] " );
            result.Append( "From [t]" );

            //执行
            _builder.Select( "a.b as c" )
                .From( "t" )
                .GroupBy( "t.x" )
                .Having( "Count([a].[x])", 10, Operator.Equal, false )
                .ClearGroupBy();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}
