using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// From子句测试
    /// </summary>
    public class FromClauseTest {

        #region 测试初始化

        /// <summary>
        /// From子句
        /// </summary>
        private readonly FromClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FromClauseTest() {
            _clause = new FromClause( new TestSqlBuilder() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IFromClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region 默认输出

        /// <summary>
        /// 默认输出空
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Empty( GetSql() );
        }

        #endregion

        #region From

        /// <summary>
        /// 测试设置简单表
        /// </summary>
        [Fact]
        public void TestFrom_1() {
            _clause.From( "a" );
            Assert.Equal( "From [a]", GetSql() );
        }

        /// <summary>
        /// 测试设置带架构的表
        /// </summary>
        [Fact]
        public void TestFrom_2() {
            _clause.From( "a.b" );
            Assert.Equal( "From [a].[b]", GetSql() );
        }

        /// <summary>
        /// 测试设置带表别名的表
        /// </summary>
        [Fact]
        public void TestFrom_3() {
            _clause.From( "a as b" );
            Assert.Equal( "From [a] As [b]", GetSql() );
        }

        /// <summary>
        /// 测试设置带架构和表别名的表
        /// </summary>
        [Fact]
        public void TestFrom_4() {
            _clause.From( "a.b as c" );
            Assert.Equal( "From [a].[b] As [c]", GetSql() );
        }

        /// <summary>
        /// 测试设置子查询表
        /// </summary>
        [Fact]
        public void TestFrom_5() {
            var result = new StringBuilder();
            result.AppendLine( "From (Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.From( builder, "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试设置子查询表 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestFrom_6() {
            var result = new StringBuilder();
            result.AppendLine( "From (Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.From( t => t.Select( "a" ).From( "b" ), "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendSql

        /// <summary>
        /// 添加到from子句 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            var clause = new FromClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.AppendSql( "[a].[b], c.[D]", false );
            Assert.Equal( "From $a&.$b&, c.$D&", GetSql( clause ) );
        }

        /// <summary>
        /// 添加到from子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            var clause = new FromClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.AppendSql( "[a].[b], c.[D]", true );
            Assert.Equal( "From [a].[b], c.[D]", GetSql( clause ) );
        }

        /// <summary>
        /// 添加到from子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendSql_3() {
            var clause = new FromClause( new TestSqlBuilder( new TestDialect2() ) );
            clause.AppendSql( "[a].", true );
            clause.AppendSql( "[b]", true );
            Assert.Equal( "From [a].[b]", GetSql( clause ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.From( "a" );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制From子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //设置表
            _clause.From( "a" );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( "From [a]", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Clear();
            Assert.Equal( "From [a]", GetSql( clone ) );
        }

        #endregion
    }
}
