using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Helpers;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// MySql Sql执行器测试 - 标识列测试
    /// </summary>
    public partial class MySqlExecutorTest {
        /// <summary>
        /// 测试插入Guid主键
        /// </summary>
        [Fact]
        public async Task TestInsert_Guid() {
            var id = Guid.NewGuid();
            await _sqlExecutor
                .Insert( "ProductId,Code", "Product" )
                .Values( id, TestConfig.Value )
                .ExecuteAsync();
            var result = await _sqlExecutor
                .Select( "Code" )
                .From( "Product" )
                .Where( "ProductId", id )
                .ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }

        /// <summary>
        /// 测试插入int自增长主键
        /// </summary>
        [Fact]
        public async Task TestInsert_Int() {
            var value = Id.Create();
            await _sqlExecutor
                .Insert( "Code", "Customer" )
                .Values( value )
                .ExecuteAsync();
            var result = await _sqlExecutor
                .Select( "CustomerId" )
                .From( "Customer" )
                .Where( "Code", value )
                .ToIntAsync();
            Assert.True( result > 0 );
        }

        /// <summary>
        /// 测试插入string主键
        /// </summary>
        [Fact]
        public async Task TestInsert_String() {
            var id = Id.Create();
            await _sqlExecutor
                .Insert( "OrderId,CustomerName", "Order" )
                .Values( id, TestConfig.Value )
                .ExecuteAsync();
            var result = await _sqlExecutor
                .Select( "CustomerName" )
                .From( "Order" )
                .Where( "OrderId", id )
                .ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }
    }
}
