using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// MySql Sql执行器测试 - 执行Sql测试
    /// </summary>
    public partial class MySqlExecutorTest {
        /// <summary>
        /// 测试执行Sql增删改操作
        /// </summary>
        [Fact]
        public async Task TestExecuteAsync() {
            var id = Guid.NewGuid();
            await _sqlExecutor
                .AppendLine( "Insert Product(ProductId,Code) " )
                .Append( "Values(@ProductId,@Code)" )
                .AddParam( "@ProductId", id )
                .AddParam( "Code", TestConfig.Value )
                .ExecuteAsync();
            var result = await _sqlExecutor.Select( "Code" ).From( "Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }
    }
}
