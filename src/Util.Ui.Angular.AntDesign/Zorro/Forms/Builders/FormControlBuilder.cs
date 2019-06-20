using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Configs;
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
        /// 是否包含栅格布局
        /// </summary>
        public bool HasGrid( Config config ) {
            var shareConfig = GetShareConfig( config );
            if ( shareConfig?.ControlSpan.IsEmpty() == false )
                return true;
            if ( config.Contains( UiConst.Span ) )
                return true;
            return false;
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private GridShareConfig GetShareConfig( Config config ) {
            return config.Context?.GetValueFromItems<GridShareConfig>( GridShareConfig.Key );
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
