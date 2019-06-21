using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Grid.Helpers;

namespace Util.Ui.Zorro.Forms.Builders {
    /// <summary>
    /// NgZorro表单控件生成器
    /// </summary>
    public class FormControlBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro表单控件生成器
        /// </summary>
        public FormControlBuilder( ) : base( "nz-form-control" ) {
        }

        /// <summary>
        /// 添加布局
        /// </summary>
        public void AddLayout( Config config ) {
            var gridConfig = new FormControlGridConfig( this, config );
            gridConfig.Config();
        }
    }
}
