using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Helpers;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// Sql项
    /// </summary>
    public class SqlItem {
        /// <summary>
        /// 初始化Sql项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="prefix">前缀</param>
        /// <param name="alias">别名</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isSplit">是否用句点分割名称</param>
        public SqlItem( string name, string prefix = null, string alias = null, bool raw = false,bool isSplit = true ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            Prefix = prefix;
            Alias = alias;
            Raw = raw;
            if( raw ) {
                Name = name;
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
                Alias = list[1];
            if ( isSplit ) {
                SplitName( list[0] );
                return;
            }
            Name = name;
        }

        /// <summary>
        /// 分割名称
        /// </summary>
        private void SplitName( string name ) {
            var result = new NameItem( name );
            if( string.IsNullOrWhiteSpace( result.Prefix ) == false )
                Prefix = result.Prefix;
            if( string.IsNullOrWhiteSpace( result.Name ) == false )
                Name = result.Name;
        }

        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }

        /// <summary>
        /// 前缀
        /// </summary>
        private string _prefix;
        /// <summary>
        /// 前缀，范例:t.a As b，值为 t
        /// </summary>
        public string Prefix {
            get => _prefix.SafeString();
            set => _prefix = value;
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string _name;
        /// <summary>
        /// 名称，范例:t.a As b，值为 a
        /// </summary>
        public string Name {
            get => Raw ? _name : _name.SafeString();
            set => _name = value;
        }

        /// <summary>
        /// 别名
        /// </summary>
        private string _alias;
        /// <summary>
        /// 别名，范例:t.a As b，值为 b
        /// </summary>
        public string Alias {
            get => _alias.SafeString();
            set => _alias = value;
        }

        /// <summary>
        /// 获取Sql
        /// </summary>
        public string ToSql( IDialect dialect = null ) {
            if( string.IsNullOrWhiteSpace( Name ) )
                return null;
            if( Raw )
                return Name;
            var column = string.IsNullOrWhiteSpace( Prefix ) ? GetSafeName( dialect, Name ) : $"{GetSafeName( dialect, Prefix )}.{GetSafeName( dialect, Name )}";
            return string.IsNullOrWhiteSpace( Alias ) ? column : $"{column} As {GetSafeName( dialect, Alias )}";
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
