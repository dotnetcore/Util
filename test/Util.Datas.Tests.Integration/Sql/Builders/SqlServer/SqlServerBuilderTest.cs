using System;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Queries;
using Util.Datas.Sql;
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
    }
}