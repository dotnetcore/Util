using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Util.Tests.Models;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql查询对象测试 - 执行存储过程测试
    /// 说明:
    /// 1. PostgreSql的存储过程不能返回数据
    /// 2. PostgreSql的函数可以返回数据,能够使用ExecuteProcedureXXXX方法调用函数
    /// 3. 需要特别注意PostgreSql函数和存储过程中大小写问题
    /// </summary>
    public partial class PostgreSqlQueryTest {

        #region ExecuteProcedureScalar

        /// <summary>
        /// 测试执行存储过程获取单值
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_1() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar( "Products.Func_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_2() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar<string>( "Products.Func_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureScalarAsync

        /// <summary>
        /// 测试执行存储过程获取单值
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_1() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalarAsync( "Products.Func_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_2() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalarAsync<string>( "Products.Func_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingle

        /// <summary>
        /// 测试执行存储过程获取单个实体
        /// </summary>
        [Fact]
        public void TestExecuteProcedureSingle() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingle<Product>( "Products.Func_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "\"Products\".\"Func_GetProduct\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingleAsync

        /// <summary>
        /// 测试执行存储过程获取单个实体
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureSingleAsync() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingleAsync<Product>( "Products.Func_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "\"Products\".\"Func_GetProduct\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureQuery

        /// <summary>
        /// 测试执行存储过程获取实体集合
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQuery( "Products.Func_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "\"Products\".\"Func_GetProducts\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试获取实体集合 - 1个泛型参数
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQuery<Product>( "Products.Func_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "\"Products\".\"Func_GetProducts\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureQueryAsync

        /// <summary>
        /// 测试执行存储过程获取实体集合
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = await _sqlQuery
                .AddDynamicParams( new{ productId=id, productId2=id2 } )
                .ExecuteProcedureQueryAsync( "Products.Func_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
        }

        /// <summary>
        /// 测试获取实体集合 - 1个泛型参数
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQueryAsync<Product>( "Products.Func_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
        }

        #endregion
    }
}
