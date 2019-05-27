using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Icons.Builders;

namespace Util.Ui.Material.Icons.Renders {
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
        /// 初始化生成器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected override void InitBuilder( TagBuilder builder ) {
            builder.AddOutputAttributes( _config );
            builder.Angular( _config );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            TagBuilder result = GetIconBuilder();
            if( result == TagBuilder.Null )
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
            if( _config.Contains( UiConst.ChildClass ) )
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
            if( IsFontAwesome() )
                result = GetFontAwesomeBuilder();
            if( IsMaterial() )
                result = GetMaterialIconBuilder();
            result.AddOutputAttributes( _config );
            result.Class( _config );
            return result;
        }

        /// <summary>
        /// 是否FontAwesome图标
        /// </summary>
        private bool IsFontAwesome() {
            return _config.Contains( UiConst.FontAwesomeIcon ) || _config.Contains( AngularConst.BindFontAwesomeIcon );
        }

        /// <summary>
        /// 获取Font Awesome图标标签生成器
        /// </summary>
        private FontAwesomeIconBuilder GetFontAwesomeBuilder( string key = "", string bindKey = "" ) {
            var builder = new FontAwesomeIconBuilder();
            builder.SetIcon( _config, key );
            builder.SetBindIcon( _config, bindKey );
            return builder;
        }

        /// <summary>
        /// 是否Material图标
        /// </summary>
        private bool IsMaterial() {
            return _config.Contains( UiConst.MaterialIcon ) || _config.Contains( AngularConst.BindMaterialIcon );
        }

        /// <summary>
        /// 获取Material图标标签生成器
        /// </summary>
        private MaterialIconBuilder GetMaterialIconBuilder() {
            var builder = new MaterialIconBuilder();
            builder.SetIcon( _config );
            builder.SetBindIcon( _config );
            return builder;
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            builder.Style( _config );
            ConfigId( builder );
            ConfigSize( builder );
            ConfigSpin( builder );
            ConfigRotate( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.Attribute( UiConst.Id, _config.GetValue( UiConst.Id ), true );
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
