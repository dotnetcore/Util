using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 导航列表图标渲染器
    /// </summary>
    public class NavListIconRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化导航列表图标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public NavListIconRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            if( _config.Contains( UiConst.MaterialIcon ) )
                return GetMaterialIconBuilder();
            return _config.Contains( UiConst.FontAwesomeIcon ) ? GetFontAwesomeIconBuilder() : new EmptyTagBuilder();
        }

        /// <summary>
        /// 创建MaterialIcon标签生成器
        /// </summary>
        private TagBuilder GetMaterialIconBuilder() {
            var builder = new MaterialIconBuilder();
            Config( builder );
            builder.SetIcon( _config );
            builder.SetSize( _config );
            return builder;
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigPosition( builder );
        }

        /// <summary>
        /// 配置位置
        /// </summary>
        private void ConfigPosition( TagBuilder builder ) {
            if ( _config.GetValue<XPosition?>( UiConst.Position ) != XPosition.Right )
                builder.AddAttribute( "mat-list-icon" );
        }

        /// <summary>
        /// 创建FontAwesomeIcon标签生成器
        /// </summary>
        private TagBuilder GetFontAwesomeIconBuilder() {
            var builder = new FontAwesomeIconBuilder();
            Config( builder );
            builder.SetIcon( _config );
            builder.SetSize( _config );
            return builder;
        }
    }
}