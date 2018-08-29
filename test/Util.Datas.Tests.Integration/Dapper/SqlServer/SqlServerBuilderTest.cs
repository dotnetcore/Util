using System;
using System.Collections.Generic;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.XUnitHelpers;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Dapper.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器测试
    /// </summary>
    public class SqlServerBuilderTest {
        /// <summary>
        /// Sql Server Sql生成器
        /// </summary>
        private readonly SqlServerBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlServerBuilderTest() {
            _builder = new SqlServerBuilder();
        }

        /// <summary>
        /// 验证表名为空
        /// </summary>
        [Fact]
        public void Test_Validate_1() {
            _builder.Select( "a" );
            AssertHelper.Throws<InvalidOperationException>( () => _builder.ToSql() );
        }

        /// <summary>
        /// 设置查询条件 - 验证列名为空
        /// </summary>
        [Fact]
        public void Test_Validate_2() {
            AssertHelper.Throws<ArgumentNullException>( () => _builder.Where( "", "a" ) );
        }

        /// <summary>
        /// 内连接
        /// </summary>
        [Fact]
        public void Test_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a3].[a],[a1].[b1],[a2].[b2] " );
            result.AppendLine( "From [b] As [a2] " );
            result.Append( "Join [c] As [a3] On [a2].[d]=[a3].[e]" );

            //执行
            _builder.Select( "a,a1.b1,[a2].[b2]", "a3" )
                .From( "b", "a2" )
                .Join( "c", "a3" ).On( "a2.d", "a3.[e]" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 左连接 - lambda表达式
        /// </summary>
        [Fact]
        public void Test_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email],[a].[BoolValue],[b].[Description],[b].[IntValue] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Left Join [Sample2] As [b] On [a].[Email]=[b].[StringValue] And [a].[IntValue]<>[b].[IntValue]" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email, t.BoolValue } )
                .Select<Sample2>( t => new object[] { t.Description, t.IntValue } )
                .From<Sample>( "a" )
                .LeftJoin<Sample2>( "b" ).On<Sample, Sample2>( ( l, r ) => l.Email == r.StringValue && l.IntValue != r.IntValue );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void Test_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a3].[a],[a1].[b1],[a2].[b2] " );
            result.AppendLine( "From [b] As [a2] " );
            result.AppendLine( "Join [c] As [a3] On [a2].[d]=[a3].[e] " );
            result.Append( "Where [b].[Name]=@_p_0" );

            //执行
            _builder.Select( "a,a1.b1,[a2].[b2]", "a3" )
                .From( "b", "a2" )
                .Join( "c", "a3" ).On( "a2.d", "a3.[e]" )
                .Where( "b.Name", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - lambda表达式
        /// </summary>
        [Fact]
        public void Test_4() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email],[a].[BoolValue],[b].[Description],[b].[IntValue] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.AppendLine( "Left Join [Sample2] As [b] On [a].[Email]=[b].[StringValue] And [a].[IntValue]<>[b].[IntValue] " );
            result.Append( "Where [a].[Email]=@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email, t.BoolValue } )
                .Select<Sample2>( t => new object[] { t.Description, t.IntValue } )
                .From<Sample>( "a" )
                .LeftJoin<Sample2>( "b" ).On<Sample, Sample2>( ( l, r ) => l.Email == r.StringValue && l.IntValue != r.IntValue )
                .Where<Sample>( t => t.Email, "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 设置条件 - 相等
        /// </summary>
        [Fact]
        public void Test_5() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email],[a].[BoolValue] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[Email]=@_p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email, t.BoolValue } )
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
        public void Test_6() {
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

        /// <summary>
        /// 设置条件 - 不相等
        /// </summary>
        [Fact]
        public void Test_7() {
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
        public void Test_8() {
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

        /// <summary>
        /// 设置条件 - 大于
        /// </summary>
        [Fact]
        public void Test_9() {
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
        public void Test_10() {
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

        /// <summary>
        /// 设置条件 - 小于
        /// </summary>
        [Fact]
        public void Test_11() {
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
        public void Test_12() {
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

        /// <summary>
        /// 设置条件 - 大于等于
        /// </summary>
        [Fact]
        public void Test_13() {
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
        public void Test_14() {
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

        /// <summary>
        /// 设置条件 - 小于等于
        /// </summary>
        [Fact]
        public void Test_15() {
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
        public void Test_16() {
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

        /// <summary>
        /// 设置条件 - 模糊匹配
        /// </summary>
        [Fact]
        public void Test_17() {
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
        public void Test_18() {
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

        /// <summary>
        /// 设置条件 - 头匹配
        /// </summary>
        [Fact]
        public void Test_19() {
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
        public void Test_20() {
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

        /// <summary>
        /// 设置条件 - 尾匹配
        /// </summary>
        [Fact]
        public void Test_21() {
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
        public void Test_22() {
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

        /// <summary>
        /// 设置条件 - Is Null
        /// </summary>
        [Fact]
        public void Test_23() {
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
        public void Test_24() {
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

        /// <summary>
        /// 设置条件 - Is Not Null
        /// </summary>
        [Fact]
        public void Test_25() {
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
        public void Test_26() {
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

        /// <summary>
        /// 设置条件 - 空条件
        /// </summary>
        [Fact]
        public void Test_27() {
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
        public void Test_28() {
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

        /// <summary>
        /// 设置条件 - 非空条件
        /// </summary>
        [Fact]
        public void Test_29() {
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
        public void Test_30() {
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

        /// <summary>
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void Test_31() {
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
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void Test_32() {
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
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void Test_33() {
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
        /// 测试分组
        /// </summary>
        [Fact]
        public void Test_34() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Group By [a].[B],[c].[D]" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .GroupBy( "a.B,c.[D]" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 测试范围查询
        /// </summary>
        [Fact]
        public void Test_35() {
            //结果
            var result = new String();
            result.AppendLine( "Select [a].[Email] " );
            result.AppendLine( "From [Sample] As [a] " );
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _builder.Select<Sample>( t => t.Email )
                .From<Sample>( "a" )
                .Between( "a.B",1,2 );

            //验证
            Assert.Equal( 1, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 2, _builder.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 与连接
        /// </summary>
        [Fact]
        public void Test_36() {
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
        public void Test_37() {
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
        /// 连接查询条件 - 创建1个子生成器
        /// </summary>
        [Fact]
        public void Test_38() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where [Age]=@_p_1 And [Name]=@_p_0" );

            //执行
            var newBuilder = _builder.New().Where( "Name", "a" );
            _builder.From( "Test" ).Where( "Age", 1 ).And( newBuilder );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 连接查询条件 - 创建2个子生成器
        /// </summary>
        [Fact]
        public void Test_39() {
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

        /// <summary>
        /// 连接查询条件 - 创建1个子生成器 - Or
        /// </summary>
        [Fact]
        public void Test_40() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where ([Age]=@_p_1 Or [Name]=@_p_0)" );

            //执行
            var newBuilder = _builder.New().Where( "Name", "a" );
            _builder.From( "Test" ).Where( "Age", 1 ).Or( newBuilder );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 连接查询条件 - 创建2个子生成器 - Or
        /// </summary>
        [Fact]
        public void Test_41() {
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
    }
}