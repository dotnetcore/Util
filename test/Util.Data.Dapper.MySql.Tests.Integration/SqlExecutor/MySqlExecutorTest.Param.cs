using System;
using System.Data;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// MySql Sql执行器测试 - 执行存储过程参数测试
    /// </summary>
    public partial class MySqlExecutorTest {
        /// <summary>
        /// 测试添加动态参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_Dynamic() {
            var id = Guid.NewGuid();
            await _sqlExecutor
                .AppendLine( "Insert Product(ProductId,Code) " )
                .Append( "Values(@ProductId,@Code)" )
                .AddDynamicParams( new { ProductId=id, Code= TestConfig.Value } )
                .ExecuteAsync();
            var result = await _sqlExecutor.Select( "Code" ).From( "Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }

        /// <summary>
        /// 测试添加和获取输出参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_Output() {
            //定义变量
            var id = Guid.NewGuid();

            //插入数据
            await _sqlExecutor
                .AppendLine( "Insert Product(ProductId,Code) " )
                .Append( "Values(@ProductId,@Code)" )
                .AddParam( "@ProductId", id )
                .AddParam( "Code", TestConfig.Value )
                .ExecuteAsync();

            //执行存储过程 - 添加输出参数
            await _sqlExecutor
                .AddParam( "id", id )
                .AddParam( "code_output", dbType: DbType.String,direction: ParameterDirection.Output,size:50 )
                .ExecuteProcedureAsync( "Proc_GetProductCode_Output" );

            //验证 - 使用GetParam获取输出参数
            Assert.Equal( TestConfig.Value, _sqlExecutor.GetParam<string>( "code_output" ) );
        }

        /// <summary>
        /// 测试添加参数 - 在执行前添加并获取参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_1() {
            var id = Guid.NewGuid();

            //添加第一个参数
            _sqlExecutor
                .AppendLine( "Insert Product(ProductId,Code) " )
                .Append( "Values(@ProductId,@Code)" )
                .AddParam( "@ProductId", id );

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
