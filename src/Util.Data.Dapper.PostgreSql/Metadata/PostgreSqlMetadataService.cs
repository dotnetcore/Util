using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data.Sql;

namespace Util.Data.Metadata {
    /// <summary>
    /// PostgreSql数据库元数据服务
    /// </summary>
    public class PostgreSqlMetadataService : IMetadataService {
        /// <summary>
        /// Sql查询对象
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 初始化PostgreSql数据库元数据服务
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public PostgreSqlMetadataService( ISqlQuery sqlQuery ) {
            _sqlQuery = sqlQuery ?? throw new ArgumentNullException( nameof( sqlQuery ) );
        }

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        public async Task<DatabaseInfo> GetDatabaseInfoAsync() {
            var result = await GetDatabase();
            var tables = await GetTables();
            result.Tables.AddRange( tables );
            return result;
        }

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        private async Task<DatabaseInfo> GetDatabase() {
            return await _sqlQuery
                .Select( "oid Id,datname Name" )
                .From( "pg_database" )
                .AppendWhere( "datname=current_database()" )
                .ToEntityAsync<DatabaseInfo>();
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        private async Task<List<TableInfo>> GetTables() {
            SetGetTablesSql();
            var dic = new Dictionary<string, TableInfo>();
            var tables = ( await _sqlQuery.ToListAsync<TableInfo, ColumnInfo, TableInfo>( ( table, column ) => {
                if ( table == null || column == null )
                    return null;
                if ( dic.ContainsKey( table.Id ) == false )
                    dic.Add( table.Id, table );
                TableInfo result = dic[table.Id];
                result.Columns.Add( column );
                return result;
            } ) ).Distinct().ToList();
            return tables;
        }

        /// <summary>
        /// 设置获取表信息Sql
        /// </summary>
        private void SetGetTablesSql() {
            _sqlQuery
                .Select( "c1.oid Id,t.tablename Name,t.schemaname Schema" )
                .AppendSelect( ",obj_description(c1.oid) [Comment]" )
                .Select( "c.*" )
                .From( "pg_tables t" )
                .Join( "pg_class c1" ).On( "t.tablename", "c1.relname" )
                .Join( GetColumnsSql(), "c" ).On( "c.table_id", "c1.oid" )
                .In( "t.schemaname", t => t
                    .Select( "schema_name" )
                    .From( "information_schema.schemata" )
                    .AppendWhere( "catalog_name=current_database()" )
                    .AppendWhere( "schema_name != 'information_schema'" )
                    .AppendWhere( "schema_name not like 'pg_%'" )
                );
        }

        /// <summary>
        /// 获取列信息子查询
        /// </summary>
        private ISqlBuilder GetColumnsSql() {
            return _sqlQuery.NewSqlBuilder()
                .Select( "a.attrelid table_id,a.attname Id,a.attname Name,col.udt_name DataType" )
                .Select( "col.numeric_precision Precision,col.numeric_scale Scale" )
                .AppendSelect( ",Coalesce(col.character_maximum_length, col.numeric_precision, -1) [Length]" )
                .AppendSelect( ",( Case a.attnotnull When 't' Then 0 Else 1 End ) [IsNullable]" )
                .AppendSelect( ",( Case a.attnum When con.conkey[[1]] Then 1 Else 0 End ) [IsPrimaryKey]" )
                .AppendSelect( ",( Case When col.is_identity='YES' Then 1 Else 0 End ) [IsAutoIncrement]" )
                .AppendSelect( ",col_description( a.attrelid, a.attnum ) [Comment]" )
                .From( "pg_attribute a" )
                .Join( "pg_class c2" ).On( "a.attrelid", "c2.oid" )
                .Join( "pg_constraint con" ).On( "con.conrelid", "c2.oid" ).AppendOn( "con.contype = 'p'" )
                .Join( "pg_namespace n" ).On( "n.oid", "c2.relnamespace" )
                .Join( "information_schema.columns col" ).On( "col.table_schema", "n.nspname" ).On( "col.table_name", "c2.relname" ).On( "col.column_name", "a.attname" );
        }
    }
}
