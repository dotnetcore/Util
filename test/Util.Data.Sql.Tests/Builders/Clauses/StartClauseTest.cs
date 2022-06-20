using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// 起始子句测试
    /// </summary>
    public class StartClauseTest {

        #region 测试初始化

        /// <summary>
        /// 排序子句
        /// </summary>
        private readonly StartClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public StartClauseTest() {
            _clause = new StartClause( new TestSqlBuilder() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IStartClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region Cte(公用表表达式)

        /// <summary>
        /// 测试公用表表达式CTE
        /// </summary>
        [Fact]
        public void TestCte_1() {
            var result = new StringBuilder();
            result.AppendLine( "With [Test] " );
            result.AppendLine( "As (Select [a] " );
            result.Append( "From [b])" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Cte( "Test", builder );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试公用表表达式CTE - 两个表达式
        /// </summary>
        [Fact]
        public void TestCte_2() {
            var result = new StringBuilder();
            result.AppendLine( "With [Test1] " );
            result.AppendLine( "As (Select [a] " );
            result.AppendLine( "From [b])," );
            result.AppendLine( "[Test2] " );
            result.AppendLine( "As (Select [a] " );
            result.Append( "From [b])" );

            var builder1 = new TestSqlBuilder().Select( "a" ).From( "b" );
            var builder2 = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Cte( "Test1", builder1 );
            _clause.Cte( "Test2", builder2 );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Append

        /// <summary>
        /// 测试添加到起始位置 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppend_1() {
            var clause = new StartClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.Append( "[a].[b]", false );
            Assert.Equal( "$a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到起始位置 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppend_2() {
            var clause = new StartClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.Append( "[a].[b]", true );
            Assert.Equal( "[a].[b]", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到起始位置 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppend_3() {
            var clause = new StartClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.Append( "[a].", true );
            clause.Append( "[b]", true );
            Assert.Equal( "[a].[b]", GetSql( clause ) );
        }

        #endregion

        #region ClearCte

        /// <summary>
        /// 测试清理公用表表达式CTE
        /// </summary>
        [Fact]
        public void TestClearCte() {
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Cte( "Test", builder );
            _clause.ClearCte();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Cte( "Test", builder );
            _clause.Append( "[a].[b]", false );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试起始子句 - 复制子句结果
        /// </summary>
        [Fact]
        public void TestClone_Result() {
            _clause.Append( "a", true );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( "a", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Append( "b", true );
            Assert.Equal( "a", GetSql( clone ) );
        }

        /// <summary>
        /// 测试起始子句 - 复制CTE
        /// </summary>
        [Fact]
        public void TestClone_Cte() {
            //Cte结果
            var result = new StringBuilder();
            result.AppendLine( "With [Test] " );
            result.AppendLine( "As (Select [a] " );
            result.Append( "From [b])" );

            //设置Cte
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Cte( "Test", builder );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( result.ToString(), GetSql( clone ) );

            //修改原Sql生成器,复制子句不应受影响
            builder.Where( "c", 1 );
            Assert.Equal( result.ToString(), GetSql( clone ) );
        }

        #endregion
    }
}
