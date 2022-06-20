using System.Linq;
using Util.Data.Metadata;
using Xunit;

namespace Util.Data.Dapper.Tests.Metadata {
    /// <summary>
    /// Sql Server数据库元数据服务测试
    /// </summary>
    public class SqlServerMetadataServiceTest {
        /// <summary>
        /// 数据库元信息
        /// </summary>
        private readonly DatabaseInfo _databaseInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        public SqlServerMetadataServiceTest( IMetadataService service ) {
            _databaseInfo = service.GetDatabaseInfo();
        }

        /// <summary>
        /// 测试获取数据库名称
        /// </summary>
        [Fact]
        public void TestDatabaseName() {
            Assert.Equal( "Util.Data.Dapper.Test", _databaseInfo.Name );
        }

        /// <summary>
        /// 测试获取表信息
        /// </summary>
        [Fact]
        public void TestTableInfo() {
            var table = _databaseInfo.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            Assert.Equal( "Products", table.Schema );
            Assert.Equal( "产品", table.Comment );
        }

        /// <summary>
        /// 测试获取主键信息
        /// </summary>
        [Fact]
        public void TestPrimaryKey() {
            var table = _databaseInfo.Tables.First( t => t.Name == "OrderItem" );
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
        public void TestAutoIncrement() {
            var table = _databaseInfo.Tables.FirstOrDefault( t => t.Name == "Customer" );
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
        public void TestPrecision() {
            var table = _databaseInfo.Tables.FirstOrDefault( t => t.Name == "Product" );
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
        public void TestStringInfo() {
            var table = _databaseInfo.Tables.FirstOrDefault( t => t.Name == "Product" );
            Assert.NotNull( table );
            var count = table.Columns.Count( t => t.Name == "Code" );
            Assert.Equal( 1, count );
            var column = table.Columns.FirstOrDefault( t => t.Name == "Code" );
            Assert.NotNull( column );
            Assert.Equal( "产品编码", column.Comment );
            Assert.False( column.IsPrimaryKey );
            Assert.True( column.IsNullable );
            Assert.Equal( "nvarchar", column.DataType );
            Assert.Equal( 100, column.Length );
        }
    }
}
