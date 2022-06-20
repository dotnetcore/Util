using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// 结束子句测试
    /// </summary>
    public class EndClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// 结束子句
        /// </summary>
        private readonly EndClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EndClauseTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _clause = CreateEndClause( TestDialect.Instance );
        }

        /// <summary>
        /// 创建结束子句
        /// </summary>
        private EndClause CreateEndClause( IDialect dialect ) {
            return new EndClause( new TestSqlBuilder( dialect, parameterManager:_parameterManager ) );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IEndClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region Take

        /// <summary>
        /// 测试设置获取行数
        /// </summary>
        [Fact]
        public void TestTake() {
            _clause.Take( 20 );
            Assert.Equal( "Limit @_p_0 OFFSET @_p_1", GetSql() );
            Assert.Equal( 20, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 0, _parameterManager.GetValue( "@_p_1" ) );
        }

        #endregion

        #region Skip

        /// <summary>
        /// 测试设置跳过行数
        /// </summary>
        [Fact]
        public void TestSkip() {
            _clause.Skip( 80 );
            _clause.Take( 40 );
            Assert.Equal( "Limit @_p_1 OFFSET @_p_0", GetSql() );
            Assert.Equal( 80, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 40, _parameterManager.GetValue( "@_p_1" ) );
        }

        #endregion

        #region Page

        /// <summary>
        /// 测试设置分页
        /// </summary>
        [Fact]
        public void TestPage() {
            var page = new Pager( 3, 40 );
            _clause.Page( page );
            Assert.Equal( "Limit @_p_1 OFFSET @_p_0", GetSql() );
            Assert.Equal( 80, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 40, _parameterManager.GetValue( "@_p_1" ) );
        }

        #endregion

        #region AppendSql

        /// <summary>
        /// 测试添加到结束位置 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            var clause = CreateEndClause( new TestDialect2() );
            clause.AppendSql( "[a].[b]", false );
            Assert.Equal( "$a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到结束位置 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            var clause = CreateEndClause( new TestDialect2() );
            clause.AppendSql( "[a].[b]", true );
            Assert.Equal( "[a].[b]", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到结束位置 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendSql_3() {
            var clause = CreateEndClause( new TestDialect2() );
            clause.AppendSql( "[a].", true );
            clause.AppendSql( "[b]", true );
            Assert.Equal( "[a].[b]", GetSql( clause ) );
        }

        #endregion

        #region ClearPage

        /// <summary>
        /// 测试清理分页
        /// </summary>
        [Fact]
        public void TestClearPage() {
            var page = new Pager( 3, 40 );
            _clause.Page( page );
            _clause.ClearPage();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            var page = new Pager( 3, 40 );
            _clause.Page( page );
            _clause.AppendSql( "[a].[b]", false );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制结束子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //设置分页
            var page = new Pager( 3, 40 );
            _clause.Page( page );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( "Limit @_p_1 OFFSET @_p_0", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Clear();
            Assert.Equal( "Limit @_p_1 OFFSET @_p_0", GetSql( clone ) );
        }

        #endregion
    }
}
