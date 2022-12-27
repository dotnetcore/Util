using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Buttons.Builders {
    /// <summary>
    /// nz-button-group标签生成器
    /// </summary>
    public class ButtonGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化nz-button-group标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonGroupBuilder( Config config ) : base( config,"nz-button-group" ) {
            _config = config;
        }

        /// <summary>
        /// 配置按钮组尺寸
        /// </summary>
        public ButtonGroupBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<ButtonSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Size();
        }
    }
}
