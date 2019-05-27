using System.Text;
using Util.Datas.Sql.Matedatas;
using Util.Helpers;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// Sql项
    /// </summary>
    public class SqlItem {
        /// <summary>
        /// 名称
        /// </summary>
        private string _name;
        /// <summary>
        /// 前缀
        /// </summary>
        private string _prefix;
        /// <summary>
        /// 别名
        /// </summary>
        private string _alias;

        /// <summary>
        /// 初始化Sql项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="prefix">前缀</param>
        /// <param name="alias">别名</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isSplit">是否用句点分割名称</param>
        public SqlItem( string name, string prefix = null, string alias = null, bool raw = false, bool isSplit = true ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            _prefix = prefix;
            _alias = alias;
            Raw = raw;
            if( raw ) {
                _name = name;
                return;
            }
            Resolve( name, isSplit );
        }

        /// <summary>
        /// 设置别名，返回前缀和名称
        /// </summary>
        private void Resolve( string name, bool isSplit ) {
            var pattern = @"\s+[aA][sS]\s+";
            var list = Regex.Split( name, pattern );
            if( list == null || list.Length == 0 )
                return;
            if( list.Length == 2 )
                _alias = list[1];
            if( isSplit ) {
                SplitName( list[0] );
                return;
            }
            _name = name;
        }

        /// <summary>
        /// 分割名称
        /// </summary>
        private void SplitName( string name ) {
            var result = new NameItem( name );
            if( string.IsNullOrWhiteSpace( result.Name ) == false )
                _name = result.Name;
            if( string.IsNullOrWhiteSpace( result.Prefix ) == false )
                _prefix = result.Prefix;
            if( string.IsNullOrWhiteSpace( result.DatabaseName ) == false )
                DatabaseName = result.DatabaseName;
        }

        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }

        /// <summary>
        /// 前缀，范例:t.a As b，值为 t
        /// </summary>
        public string Prefix => _prefix.SafeString();

        /// <summary>
        /// 名称，范例:t.a As b，值为 a
        /// </summary>
        public string Name => Raw ? _name : _name.SafeString();

        /// <summary>
        /// 别名，范例:t.a As b，值为 b
        /// </summary>
        public string Alias => _alias.SafeString();

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; private set; }

        /// <summary>
        /// 复制副本
        /// </summary>
        public SqlItem Clone() {
            return new SqlItem( Name, Prefix, Alias, Raw, false );
        }

        /// <summary>
        /// 获取Sql
        /// </summary>
        public string ToSql( IDialect dialect = null, ITableDatabase tableDatabase = null ) {
            if( string.IsNullOrWhiteSpace( Name ) )
                return null;
            if( Raw )
                return Name;
            return string.IsNullOrWhiteSpace( Alias ) ? GetColumn( dialect, tableDatabase ) : $"{GetColumn( dialect, tableDatabase )} As {GetSafeName( dialect, Alias )}";
        }

        /// <summary>
        /// 获取列
        /// </summary>
        private string GetColumn( IDialect dialect, ITableDatabase tableDatabase ) {
            var result = new StringBuilder();
            var database = DatabaseName;
            if ( string.IsNullOrWhiteSpace( DatabaseName ) && tableDatabase != null )
                database = tableDatabase.GetDatabase( GetName() );
            if( string.IsNullOrWhiteSpace( database ) == false )
                result.Append( $"{GetSafeName( dialect, database )}." );
            if( string.IsNullOrWhiteSpace( Prefix ) == false )
                result.Append( $"{GetSafeName( dialect, Prefix )}." );
            result.Append( GetSafeName( dialect, Name ) );
            return result.ToString();
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        private string GetName() {
            if ( string.IsNullOrWhiteSpace( Prefix ) )
                return Name;
            return $"{Prefix}.{Name}";
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        private string GetSafeName( IDialect dialect, string name ) {
            if( dialect == null )
                return name;
            return dialect.SafeName( name );
        }
    }
}
