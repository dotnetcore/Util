using System;
using System.Data;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// Oracle Sql执行器测试 - 执行存储过程参数测试
    /// </summary>
    public partial class OracleExecutorTest {
        /// <summary>
        /// 测试添加动态参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_Dynamic() {
            var id = Guid.NewGuid();
            await _sqlExecutor
                .AppendLine( "Insert Into \"Product\"(\"ProductId\",\"Code\") " )
                .Append( "Values(:ProductId,:Code)" )
                .AddDynamicParams( new { ProductId=id, Code= TestConfig.Value } )
                .ExecuteAsync();
            var result = await _sqlExecutor.Select( "Code" ).From( "Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }

        /// <summary>
        /// 测试添加参数 - 在执行前添加并获取参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_1() {
            var id = Guid.NewGuid();

            //添加第一个参数
            _sqlExecutor
                .AppendLine( "Insert Into \"Product\"(\"ProductId\",\"Code\") " )
                .Append( "Values(:ProductId,:Code)" )
                .AddParam( "ProductId", id );

            //获取参数
            var param = _sqlExecutor.GetParam<Guid>( "ProductId" );
            Assert.Equal( id, param );

            //添加第二个参数并执行
            await _sqlExecutor
                .AddParam( "Code", TestConfig.Value )
                .ExecuteAsync();

            //验证
            var result = await _sqlExecutor.Select( "Code" ).From( "Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }
    }
}
