using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// Group By子句测试
    /// </summary>
    public class GroupByClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// 分组子句
        /// </summary>
        private readonly GroupByClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GroupByClauseTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _clause = new GroupByClause( new TestSqlBuilder(parameterManager: _parameterManager ) );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IGroupByClause clause = null ) {
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

        #region GroupBy

        /// <summary>
        /// 测试添加分组 - 传入空值
        /// </summary>
        [Fact]
        public void TestGroupBy_1() {
            _clause.GroupBy( "" );
            Assert.Empty( GetSql() );
        }

        /// <summary>
        /// 测试添加分组 - 1个列
        /// </summary>
        [Fact]
        public void TestGroupBy_2() {
            _clause.GroupBy( "a.B" );
            Assert.Equal( "Group By [a].[B]", GetSql() );
        }

        /// <summary>
        /// 测试添加分组 - 2个列
        /// </summary>
        [Fact]
        public void TestGroupBy_3() {
            _clause.GroupBy( "a.B,c.D" );
            Assert.Equal( "Group By [a].[B],[c].[D]", GetSql() );
        }

        /// <summary>
        /// 测试添加分组 - 多次调用GroupBy方法
        /// </summary>
        [Fact]
        public void TestGroupBy_4() {
            _clause.GroupBy( "a.B" );
            _clause.GroupBy( "c.D" );
            Assert.Equal( "Group By [a].[B],[c].[D]", GetSql() );
        }

        #endregion

        #region Having

        /// <summary>
        /// 测试添加分组条件 - 未设置GroupBy输出空
        /// </summary>
        [Fact]
        public void TestHaving_1() {
            _clause.Having( "a","b" );
            Assert.Empty( GetSql() );
        }

        /// <summary>
        /// 测试添加分组条件 - 1个条件
        /// </summary>
        [Fact]
        public void TestHaving_2() {
            var result = new StringBuilder();
            result.Append( "Group By [a].[B] " );
            result.Append( "Having sum(a)>@_p_0" );

            _clause.GroupBy( "a.B" );
            _clause.Having( "sum(a)", "1",Operator.Greater );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( "1", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试添加分组条件 - 2个条件
        /// </summary>
        [Fact]
        public void TestHaving_3() {
            var result = new StringBuilder();
            result.Append( "Group By [a].[B] " );
            result.Append( "Having sum(a)>@_p_0 And max(b)<@_p_1" );

            _clause.GroupBy( "a.B" );
            _clause.Having( "sum(a)", "1", Operator.Greater );
            _clause.Having( "max(b)", 2, Operator.Less );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( "1", _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_1" ) );
        }

        #endregion

        #region AppendGroupBy

        /// <summary>
        /// 测试添加到Group By子句 - 替换[]
        /// </summary>
        [Fact]
        public void TestAppendGroupBy_1() {
            var result = new StringBuilder();
            result.Append( "Group By $a&.$id&" );

            var clause = new GroupByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendGroupBy( "[a].[id]", false );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Group By子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendGroupBy_2() {
            var result = new StringBuilder();
            result.Append( "Group By [a].[id]" );

            var clause = new GroupByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendGroupBy( "[a].[id]", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Group By子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendGroupBy_3() {
            var result = new StringBuilder();
            result.Append( "Group By [a].[id]" );

            var clause = new GroupByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendGroupBy( "[a].", true );
            clause.AppendGroupBy( "[id]", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        #endregion

        #region AppendHaving

        /// <summary>
        /// 测试添加到Having子句 - 替换[]
        /// </summary>
        [Fact]
        public void TestAppendHaving_1() {
            var result = new StringBuilder();
            result.Append( "Group By $a1&.$id&,$b1&.$id& " );
            result.Append( "Having Count($a&.$id&)>1 And sum($b&.$id&)=2" );

            var clause = new GroupByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.GroupBy( "a1.id" );
            clause.GroupBy( "b1.id" );
            clause.AppendHaving( "Count([a].[id])>1", false );
            clause.AppendHaving( "sum([b].[id])=2", false );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Having子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendHaving_2() {
            var result = new StringBuilder();
            result.Append( "Group By $a1&.$id&,$b1&.$id& " );
            result.Append( "Having Count([a].[id])>1 And sum([b].[id])=2" );

            var clause = new GroupByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.GroupBy( "a1.id" );
            clause.GroupBy( "b1.id" );
            clause.AppendHaving( "Count([a].[id])>1", true );
            clause.AppendHaving( "sum([b].[id])=2", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.GroupBy( "a.B" );
            _clause.Having( "sum(a)", "1", Operator.Greater );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Group By子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //结果
            var result = new StringBuilder();
            result.Append( "Group By [a].[B] " );
            result.Append( "Having sum(a)>@_p_0" );

            //设置分组
            _clause.GroupBy( "a.B" );
            _clause.Having( "sum(a)", "1", Operator.Greater );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( result.ToString(), GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.GroupBy( "c.d" );
            _clause.Having( "sum(e)", "2", Operator.Greater );
            Assert.Equal( result.ToString(), GetSql( clone ) );
        }

        #endregion
    }
}
