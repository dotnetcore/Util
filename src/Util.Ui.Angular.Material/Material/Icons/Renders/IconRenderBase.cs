using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Icons.Builders;

namespace Util.Ui.Material.Icons.Renders {
    /// <summary>
    /// 图标渲染器
    /// </summary>
    public class IconRenderBase : AngularRenderBase {
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
            if( IsMaterial() )
                return GetMaterialIconBuilder();
            return IsFontAwesome() ? GetFontAwesomeIconBuilder() : new EmptyTagBuilder();
        }

        /// <summary>
        /// 是否Material图标
        /// </summary>
        private bool IsMaterial() {
            return _config.Contains( UiConst.MaterialIcon ) || _config.Contains( AngularConst.BindMaterialIcon );
        }

        /// <summary>
        /// 创建MaterialIcon标签生成器
        /// </summary>
        private TagBuilder GetMaterialIconBuilder() {
            var builder = new MaterialIconBuilder();
            Config( builder );
            builder.SetIcon( _config );
            builder.SetBindIcon( _config );
            builder.SetSize( _config );
            return builder;
        }

        /// <summary>
        /// 是否FontAwesome图标
        /// </summary>
        private bool IsFontAwesome() {
            return _config.Contains( UiConst.FontAwesomeIcon ) || _config.Contains( AngularConst.BindFontAwesomeIcon );
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
            builder.SetBindIcon( _config );
            builder.SetSize( _config );
            return builder;
        }
    }
}