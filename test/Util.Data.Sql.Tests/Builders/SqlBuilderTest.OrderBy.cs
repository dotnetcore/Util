using System.Text;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - OrderBy子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region OrderBy

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestOrderBy_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Order By [c].[b] Desc" );

            //执行
            _builder.Select( "c.D as e" )
                .From( "a.B as c" )
                .OrderBy( "c.b desc" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendOrderBy

        /// <summary>
        /// 测试添加到Order By子句
        /// </summary>
        [Fact]
        public void TestAppendOrderBy_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Order By [c].[b] Desc" );

            //执行
            _builder.Select( "c.D as e" )
                .From( "a.B as c" )
                .AppendOrderBy( "[c].[b] Desc" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearOrderBy

        /// <summary>
        /// 测试清空Order By子句
        /// </summary>
        [Fact]
        public void TestClearOrderBy() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            _builder.Select( "c.D as e" )
                .From( "a.B as c" )
                .OrderBy( "c.b desc" )
                .ClearOrderBy();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}
