using System;
using System.Data;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// PostgreSql Sql执行器测试 - 执行存储过程参数测试
    /// </summary>
    public partial class PostgreSqlExecutorTest {
        /// <summary>
        /// 测试添加动态参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_Dynamic() {
            var id = Guid.NewGuid();
            await _sqlExecutor
                .AppendLine( "Insert Into \"Products\".\"Product\"(\"ProductId\",\"Code\") " )
                .Append( "Values(@ProductId,@Code)" )
                .AddDynamicParams( new { ProductId=id, Code= TestConfig.Value } )
                .ExecuteAsync();
            var result = await _sqlExecutor.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }

        /// <summary>
        /// 测试添加和获取输出参数
        /// 说明
        /// 1. PostgreSql数据库的存储过程需要使用call进行调用
        /// 2. 存储过程名称如果包含大写,需要使用转义符"",也可以使用[],会自动转换为""
        /// 3. 调用存储过程时,输出参数值传入null
        /// 4. 定义存储过程的输出参数需要使用in out参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_Output() {
            //定义变量
            var id = Guid.NewGuid();

            //插入数据
            await _sqlExecutor
                .AppendLine( "Insert Into \"Products\".\"Product\"(\"ProductId\",\"Code\") " )
                .Append( "Values(@ProductId,@Code)" )
                .AddParam( "@ProductId", id )
                .AddParam( "Code", TestConfig.Value )
                .ExecuteAsync();

            //执行存储过程 - 添加输出参数
            await _sqlExecutor
                .AddParam( "productId", id )
                .AddParam( "code",DbType.String,ParameterDirection.InputOutput )
                .ExecuteProcedureAsync( "call [Products].[Proc_GetProductCode_Output](@productId,null)" );

            //验证 - 使用GetParam获取输出参数
            Assert.Equal( TestConfig.Value, _sqlExecutor.GetParam<string>( "code" ) );
        }

        /// <summary>
        /// 测试添加参数 - 在执行前添加并获取参数
        /// </summary>
        [Fact]
        public async Task TestAddParam_1() {
            var id = Guid.NewGuid();

            //添加第一个参数
            _sqlExecutor
                .AppendLine( "Insert Into \"Products\".\"Product\"(\"ProductId\",\"Code\") " )
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
            var result = await _sqlExecutor.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }
    }
}
