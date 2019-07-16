using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 列生成器
    /// </summary>
    public abstract class ColumnBuilderBase : TagBuilder, IInit {
        /// <summary>
        /// 初始化列生成器
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="content">内容</param>
        protected ColumnBuilderBase( string column, TagHelperContent content ) : base( "td" ) {
            Column = column;
            Content = content;
        }

        /// <summary>
        /// 列名
        /// </summary>
        protected string Column { get; }

        /// <summary>
        /// 内容
        /// </summary>
        protected TagHelperContent Content { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            if( Content.IsEmpty() == false ) {
                base.AppendContent( Content );
                return;
            }
            if( Column.IsEmpty() )
                return;
            InitColumn();
        }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected abstract void InitColumn();
    }
}
