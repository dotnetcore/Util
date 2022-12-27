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
    /// MySql Sql查询对象测试 - 执行存储过程测试
    /// </summary>
    public partial class MySqlQueryTest {

        #region ExecuteProcedureScalar

        /// <summary>
        /// 测试执行存储过程获取单值
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_1() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureScalar( "Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "`Proc_GetProductCode`", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_2() {
            //执行存储过程
            var result = _sqlQuery
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureScalar<string>( "Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "`Proc_GetProductCode`", _sqlQuery.PreviousSql.GetSql() );
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
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureScalarAsync( "Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "`Proc_GetProductCode`", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试执行存储过程获取单值 - 泛型方法
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_2() {
            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureScalarAsync<string>( "Proc_GetProductCode" );

            //断言
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "`Proc_GetProductCode`", _sqlQuery.PreviousSql.GetSql() );
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
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureSingle<Product>( "Proc_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "`Proc_GetProduct`", _sqlQuery.PreviousSql.GetSql() );
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
                .AddParam( "id", TestConfig.Id )
                .ExecuteProcedureSingleAsync<Product>( "Proc_GetProduct" );

            //断言
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "`Proc_GetProduct`", _sqlQuery.PreviousSql.GetSql() );
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
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = _sqlQuery
                .AddParam( "id", id )
                .AddParam( "id2", id2 )
                .ExecuteProcedureQuery( "Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "`Proc_GetProducts`", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试获取实体集合 - 1个泛型参数
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = _sqlQuery
                .AddParam( "id", id )
                .AddParam( "id2", id2 )
                .ExecuteProcedureQuery<Product>( "Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "`Proc_GetProducts`", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_3() {
            //插入订单
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //插入订单明细
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery
                .AddParam( "id", orderItemId )
                .ExecuteProcedureQuery<OrderItem, Order, OrderItem>( "Proc_GetOrderItem", ( item, order ) => {
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
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = await _sqlQuery
                .AddDynamicParams( new{ id, id2 } )
                .ExecuteProcedureQueryAsync( "Proc_GetProducts" );

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
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //执行存储过程
            var result = await _sqlQuery
                .AddParam( "id", id )
                .AddParam( "id2", id2 )
                .ExecuteProcedureQueryAsync<Product>( "Proc_GetProducts" );

            //断言
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_3() {
            //插入订单
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //插入订单明细
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery
                .AddParam( "id", orderItemId )
                .ExecuteProcedureQueryAsync<OrderItem, Order, OrderItem>( "Proc_GetOrderItem", ( item, order ) => {
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
