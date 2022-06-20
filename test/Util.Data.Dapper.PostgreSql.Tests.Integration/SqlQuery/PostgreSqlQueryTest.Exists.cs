using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql��ѯ������� - �ж��Ƿ���ڲ���
    /// </summary>
    public partial class PostgreSqlQueryTest {
        /// <summary>
        /// �����ж��Ƿ���� - ����
        /// </summary>
        [Fact]
        public void TestExecuteExists_1() {
            var result = _sqlQuery.From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExists();
            Assert.True( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ������
        /// </summary>
        [Fact]
        public void TestExecuteExists_2() {
            var result = _sqlQuery.From( "Products.Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExists();
            Assert.False( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ����
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_1() {
            var result = await _sqlQuery.From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExistsAsync();
            Assert.True( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ������
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_2() {
            var result = await _sqlQuery.From( "Products.Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExistsAsync();
            Assert.False( result );
        }
    }
}
