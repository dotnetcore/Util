using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// 插入子句测试
    /// </summary>
    public class InsertClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// Select子句
        /// </summary>
        private readonly InsertClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public InsertClauseTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _clause = new InsertClause( new TestSqlBuilder( parameterManager: _parameterManager ) );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IInsertClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region Insert

        /// <summary>
        /// 测试插入一列 - 未设置值
        /// </summary>
        [Fact]
        public void TestInsert_1() {
            var result = new StringBuilder();
            result.Append( "Insert Into [t].[c]([a].[b]) " );

            _clause.Insert( "a.b", "t.c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试插入2列
        /// </summary>
        [Fact]
        public void TestInsert_2() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [z].[t]([a].[b],[c].[d]) " );
            result.Append( "Values(@_p_0,@_p_1)" );

            _clause.Insert( "a.b,c.d", "z.t" );
            _clause.Values( 1, "a" );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_1" ) );
        }

        /// <summary>
        /// 测试插入2列 - 多次调用Insert
        /// </summary>
        [Fact]
        public void TestInsert_3() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [z].[t]([a].[b],[c].[d]) " );
            result.Append( "Values(@_p_0,@_p_1)" );

            _clause.Insert( "a.b", "z.t" );
            _clause.Insert( "c.d" );
            _clause.Values( 1, "a" );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_1" ) );
        }

        #endregion

        #region Values

        /// <summary>
        /// 测试插入一行
        /// </summary>
        [Fact]
        public void TestValues_1() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t].[c]([a].[b]) " );
            result.Append( "Values(@_p_0)" );

            _clause.Insert( "a.b", "t.c" );
            _clause.Values( 1 );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试插入多行
        /// </summary>
        [Fact]
        public void TestValues_2() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [z].[t]([a].[b],[c].[d]) " );
            result.Append( "Values(@_p_0,@_p_1)," );
            result.Append( "(@_p_2,@_p_3)" );

            _clause.Insert( "a.b", "z.t" );
            _clause.Insert( "c.d" );
            _clause.Values( 1, "a" );
            _clause.Values( 2, "b" );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_2" ) );
            Assert.Equal( "b", _parameterManager.GetValue( "@_p_3" ) );
        }

        #endregion

        #region AppendInsert

        /// <summary>
        /// 测试添加到Insert子句 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendInsert_1() {
            var result = new StringBuilder();
            result.Append( "Insert Into $t&.$c&($a&.$b&) " );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendInsert( "[t].[c]([a].[b])", false );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Insert子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendInsert_2() {
            var result = new StringBuilder();
            result.Append( "Insert Into [t].[c]([a].[b]) " );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendInsert( "[t].[c]([a].[b])", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Insert子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendInsert_3() {
            var result = new StringBuilder();
            result.Append( "Insert Into [t].[c]([a].[b],[c].[d]) " );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendInsert( "[t].[c]([a].[b],", true );
            clause.AppendInsert( "[c].[d])", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        #endregion

        #region AppendValues

        /// <summary>
        /// 测试添加到Values子句 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendValues_1() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into $t&($a&) " );
            result.Append( "Values($c&)" );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.Insert( "a", "t" );
            clause.AppendValues( "([c])", false );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Values子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendValues_2() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into $t&($a&) " );
            result.Append( "Values([c])" );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.Insert( "a", "t" );
            clause.AppendValues( "([c])", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Values子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendValues_3() {
            var result = new StringBuilder();
            result.AppendLine( "Insert Into $t&($a&) " );
            result.Append( "Values([c],[d])" );

            var clause = new InsertClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.Insert( "a", "t" );
            clause.AppendValues( "([c]", true );
            clause.AppendValues( ",[d])", true );
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.Insert( "a.b", "t.c" );
            _clause.Values( 1 );
            _clause.AppendInsert( "[t].[c]([a].[b])", false );
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
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t].[c]([a].[b]) " );
            result.Append( "Values(@_p_0)" );

            //插入数据
            _clause.Insert( "a.b", "t.c" );
            _clause.Values( 1 );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( result.ToString(), GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Values( 2 );
            Assert.Equal( result.ToString(), GetSql( clone ) );
        }

        #endregion
    }
}
