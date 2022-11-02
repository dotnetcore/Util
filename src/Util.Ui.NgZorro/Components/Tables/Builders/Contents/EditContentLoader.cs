using System;
using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 编辑模式非第一列内容加载器
    /// </summary>
    public class EditContentLoader : ITableColumnContentLoader {
        /// <inheritdoc />
        public void Load( TableColumnBuilder builder, IHtmlContent displayContent ) {
            if ( builder.GetConfig().Content.IsEmpty() )
                throw new InvalidOperationException( "编辑列内容未设置" );
            if ( builder.GetTableColumnShareConfig().IsAutoCreateControl == false ) {
                builder.SetContent( builder.GetConfig().Content );
                return;
            }
            var displayBuilder = CreateDisplayBuilder( builder );
            displayBuilder.SetContent( displayContent );
            var controlBuilder = CreateControlBuilder( builder );
            controlBuilder.SetContent( builder.GetConfig().Content );
        }

        /// <summary>
        /// 创建表格编辑列显示区域标签生成器
        /// </summary>
        private TagBuilder CreateDisplayBuilder( TableColumnBuilder builder ) {
            var result = new TableColumnDisplayBuilder( builder.GetConfig().CopyRemoveId() );
            result.Config();
            builder.AppendContent( result );
            return result;
        }

        /// <summary>
        /// 创建表格编辑列控件区域标签生成器
        /// </summary>
        private TableColumnControlBuilder CreateControlBuilder( TableColumnBuilder builder ) {
            var result = new TableColumnControlBuilder( builder.GetConfig().CopyRemoveId() );
            result.Config();
            builder.AppendContent( result );
            return result;
        }
    }
}
