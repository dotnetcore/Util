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
    /// MySql Sql查询对象测试 - 查询测试
    /// </summary>
    public partial class MySqlQueryTest {

        #region ExecuteQuery

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQuery_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQuery();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 1个泛型参数
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQuery_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery.Select("ProductId As Id,Code").From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQuery<Product>();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_3() {
            //插入订单
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //插入订单明细
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId,TestConfig.DecimalValue )
                .ExecuteAsync();

            ////获取对象
            var result = _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //将OrderItemId映射为Id,必须在之后紧跟OrderItem相关的列
                .Select( "o.OrderId As Id,o.*" ) //将OrderId映射为Id,将割断之前OrderItem表中的信息,之后继续添加Order表中的列
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ExecuteQuery<OrderItem, Order, OrderItem>( ( item, order ) => {
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

        #region ExecuteQueryAsync

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQueryAsync_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQueryAsync();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQueryAsync_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQueryAsync<Product>();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_3() {
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

            ////获取对象
            var result = await _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //将OrderItemId映射为Id,必须在之后紧跟OrderItem相关的列
                .Select( "o.OrderId As Id,o.*" ) //将OrderId映射为Id,将割断之前OrderItem表中的信息,之后继续添加Order表中的列
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ExecuteQueryAsync<OrderItem, Order, OrderItem>( ( item, order ) => {
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

        #region ToList

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestToList_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToList_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToList();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 1个泛型参数
        /// </summary>
        [Fact]
        public async Task TestToList_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToList_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToList<Product>();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestToList_3() {
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

            ////获取对象
            var result = _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //将OrderItemId映射为Id,必须在之后紧跟OrderItem相关的列
                .Select( "o.OrderId As Id,o.*" ) //将OrderId映射为Id,将割断之前OrderItem表中的信息,之后继续添加Order表中的列
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ToList<OrderItem, Order, OrderItem>( ( item, order ) => {
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

        #region ToListAsync

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestToListAsync_1() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToListAsync_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToListAsync();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合
        /// </summary>
        [Fact]
        public async Task TestToListAsync_2() {
            //插入2条数据
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToListAsync_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //获取对象
            var result = await _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToListAsync<Product>();

            //断言
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// 测试获取实体集合 - 3个泛型参数 - 主从表,设置关联属性
        /// </summary>
        [Fact]
        public async Task TestToListAsync_3() {
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

            ////获取对象
            var result = await _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //将OrderItemId映射为Id,必须在之后紧跟OrderItem相关的列
                .Select( "o.OrderId As Id,o.*" ) //将OrderId映射为Id,将割断之前OrderItem表中的信息,之后继续添加Order表中的列
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ToListAsync<OrderItem, Order, OrderItem>( ( item, order ) => {
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
