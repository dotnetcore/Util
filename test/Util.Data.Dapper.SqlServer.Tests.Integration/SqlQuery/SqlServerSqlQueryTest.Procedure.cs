using System;
using System.Collections;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Helpers;
using Util.Tests.Configs;
using Util.Tests.Models;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// Sql Server Sql查询对象测试 - 执行存储过程测试
    /// </summary>
    public partial class SqlServerSqlQueryTest {

        #region ExecuteProcedureScalar

        /// <summary>
        /// 测试执行存储过程获取单值
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_1() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar( "Products.Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "[Products].[Proc_GetProductCode]", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_2() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar<string>( "Products.Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "[Products].[Proc_GetProductCode]", _sqlQuery.PreviousSql.GetSql() );
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
                .ExecuteProcedureScalarAsync( "Products.Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "[Products].[Proc_GetProductCode]", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_2() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalarAsync<string>( "Products.Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "[Products].[Proc_GetProductCode]", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingle

        /// <summary>
        /// 测试执行存储过程获取单个实体
        /// </summary>
        [Fact(Skip = "扩展属性转换失败,尚未处理")]
        public void TestExecuteProcedureSingle() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingle<Product>( "Products.Proc_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "[Products].[Proc_GetProduct]", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingleAsync

        /// <summary>
        /// 测试执行存储过程获取单个实体
        /// </summary>
        [Fact( Skip = "扩展属性转换失败,尚未处理" )]
        public async Task TestExecuteProcedureSingleAsync() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingleAsync<Product>( "Products.Proc_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "[Products].[Proc_GetProduct]", _sqlQuery.PreviousSql.GetSql() );
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
                .ExecuteProcedureQuery( "Products.Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "[Products].[Proc_GetProducts]", _sqlQuery.PreviousSql.GetSql() );
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
                .ExecuteProcedureQuery<Product>( "Products.Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "[Products].[Proc_GetProducts]", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_3() {
            //插入订单
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Sales.Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //插入订单明细
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "Sales.OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery
                .AddParam( "orderItemId", orderItemId )
                .ExecuteProcedureQuery<OrderItem, Order, OrderItem>( "Sales.Proc_GetOrderItem", ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //断言
            Assert.Single( (IEnumerable)result );
            Assert.Equal( orderItemId, result[0].Id );
            Assert.Equal( TestConfig.DecimalValue, result[0].Price );
            Assert.Equal( orderId, result[0].OrderId );
            Assert.Equal( orderId, result[0].Order.Id );
            Assert.Equal( customerName, result[0].Order.CustomerName );
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
                .ExecuteProcedureQueryAsync( "Products.Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "[Products].[Proc_GetProducts]", _sqlQuery.PreviousSql.GetSql() );
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
                .ExecuteProcedureQueryAsync<Product>( "Products.Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "[Products].[Proc_GetProducts]", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_3() {
            //插入订单
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Sales.Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //插入订单明细
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "Sales.OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery
                .AddParam( "orderItemId", orderItemId )
                .ExecuteProcedureQueryAsync<OrderItem, Order, OrderItem>( "Sales.Proc_GetOrderItem", ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //断言
            Assert.Single( (IEnumerable)result );
            Assert.Equal( orderItemId, result[0].Id );
            Assert.Equal( TestConfig.DecimalValue, result[0].Price );
            Assert.Equal( orderId, result[0].OrderId );
            Assert.Equal( orderId, result[0].Order.Id );
            Assert.Equal( customerName, result[0].Order.CustomerName );
        }

        #endregion
    }
}
