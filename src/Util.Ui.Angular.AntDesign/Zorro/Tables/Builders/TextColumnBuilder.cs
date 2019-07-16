using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 文本列生成器
    /// </summary>
    public class TextColumnBuilder : ColumnBuilderBase {
        /// <summary>
        /// 初始化文本列生成器
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="trancateLength">截断保留长度</param>
        /// <param name="content">内容</param>
        public TextColumnBuilder( string column, int? trancateLength, TagHelperContent content ) : base( column, content ) {
            TrancateLength = trancateLength;
        }

        /// <summary>
        /// 截断保留长度
        /// </summary>
        protected int? TrancateLength { get; }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected override void InitColumn() {
            InitColumn( this, Column, TrancateLength );
        }

        /// <summary>
        /// 初始化列
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="column">列名</param>
        /// <param name="trancateLength">截断保留长度</param>
        public static void InitColumn( TagBuilder builder, string column, int? trancateLength ) {
            if( trancateLength == null ) {
                builder.AppendContent( $"{{{{row.{column}}}}}" );
                return;
            }
            builder.AddAttribute( "nz-tooltip" );
            builder.AddAttribute( "[nzTitle]", $"(row.{column}|isTruncate:{trancateLength})?row.{column}:''" );
            builder.AppendContent( $"{{{{row.{column}|truncate:{trancateLength}}}}}" );
        }
    }
}
