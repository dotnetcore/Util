using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data.Sql;

namespace Util.Data.Metadata {
    /// <summary>
    /// Sql Server数据库元数据服务
    /// </summary>
    public class SqlServerMetadataService : IMetadataService {
        /// <summary>
        /// Sql查询对象
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 初始化Sql Server数据库元数据服务
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public SqlServerMetadataService( ISqlQuery sqlQuery ) {
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
                .Select( "Dbid Id,Name" )
                .From( "sys.SysDataBases" )
                .Where( "DbId", t => t.Select( "Dbid" ).From( "sys.SysProcesses" ).AppendWhere( "Spid = @@spid" ) )
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
                .Select( "o.object_id Id,o.name,s.name Schema,ep.value Comment" )
                .Select( "c.Id,c.name,c.Comment" )
                .AppendSelect( ",(Case When Exists(" )
                .AppendSelect( GetIsPrimaryKeySql() )
                .AppendSelect( ") Then Cast(1 As Bit) Else Cast(0 As Bit) End) As IsPrimaryKey" )
                .Select( "c.is_identity IsAutoIncrement,c.is_nullable IsNullable" )
                .Select( "c.DataType,c.max_length Length,c.precision,c.scale" )
                .From( "sys.Objects o" )
                .LeftJoin( "sys.Schemas s" ).On( "o.schema_id", "s.schema_id" )
                .LeftJoin( "sys.Extended_Properties ep" ).On( "o.object_id", "ep.major_id" ).On( "ep.minor_id", 0 )
                .Join( GetColumnsSql(), "c" ).On( "c.object_id", "o.object_id" )
                .In( "o.type", new[] { 'U', 'V' } );
        }

        /// <summary>
        /// 获取是否主键子查询
        /// </summary>
        private ISqlBuilder GetIsPrimaryKeySql() {
            return _sqlQuery.NewSqlBuilder()
                .Select()
                .From( "Information_Schema.Key_Column_Usage k" )
                .Join( "Information_Schema.Table_Constraints tc" )
                .On( "k.table_name", "tc.table_name" )
                .On( "k.Constraint_Name", "tc.Constraint_Name" )
                .AppendOn( "tc.Constraint_Type='PRIMARY KEY'" )
                .AppendWhere( "o.name=k.table_name" )
                .AppendWhere( "c.name=k.column_name" );
        }

        /// <summary>
        /// 获取列信息子查询
        /// </summary>
        private ISqlBuilder GetColumnsSql() {
            return _sqlQuery.NewSqlBuilder()
                .Select( "c.object_id,c.column_id Id,c.name,ep.value Comment" )
                .Select( "c.is_identity,c.is_nullable,t.name DataType,c.max_length" )
                .Select( "c.precision,c.scale" )
                .From( "sys.Columns c" )
                .LeftJoin( "sys.Extended_Properties ep" ).On( "c.object_id", "ep.major_id" ).On( "c.column_id", "ep.minor_id" )
                .LeftJoin( "sys.Types t" ).On( "c.system_type_id", "t.system_type_id" )
                .AppendWhere( "t.name!='sysname'" );
        }
    }
}
