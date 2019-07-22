using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 日期列生成器
    /// </summary>
    public class DateColumnBuilder : ColumnBuilderBase {
        /// <summary>
        /// 初始化日期列生成器
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="format">日期格式</param>
        /// <param name="content">内容</param>
        public DateColumnBuilder( string column, string format, TagHelperContent content ) : base( column, content ) {
            Format = format;
        }

        /// <summary>
        /// 日期格式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected override void InitColumn() {
            if( Format.IsEmpty() )
                Format = "yyyy-MM-dd";
            base.AppendContent( $"{{{{ row.{Column} | date:\"{Format}\" }}}}" );
        }
    }
}
