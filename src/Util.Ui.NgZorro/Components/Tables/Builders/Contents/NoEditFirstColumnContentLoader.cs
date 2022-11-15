using System;
using Microsoft.AspNetCore.Html;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 非编辑模式第一列内容加载器
    /// </summary>
    public class NoEditFirstColumnContentLoader : ITableColumnContentLoader {
        /// <summary>
        /// 表格列选择框创建服务
        /// </summary>
        private readonly ISelectCreateService _selectCreateService;

        /// <summary>
        /// 初始化非编辑模式第一列内容加载器
        /// </summary>
        /// <param name="service">表格列选择框创建服务</param>
        public NoEditFirstColumnContentLoader( ISelectCreateService service ) {
            _selectCreateService = service ?? throw new ArgumentNullException( nameof( service ) );
        }

        /// <inheritdoc />
        public virtual void Load( TableColumnBuilder builder, IHtmlContent displayContent ) {
            displayContent = GetDisplayContent( builder, displayContent );
            AddCheckbox( builder, displayContent );
            AddRadio( builder, displayContent );
            AddLineNumber( builder );
            if ( _selectCreateService.IsAddContentToSelect( builder ) )
                return;
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
            _selectCreateService.CreateCheckbox( builder, content );
        }

        /// <summary>
        /// 添加单选框
        /// </summary>
        protected virtual void AddRadio( TableColumnBuilder builder, IHtmlContent content ) {
            if ( builder.GetTableColumnShareConfig().IsShowCheckbox )
                return;
            if ( builder.GetTableColumnShareConfig().IsShowRadio == false )
                return;
            _selectCreateService.CreateRadio( builder, content );
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
