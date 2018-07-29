using Util.Helpers;

namespace Util.Datas.Sql.Queries.Builders {
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
        public SqlItem( string name, string prefix = null, string alias = null ) {
            if ( string.IsNullOrWhiteSpace( name ) )
                return;
            Prefix = prefix;
            Alias = alias;
            Resolve( name );
        }

        /// <summary>
        /// 设置别名，返回前缀和名称
        /// </summary>
        private void Resolve( string name ) {
            var pattern = @"\s*[aA][sS]\s*";
            var list = Regex.Split( name, pattern );
            if( list == null || list.Length == 0 )
                return;
            if ( list.Length == 2 )
                Alias = list[1];
            SetName( list[0] );
        }

        /// <summary>
        /// 设置名称
        /// </summary>
        private void SetName( string name ) {
            if ( string.IsNullOrWhiteSpace( name ) )
                return;
            if ( name.Contains( "." ) == false ) {
                Name = name;
                return;
            }
            var list = name.Split( '.' );
            if( list.Length == 0 )
                return;
            if ( list.Length == 1 ) {
                Name = list[0];
                return;
            }
            if ( list.Length == 2 ) {
                Prefix = list[0];
                Name = list[1];
            }
        }

        /// <summary>
        /// 前缀
        /// </summary>
        private string _prefix;
        /// <summary>
        /// 前缀，范例:t.a As b，值为 t
        /// </summary>
        public string Prefix {
            get => _prefix.SafeString().Trim();
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
            get => _name.SafeString().Trim();
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
            get => _alias.SafeString().Trim();
            set => _alias = value;
        }
    }
}
