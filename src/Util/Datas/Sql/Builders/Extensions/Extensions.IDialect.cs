namespace Util.Datas.Sql.Builders.Extensions {
    /// <summary>
    /// Sql方言扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="columnAlias">列别名</param>
        public static string GetColumn( this IDialect source, string column, string columnAlias ) {
            if ( columnAlias.IsEmpty() )
                return column;
            return $"{column} {GetAs( source )}{columnAlias}";
        }

        /// <summary>
        /// 获取As关键字
        /// </summary>
        private static string GetAs( IDialect dialect ) {
            if ( dialect == null )
                return null;
            return dialect.SupportSelectAs() ? "As " : null;
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        public static string GetSafeName( this IDialect source, string name ) {
            if( source == null )
                return name;
            return source.SafeName( name );
        }
    }
}