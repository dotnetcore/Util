using System.Text;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 列项
    /// </summary>
    public class ColumnItem {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;

        /// <summary>
        /// 初始化列项
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="name">列名</param>
        public ColumnItem( IDialect dialect, string name ) {
            _dialect = dialect;
            Resolve( name );
        }

        /// <summary>
        /// 解析
        /// </summary>
        private void Resolve( string name ) {
            var item = new NameItem( name );
            TableAlias = item.Prefix;
            Name = item.Name;
            ColumnAlias = item.Alias;
        }

        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAlias { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 列别名
        /// </summary>
        public string ColumnAlias { get; set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        public string ToResult() {
            var builder = new StringBuilder();
            AppendTo( builder );
            return builder.ToString();
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            AppendTableAlias( builder );
            AppendColumn( builder );
            AppendColumnAlias( builder );
        }

        /// <summary>
        /// 添加表别名
        /// </summary>
        private void AppendTableAlias( StringBuilder builder ) {
            if ( TableAlias.IsEmpty() )
                return;
            builder.AppendFormat( "{0}.", _dialect.GetSafeName( TableAlias ) );
        }

        /// <summary>
        /// 添加列名
        /// </summary>
        private void AppendColumn( StringBuilder builder ) {
            if( Name.IsEmpty() )
                return;
            builder.AppendFormat( _dialect.GetSafeName( Name ) );
        }

        /// <summary>
        /// 添加列别名
        /// </summary>
        private void AppendColumnAlias( StringBuilder builder ) {
            if( ColumnAlias.IsEmpty() )
                return;
            builder.AppendFormat( " As {0}", _dialect.GetSafeName( ColumnAlias ) );
        }
    }
}
