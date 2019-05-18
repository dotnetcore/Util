using Util.Ui.Builders;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格复选框生成器
    /// </summary>
    public class CheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格复选框生成器
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="column">列名</param>
        public CheckBoxBuilder( string id,string column  ) : base( "label" ) {
            base.AddAttribute( "nz-checkbox" );
            base.AddAttribute( "*ngIf", $"{id}.showCheckbox" );
            base.AddAttribute( "[nzIndeterminate]", $"{id}.isIndeterminate(row)" );
            base.AddAttribute( "[nzChecked]", $"{id}.isChecked(row)" );
            base.AddAttribute( "(nzCheckedChange)", $"{id}.toggle(row)" );
            base.SetContent( $"{{{{{column}}}}}" );
        }
    }
}
