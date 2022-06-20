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
    /// MySql Sql��ѯ������� - ��ѯ����
    /// </summary>
    public partial class MySqlQueryTest {

        #region ExecuteQuery

        /// <summary>
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQuery_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQuery();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 1�����Ͳ���
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQuery_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = _sqlQuery.Select("ProductId As Id,Code").From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQuery<Product>();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 3�����Ͳ��� - ���ӱ�,���ù�������
        /// </summary>
        [Fact]
        public async Task TestExecuteQuery_3() {
            //���붩��
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //���붩����ϸ
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId,TestConfig.DecimalValue )
                .ExecuteAsync();

            ////��ȡ����
            var result = _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //��OrderItemIdӳ��ΪId,������֮�����OrderItem��ص���
                .Select( "o.OrderId As Id,o.*" ) //��OrderIdӳ��ΪId,�����֮ǰOrderItem���е���Ϣ,֮��������Order���е���
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ExecuteQuery<OrderItem, Order, OrderItem>( ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //����
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
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQueryAsync_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = await _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQueryAsync();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestExecuteQueryAsync_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = await _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ExecuteQueryAsync<Product>();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 3�����Ͳ��� - ���ӱ�,���ù�������
        /// </summary>
        [Fact]
        public async Task TestExecuteQueryAsync_3() {
            //���붩��
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //���붩����ϸ
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            ////��ȡ����
            var result = await _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //��OrderItemIdӳ��ΪId,������֮�����OrderItem��ص���
                .Select( "o.OrderId As Id,o.*" ) //��OrderIdӳ��ΪId,�����֮ǰOrderItem���е���Ϣ,֮��������Order���е���
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ExecuteQueryAsync<OrderItem, Order, OrderItem>( ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //����
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
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestToList_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToList_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToList();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 1�����Ͳ���
        /// </summary>
        [Fact]
        public async Task TestToList_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToList_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToList<Product>();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 3�����Ͳ��� - ���ӱ�,���ù�������
        /// </summary>
        [Fact]
        public async Task TestToList_3() {
            //���붩��
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //���붩����ϸ
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            ////��ȡ����
            var result = _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //��OrderItemIdӳ��ΪId,������֮�����OrderItem��ص���
                .Select( "o.OrderId As Id,o.*" ) //��OrderIdӳ��ΪId,�����֮ǰOrderItem���е���Ϣ,֮��������Order���е���
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ToList<OrderItem, Order, OrderItem>( ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //����
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
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestToListAsync_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToListAsync_1";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = await _sqlQuery.Select().From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToListAsync();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.ProductId == id );
            Assert.Contains( result, t => t.ProductId == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestToListAsync_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var code = "TestToListAsync_2";
            await _sqlExecutor.Insert( "ProductId,Code", "Product" )
                .Values( id, code )
                .Values( id2, code )
                .ExecuteAsync();

            //��ȡ����
            var result = await _sqlQuery.Select( "ProductId As Id,Code" ).From( "Product" ).In( "ProductId", new[] { id, id2 } ).ToListAsync<Product>();

            //����
            Assert.NotNull( result );
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id );
            Assert.Contains( result, t => t.Id == id2 );
            Assert.Contains( result, t => t.Code == code );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 3�����Ͳ��� - ���ӱ�,���ù�������
        /// </summary>
        [Fact]
        public async Task TestToListAsync_3() {
            //���붩��
            var orderId = Id.Create();
            var customerName = "customerName";
            await _sqlExecutor.Insert( "OrderId,CustomerName", "Order" )
                .Values( orderId, customerName )
                .ExecuteAsync();

            //���붩����ϸ
            var orderItemId = Id.CreateGuid();
            await _sqlExecutor.Insert( "OrderItemId,OrderId,Price", "OrderItem" )
                .Values( orderItemId, orderId, TestConfig.DecimalValue )
                .ExecuteAsync();

            ////��ȡ����
            var result = await _sqlQuery
                .Select( "i.OrderItemId As Id,i.*" ) //��OrderItemIdӳ��ΪId,������֮�����OrderItem��ص���
                .Select( "o.OrderId As Id,o.*" ) //��OrderIdӳ��ΪId,�����֮ǰOrderItem���е���Ϣ,֮��������Order���е���
                .From( "OrderItem As i" )
                .LeftJoin( "Order As o" ).On( "o.OrderId", "i.OrderId" )
                .Where( "i.OrderItemId", orderItemId )
                .ToListAsync<OrderItem, Order, OrderItem>( ( item, order ) => {
                    item.Order = order;
                    return item;
                } );

            //����
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
