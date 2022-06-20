using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// Join子句测试
    /// </summary>
    public class JoinClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// Join子句
        /// </summary>
        private readonly JoinClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public JoinClauseTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _clause = new JoinClause( new TestSqlBuilder( parameterManager: _parameterManager ) );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IJoinClause clause = null ) {
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

        #region On

        /// <summary>
        /// 测试表连接条件 - 未设置join返回空
        /// </summary>
        [Fact]
        public void TestOn_1() {
            _clause.On( "a.id", "b" );
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Join

        /// <summary>
        /// 测试内连接
        /// </summary>
        [Fact]
        public void TestJoin_1() {
            _clause.Join( "a.b as c" );
            Assert.Equal( "Join [a].[b] As [c]", GetSql() );
        }

        /// <summary>
        /// 测试内连接 - 连接列
        /// </summary>
        [Fact]
        public void TestJoin_2() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.Append( "On [t].[id]=[a].[id]" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试内连接 - 2个条件
        /// </summary>
        [Fact]
        public void TestJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.Append( "On [t].[id]=[a].[id] And [t].[id]>@_p_0" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.On( "t.id", 1, Operator.Greater, true );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试2个内连接
        /// </summary>
        [Fact]
        public void TestJoin_4() {
            var result = new StringBuilder();
            result.Append( "Join [b] " );
            result.AppendLine( "On [b].[id]=[a].[id] " );
            result.Append( "Join [c] " );
            result.Append( "On [c].[id]=[b].[id] And [c].[id]>@_p_0" );

            _clause.Join( "b" );
            _clause.On( "b.id", "a.id" );
            _clause.Join( "c" );
            _clause.On( "c.id", "b.id" );
            _clause.On( "c.id", 1, Operator.Greater, true );
            Assert.Equal( result.ToString(), GetSql() );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试内连接 - 子查询
        /// </summary>
        [Fact]
        public void TestJoin_5() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.Join( builder, "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试内连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestJoin_6() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.Join( t => t.Select( "a" ).From( "b" ), "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region LeftJoin

        /// <summary>
        /// 测试左外连接
        /// </summary>
        [Fact]
        public void TestLeftJoin_1() {
            _clause.LeftJoin( "a.b as c" );
            Assert.Equal( "Left Join [a].[b] As [c]", GetSql() );
        }

        /// <summary>
        /// 测试左外连接 - 子查询
        /// </summary>
        [Fact]
        public void TestLeftJoin_2() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Left Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.LeftJoin( builder, "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试左外连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestLeftJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Left Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.LeftJoin( t => t.Select( "a" ).From( "b" ), "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region RightJoin

        /// <summary>
        /// 测试右外连接
        /// </summary>
        [Fact]
        public void TestRightJoin_1() {
            _clause.RightJoin( "a.b as c" );
            Assert.Equal( "Right Join [a].[b] As [c]", GetSql() );
        }

        /// <summary>
        /// 测试右外连接 - 子查询
        /// </summary>
        [Fact]
        public void TestRightJoin_2() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Right Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.RightJoin( builder, "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试右外连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestRightJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.AppendLine( "Right Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.RightJoin( t => t.Select( "a" ).From( "b" ), "c" );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendJoin

        /// <summary>
        /// 测试添加到内连接 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendJoin_1() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ),_parameterManager ) );
            clause.AppendJoin( "[a].[b]", false );
            Assert.Equal( "Join $a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到内连接 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendJoin_2() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.AppendJoin( "[a].[b] as c", true );
            Assert.Equal( "Join [a].[b] as c", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到内连接 - 先调用select,再调用appendJoin
        /// </summary>
        [Fact]
        public void TestAppendJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.Append( "Join [a].[b] as c" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.AppendJoin( "[a].[b] as c", false );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendLeftJoin

        /// <summary>
        /// 测试添加到左外连接 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendLeftJoin_1() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.AppendLeftJoin( "[a].[b]", false );
            Assert.Equal( "Left Join $a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到左外连接 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendLeftJoin_2() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.AppendLeftJoin( "[a].[b] as c", true );
            Assert.Equal( "Left Join [a].[b] as c", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到左外连接 - 先调用select,再调用AppendLeftJoin
        /// </summary>
        [Fact]
        public void TestAppendLeftJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.Append( "Left Join [a].[b] as c" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.AppendLeftJoin( "[a].[b] as c", false );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendRightJoin

        /// <summary>
        /// 测试添加到右外连接 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendRightJoin_1() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.AppendRightJoin( "[a].[b]", false );
            Assert.Equal( "Right Join $a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到右外连接 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendRightJoin_2() {
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.AppendRightJoin( "[a].[b] as c", true );
            Assert.Equal( "Right Join [a].[b] as c", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到右外连接 - 先调用select,再调用AppendRightJoin
        /// </summary>
        [Fact]
        public void TestAppendRightJoin_3() {
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.AppendLine( "On [t].[id]=[a].[id] " );
            result.Append( "Right Join [a].[b] as c" );

            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.AppendRightJoin( "[a].[b] as c", false );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendOn

        /// <summary>
        /// 添加到On子句
        /// </summary>
        [Fact]
        public void TestAppendOn_1() {
            //结果
            var result = new StringBuilder();
            result.Append( "Join $t& " );
            result.Append( "On $a&.$id&=b.id" );

            //操作
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.Join( "t" );
            clause.AppendOn( "[a].[id]=b.id", false );


            //验证
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 添加到On子句 - 先调用On,再调用AppendOn
        /// </summary>
        [Fact]
        public void TestAppendOn_2() {
            //结果
            var result = new StringBuilder();
            result.Append( "Join $t& " );
            result.Append( "On $a&.$id&=$b&.$id& " );
            result.Append( "And [c].[id]=b.id" );

            //操作
            var clause = new JoinClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ), _parameterManager ) );
            clause.Join( "t" );
            clause.On( "a.id", "b.id" );
            clause.AppendOn( "[c].[id]=b.id", true );


            //验证
            Assert.Equal( result.ToString(), GetSql( clause ) );
        }

        /// <summary>
        /// 添加到On子句 - 综合调用
        /// </summary>
        [Fact]
        public void TestAppendOn_3() {
            //结果
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.Append( "On [a].[id]=[b].[id] " );
            result.AppendLine( "And [c].[id]=b.id " );
            result.Append( "Join a " );
            result.Append( "On [a].[id2]=[b].[id] " );
            result.Append( "And [c].[id]=[a].[id] " );
            result.Append( "And c.id=b.id" );

            //操作
            _clause.Join( "t" );
            _clause.On( "a.id", "b.id" );
            _clause.AppendOn( "[c].[id]=b.id", false );
            _clause.AppendJoin( "a", false );
            _clause.AppendOn( "[a].[id2]=[b].[id]", false );
            _clause.On( "c.id", "a.id" );
            _clause.AppendOn( "c.id=b.id", false );


            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Join子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //结果
            var result = new StringBuilder();
            result.Append( "Join [t] " );
            result.Append( "On [t].[id]=[a].[id]" );

            //设置join条件
            _clause.Join( "t" );
            _clause.On( "t.id", "a.id" );


            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( result.ToString(), GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Join( "t2" );
            _clause.On( "t2.id", "b.id" );
            Assert.Equal( result.ToString(), GetSql( clone ) );
        }

        #endregion
    }
}
