using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// MySql Sql查询对象测试 - 判断是否存在测试
    /// </summary>
    public partial class MySqlQueryTest {
        /// <summary>
        /// 测试判断是否存在 - 存在
        /// </summary>
        [Fact]
        public void TestExecuteExists_1() {
            var result = _sqlQuery.From( "Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExists();
            Assert.True( result );
        }

        /// <summary>
        /// 测试判断是否存在 - 不存在
        /// </summary>
        [Fact]
        public void TestExecuteExists_2() {
            var result = _sqlQuery.From( "Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExists();
            Assert.False( result );
        }

        /// <summary>
        /// 测试判断是否存在 - 存在
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_1() {
            var result = await _sqlQuery.From( "Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExistsAsync();
            Assert.True( result );
        }

        /// <summary>
        /// 测试判断是否存在 - 不存在
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_2() {
            var result = await _sqlQuery.From( "Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExistsAsync();
            Assert.False( result );
        }
    }
}
