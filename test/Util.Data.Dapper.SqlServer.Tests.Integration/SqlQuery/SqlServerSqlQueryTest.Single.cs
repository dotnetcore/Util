using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Util.Tests.Models;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// Sql Server Sql查询对象测试 - 获取单个对象测试
    /// </summary>
    public partial class SqlServerSqlQueryTest {
        /// <summary>
        /// 测试获取单个实体
        /// </summary>
        [Fact]
        public void TestExecuteSingle() {
            var result = _sqlQuery.Select( "ProductId as Id,Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteSingle<Product>();
            Assert.Equal( TestConfig.Id, result.Id );
            Assert.Equal( TestConfig.Value, result.Code );
        }

        /// <summary>
        /// 测试获取单个实体
        /// </summary>
        [Fact]
        public async Task TestExecuteSingleAsync() {
            var result = await _sqlQuery.Select( "ProductId as Id,Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteSingleAsync<Product>();
            Assert.Equal( TestConfig.Id, result.Id );
            Assert.Equal( TestConfig.Value, result.Code );
        }

        /// <summary>
        /// 测试获取单个实体
        /// </summary>
        [Fact]
        public void TestToEntity() {
            var result = _sqlQuery.Select( "ProductId as Id,Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToEntity<Product>();
            Assert.Equal( TestConfig.Id, result.Id );
            Assert.Equal( TestConfig.Value, result.Code );
        }

        /// <summary>
        /// 测试获取单个实体
        /// </summary>
        [Fact]
        public async Task TestToEntityAsync() {
            var result = await _sqlQuery.Select( "ProductId as Id,Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToEntityAsync<Product>();
            Assert.Equal( TestConfig.Id, result.Id );
            Assert.Equal( TestConfig.Value, result.Code );
        }
    }
}
