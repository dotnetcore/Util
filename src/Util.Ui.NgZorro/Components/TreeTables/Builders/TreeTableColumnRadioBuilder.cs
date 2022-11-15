using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表格单元格单选框标签生成器
    /// </summary>
    public class TreeTableColumnRadioBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化树形表格单元格单选框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tableExtendId">表格扩展标识</param>
        /// <param name="content">内容</param>
        public TreeTableColumnRadioBuilder( Config config,string tableExtendId, IHtmlContent content = null ) : base( config, "label" ) {
            base.Attribute( "nz-radio" );
            base.Attribute( "(click)", "$event.stopPropagation()" );
            this.NgIf( $"{tableExtendId}.isShowRadio(row)" );
            base.Attribute( "name", $"r_{tableExtendId}" );
            base.Attribute( "[ngModel]", $"{tableExtendId}.isChecked(row)" );
            base.Attribute( "(ngModelChange)", $"{tableExtendId}.checkRowOnly(row)" );
            if ( content == null )
                return;
            base.SetContent( content );
        }
    }
}