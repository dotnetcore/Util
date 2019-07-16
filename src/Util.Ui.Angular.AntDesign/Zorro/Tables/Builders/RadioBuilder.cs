using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 表格单选框生成器
    /// </summary>
    public class RadioBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格单选框生成器
        /// </summary>
        public RadioBuilder( string tableId ) : base( "label" ) {
            base.AddAttribute( "name", $"radio_{tableId}" );
            base.AddAttribute( "nz-radio" );
            this.NgIf( $"!{tableId}_wrapper.multiple" );
            base.AddAttribute( "(click)", "$event.stopPropagation()" );
            base.AddAttribute( "[ngModel]", $"{tableId}_wrapper.checkedSelection.isSelected(row)" );
            base.AddAttribute( "(ngModelChange)", $"{tableId}_wrapper.checkRowOnly(row)" );
        }
    }
}
