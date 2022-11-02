using Util.Ui.Angular.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Label.Builders {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public class LabelBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public LabelBuilder( Config config ) : base( config, "span" ) {
            _config = config;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            if ( config.Content.IsEmpty() == false ) {
                config.Content.AppendTo( this );
                return;
            }
            ConfigValue();
        }

        /// <summary>
        /// 配置值
        /// </summary>
        private void ConfigValue() {
            var value = _config.GetValue( UiConst.Value );
            SetContent( value );
        }
    }
}
