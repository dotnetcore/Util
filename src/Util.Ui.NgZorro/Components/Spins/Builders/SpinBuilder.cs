using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Spins.Builders {
    /// <summary>
    /// 加载中标签生成器
    /// </summary>
    public class SpinBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化加载中标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SpinBuilder( Config config ) : base( config,"nz-spin" ) {
            _config = config;
        }

        /// <summary>
        /// 配置延迟显示时间
        /// </summary>
        public SpinBuilder Delay() {
            AttributeIfNotEmpty( "nzDelay", _config.GetValue( UiConst.Delay ) );
            AttributeIfNotEmpty( "[nzDelay]", _config.GetValue( AngularConst.BindDelay ) );
            return this;
        }

        /// <summary>
        /// 配置加载指示符
        /// </summary>
        public SpinBuilder Indicator() {
            AttributeIfNotEmpty( "[nzIndicator]", _config.GetValue( UiConst.Indicator ) );
            return this;
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        public SpinBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<SpinSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置是否旋转
        /// </summary>
        public SpinBuilder Spinning() {
            AttributeIfNotEmpty( "[nzSpinning]", _config.GetBoolValue( UiConst.Spinning ) );
            AttributeIfNotEmpty( "[nzSpinning]", _config.GetValue( AngularConst.BindSpinning ) );
            return this;
        }

        /// <summary>
        /// 配置是否简单模式
        /// </summary>
        public SpinBuilder Simple() {
            AttributeIf( "nzSimple", _config.GetValue<bool?>( UiConst.Simple ) == true );
            AttributeIfNotEmpty( "[nzSimple]", _config.GetValue( AngularConst.BindSimple ) );
            return this;
        }

        /// <summary>
        /// 配置提示文字
        /// </summary>
        public SpinBuilder Tip() {
            AttributeIfNotEmpty( "nzTip", _config.GetValue( UiConst.Tip ) );
            AttributeIfNotEmpty( "[nzTip]", _config.GetValue( AngularConst.BindTip ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Delay().Indicator().Size().Spinning().Simple().Tip();
        }
    }
}