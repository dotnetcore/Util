using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 文本编辑列生成器
    /// </summary>
    public class TextEditColumnBuilder : EditColumnBuilderBase {
        /// <summary>
        /// 初始化文本编辑列生成器
        /// </summary>
        /// <param name="editTableId">编辑表格标识</param>
        /// <param name="templateId">模板标识</param>
        /// <param name="column">列名</param>
        /// <param name="trancateLength">截断保留长度</param>
        /// <param name="content">内容</param>
        /// <param name="isCreateDisplay">是否创建显示内容</param>
        /// <param name="isCreateControl">是否创建控件</param>
        public TextEditColumnBuilder( string editTableId, string templateId, string column, int? trancateLength,
            TagHelperContent content, bool? isCreateDisplay = true, bool? isCreateControl = true )
            : base( editTableId, templateId, column, content, isCreateDisplay, isCreateControl ) {
            TrancateLength = trancateLength;
        }

        /// <summary>
        /// 截断保留长度
        /// </summary>
        protected int? TrancateLength { get; }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected override void InitColumn( TagBuilder builder ) {
            TextColumnBuilder.InitColumn( builder,Column,TrancateLength );
        }
    }
}
