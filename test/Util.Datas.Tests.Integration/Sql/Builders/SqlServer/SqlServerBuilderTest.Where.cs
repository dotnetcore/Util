using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Util.Datas.Queries;
using Util.Datas.Sql;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Tests.Samples;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器测试 - Where子句
    /// </summary>
    public partial class SqlServerBuilderTest {

        #region And

        /// <summary>
        /// And条件
        /// </summary>
        [Fact]
        public void TestAnd_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [Age]=@_p_0 And a<@a" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "Age", 1 )
                .And( new LessCondition( "a", "@a" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// And条件 - 2个子生成器
        /// </summary>
        [Fact]
        public void TestAnd_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where [Age]=@_p_2 And [Name]=@_p_0 And [Code]=@_p_1" );

            //执行
            var builder1 = _builder.New().Where( "Name", "a" );
            var builder2 = _builder.New().Where( "Code", "b" );
            _builder.From( "Test" ).Where( "Age", 1 ).And( builder1 ).And( builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 3, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_2"] );
        }

        #endregion

        #region Or

        /// <summary>
        /// Or条件
        /// </summary>
        [Fact]
        public void TestOr_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where ([Age]=@_p_0 Or a<@a)" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "Age", 1 )
                .Or( new LessCondition( "a", "@a" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// Or条件 - lambda
        /// </summary>
        [Fact]
        public void TestOr_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where ([s].[Email]=@_p_0 Or [s].[Url]<>@_p_1)" );

            //执行
            _builder.From<Sample>( "s" ).Or<Sample>( t => t.Email == "a", t => t.Url != "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// Or条件 - 2个子生成器
        /// </summary>
        [Fact]
        public void TestOr_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where (([Age]=@_p_2 Or [Name]=@_p_0) Or [Code]=@_p_1)" );

            //执行
            var builder1 = _builder.New().Where( "Name", "a" );
            var builder2 = _builder.New().Where( "Code", "b" );
            _builder.From( "Test" ).Where( "Age", 1 ).Or( builder1 ).Or( builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 3, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_2"] );
        }

        /// <summary>
        /// Or条件
        /// </summary>
        [Fact]
        public void TestOrIf_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where ([Age]=@_p_0 Or a<@a)" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "Age", 1 )
                .OrIf( new EqualCondition( "b", "@b" ), false )
                .OrIf( new LessCondition( "a", "@a" ), true );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// Or条件 - 条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where ([s].[Email]=@_p_0 Or [s].[Url]<>@_p_1)" );

            //执行
            _builder.From<Sample>( "s" ).OrIfNotEmpty<Sample>( t => t.Email == "" ).Or<Sample>( t => t.Email == "a", t => t.Url != "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        #endregion

        #region Where

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [Age]=@_p_0 And a<@a" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "Age", 1 )
                .Where( new LessCondition( "a", "@a" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>@_p_0" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Where( "b.Name", "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .Where<Sample>( t => t.Email, "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 布尔表达式
        /// </summary>
        [Fact]
        public void TestWhere_4() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .Where<Sample>( t => t.Email != "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 添加Where子查询
        /// </summary>
        [Fact]
        public void TestWhere_5() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.From( "abc.Test" ).Where( "b2", builder2, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhere_6() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[Email]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.Email, builder2, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 委托
        /// </summary>
        [Fact]
        public void TestWhere_7() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            _builder.From( "abc.Test" ).Where( "b2", builder => {
                builder.Count().From( "Test2" ).Where( "Name", "a" );
            }, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 委托 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhere_8() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[Email]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.Email, builder => {
                builder.Count().From( "Test2" ).Where( "Name", "a" );
            }, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 与连接
        /// </summary>
        [Fact]
        public void TestWhere_9() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [k] " );
            result.Append( "Where [k].[Email]=@_p_0 And [k].[StringValue] Like @_p_1" );

            //执行
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "%b%", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 或连接
        /// </summary>
        [Fact]
        public void TestWhere_10() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [k] " );
            result.Append( "Where ([k].[Email]=@_p_0 And [k].[StringValue] Like @_p_1 Or [k].[IntValue]=@_p_2) " );
            result.Append( "And ([k].[Email]=@_p_3 Or [k].[IntValue]=@_p_4)" );

            //执行
            _builder.From<Sample>( "k" )
                .Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) || t.IntValue == 1 )
                .Where<Sample>( t => t.Email == "c" || t.IntValue == 2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void TestWhere_11() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Where<Sample>( t => list.Contains( t.Email ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - 枚举
        /// </summary>
        [Fact]
        public void TestWhere_12() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[LogLevel]=@_p_0" );

            //执行
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.LogLevel == LogLevel.Error );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 4, _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 枚举 - 可空
        /// </summary>
        [Fact]
        public void TestWhere_13() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[NullableLogLevel]=@_p_0" );

            //执行
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.NullableLogLevel == LogLevel.Error );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 4, _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 枚举 - 参数对象属性为枚举
        /// </summary>
        [Fact]
        public void TestWhere_14() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[LogLevel]=@_p_0" );

            //执行
            var sample = new Sample { LogLevel = LogLevel.Error };
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.LogLevel == sample.LogLevel );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 4, _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 枚举 - 参数对象属性为枚举 - 可空
        /// </summary>
        [Fact]
        public void TestWhere_15() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[NullableLogLevel]=@_p_0" );

            //执行
            var sample = new Sample { NullableLogLevel = LogLevel.Error };
            _builder.From<Sample>( "s" ).Where<Sample>( t => t.NullableLogLevel == sample.NullableLogLevel );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 4, _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region WhereIf

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhereIf_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>@_p_0" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .WhereIf( "b.A", "b", false )
                .WhereIf( "b.Name", "abc", true, Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhereIf_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .WhereIf<Sample>( t => t.Email, "a", false )
                .WhereIf<Sample>( t => t.Email, "abc", true, Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 布尔表达式
        /// </summary>
        [Fact]
        public void TestWhereIf_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .WhereIf<Sample>( t => t.Email == "a", false )
                .WhereIf<Sample>( t => t.Email != "abc", true );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 添加Where子查询
        /// </summary>
        [Fact]
        public void TestWhereIf_4() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.From( "abc.Test" ).WhereIf( "a", builder2, false ).WhereIf( "b2", builder2, true, Operator.NotEqual ).Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhereIf_5() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[Email]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.From<Sample>( "s" )
                .WhereIf<Sample>( t => t.Url, builder2, false )
                .WhereIf<Sample>( t => t.Email, builder2, true, Operator.NotEqual )
                .Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 委托
        /// </summary>
        [Fact]
        public void TestWhereIf_6() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [abc].[Test] " );
            result.Append( "Where [b2]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            _builder.From( "abc.Test" )
                .WhereIf( "b2", builder => {
                    builder.Count().From( "a" ).Where( "Name", "b" );
                }, false )
                .WhereIf( "b2", builder => {
                    builder.Count().From( "Test2" ).Where( "Name", "a" );
                }, true, Operator.NotEqual )
                .Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 添加Where子查询 - 委托 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhereIf_7() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [s] " );
            result.Append( "Where [s].[Email]<>" );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.Append( "Where [Name]=@_p_0) " );
            result.Append( "And [Age]=@_p_1" );

            //执行
            _builder.From<Sample>( "s" )
                .WhereIf<Sample>( t => t.Email, builder => {
                    builder.Count().From( "a" ).Where( "Name", "b" );
                }, false )
                .WhereIf<Sample>( t => t.Email, builder => {
                    builder.Count().From( "Test2" ).Where( "Name", "a" );
                }, true, Operator.NotEqual )
                .Where( "Age", 1 );
            _output.WriteLine( _builder.ToSql() );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        #endregion

        #region WhereIfNotEmpty

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>@_p_0" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .WhereIfNotEmpty( "a.Name", "" )
                .WhereIfNotEmpty( "b.Name", "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .WhereIfNotEmpty<Sample>( t => t.Url, "" )
                .WhereIfNotEmpty<Sample>( t => t.Email, "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 布尔表达式
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .WhereIfNotEmpty<Sample>( t => t.Url == "" )
                .WhereIfNotEmpty<Sample>( t => t.Email != "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Equal

        /// <summary>
        /// 设置条件 - 相等
        /// </summary>
        [Fact]
        public void TestEqual_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]=@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .Equal( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 相等 - lambda表达式
        /// </summary>
        [Fact]
        public void TestEqual_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email],[a].[BoolValue] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]=@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email, t.BoolValue } )
                .From<Sample>( "a" )
                .Equal<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region NotEqual

        /// <summary>
        /// 设置条件 - 不相等
        /// </summary>
        [Fact]
        public void TestNotEqual_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .NotEqual( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 不相等 - lambda表达式
        /// </summary>
        [Fact]
        public void TestNotEqual_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<>@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .NotEqual<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Greater

        /// <summary>
        /// 设置条件 - 大于
        /// </summary>
        [Fact]
        public void TestGreater_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]>@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Greater( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 大于 - lambda表达式
        /// </summary>
        [Fact]
        public void TestGreater_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]>@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Greater<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Less

        /// <summary>
        /// 设置条件 - 小于
        /// </summary>
        [Fact]
        public void TestLess_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Less( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 小于 - lambda表达式
        /// </summary>
        [Fact]
        public void TestLess_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Less<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region GreaterEqual

        /// <summary>
        /// 设置条件 - 大于等于
        /// </summary>
        [Fact]
        public void TestGreaterEqual_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]>=@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .GreaterEqual( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 大于等于 - lambda表达式
        /// </summary>
        [Fact]
        public void TestGreaterEqual_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]>=@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .GreaterEqual<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region LessEqual

        /// <summary>
        /// 设置条件 - 小于等于
        /// </summary>
        [Fact]
        public void TestLessEqual_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<=@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .LessEqual( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 小于等于 - lambda表达式
        /// </summary>
        [Fact]
        public void TestLessEqual_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]<=@_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .LessEqual<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Contains

        /// <summary>
        /// 设置条件 - 模糊匹配
        /// </summary>
        [Fact]
        public void TestContains_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Contains( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%abc%", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 模糊匹配 - lambda表达式
        /// </summary>
        [Fact]
        public void TestContains_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Contains<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%abc%", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Starts

        /// <summary>
        /// 设置条件 - 头匹配
        /// </summary>
        [Fact]
        public void TestStarts_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Starts( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc%", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 头匹配 - lambda表达式
        /// </summary>
        [Fact]
        public void TestStarts_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Starts<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc%", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region Ends

        /// <summary>
        /// 设置条件 - 尾匹配
        /// </summary>
        [Fact]
        public void TestEnds_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Ends( "a.Email", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 尾匹配 - lambda表达式
        /// </summary>
        [Fact]
        public void TestEnds_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Like @_p_0" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Ends<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%abc", _builder.GetParams()["@_p_0"] );
        }

        #endregion

        #region IsNull

        /// <summary>
        /// 设置条件 - Is Null
        /// </summary>
        [Fact]
        public void TestIsNull_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Null" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNull( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - Is Null - lambda表达式
        /// </summary>
        [Fact]
        public void TestIsNull_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Null" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNull<Sample>( t => t.Email );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion

        #region IsNotNull

        /// <summary>
        /// 设置条件 - Is Not Null
        /// </summary>
        [Fact]
        public void TestIsNotNull_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNotNull( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - Is Not Null - lambda表达式
        /// </summary>
        [Fact]
        public void TestIsNotNull_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNotNull<Sample>( t => t.Email );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// 设置条件 - 空条件
        /// </summary>
        [Fact]
        public void TestIsEmpty_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where ([a].[Email] Is Null Or [a].[Email]='')" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsEmpty( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 空条件 - lambda表达式
        /// </summary>
        [Fact]
        public void TestIsEmpty_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where ([a].[Email] Is Null Or [a].[Email]='')" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsEmpty<Sample>( t => t.Email );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// 设置条件 - 非空条件
        /// </summary>
        [Fact]
        public void TestIsNotEmpty_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null And [a].[Email]<>''" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNotEmpty( "a.Email" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 非空条件 - lambda表达式
        /// </summary>
        [Fact]
        public void TestIsNotEmpty_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Is Not Null And [a].[Email]<>''" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .IsNotEmpty<Sample>( t => t.Email );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion

        #region In

        /// <summary>
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void TestIn_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .In( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - In - 属性表达式
        /// </summary>
        [Fact]
        public void TestIn_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .In<Sample>( t => t.Email, list );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - In - 子查询
        /// </summary>
        [Fact]
        public void TestIn_3() {
            //结果
            var result = new String();
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
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Where( "a.Name", "n" )
                .In( "a.Email", builder );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "u", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "n", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - In - 子查询 - 属性表达式
        /// </summary>
        [Fact]
        public void TestIn_4() {
            //结果
            var result = new String();
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
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Where( "a.Name", "n" )
                .In<Sample>( t => t.Email, builder );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "u", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "n", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - In - 子查询 - 委托
        /// </summary>
        [Fact]
        public void TestIn_5() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_0 And " );
            result.Append( "[a].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_1" );
            result.Append( ")" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Where( "a.Name", "n" )
                .In( "a.Email", builder=>builder.Select( "a" ).From( "b" ).Where( "b.Url", "u" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "n", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "u", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - In - 子查询 - 委托 - 属性表达式
        /// </summary>
        [Fact]
        public void TestIn_6() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Name]=@_p_0 And " );
            result.Append( "[a].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Url]=@_p_1" );
            result.Append( ")" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Where( "a.Name", "n" )
                .In<Sample>( t => t.Email, builder => builder.Select( "a" ).From( "b" ).Where( "b.Url", "u" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "n", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "u", _builder.GetParams()["@_p_1"] );
        }

        #endregion

        #region NotIn

        /// <summary>
        /// 设置条件 - Not In
        /// </summary>
        [Fact]
        public void TestNotIn_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .NotIn( "a.Email", list );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置条件 - Not In
        /// </summary>
        [Fact]
        public void TestNotIn_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .NotIn<Sample>( t => t.Email, list );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p_1"] );
        }

        #endregion

        #region Between

        /// <summary>
        /// 测试范围查询
        /// </summary>
        [Fact]
        public void TestBetween_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Between( "a.B", 1, 2 );

            //验证
            Assert.Equal( 1, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 2, _builder.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion
    }
}