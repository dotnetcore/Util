using System.Threading.Tasks;
using Util.Data.Metadata;

namespace Util.Generators.Tests.Mocks {
    /// <summary>
    /// 模拟数据库元数据服务
    /// </summary>
    public class MockMetadataService : IMetadataService {
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        public Task<DatabaseInfo> GetDatabaseInfoAsync() {
            var result = new DatabaseInfo();
            TableInfo table = new TableInfo {
                Schema = "TestSchema", 
                Name = "TestName", 
                Comment = "TestComment"
            };
            result.Tables.Add( table );

            var column = new ColumnInfo {
                Name = "TestColumn",
                Comment = "TestComment",
                DataType = "nvarchar",
                Length = 200
            };
            table.Columns.Add( column );

            var column2 = new ColumnInfo {
                Name = "TestColumn2",
                Comment = "TestComment2",
                IsPrimaryKey = true,
                DataType = "varchar",
                IsAutoIncrement = true
            };
            table.Columns.Add( column2 );

            TableInfo table2 = new TableInfo {
                Schema = "TestSchema2", 
                Name = "TestName2", 
                Comment = "TestComment2"
            };
            result.Tables.Add( table2 );

            var column3 = new ColumnInfo {
                Name = "TestColumn3",
                Comment = "TestComment3",
                DataType = "decimal",
                Precision = 5,
                Scale = 2
            };
            table2.Columns.Add( column3 );

            var column4 = new ColumnInfo {
                Name = "TestColumn4",
                Comment = "TestComment4",
                IsNullable = false
            };
            table2.Columns.Add( column4 );

            return Task.FromResult( result );
        }
    }

    /// <summary>
    /// 模拟数据库元数据服务
    /// </summary>
    public class MockMetadataService2 : IMetadataService {
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        public Task<DatabaseInfo> GetDatabaseInfoAsync() {
            var result = new DatabaseInfo();
            TableInfo table = new TableInfo {
                Schema = "TestSchema3", 
                Name = "TestName3", 
                Comment = "TestComment3"
            };
            result.Tables.Add( table );

            TableInfo table2 = new TableInfo {
                Schema = "TestSchema4", 
                Name = "TestName4", 
                Comment = "TestComment4"
            };
            result.Tables.Add( table2 );
            return Task.FromResult( result );
        }
    }
}
