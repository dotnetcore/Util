using System;
using Microsoft.AspNetCore.Html;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Builders.Factories;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 非编辑模式第一列内容加载器
    /// </summary>
    public class NoEditFirstColumnContentLoader : ITableColumnContentLoader {
        /// <summary>
        /// 表格列选择框标签生成器工厂
        /// </summary>
        private readonly ISelectBuilderFactory _factory;

        /// <summary>
        /// 初始化非编辑模式第一列内容加载器
        /// </summary>
        /// <param name="factory">表格列选择框标签生成器工厂</param>
        public NoEditFirstColumnContentLoader( ISelectBuilderFactory factory ) {
            _factory = factory ?? throw new ArgumentNullException( nameof( factory ) );
        }

        /// <inheritdoc />
        public virtual void Load( TableColumnBuilder builder, IHtmlContent displayContent ) {
            displayContent = GetDisplayContent( builder, displayContent );
            AddCheckbox( builder, displayContent );
            AddRadio( builder, displayContent );
            AddLineNumber( builder );
            AddContent( builder, displayContent );
        }

        /// <summary>
        /// 获取显示内容
        /// </summary>
        protected virtual IHtmlContent GetDisplayContent( TableColumnBuilder builder, IHtmlContent htmlContent ) {
            var content = builder.GetConfig().Content;
            if ( content.IsEmpty() == false )
                return content;
            return htmlContent;
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        protected virtual void AddCheckbox( TableColumnBuilder builder, IHtmlContent content ) {
            if ( builder.GetTableColumnShareConfig().IsShowCheckbox == false )
                return;
            var checkboxBuilder = _factory.CreateCheckbox( content );
            builder.PreBuilder = checkboxBuilder;
        }

        /// <summary>
        /// 添加单选框
        /// </summary>
        protected virtual void AddRadio( TableColumnBuilder builder, IHtmlContent content ) {
            if ( builder.GetTableColumnShareConfig().IsShowCheckbox )
                return;
            if ( builder.GetTableColumnShareConfig().IsShowRadio == false )
                return;
            var radiobBuilder = _factory.CreateRadio( content );
            builder.PreBuilder = radiobBuilder;
        }

        /// <summary>
        /// 添加序号
        /// </summary>
        protected virtual void AddLineNumber( TableColumnBuilder builder ) {
            if ( builder.GetTableColumnShareConfig().IsShowLineNumber == false )
                return;
            var lineNumberBuilder = new TableColumnBuilder( builder.GetConfig(), builder.GetTableColumnShareConfig() );
            lineNumberBuilder.AddLineNumber();
            if ( builder.PreBuilder == null ) {
                builder.PreBuilder = lineNumberBuilder;
                return;
            }
            builder.PreBuilder.PostBuilder = lineNumberBuilder;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        protected virtual void AddContent( TableColumnBuilder builder, IHtmlContent content ) {
            builder.SetContent( content );
        }
    }
}
