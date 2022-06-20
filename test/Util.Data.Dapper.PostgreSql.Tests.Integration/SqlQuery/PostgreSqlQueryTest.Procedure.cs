using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Util.Tests.Models;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql��ѯ������� - ִ�д洢���̲���
    /// ˵��:
    /// 1. PostgreSql�Ĵ洢���̲��ܷ�������
    /// 2. PostgreSql�ĺ������Է�������,�ܹ�ʹ��ExecuteProcedureXXXX�������ú���
    /// 3. ��Ҫ�ر�ע��PostgreSql�����ʹ洢�����д�Сд����
    /// </summary>
    public partial class PostgreSqlQueryTest {

        #region ExecuteProcedureScalar

        /// <summary>
        /// ����ִ�д洢���̻�ȡ��ֵ
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_1() {
            //ִ�д洢����
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar( "Products.Func_GetProductCode" );

            //����
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// ����ִ�д洢���̻�ȡ��ֵ - ���ͷ���
        /// </summary>
        [Fact]
        public void TestExecuteProcedureScalar_2() {
            //ִ�д洢����
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalar<string>( "Products.Func_GetProductCode" );

            //����
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureScalarAsync

        /// <summary>
        /// ����ִ�д洢���̻�ȡ��ֵ
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_1() {
            //ִ�д洢����
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalarAsync( "Products.Func_GetProductCode" );

            //����
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// ����ִ�д洢���̻�ȡ��ֵ - ���ͷ���
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureScalarAsync_2() {
            //ִ�д洢����
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureScalarAsync<string>( "Products.Func_GetProductCode" );

            //����
            Assert.Equal( TestConfig.Value, result );
            Assert.Equal( "\"Products\".\"Func_GetProductCode\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingle

        /// <summary>
        /// ����ִ�д洢���̻�ȡ����ʵ��
        /// </summary>
        [Fact]
        public void TestExecuteProcedureSingle() {
            //ִ�д洢����
            var result = _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingle<Product>( "Products.Func_GetProduct" );

            //����
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "\"Products\".\"Func_GetProduct\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureSingleAsync

        /// <summary>
        /// ����ִ�д洢���̻�ȡ����ʵ��
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureSingleAsync() {
            //ִ�д洢����
            var result = await _sqlQuery
                .AddParam( "productId", TestConfig.Id )
                .ExecuteProcedureSingleAsync<Product>( "Products.Func_GetProduct" );

            //����
            Assert.Equal( TestConfig.Value, result.Code );
            Assert.Equal( "\"Products\".\"Func_GetProduct\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureQuery

        /// <summary>
        /// ����ִ�д洢���̻�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //ִ�д洢����
            var result = _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQuery( "Products.Func_GetProducts" );

            //����
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "\"Products\".\"Func_GetProducts\"", _sqlQuery.PreviousSql.GetSql() );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 1�����Ͳ���
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQuery_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //ִ�д洢����
            var result = _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQuery<Product>( "Products.Func_GetProducts" );

            //����
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
            Assert.Equal( "\"Products\".\"Func_GetProducts\"", _sqlQuery.PreviousSql.GetSql() );
        }

        #endregion

        #region ExecuteProcedureQueryAsync

        /// <summary>
        /// ����ִ�д洢���̻�ȡʵ�弯��
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_1() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //ִ�д洢����
            var result = await _sqlQuery
                .AddDynamicParams( new{ productId=id, productId2=id2 } )
                .ExecuteProcedureQueryAsync( "Products.Func_GetProducts" );

            //����
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
        }

        /// <summary>
        /// ���Ի�ȡʵ�弯�� - 1�����Ͳ���
        /// </summary>
        [Fact]
        public async Task TestExecuteProcedureQueryAsync_2() {
            //����2������
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            await _sqlExecutor.Insert( "ProductId,Code", "Products.Product" )
                .Values( id, "a" )
                .Values( id2, "b" )
                .ExecuteAsync();

            //ִ�д洢����
            var result = await _sqlQuery
                .AddParam( "productId", id )
                .AddParam( "productId2", id2 )
                .ExecuteProcedureQueryAsync<Product>( "Products.Func_GetProducts" );

            //����
            Assert.Equal( 2, result.Count );
            Assert.Contains( result, t => t.Id == id && t.Code == "a" );
            Assert.Contains( result, t => t.Id == id2 && t.Code == "b" );
        }

        #endregion
    }
}
