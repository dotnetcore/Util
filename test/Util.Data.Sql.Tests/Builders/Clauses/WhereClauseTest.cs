using System;
using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// Where子句测试
    /// </summary>
    public class WhereClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// Where子句
        /// </summary>
        private readonly WhereClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public WhereClauseTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _clause = new WhereClause( new TestSqlBuilder( parameterManager: _parameterManager ) );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IWhereClause clause = null ) {
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

        #region Where(设置条件)

        /// <summary>
        /// 设置相等条件 - 1个条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            _clause.Where( "Name", "a", Operator.Equal );
            Assert.Equal( "Where [Name]=@_p_0", GetSql() );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 设置相等条件 - 带表别名
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            _clause.Where( "f.Name", "a", Operator.Equal );
            Assert.Equal( "Where [f].[Name]=@_p_0", GetSql() );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 设置相等条件 - 2个条件
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            _clause.Where( "f.Name", "a", Operator.Equal );
            _clause.Where( "s.Age", "b", Operator.Equal );
            Assert.Equal( "Where [f].[Name]=@_p_0 And [s].[Age]=@_p_1", GetSql() );
            Assert.Equal( "a", _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "b", _parameterManager.GetValue( "@_p_1" ) );
        }

        /// <summary>
        /// 测试设置子查询条件
        /// </summary>
        [Fact]
        public void TestWhere_4() {
            var result = new StringBuilder();
            result.Append( "Where [a].[b]=" );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b])" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _clause.Where( "a.b", builder,Operator.Equal );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试设置子查询条件 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestWhere_5() {
            var result = new StringBuilder();
            result.Append( "Where [a].[b]=" );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b])" );

            _clause.Where( "a.b", t => t.Select( "a" ).From( "b" ), Operator.Equal );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region IsNull

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        [Fact]
        public void TestIsNull() {
            _clause.IsNull( "f.Name" );
            Assert.Equal( "Where [f].[Name] Is Null", GetSql() );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        #endregion

        #region IsNotNull

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        [Fact]
        public void TestIsNotNull_1() {
            _clause.IsNotNull( "f.Name" );
            Assert.Equal( "Where [f].[Name] Is Not Null", GetSql() );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsEmpty_1() {
            _clause.IsEmpty( "f.Name" );
            Assert.Equal( "Where ([f].[Name] Is Null Or [f].[Name]='')", GetSql() );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsNotEmpty_1() {
            _clause.IsNotEmpty( "f.Name" );
            Assert.Equal( "Where [f].[Name] Is Not Null And [f].[Name]<>''", GetSql() );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        #endregion

        #region Between(范围查询)

        /// <summary>
        /// 测试范围查询 - 整型
        /// </summary>
        [Fact]
        public void TestBetween_1() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1, 2, Boundary.Both );

            //验证
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 不包含边界
        /// </summary>
        [Fact]
        public void TestBetween_2() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            _clause.Between( "a.B", 1, 2, Boundary.Neither );

            //验证
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestBetween_3() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            _clause.Between( "a.B", 2, 1, Boundary.Neither );

            //验证
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestBetween_4() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]<=@_p_0" );

            //执行
            _clause.Between( "a.B", null, 2, Boundary.Both );

            //验证
            Assert.Equal( 2, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestBetween_5() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            _clause.Between( "a.B", 1, null, Boundary.Both );

            //验证
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void TestBetween_6() {
            //执行
            _clause.Between( "a.B", null, null, Boundary.Both );

            //验证
            Assert.Empty( _parameterManager.GetParams() );
            Assert.Empty( GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - double
        /// </summary>
        [Fact]
        public void TestBetween_7() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1.2, 3.4, Boundary.Both );

            //验证
            Assert.Equal( 1.2, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 3.4, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - decimal
        /// </summary>
        [Fact]
        public void TestBetween_8() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1.2M, 3.4M, Boundary.Both );

            //验证
            Assert.Equal( 1.2M, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( 3.4M, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间
        /// </summary>
        [Fact]
        public void TestBetween_9() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, true, null );

            //验证
            Assert.Equal( min, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( max, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间
        /// </summary>
        [Fact]
        public void TestBetween_10() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-1" ), _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( DateTime.Parse( "2000-1-3" ), _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 设置边界
        /// </summary>
        [Fact]
        public void TestBetween_11() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, true, Boundary.Neither );

            //验证
            Assert.Equal( min, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( max, _parameterManager.GetValue( "@_p_1" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间 - 最大值为空
        /// </summary>
        [Fact]
        public void TestBetween_12() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            _clause.Between( "a.B", min, null, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-1" ), _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间  - 最大值为空
        /// </summary>
        [Fact]
        public void TestBetween_13() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            _clause.Between( "a.B", min, null, true, null );

            //验证
            Assert.Equal( min, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间 - 最小值为空
        /// </summary>
        [Fact]
        public void TestBetween_14() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]<@_p_0" );

            //执行
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", null, max, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-3" ), _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间 - 最小值为空
        /// </summary>
        [Fact]
        public void TestBetween_15() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where [a].[B]<=@_p_0" );

            //执行
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", null, max, true, null );

            //验证
            Assert.Equal( max, _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Exists

        /// <summary>
        /// 设置Exists条件 - 子查询Sql生成器
        /// </summary>
        [Fact]
        public void TestExists_1() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //子查询
            var subBuilder = new TestSqlBuilder();
            subBuilder.Select( "Name" ).From( "t" );

            //执行
            _clause.Exists( subBuilder );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置Exists条件 - 子查询操作
        /// </summary>
        [Fact]
        public void TestExists_2() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //执行
            _clause.Exists( t => t.Select( "Name" ).From( "t" ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region NotExists

        /// <summary>
        /// 设置Not Exists条件 - 子查询Sql生成器
        /// </summary>
        [Fact]
        public void TestNotExists_1() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where Not Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //子查询
            var subBuilder = new TestSqlBuilder();
            subBuilder.Select( "Name" ).From( "t" );

            //执行
            _clause.NotExists( subBuilder );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置Not Exists条件 - 子查询操作
        /// </summary>
        [Fact]
        public void TestNotExists_2() {
            //结果
            var result = new StringBuilder();
            result.Append( "Where Not Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //执行
            _clause.NotExists( t => t.Select( "Name" ).From( "t" ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region AppendSql(添加到Where子句)

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        [Fact]
        public void TestAppendSql() {
            var clause = new WhereClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a]", false );
            clause.AppendSql( "[b]", true );
            Assert.Equal( "Where $a& And [b]", GetSql( clause ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.Where( "Name", "a", Operator.Equal );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Where子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //设置条件
            _clause.Where( "Name", "a", Operator.Equal );

            //复制并验证
            var sqlBuilder = new TestSqlBuilder();
            var clone = _clause.Clone( sqlBuilder );
            Assert.Equal( "Where [Name]=@_p_0", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.Where( "Code", "b", Operator.Equal );
            Assert.Equal( "Where [Name]=@_p_0", GetSql( clone ) );
        }

        #endregion
    }
}
