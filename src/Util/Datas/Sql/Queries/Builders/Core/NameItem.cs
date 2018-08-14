namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 名称项，处理名称中包含符号.
    /// </summary>
    public class NameItem {
        /// <summary>
        /// 初始化名称项
        /// </summary>
        /// <param name="name">名称</param>
        public NameItem( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            var list = name.Split( '.' );
            if( list.Length == 1 ) {
                Name = list[0];
                return;
            }
            if( list.Length == 2 ) {
                Prefix = list[0];
                Name = list[1];
            }
        }

        /// <summary>
        /// 前缀
        /// </summary>
        private string _prefix;
        /// <summary>
        /// 前缀
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
        /// 名称
        /// </summary>
        public string Name {
            get => _name.SafeString();
            set => _name = value;
        }
    }
}
