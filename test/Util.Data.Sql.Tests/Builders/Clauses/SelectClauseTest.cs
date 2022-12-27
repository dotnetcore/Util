using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// Select子句测试
    /// </summary>
    public class SelectClauseTest {

        #region 测试初始化

        /// <summary>
        /// Select子句
        /// </summary>
        private readonly SelectClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectClauseTest() {
            _clause = new SelectClause( new TestSqlBuilder() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( ISelectClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region  默认输出

        /// <summary>
        /// 默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Select

        /// <summary>
        /// 测试设置列名为*
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            _clause.Select();
            Assert.Equal( "Select *", GetSql() );
        }

        /// <summary>
        /// 测试设置列名为*
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            _clause.Select( "*" );
            Assert.Equal( "Select *", GetSql() );
        }

        /// <summary>
        /// 测试设置1个简单列
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            _clause.Select( "a" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        /// <summary>
        /// 测试设置2个简单列
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            _clause.Select( "a,b" );
            Assert.Equal( "Select [a],[b]", GetSql() );
        }

        /// <summary>
        /// 测试设置1个带表别名的列
        /// </summary>
        [Fact]
        public void TestSelect_5() {
            _clause.Select( "a.b" );
            Assert.Equal( "Select [a].[b]", GetSql() );
        }

        /// <summary>
        /// 测试设置1个带表别名和列别名的列
        /// </summary>
        [Fact]
        public void TestSelect_6() {
            _clause.Select( "a.b as c" );
            Assert.Equal( "Select [a].[b] As [c]", GetSql() );
        }

        /// <summary>
        /// 测试设置2个带表别名和列别名的列
        /// </summary>
        [Fact]
        public void TestSelect_7() {
            _clause.Select( "a.b as c,[d].[e] [F]" );
            Assert.Equal( "Select [a].[b] As [c],[d].[e] As [F]", GetSql() );
        }

        /// <summary>
        /// 测试设置多个select
        /// </summary>
        [Fact]
        public void TestSelect_8() {
            _clause.Select( "a.b as c" );
            _clause.Select( "[d].[e] [F]" );
            Assert.Equal( "Select [a].[b] As [c],[d].[e] As [F]", GetSql() );
        }

        /// <summary>
        /// 测试设置子查询列
        /// </summary>
        [Fact]
        public void TestSelect_9() {
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Select( "a.b" );
            _clause.Select( builder,"c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试设置子查询列 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestSelect_10() {
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.Select( "a.b" );
            _clause.Select( t => t.Select( "a" ).From( "b" ), "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试设置列 - 验证空值
        /// </summary>
        [Fact]
        public void TestSelect_11() {
            _clause.Select( "a" );
            _clause.Select( "" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        #endregion

        #region AppendSql

        /// <summary>
        /// 添加到select子句 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            var clause = new SelectClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a].[b], c.[D]", false );
            Assert.Equal( "Select $a&.$b&, c.$D&", GetSql( clause ) );
        }

        /// <summary>
        /// 添加到select子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            var clause = new SelectClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a].[b], c.[D]", true );
            Assert.Equal( "Select [a].[b], c.[D]", GetSql( clause ) );
        }

        /// <summary>
        /// 添加到select子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendSql_3() {
            var clause = new SelectClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a].[b],", true );
            clause.AppendSql( "c.[D]", true );
            Assert.Equal( "Select [a].[b],c.[D]", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到select子句 - 子查询
        /// </summary>
        [Fact]
        public void TestAppendSql_4() {
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.AppendSql( "[a].[b],",true );
            _clause.AppendSql( "(", true );
            _clause.AppendSql( builder );
            _clause.AppendSql( ") As [c]", true );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试添加到select子句 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestAppendSql_5() {
            var result = new StringBuilder();
            result.Append( "Select [a].[b]," );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.AppendSql( "[a].[b],", true );
            _clause.AppendSql( "(", true );
            _clause.AppendSql( t => t.Select( "a" ).From( "b" ) );
            _clause.AppendSql( ") As [c]", true );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试添加到select子句 - AppendSql末尾添加逗号,后跟Select
        /// </summary>
        [Fact]
        public void TestAppendSql_6() {
            var result = new StringBuilder();
            result.Append( "Select [a].[b],c,[d]" );

            _clause.Select( "a.b" );
            _clause.AppendSql( ",c,", true );
            _clause.Select( "d" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 添加到select子句 - 对[]转义
        /// </summary>
        [Fact]
        public void TestAppendSql_7() {
            var clause = new SelectClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[[a]].[b], c.[D]", false );
            Assert.Equal( "Select [a].$b&, c.$D&", GetSql( clause ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.Select( "a" );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Select子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //设置列
            _clause.Select( "a" );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( "Select [a]", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Select( "b" );
            Assert.Equal( "Select [a]", GetSql( clone ) );
        }

        #endregion
    }
}
