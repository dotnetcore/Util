using Util.Ui.Builders;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 复选框列生成器
    /// </summary>
    public class CheckboxColumnBuilder : TagBuilder {
        /// <summary>
        /// 初始化复选框列生成器
        /// </summary>
        public CheckboxColumnBuilder( string tableId ) : base( "td" ) {
            base.AddAttribute( "[nzShowCheckbox]", $"{tableId}_wrapper.multiple" );
            base.AddAttribute( "(click)", "$event.stopPropagation()" );
            base.AddAttribute( "(nzCheckedChange)", $"{tableId}_wrapper.checkedSelection.toggle(row)" );
            base.AddAttribute( "[nzChecked]", $"{tableId}_wrapper.checkedSelection.isSelected(row)" );
            base.AppendContent( new RadioBuilder( tableId ) );
        }
    }
}
