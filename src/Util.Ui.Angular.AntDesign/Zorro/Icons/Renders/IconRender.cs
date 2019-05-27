using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Icons.Builders;

namespace Util.Ui.Zorro.Icons.Renders {
    /// <summary>
    /// 图标渲染器
    /// </summary>
    public class IconRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化图标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public IconRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var result = new IconBuilder();
            Config( result );
            return result;
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void Config( IconBuilder builder ) {
            ConfigId( builder );
            ConfigType( builder );
            ConfigTheme( builder );
            ConfigSpin( builder );
        }

        /// <summary>
        /// 配置图标类型
        /// </summary>
        private void ConfigType( IconBuilder builder ) {
            builder.AddType( _config.GetValue<AntDesignIcon?>( UiConst.Type )?.Description() );
            builder.AddBindType( _config.GetValue( AngularConst.BindType ) );
        }

        /// <summary>
        /// 配置图标主题
        /// </summary>
        private void ConfigTheme( TagBuilder builder ) {
            builder.AddAttribute( "nzTheme", _config.GetValue<AntDesignTheme?>( UiConst.Theme )?.Description() );
            builder.AddAttribute( "[nzTheme]", _config.GetValue( AngularConst.BindTheme ) );
        }

        /// <summary>
        /// 配置图标旋转
        /// </summary>
        private void ConfigSpin( TagBuilder builder ) {
            builder.AddAttribute( "[nzSpin]", _config.GetBoolValue( UiConst.Spin ) );
            builder.AddAttribute( "[nzRotate]", _config.GetValue( UiConst.Rotate ) );
        }
    }
}
