using System;
using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Factories {
    /// <summary>
    /// 表格列选择框标签生成器工厂
    /// </summary>
    public class TableSelectBuilderFactory : ISelectBuilderFactory {
        /// <summary>
        /// 表格单元格标签生成器
        /// </summary>
        private readonly TableColumnBuilder _builder;

        /// <summary>
        /// 初始化表格列选择框标签生成器工厂
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        public TableSelectBuilderFactory( TableColumnBuilder builder ) {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// 创建表格列复选框标签生成器
        /// </summary>
        /// <param name="content">内容</param>
        public TagBuilder CreateCheckbox( IHtmlContent content ) {
            var result = new TableColumnBuilder( _builder.GetConfig(), _builder.GetTableColumnShareConfig() );
            result.AddCheckbox();
            return result;
        }

        /// <summary>
        /// 创建表格列单选框标签生成器
        /// </summary>
        /// <param name="content">内容</param>
        public TagBuilder CreateRadio( IHtmlContent content ) {
            var result = new TableColumnBuilder( _builder.GetConfig(), _builder.GetTableColumnShareConfig() );
            var radioBuilder = new TableColumnRadioBuilder( _builder.GetConfig(), _builder.GetTableColumnShareConfig().TableExtendId );
            result.AppendContent( radioBuilder );
            return result;
        }
    }
}
