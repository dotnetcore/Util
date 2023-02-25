using System.Linq;
using System.Threading.Tasks;
using Util.Data.Metadata;
using Xunit;

namespace Util.Data.Dapper.Tests.Metadata {
    /// <summary>
    /// MySql数据库元数据服务测试
    /// </summary>
    public class MySqlMetadataServiceTest {
        /// <summary>
        /// 数据库元信息服务
        /// </summary>
        private readonly IMetadataService _metadataService;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MySqlMetadataServiceTest( IMetadataService service ) {
            _metadataService = service;
        }

        /// <summary>
        /// 测试获取数据库名称
        /// </summary>
        [Fact]
        public async Task TestDatabaseName() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            Assert.Equal( "Util.Data.Dapper.Test", info.Name );
        }

        /// <summary>
        /// 测试获取表信息
        /// </summary>
        [Fact]
        public async Task TestTableInfo() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            Assert.Null( table.Schema );
            Assert.Equal( "产品", table.Comment );
        }

        /// <summary>
        /// 测试获取主键信息
        /// </summary>
        [Fact]
        public async Task TestPrimaryKey() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.First( t => t.Name == "OrderItem" );
            var pkColumn = table.Columns.FirstOrDefault( t => t.Name == "OrderItemId" );
            Assert.NotNull( pkColumn );
            Assert.True( pkColumn.IsPrimaryKey );
            var fkColumn = table.Columns.FirstOrDefault( t => t.Name == "OrderId" );
            Assert.NotNull( fkColumn );
            Assert.False( fkColumn.IsPrimaryKey );
        }

        /// <summary>
        /// 测试获取自增信息
        /// </summary>
        [Fact]
        public async Task TestAutoIncrement() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.FirstOrDefault( t => t.Name == "Customer" );
            Assert.NotNull( table );
            var column = table.Columns.FirstOrDefault( t => t.Name == "CustomerId" );
            Assert.NotNull( column );
            Assert.True( column.IsAutoIncrement );
            Assert.Equal( "int", column.DataType );
        }

        /// <summary>
        /// 测试获取数值精度信息
        /// </summary>
        [Fact]
        public async Task TestPrecision() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            var column = table.Columns.FirstOrDefault( t => t.Name == "Price" );
            Assert.NotNull( column );
            Assert.Equal( 12, column.Precision );
            Assert.Equal( 2, column.Scale );
        }

        /// <summary>
        /// 测试获取字符串列信息
        /// </summary>
        [Fact]
        public async Task TestStringInfo() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            var count = table.Columns.Count( t => t.Name == "Code" );
            Assert.Equal( 1, count );
            var column = table.Columns.FirstOrDefault( t => t.Name == "Code" );
            Assert.NotNull( column );
            Assert.Equal( "产品编码", column.Comment );
            Assert.False( column.IsPrimaryKey );
            Assert.True( column.IsNullable );
            Assert.Equal( "varchar", column.DataType );
            Assert.Equal( 50, column.Length );
        }

        /// <summary>
        /// 测试获取布尔列信息
        /// </summary>
        [Fact]
        public async Task TestBoolInfo() {
            var info = await _metadataService.GetDatabaseInfoAsync();
            var table = info.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            var column = table.Columns.FirstOrDefault( t => t.Name == "IsDeleted" );
            Assert.NotNull( column );
            Assert.Equal( "tinyint", column.DataType );
            Assert.Equal( 1, column.Length );
        }
    }
}
