using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spaces.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Spaces.Renders {
    /// <summary>
    /// 间距渲染器
    /// </summary>
    public class SpaceRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化间距渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SpaceRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SpaceBuilder();
            ConfigSize( builder );
            ConfigDirection( builder );
            ConfigAlign( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置间距大小
        /// </summary>
        private void ConfigSize( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzSize", _config.GetValue<SpaceSize?>( UiConst.Size )?.Description() );
            builder.AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        }

        /// <summary>
        /// 配置间距方向
        /// </summary>
        private void ConfigDirection( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzDirection", _config.GetValue<SpaceDirection?>( UiConst.Direction )?.Description() );
            builder.AttributeIfNotEmpty( "[nzDirection]", _config.GetValue( AngularConst.BindDirection ) );
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzAlign", _config.GetValue<SpaceAlign?>( UiConst.Align )?.Description() );
            builder.AttributeIfNotEmpty( "[nzAlign]", _config.GetValue( AngularConst.BindAlign ) );
        }
    }
}