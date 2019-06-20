using Util.Ui.Builders;
using Util.Ui.Configs;

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
        /// 是否包含栅格布局
        /// </summary>
        public bool HasGrid( IConfig config ) {
            if ( config.Contains( UiConst.Span ) )
                return true;
            return false;
        }

        /// <summary>
        /// 添加布局
        /// </summary>
        public void AddLayout( IConfig config ) {
            AddAttribute( "[nzSpan]", config.GetValue( UiConst.Span ) );
        }
    }
}
