using System.Text;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - From子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region From

        /// <summary>
        /// 设置表
        /// </summary>
        [Fact]
        public void TestFrom_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            _builder.Select( "c.D as e" )
                .From( "a.B as c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置子查询表
        /// </summary>
        [Fact]
        public void TestFrom_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] " );
            result.AppendLine( "From (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.Select( "a.b" )
                .From( builder, "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置子查询表 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestFrom_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[b] " );
            result.AppendLine( "From (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            _builder.Select( "a.b" )
                .From( t => t.Select( "a" ).From( "b" ), "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendFrom

        /// <summary>
        /// 添加到from子句
        /// </summary>
        [Fact]
        public void TestAppendFrom_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            _builder.Select( "c.D as e" )
                .AppendFrom( "[a].[B] As [c]" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearFrom

        /// <summary>
        /// 测试清空From子句
        /// </summary>
        [Fact]
        public void TestClearFrom() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [d]" );

            //执行
            _builder.Select( "c.D as e" )
                .From( "a.B as c" )
                .ClearFrom()
                .From( "d" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}
