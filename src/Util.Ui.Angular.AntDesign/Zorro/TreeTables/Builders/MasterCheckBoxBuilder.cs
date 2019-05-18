using Util.Ui.Builders;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格标题复选框生成器
    /// </summary>
    public class MasterCheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格标题复选框生成器
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="title">标题</param>
        public MasterCheckBoxBuilder( string id, string title ) : base( "label" ) {
            base.AddAttribute( "nz-checkbox" );
            base.AddAttribute( "*ngIf", $"{id}.showCheckbox" );
            base.AddAttribute( "[nzIndeterminate]", $"{id}.isMasterIndeterminate()" );
            base.AddAttribute( "[nzChecked]", $"{id}.isMasterChecked()" );
            base.AddAttribute( "(nzCheckedChange)", $"{id}.masterToggle()" );
            base.SetContent( $"{title}" );
        }
    }
}
