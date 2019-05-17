using Util.Ui.Builders;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格复选框生成器
    /// </summary>
    public class MasterCheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格复选框生成器
        /// </summary>
        public MasterCheckBoxBuilder( ) : base( "label" ) {
            base.AddAttribute( "nz-checkbox" );
        }
    }
}
