using System;
using System.Collections.Generic;
using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - Where子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Where

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>@_p_0" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "b.Name", "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParam<string>( "@_p_0" ) );
        }

        /// <summary>
        /// 添加Where子查询
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Select("a").From( "Test2" ).Where( "Name", "a" );
            _builder.Select().From( "abc.Test" ).Where( "b2", builder2, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.GetSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_1" ) );
        }

        /// <summary>
        /// 添加Where子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select [a] " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            _builder.Select().From( "abc.Test" ).Where( "b2", t => t.Select( "a" ).From( "Test2" ).Where( "Name", "a" ), Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.GetSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_1" ) );
        }

        #endregion

        #region In

        /// <summary>
        /// 设置In条件
        /// </summary>
        [Fact]
        public void TestIn_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .In( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "b", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置In条件 - 数组
        /// </summary>
        [Fact]
        public void TestIn_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new[] { "a", "b" };
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .In( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "b", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置In条件 - 子查询
        /// </summary>
        [Fact]
        public void TestIn_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_1 And " );
            result.Append( "[a].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_0" );
            result.Append( ")" );

            //执行
            var builder = _builder.New().Select( "a" ).From( "b" ).Where( "b.Url", "u" );
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .Where( "a.Name", "n" )
                .In( "a.Email", builder );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "u", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "n", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置In条件 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestIn_4() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_0 And " );
            result.Append( "[a].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_1" );
            result.Append( ")" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .Where( "a.Name", "n" )
                .In( "a.Email", builder => builder.Select( "a" ).From( "b" ).Where( "b.Url", "u" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "n", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "u", _builder.GetParam<string>( "@_p_1" ) );
        }

        #endregion

        #region NotIn

        /// <summary>
        /// 设置NotIn条件
        /// </summary>
        [Fact]
        public void TestNotIn_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .NotIn( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "b", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置NotIn条件 - 数组
        /// </summary>
        [Fact]
        public void TestNotIn_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new[] { "a", "b" };
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .NotIn( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "b", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置NotIn条件 - 子查询
        /// </summary>
        [Fact]
        public void TestNotIn_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_1 And " );
            result.Append( "[a].[Email] Not In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_0" );
            result.Append( ")" );

            //执行
            var builder = _builder.New().Select( "a" ).From( "b" ).Where( "b.Url", "u" );
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .Where( "a.Name", "n" )
                .NotIn( "a.Email", builder );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "u", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "n", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 设置NotIn条件 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestNotIn_4() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_0 And " );
            result.Append( "[a].[Email] Not In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_1" );
            result.Append( ")" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample as a" )
                .Where( "a.Name", "n" )
                .NotIn( "a.Email", builder => builder.Select( "a" ).From( "b" ).Where( "b.Url", "u" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "n", _builder.GetParam<string>( "@_p_0" ) );
            Assert.Equal( "u", _builder.GetParam<string>( "@_p_1" ) );
        }

        #endregion

        #region IsNull

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        [Fact]
        public void TestIsNull() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Null" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .IsNull( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region IsNotNull

        /// <summary>
        /// 设置条件 - Is Not Null
        /// </summary>
        [Fact]
        public void TestIsNotNull() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .IsNotNull( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// 测试设置空条件
        /// </summary>
        [Fact]
        public void TestIsEmpty() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where ([a].[Email] Is Null Or [a].[Email]='')" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .IsEmpty( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// 设置非空条件
        /// </summary>
        [Fact]
        public void TestIsNotEmpty() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null And [a].[Email]<>''" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .IsNotEmpty( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region Between

        /// <summary>
        /// 测试范围查询 - int类型
        /// </summary>
        [Fact]
        public void TestBetween_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .Between( "a.B", 1, 2,Boundary.Left );

            //验证
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( 2, _builder.GetParam<int>( "@_p_1" ) );
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - double类型
        /// </summary>
        [Fact]
        public void TestBetween_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .Between( "a.B", 1.1, 2.2, Boundary.Left );

            //验证
            Assert.Equal( 1.1, _builder.GetParam<double>( "@_p_0" ) );
            Assert.Equal( 2.2, _builder.GetParam<double>( "@_p_1" ) );
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - decimal类型
        /// </summary>
        [Fact]
        public void TestBetween_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .Between( "a.B", 1.1M, 2.2M, Boundary.Left );

            //验证
            Assert.Equal( 1.1M, _builder.GetParam<decimal>( "@_p_0" ) );
            Assert.Equal( 2.2M, _builder.GetParam<decimal>( "@_p_1" ) );
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - DateTime类型
        /// </summary>
        [Fact]
        public void TestBetween_4() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //日期
            var min = "2012-12-12 12:12:12".ToDateTime();
            var max = "2012-12-16 12:12:12".ToDateTime();

            //执行
            _builder.Select( "a.Email" )
                .From( "Sample a" )
                .Between( "a.B", min, max,true, Boundary.Left );

            //验证
            Assert.Equal( min, _builder.GetParam<DateTime>( "@_p_0" ) );
            Assert.Equal( max, _builder.GetParam<DateTime>( "@_p_1" ) );
            Assert.Equal( result.ToString(), _builder.GetSql() );
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
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //子查询
            var subBuilder = new TestSqlBuilder();
            subBuilder.Select( "Name" ).From( "t" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Exists( subBuilder );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置Exists条件 - 子查询操作
        /// </summary>
        [Fact]
        public void TestExists_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Exists( t => t.Select( "Name" ).From( "t" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
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
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where Not Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //子查询
            var subBuilder = new TestSqlBuilder();
            subBuilder.Select( "Name" ).From( "t" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .NotExists( subBuilder );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 设置Not Exists条件 - 子查询操作
        /// </summary>
        [Fact]
        public void TestNotExists_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where Not Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .NotExists( t => t.Select( "Name" ).From( "t" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendWhere

        /// <summary>
        /// 测试添加到Where子句
        /// </summary>
        [Fact]
        public void TestAppendWhere_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>'abc'" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendWhere( "[b].[Name]<>'abc'" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearWhere

        /// <summary>
        /// 测试清空Where子句
        /// </summary>
        [Fact]
        public void TestClearWhere() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "b.Name", "abc", Operator.NotEqual )
                .ClearWhere();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}