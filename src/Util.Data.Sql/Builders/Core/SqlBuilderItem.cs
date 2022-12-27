using System.Text;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// Sql生成器项 - 用于子查询
    /// </summary>
    public class SqlBuilderItem {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// Sql生成器实例
        /// </summary>
        private readonly ISqlBuilder _builder;
        /// <summary>
        /// 别名
        /// </summary>
        private readonly string _alias;

        /// <summary>
        /// 初始化Sql生成器列项
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="builder">Sql生成器实例</param>
        /// <param name="alias">别名</param>
        public SqlBuilderItem( IDialect dialect, ISqlBuilder builder, string alias = null ) {
            _dialect = dialect;
            _builder = builder;
            _alias = alias;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            builder.Append( "(" );
            _builder.AppendTo( builder );
            builder.Append( ")" );
            if ( _alias.IsEmpty() )
                return;
            builder.AppendFormat( " As {0}", _dialect.GetSafeName( _alias ) );
        }
    }
}
