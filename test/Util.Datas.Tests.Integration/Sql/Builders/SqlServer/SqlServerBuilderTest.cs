using System;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Queries;
using Util.Datas.Sql;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.XUnitHelpers;
using Util.Properties;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Sql.Builders.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器测试
    /// </summary>
    public partial class SqlServerBuilderTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// Sql Server Sql生成器
        /// </summary>
        private readonly SqlServerBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlServerBuilderTest( ITestOutputHelper output ) {
            _output = output;
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
        /// 验证分页时未设置排序字段，抛出异常
        /// </summary>
        [Fact]
        public void TestPage_1() {
            var pager = new QueryParameter();
            _builder.From( "a" ).Page( pager );
            AssertHelper.Throws<ArgumentException>( () => _builder.ToSql(), LibraryResource.OrderIsEmptyForPage );
        }

        /// <summary>
        /// 分页时设置了排序字段
        /// </summary>
        [Fact]
        public void TestPage_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] " );
            result.AppendLine( "Order By [a] " );
            result.Append( "Offset @_p_0 Rows Fetch Next @_p_1 Rows Only" );

            //执行
            var pager = new QueryParameter { Order = "a" };
            _builder.From( "Test" ).Page( pager );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 0, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 20, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 测试联合操作
        /// </summary>
        [Fact]
        public void TestUnion_1() {
            //结果
            var result = new String();
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test] " );
            result.AppendLine( "Where [c]=@_p_1 " );
            result.AppendLine( ") " );
            result.AppendLine( "Union " );
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [c]=@_p_0 " );
            result.Append( ")" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" ).Where( "c", 1 );
            _builder.Select( "a,b" ).From( "Test" ).Where( "c", 2 ).Union( builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 1, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 2, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 测试联合操作 - 排序
        /// </summary>
        [Fact]
        public void TestUnion_2() {
            //结果
            var result = new String();
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test] " );
            result.AppendLine( "Where [c]=@_p_1 " );
            result.AppendLine( ") " );
            result.AppendLine( "Union " );
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [c]=@_p_0 " );
            result.AppendLine( ") " );
            result.Append( "Order By [a]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" ).Where( "c", 1 );
            _builder.Select( "a,b" ).From( "Test" ).Where( "c", 2 ).OrderBy( "a" ).Union( builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 1, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 2, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 测试联合操作 - 排序 - 联合查询中带排序被过滤
        /// </summary>
        [Fact]
        public void TestUnion_3() {
            //结果
            var result = new String();
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test] " );
            result.AppendLine( "Where [c]=@_p_1 " );
            result.AppendLine( ") " );
            result.AppendLine( "Union " );
            result.AppendLine( "(Select [a],[b] " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [c]=@_p_0 " );
            result.AppendLine( ") " );
            result.Append( "Order By [a]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" ).Where( "c", 1 ).OrderBy( "b" );
            _builder.Select( "a,b" ).From( "Test" ).Where( "c", 2 ).OrderBy( "a" ).Union( builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 1, _builder.GetParams()["@_p_0"] );
            Assert.Equal( 2, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 测试CTE
        /// </summary>
        [Fact]
        public void TestWith_1() {
            //结果
            var result = new String();
            result.AppendLine( "With [Test] " );
            result.AppendLine( "As (Select [a],[b] " );
            result.AppendLine( "From [Test2])" );
            result.AppendLine( "Select [a],[b] " );
            result.Append( "From [Test]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            _builder.Select( "a,b" ).From( "Test" ).With( "Test", builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 测试CTE - 两个CTE
        /// </summary>
        [Fact]
        public void TestWith_2() {
            //结果
            var result = new String();
            result.AppendLine( "With [Test] " );
            result.AppendLine( "As (Select [a],[b] " );
            result.AppendLine( "From [Test2])," );
            result.AppendLine( "[Test3] " );
            result.AppendLine( "As (Select [a],[b] " );
            result.AppendLine( "From [Test3])" );
            result.AppendLine( "Select [a],[b] " );
            result.Append( "From [Test]" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            var builder3 = _builder.New().Select( "a,b" ).From( "Test3" );
            _builder.Select( "a,b" ).From( "Test" ).With( "Test", builder2 ).With( "Test3", builder3 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 测试逻辑删除过滤器 - 内连接
        /// </summary>
        [Fact]
        public void TestIsDeletedFilter_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [s].[StringValue] " );
            result.AppendLine( "From [Sample5] As [s] " );
            result.AppendLine( "Join [Sample2] As [s2] On [s].[IntValue]=[s2].[IntValue] " );
            result.Append( "Where [s].[IsDeleted]=@_p_0" );

            //执行
            _builder.Select<Sample5>( t => t.StringValue ).From<Sample5>( "s" ).Join<Sample2>( "s2" ).On<Sample5, Sample2>( ( l, r ) => l.IntValue == r.IntValue );

            //验证
            _output.WriteLine( _builder.ToSql() );
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }
    }
}
