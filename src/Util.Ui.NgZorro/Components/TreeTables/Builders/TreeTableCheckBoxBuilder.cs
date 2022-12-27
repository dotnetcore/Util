using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格复选框生成器
    /// </summary>
    public class TreeTableCheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格复选框生成器
        /// </summary>
        /// <param name="tableExtendId">表格扩展标识</param>
        public TreeTableCheckBoxBuilder( string tableExtendId  ) : base( "label" ) {
            base.Attribute( "nz-checkbox" );
            base.Attribute( "[nzIndeterminate]", $"{tableExtendId}.isIndeterminate(row)" );
            base.Attribute( "[nzChecked]", $"{tableExtendId}.isChecked(row)" );
            base.Attribute( "(nzCheckedChange)", $"{tableExtendId}.toggle(row)" );
        }
    }
}
