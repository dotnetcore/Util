using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Icons.Renders {
    /// <summary>
    /// 图标渲染器
    /// </summary>
    public class IconRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化图标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public IconRender( IConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            if ( _config.Contains( UiConst.FontAwesomeIcon ) )
                return GetItalicBuilder();
            return _config.Contains( UiConst.MaterialIcon ) ? GetIconBuilder() : new EmptyTagBuilder();
        }

        /// <summary>
        /// 获取i标签生成器
        /// </summary>
        private ITagBuilder GetItalicBuilder() {
            var builder = new ItalicBuilder();
            builder.Class( _config.GetValue<FontAwesomeIcon>( UiConst.FontAwesomeIcon ).GetIcon() );
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder) {
            builder.AddOtherAttributes( _config );
            builder.Id( _config );
            if( _config.Contains( UiConst.IconSize ) )
                builder.Class( _config.GetValue<IconSize>( UiConst.IconSize ).Description() );
            if( _config.GetValue<bool>( UiConst.Spin ) )
                builder.Class( "fa-spin" );
        }

        /// <summary>
        /// 获取mat-icon标签生成器
        /// </summary>
        private ITagBuilder GetIconBuilder() {
            var builder = new IconBuilder();
            builder.SetContent( _config.GetValue<MaterialIcon>( UiConst.MaterialIcon ).Description() );
            Config( builder );
            return builder;
        }
    }
}
