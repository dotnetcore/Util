using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// MySql Sql��ѯ������� - �ж��Ƿ���ڲ���
    /// </summary>
    public partial class MySqlQueryTest {
        /// <summary>
        /// �����ж��Ƿ���� - ����
        /// </summary>
        [Fact]
        public void TestExecuteExists_1() {
            var result = _sqlQuery.From( "Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExists();
            Assert.True( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ������
        /// </summary>
        [Fact]
        public void TestExecuteExists_2() {
            var result = _sqlQuery.From( "Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExists();
            Assert.False( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ����
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_1() {
            var result = await _sqlQuery.From( "Product" ).Where( "ProductId", TestConfig.Id ).ExecuteExistsAsync();
            Assert.True( result );
        }

        /// <summary>
        /// �����ж��Ƿ���� - ������
        /// </summary>
        [Fact]
        public async Task TestExecuteExistsAsync_2() {
            var result = await _sqlQuery.From( "Product" ).Where( "ProductId", Guid.NewGuid() ).ExecuteExistsAsync();
            Assert.False( result );
        }
    }
}
