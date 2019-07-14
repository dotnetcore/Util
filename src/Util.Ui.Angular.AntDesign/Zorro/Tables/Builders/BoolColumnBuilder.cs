using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Properties;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 布尔列生成器
    /// </summary>
    public class BoolColumnBuilder : ColumnBuilderBase {
        /// <summary>
        /// 初始化布尔列生成器
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="content">内容</param>
        public BoolColumnBuilder( string column, TagHelperContent content ) : base( column, content ) {
        }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected override void InitColumn() {
            AppendContent( $"{{{{row.{Column}?'{R.Yes}':'{R.No}'}}}}" );
        }
    }
}
