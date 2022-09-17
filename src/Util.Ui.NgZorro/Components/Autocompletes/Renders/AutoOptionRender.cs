using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Autocompletes.Builders;

namespace Util.Ui.NgZorro.Components.Autocompletes.Renders {
    /// <summary>
    /// 自动完成项渲染器
    /// </summary>
    public class AutoOptionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AutoOptionRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AutoOptionBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() == false ) {
                _config.Content.AppendTo( builder );
                return;
            }
            var label = _config.GetValue( UiConst.Label );
            if ( string.IsNullOrWhiteSpace( label ) == false ) {
                builder.AppendContent( label );
                return;
            }
            var bindLabel = _config.GetValue( AngularConst.BindLabel );
            if ( string.IsNullOrWhiteSpace( bindLabel ) )
                return;
            builder.AppendContent( $"{{{{{bindLabel}}}}}" );
        }
    }
}