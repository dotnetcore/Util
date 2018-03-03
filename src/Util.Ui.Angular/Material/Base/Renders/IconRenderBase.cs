using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Base.Renders {
    /// <summary>
    /// 图标渲染器
    /// </summary>
    public class IconRenderBase : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化图标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public IconRenderBase( IConfig config ) : base( config ) {
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
        protected virtual void Config( TagBuilder builder ) {
            ConfigId( builder );
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