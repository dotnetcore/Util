using Util.Ui.Builders;

namespace Util.Ui.Zorro.Forms.Builders {
    /// <summary>
    /// NgZorro复选框生成器
    /// </summary>
    public class CheckBoxBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro复选框生成器
        /// </summary>
        public CheckBoxBuilder( ) : base( "label" ) {
            base.AddAttribute( "nz-checkbox" );
        }
    }
}
