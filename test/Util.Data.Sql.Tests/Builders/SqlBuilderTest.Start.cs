using System.Text;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - 起始子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Cte

        /// <summary>
        /// 测试公用表表达式CTE
        /// </summary>
        [Fact]
        public void TestCte() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "With [Test] " );
            result.AppendLine( "As (Select [a],[b] " );
            result.AppendLine( "From [Test2])," );
            result.AppendLine( "[Test3] " );
            result.AppendLine( "As (Select [a],[b] " );
            result.AppendLine( "From [Test3]) " );
            result.AppendLine( "Select [a],[b] " );
            result.Append( "From [Test]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            var builder3 = _builder.New().Select( "a,b" ).From( "Test3" );
            _builder.Cte( "Test", builder2 ).Cte( "Test3", builder3 ).Select( "a,b" ).From( "Test" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region Append

        /// <summary>
        /// 添加到起始位置
        /// </summary>
        [Fact]
        public void TestAppend() {
            //结果
            var result = new StringBuilder();
            result.Append( "Select a From b" );

            //执行
            _builder.Append( "Select a " );
            _builder.Append( "From b" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendLine

        /// <summary>
        /// 添加到起始位置并换行
        /// </summary>
        [Fact]
        public void TestAppendLine() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select a " );
            result.Append( "From b" );

            //执行
            _builder.AppendLine( "Select a " );
            _builder.Append( "From b" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendStart

        /// <summary>
        /// 添加到起始位置
        /// </summary>
        [Fact]
        public void TestAppendStart_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "with(a) " );
            result.AppendLine( "Select [c].[D] As [e] " );
            result.Append( "From [a].[B] As [c]" );

            //执行
            _builder.AppendStart( "with(a)" )
                .Select( "c.D as e" )
                .From( "a.B as c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearCte

        /// <summary>
        /// 测试清理公用表表达式CTE
        /// </summary>
        [Fact]
        public void TestClearCte() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a],[b] " );
            result.Append( "From [Test]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            var builder3 = _builder.New().Select( "a,b" ).From( "Test3" );
            _builder.Cte( "Test", builder2 ).Cte( "Test3", builder3 ).Select( "a,b" ).From( "Test" ).ClearCte();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearStart

        /// <summary>
        /// 测试清理起始子句
        /// </summary>
        [Fact]
        public void TestClearStart() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a],[b] " );
            result.Append( "From [Test]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            var builder3 = _builder.New().Select( "a,b" ).From( "Test3" );
            _builder.AppendStart( "with(a)" ).Cte( "Test", builder2 ).Cte( "Test3", builder3 ).Select( "a,b" ).From( "Test" ).ClearStart();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}
