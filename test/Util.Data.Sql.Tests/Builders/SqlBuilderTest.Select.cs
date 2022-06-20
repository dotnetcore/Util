using System.Text;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - Select子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Select

        /// <summary>
        /// 设置*列
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select * " );
            result.Append( "From [t]" );

            //执行
            _builder.Select().From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] As [c] " );
            result.Append( "From [t]" );

            //执行
            _builder.Select( "a.b as c" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            //结果
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [b]) As [c] " );
            result.Append( "From [t]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.Select( "a.b" )
                .Select( builder,"c" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置子查询列 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            //结果
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [b]) As [c] " );
            result.Append( "From [t]" );

            //执行
            _builder.Select( "a.b" )
                .Select( t => t.Select( "a" ).From( "b" ), "c" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendSelect

        /// <summary>
        /// 添加到select子句
        /// </summary>
        [Fact]
        public void TestAppendSelect_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] as [c] " );
            result.Append( "From [t]" );

            //执行
            _builder.AppendSelect( "[a].[b] " )
                .AppendSelect( "as [c]" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 添加到select子句 - 子查询
        /// </summary>
        [Fact]
        public void TestAppendSelect_2() {
            //结果
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [b]) As [c] " );
            result.Append( "From [t]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.AppendSelect( "[a].[b]," )
                .AppendSelect( "(" )
                .AppendSelect( builder )
                .AppendSelect( ") As [c]" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 添加到select子句 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestAppendSelect_3() {
            //结果
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [b]) As [c] " );
            result.Append( "From [t]" );

            //执行
            _builder.AppendSelect( "[a].[b]," )
                .AppendSelect( "(" )
                .AppendSelect( t => t.Select( "a" ).From( "b" ) )
                .AppendSelect( ") As [c]" )
                .From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearSelect

        /// <summary>
        /// 测试清空Select子句
        /// </summary>
        [Fact]
        public void TestClearSelect() {
            //执行
            _builder.Select( "a.b as c" )
                .ClearSelect();

            //验证
            Assert.Empty( _builder.GetSql() );
        }

        #endregion
    }
}