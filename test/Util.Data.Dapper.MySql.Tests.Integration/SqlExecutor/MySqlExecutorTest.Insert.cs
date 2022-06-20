using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// MySql Sql执行器测试 - 插入测试
    /// </summary>
    public partial class MySqlExecutorTest {
        /// <summary>
        /// 测试使用Insert Values语句插入一条数据
        /// </summary>
        [Fact]
        public async Task TestInsert_1() {
            //插入一条数据
            var id = Guid.NewGuid();
            await _sqlExecutor
                .Insert( "ProductId,Code", "Product" )
                .Values( id, TestConfig.Value )
                .ExecuteAsync();

            //获取值
            var result = await _sqlExecutor
                .Select( "Code" )
                .From( "Product" )
                .Where( "ProductId", id )
                .ToStringAsync();

            //验证
            Assert.Equal( TestConfig.Value, result );
        }

        /// <summary>
        /// 测试使用Insert Values语句插入2条数据
        /// </summary>
        [Fact]
        public async Task TestInsert_2() {
            //插入一条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor
                .Insert( "ProductId,Code", "Product" )
                .Values( id, TestConfig.Value )
                .Values( id2, TestConfig.Value )
                .ExecuteAsync();

            //获取值
            var result = await _sqlExecutor
                .AppendSelect( "Count(*)" )
                .From( "Product" )
                .In( "ProductId", new[]{id,id2} )
                .ToIntAsync();

            //验证
            Assert.Equal( 2, result );
        }

        /// <summary>
        /// 测试使用Insert Select语句插入
        /// </summary>
        [Fact]
        public async Task TestInsert_3() {
            //用Insert Select插入一条数据
            var id = Guid.NewGuid();
            await _sqlExecutor
                .Insert( "ProductId,Code", "Product" )
                .AppendSelect( $"'{id}','{TestConfig.Value}'" )
                .ExecuteAsync();

            //获取值
            var result = await _sqlExecutor
                .Select( "Code" )
                .From( "Product" )
                .Where( "ProductId", id )
                .ToStringAsync();

            //验证
            Assert.Equal( TestConfig.Value, result );
        }
    }
}
