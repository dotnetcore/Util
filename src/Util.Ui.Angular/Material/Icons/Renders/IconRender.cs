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
        public IconRender( IConfig config ) : base( config ){
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            TagBuilder result = GetIconBuilder();
            if ( result == TagBuilder.Null )
                return result;
            Config( result );
            return result;
        }

        /// <summary>
        /// 获取图标生成器
        /// </summary>
        private TagBuilder GetIconBuilder() {
            if( IsStackIcon() )
                return GetStackIconBuilder();
            return GetSingleIconBuilder();
        }

        /// <summary>
        /// 是否堆叠图标
        /// </summary>
        private bool IsStackIcon() {
            return _config.Contains( UiConst.Child );
        }

        /// <summary>
        /// 获取堆叠图标标签生成器
        /// </summary>
        private TagBuilder GetStackIconBuilder() {
            var result = new StackIconBuilder();
            var parentIcon = GetSingleIconBuilder().Class( "fa-stack-2x" );
            var childIcon = GetFontAwesomeBuilder( UiConst.Child ).Class( "fa-stack-1x" );
            if ( _config.Contains( UiConst.ChildClass ) )
                childIcon.Class( _config.GetValue( UiConst.ChildClass ) );
            result.AppendContent( parentIcon );
            result.AppendContent( childIcon );
            return result;
        }

        /// <summary>
        /// 获取单个图标生成器
        /// </summary>
        private TagBuilder GetSingleIconBuilder() {
            TagBuilder result = TagBuilder.Null;
            if( _config.Contains( UiConst.FontAwesomeIcon ) )
                result = GetFontAwesomeBuilder( UiConst.FontAwesomeIcon );
            if( _config.Contains( UiConst.MaterialIcon ) )
                result = GetMaterialIconBuilder();
            result.AddOutputAttributes( _config );
            result.Class( _config );
            return result;
        }

        /// <summary>
        /// 获取Font Awesome图标标签生成器
        /// </summary>
        private FontAwesomeIconBuilder GetFontAwesomeBuilder( string key ) {
            var builder = new FontAwesomeIconBuilder();
            builder.SetIcon( _config, key );
            return builder;
        }

        /// <summary>
        /// 获取Material图标标签生成器
        /// </summary>
        private MaterialIconBuilder GetMaterialIconBuilder() {
            var builder = new MaterialIconBuilder();
            builder.SetIcon( _config );
            return builder;
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            builder.Id( _config );
            ConfigSize( builder );
            ConfigSpin( builder );
            ConfigRotate( builder );
        }

        /// <summary>
        /// 配置图标大小
        /// </summary>
        private void ConfigSize( TagBuilder builder ) {
            if( _config.Contains( UiConst.Size ) )
                builder.Class( _config.GetValue<IconSize>( UiConst.Size ).Description() );
        }

        /// <summary>
        /// 配置图标旋转
        /// </summary>
        private void ConfigSpin( TagBuilder builder ) {
            if( _config.GetValue<bool>( UiConst.Spin ) )
                builder.Class( "fa-spin" );
        }

        /// <summary>
        /// 配置图标旋转
        /// </summary>
        private void ConfigRotate( TagBuilder builder ) {
            if( _config.Contains( UiConst.Rotate ) )
                builder.Class( _config.GetValue<RotateType>( UiConst.Rotate ).Description() );
        }
    }
}
