using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格标题复选框生成器
    /// </summary>
    public class TreeTableMasterCheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格标题复选框生成器
        /// </summary>
        /// <param name="tableExtendId">表格扩展标识</param>
        /// <param name="title">标题</param>
        public TreeTableMasterCheckBoxBuilder( string tableExtendId, string title ) : base( "label" ) {
            base.Attribute( "nz-checkbox" );
            base.Attribute( "[nzIndeterminate]", $"{tableExtendId}.isMasterIndeterminate()" );
            base.Attribute( "[nzChecked]", $"{tableExtendId}.isMasterChecked()" );
            base.Attribute( "(nzCheckedChange)", $"{tableExtendId}.masterToggle()" );
            base.SetContent( $"{title}" );
        }
    }
}
