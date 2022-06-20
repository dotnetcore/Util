using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql��ѯ������� - ��ֵ����
    /// </summary>
    public partial class PostgreSqlQueryTest {

        #region ExecuteScalar

        /// <summary>
        /// ���Ի�ȡ��ֵ
        /// </summary>
        [Fact]
        public void TestExecuteScalar_1() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteScalar();
            Assert.Equal( TestConfig.Value, result.SafeString() );
        }

        /// <summary>
        /// ���Ի�ȡ��ֵ - ����
        /// </summary>
        [Fact]
        public void TestExecuteScalar_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteScalar<string>();
            Assert.Equal( TestConfig.Value, result );
        }

        #endregion

        #region ExecuteScalarAsync

        /// <summary>
        /// ���Ի�ȡ��ֵ
        /// </summary>
        [Fact]
        public async Task TestExecuteScalarAsync_1() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteScalarAsync();
            Assert.Equal( TestConfig.Value, result.SafeString() );
        }

        /// <summary>
        /// ���Ի�ȡ��ֵ - ����
        /// </summary>
        [Fact]
        public async Task TestExecuteScalarAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ExecuteScalarAsync<string>();
            Assert.Equal( TestConfig.Value, result );
        }

        #endregion

        #region ToStringAsync

        /// <summary>
        /// ���Ի�ȡ�ַ���ֵ
        /// </summary>
        [Fact]
        public async Task TestToStringAsync() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToStringAsync();
            Assert.Equal( TestConfig.Value, result );
        }

        #endregion

        #region ToInt

        /// <summary>
        /// ���Ի�ȡ32λ����ֵ
        /// </summary>
        [Fact]
        public void TestToInt() {
            var result = _sqlQuery.Select( "IntPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToInt();
            Assert.Equal( TestConfig.IntValue, result );
        }

        #endregion

        #region ToIntAsync

        /// <summary>
        /// ���Ի�ȡ32λ����ֵ
        /// </summary>
        [Fact]
        public async Task TestToIntAsync() {
            var result = await _sqlQuery.Select( "IntPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToIntAsync();
            Assert.Equal( TestConfig.IntValue, result );
        }

        #endregion

        #region ToIntOrNull

        /// <summary>
        /// ���Ի�ȡ32λ����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToIntOrNull_1() {
            var result = _sqlQuery.Select( "IntPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToIntOrNull();
            Assert.Equal( TestConfig.IntValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ32λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToIntOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToIntOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToIntOrNullAsync

        /// <summary>
        /// ���Ի�ȡ32λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToIntOrNullAsync_1() {
            var result = await _sqlQuery.Select( "IntPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToIntOrNullAsync();
            Assert.Equal( TestConfig.IntValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ32λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToIntOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToIntOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToLong

        /// <summary>
        /// ���Ի�ȡ64λ����ֵ
        /// </summary>
        [Fact]
        public void TestToLong() {
            var result = _sqlQuery.Select( "LongPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLong();
            Assert.Equal( TestConfig.LongValue, result );
        }

        #endregion

        #region ToLongAsync

        /// <summary>
        /// ���Ի�ȡ64λ����ֵ
        /// </summary>
        [Fact]
        public async Task TestToLongAsync() {
            var result = await _sqlQuery.Select( "LongPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLongAsync();
            Assert.Equal( TestConfig.LongValue, result );
        }

        #endregion

        #region ToLongOrNull

        /// <summary>
        /// ���Ի�ȡ64λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToLongOrNull_1() {
            var result = _sqlQuery.Select( "LongPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLongOrNull();
            Assert.Equal( TestConfig.LongValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ64λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToLongOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLongOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToLongOrNullAsync

        /// <summary>
        /// ���Ի�ȡ64λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToLongOrNullAsync_1() {
            var result = await _sqlQuery.Select( "LongPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLongOrNullAsync();
            Assert.Equal( TestConfig.LongValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ64λ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToLongOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToLongOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToGuid

        /// <summary>
        /// ���Ի�ȡGuidֵ
        /// </summary>
        [Fact]
        public void TestToGuid() {
            var result = _sqlQuery.Select( "ProductId" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuid();
            Assert.Equal( TestConfig.Id, result );
        }

        #endregion

        #region ToGuidAsync

        /// <summary>
        /// ���Ի�ȡGuidֵ
        /// </summary>
        [Fact]
        public async Task TestToGuidAsync() {
            var result = await _sqlQuery.Select( "ProductId" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuidAsync();
            Assert.Equal( TestConfig.Id, result );
        }

        #endregion

        #region ToGuidOrNull

        /// <summary>
        /// ���Ի�ȡ�ɿ�Guidֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToGuidOrNull_1() {
            var result = _sqlQuery.Select( "ProductId" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuidOrNull();
            Assert.Equal( TestConfig.Id, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Guidֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToGuidOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuidOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToGuidOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿ�Guidֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToGuidOrNullAsync_1() {
            var result = await _sqlQuery.Select( "ProductId" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuidOrNullAsync();
            Assert.Equal( TestConfig.Id, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Guidֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToGuidOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToGuidOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToBool

        /// <summary>
        /// ���Ի�ȡ����ֵ
        /// </summary>
        [Fact]
        public void TestToBool() {
            var result = _sqlQuery.Select( "Enabled" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBool();
            Assert.Equal( TestConfig.BoolValue, result );
        }

        #endregion

        #region ToBoolAsync

        /// <summary>
        /// ���Ի�ȡ����ֵ
        /// </summary>
        [Fact]
        public async Task TestToBoolAsync() {
            var result = await _sqlQuery.Select( "Enabled" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBoolAsync();
            Assert.Equal( TestConfig.BoolValue, result );
        }

        #endregion

        #region ToBoolOrNull

        /// <summary>
        /// ���Ի�ȡ�ɿղ���ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToBoolOrNull_1() {
            var result = _sqlQuery.Select( "Enabled" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBoolOrNull();
            Assert.Equal( TestConfig.BoolValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿղ���ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToBoolOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBoolOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToBoolOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿղ���ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToBoolOrNullAsync_1() {
            var result = await _sqlQuery.Select( "Enabled" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBoolOrNullAsync();
            Assert.Equal( TestConfig.BoolValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿղ���ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToBoolOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToBoolOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToFloat

        /// <summary>
        /// ���Ի�ȡFloatֵ
        /// </summary>
        [Fact]
        public void TestToFloat() {
            var result = _sqlQuery.Select( "FloatPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloat();
            Assert.Equal( TestConfig.FloatValue, result );
        }

        #endregion

        #region ToFloatAsync

        /// <summary>
        /// ���Ի�ȡFloatֵ
        /// </summary>
        [Fact]
        public async Task TestToFloatAsync() {
            var result = await _sqlQuery.Select( "FloatPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloatAsync();
            Assert.Equal( TestConfig.FloatValue, result );
        }

        #endregion

        #region ToFloatOrNull

        /// <summary>
        /// ���Ի�ȡ�ɿ�Floatֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToFloatOrNull_1() {
            var result = _sqlQuery.Select( "FloatPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloatOrNull();
            Assert.Equal( TestConfig.FloatValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Floatֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToFloatOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloatOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToFloatOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿ�Floatֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToFloatOrNullAsync_1() {
            var result = await _sqlQuery.Select( "FloatPrice" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloatOrNullAsync();
            Assert.Equal( TestConfig.FloatValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Floatֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToFloatOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToFloatOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToDouble

        /// <summary>
        /// ���Ի�ȡDoubleֵ
        /// </summary>
        [Fact]
        public void TestToDouble() {
            var result = _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDouble();
            Assert.Equal( TestConfig.DoubleValue, result );
        }

        #endregion

        #region ToDoubleAsync

        /// <summary>
        /// ���Ի�ȡDoubleֵ
        /// </summary>
        [Fact]
        public async Task TestToDoubleAsync() {
            var result = await _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDoubleAsync();
            Assert.Equal( TestConfig.DoubleValue, result );
        }

        #endregion

        #region ToDoubleOrNull

        /// <summary>
        /// ���Ի�ȡ�ɿ�Doubleֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDoubleOrNull_1() {
            var result = _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDoubleOrNull();
            Assert.Equal( TestConfig.DoubleValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Doubleֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDoubleOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDoubleOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToDoubleOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿ�Doubleֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDoubleOrNullAsync_1() {
            var result = await _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDoubleOrNullAsync();
            Assert.Equal( TestConfig.DoubleValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Doubleֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDoubleOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDoubleOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToDecimal

        /// <summary>
        /// ���Ի�ȡDecimalֵ
        /// </summary>
        [Fact]
        public void TestToDecimal() {
            var result = _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimal();
            Assert.Equal( TestConfig.DecimalValue, result );
        }

        #endregion

        #region ToDecimalAsync

        /// <summary>
        /// ���Ի�ȡDecimalֵ
        /// </summary>
        [Fact]
        public async Task TestToDecimalAsync() {
            var result = await _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimalAsync();
            Assert.Equal( TestConfig.DecimalValue, result );
        }

        #endregion

        #region ToDecimalOrNull

        /// <summary>
        /// ���Ի�ȡDecimalֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDecimalOrNull_1() {
            var result = _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimalOrNull();
            Assert.Equal( TestConfig.DecimalValue, result );
        }

        /// <summary>
        /// ���Ի�ȡDecimalֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDecimalOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimalOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToDecimalOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿ�Decimalֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDecimalOrNullAsync_1() {
            var result = await _sqlQuery.Select( "Price" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimalOrNullAsync();
            Assert.Equal( TestConfig.DecimalValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�Decimalֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDecimalOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Products.Product" ).Where( "ProductId", TestConfig.Id ).ToDecimalOrNullAsync();
            Assert.Null( result );
        }

        #endregion

        #region ToDateTime

        /// <summary>
        /// ���Ի�ȡ����ֵ
        /// </summary>
        [Fact]
        public void TestToDateTime() {
            var result = _sqlQuery.Select( "Birthday" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTime();
            Assert.Equal( TestConfig.DateTimeValue, result );
        }

        #endregion

        #region ToDateTimeAsync

        /// <summary>
        /// ���Ի�ȡ����ֵ
        /// </summary>
        [Fact]
        public async Task TestToDateTimeAsync() {
            var result = await _sqlQuery.Select( "Birthday" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTimeAsync();
            Assert.Equal( TestConfig.DateTimeValue, result );
        }

        #endregion

        #region ToDateTimeOrNull

        /// <summary>
        /// ���Ի�ȡ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDateTimeOrNull_1() {
            var result = _sqlQuery.Select( "Birthday" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTimeOrNull();
            Assert.Equal( TestConfig.DateTimeValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public void TestToDateTimeOrNull_2() {
            var result = _sqlQuery.Select( "Code" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTimeOrNull();
            Assert.Null( result );
        }

        #endregion

        #region ToDateTimeOrNullAsync

        /// <summary>
        /// ���Ի�ȡ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDateTimeOrNullAsync_1() {
            var result = await _sqlQuery.Select( "Birthday" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTimeOrNullAsync();
            Assert.Equal( TestConfig.DateTimeValue, result );
        }

        /// <summary>
        /// ���Ի�ȡ�ɿ�����ֵ - ��ֵ
        /// </summary>
        [Fact]
        public async Task TestToDateTimeOrNullAsync_2() {
            var result = await _sqlQuery.Select( "Code" ).From( "Customers.Customer" ).Where( "CustomerId", 1 ).ToDateTimeOrNullAsync();
            Assert.Null( result );
        }

        #endregion
    }
}
