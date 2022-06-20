using System;
using System.Collections.Generic;
using System.Linq;
using Util.Data.Sql;

namespace Util.Data.Metadata {
    /// <summary>
    /// MySql数据库元数据服务
    /// </summary>
    public class MySqlMetadataService : IMetadataService {
        /// <summary>
        /// Sql查询对象
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 初始化MySql数据库元数据服务
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public MySqlMetadataService( ISqlQuery sqlQuery ) {
            _sqlQuery = sqlQuery ?? throw new ArgumentNullException( nameof( sqlQuery ) );
        }

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        public DatabaseInfo GetDatabaseInfo() {
            var result = GetDatabase();
            result.Tables.AddRange( GetTables() );
            return result;
        }

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        private DatabaseInfo GetDatabase() {
            return _sqlQuery
                .AppendSelect( "Database() [Id],Database() [Name]" )
                .ToEntity<DatabaseInfo>();
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        private List<TableInfo> GetTables() {
            SetGetTablesSql();
            var dic = new Dictionary<string, TableInfo>();
            var tables = _sqlQuery.ToList<TableInfo, ColumnInfo, TableInfo>( ( table, column ) => {
                if( table == null || column == null )
                    return null;
                if( dic.ContainsKey( table.Id ) == false )
                    dic.Add( table.Id, table );
                TableInfo result = dic[table.Id];
                result.Columns.Add( column );
                return result;
            } ).Distinct().ToList();
            return tables;
        }

        /// <summary>
        /// 设置获取表信息Sql
        /// </summary>
        private void SetGetTablesSql() {
            _sqlQuery
                .Select( "t.Table_Name Id,t.Table_Name Name,t.Table_Comment Comment" )
                .Select( "c.Column_Name Id,c.Column_Name Name,c.Column_Comment Comment" )
                .Select( "c.Data_Type DataType,c.Numeric_Precision Precision,c.Numeric_Scale Scale" )
                .AppendSelect( ",( Case When c.Column_Key = 'PRI' Then 1 Else 0 End ) IsPrimaryKey" )
                .AppendSelect( ",( Case When c.Extra = 'auto_increment' Then 1 Else 0 End ) AS IsAutoIncrement" )
                .AppendSelect( ",( Case When c.Is_Nullable = 'NO' Then 0 Else 1 End ) AS IsNullable" )
                .AppendSelect( ",( Case When c.Column_Type = 'tinyint(1)' Then 1 " )
                .AppendSelect( "When c.Numeric_Precision Is Not Null Then c.Numeric_Precision " )
                .AppendSelect( "When c.Character_Maximum_Length Is Not Null Then c.Character_Maximum_Length Else Null End) Length" )
                .From( "Information_Schema.Tables t" )
                .Join( "Information_Schema.Columns c" ).On( "t.Table_Schema", "c.Table_Schema" ).On( "t.Table_Name", "c.Table_Name" )
                .AppendWhere( "[t].[Table_Schema] = Database()" );
        }
    }
}
