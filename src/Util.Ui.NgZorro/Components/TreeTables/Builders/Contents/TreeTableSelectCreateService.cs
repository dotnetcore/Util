using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Containers.Builders;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Builders.Contents;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders.Contents {
    /// <summary>
    /// 树形表格列选择框创建服务
    /// </summary>
    public class TreeTableSelectCreateService : ISelectCreateService {
        /// <inheritdoc />
        public void CreateCheckbox( TableColumnBuilder builder, IHtmlContent content ) {
            var checkBoxBuilder = new TreeTableCheckBoxBuilder( builder.GetTableColumnShareConfig().TableExtendId );
            checkBoxBuilder.AppendContent( content );
            builder.AppendContent( checkBoxBuilder );
        }

        /// <inheritdoc />
        public void CreateRadio( TableColumnBuilder builder, IHtmlContent content ) {
            var config = builder.GetConfig();
            var shareConfig = builder.GetTableColumnShareConfig();
            var tableExtendId = shareConfig.TableExtendId;
            if ( shareConfig.IsCheckLeafOnly == false ) {
                builder.AppendContent( new TableColumnRadioBuilder( config, tableExtendId, content ) );
                return;
            }
            var radioBuilder = new TreeTableColumnRadioBuilder( config, tableExtendId, content );
            builder.AppendContent( radioBuilder );
            var containerBuilder = new ContainerBuilder( config );
            containerBuilder.NgIf( $"!{tableExtendId}.isShowRadio(row)" );
            containerBuilder.SetContent( content );
            builder.AppendContent( containerBuilder );
        }

        /// <summary>
        /// 是否将内容添加到选择框
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        public bool IsAddContentToSelect( TableColumnBuilder builder ) {
            var shareConfig = builder.GetTableColumnShareConfig();
            if ( shareConfig.IsShowCheckbox )
                return true;
            if ( shareConfig.IsShowRadio )
                return true;
            return false;
        }
    }
}
