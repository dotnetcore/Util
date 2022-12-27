using System.Text;
using Util.Data.Queries;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - 结束子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Take

        /// <summary>
        /// 测试设置获取行数
        /// </summary>
        [Fact]
        public void TestTake() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            //执行
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .Take( 20 );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 20, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( 0, _builder.GetParam<int>( "@_p_1" ) );
        }

        #endregion

        #region Skip

        /// <summary>
        /// 测试设置跳过行数
        /// </summary>
        [Fact]
        public void TestSkip() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Limit @_p_1 OFFSET @_p_0" );

            //执行
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .Skip( 80 )
                .Take( 40 );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 80, _builder.GetParam<int>("@_p_0") );
            Assert.Equal( 40, _builder.GetParam<int>( "@_p_1" ) );
        }

        #endregion

        #region Page

        /// <summary>
        /// 测试设置分页
        /// </summary>
        [Fact]
        public void TestPage() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Limit @_p_1 OFFSET @_p_0" );

            //执行
            var page = new Pager( 3, 40 );
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .Page( page );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 80, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( 40, _builder.GetParam<int>( "@_p_1" ) );
        }

        #endregion

        #region AppendEnd

        /// <summary>
        /// 添加到结束位置
        /// </summary>
        [Fact]
        public void TestAppendEnd_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.AppendLine( "From [a].[B] As [c] " );
            result.Append( "Order By abc" );

            //执行
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .AppendEnd( "Order By abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearPage

        /// <summary>
        /// 测试清理分页
        /// </summary>
        [Fact]
        public void TestClearPage() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            var page = new Pager( 3, 40 );
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .Page( page )
                .ClearPage();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearEnd

        /// <summary>
        /// 测试清理结束子句
        /// </summary>
        [Fact]
        public void TestClearEnd() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            var page = new Pager( 3, 40 );
            _builder
                .Select( "c.D as e" )
                .From( "a.B as c" )
                .Page( page )
                .AppendEnd( "Order By abc" )
                .ClearEnd();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}
