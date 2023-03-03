using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Applications.Dtos;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Images.Builders {
    /// <summary>
    /// 图片标签生成器
    /// </summary>
    public class ImageBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化图片标签生成器
        /// </summary>
        public ImageBuilder( Config config ) : base( config,"img", TagRenderMode.SelfClosing ) {
            _config = config;
            base.Attribute( "nz-image" );
        }

        /// <summary>
        /// 配置图片地址
        /// </summary>
        public ImageBuilder Src() {
            AttributeIfNotEmpty( "nzSrc", _config.GetValue( UiConst.Src ) );
            AttributeIfNotEmpty( "[nzSrc]", _config.GetValue( AngularConst.BindSrc ) );
            return this;
        }

        /// <summary>
        /// 配置加载失败容错地址
        /// </summary>
        public ImageBuilder Fallback() {
            AttributeIfNotEmpty( "nzFallback", _config.GetValue( UiConst.Fallback ) );
            AttributeIfNotEmpty( "[nzFallback]", _config.GetValue( AngularConst.BindFallback ) );
            return this;
        }

        /// <summary>
        /// 配置加载失败容错地址
        /// </summary>
        public ImageBuilder Placeholder() {
            AttributeIfNotEmpty( "nzPlaceholder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[nzPlaceholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁止预览
        /// </summary>
        public ImageBuilder DisablePreview() {
            AttributeIfNotEmpty( "[nzDisablePreview]", _config.GetBoolValue( UiConst.DisablePreview ) );
            AttributeIfNotEmpty( "[nzDisablePreview]", _config.GetValue( AngularConst.BindDisablePreview ) );
            return this;
        }

        /// <summary>
        /// 配置导航时是否关闭预览
        /// </summary>
        public ImageBuilder CloseOnNavigation() {
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetBoolValue( UiConst.CloseOnNavigation ) );
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetValue( AngularConst.BindCloseOnNavigation ) );
            return this;
        }

        /// <summary>
        /// 配置文字方向
        /// </summary>
        public ImageBuilder Direction() {
            AttributeIfNotEmpty( "nzDirection", _config.GetValue<Direction?>( UiConst.Direction )?.Description() );
            AttributeIfNotEmpty( "[nzDirection]", _config.GetValue( AngularConst.BindDirection ) );
            return this;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        public ImageBuilder Width() {
            var width = GetValue( _config.GetValue( UiConst.Width ) );
            AttributeIfNotEmpty( "width", width );
            AttributeIfNotEmpty( "[width]", _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private string GetValue( string value ) {
            if ( string.IsNullOrWhiteSpace( value ) )
                return null;
            if( Util.Helpers.Validation.IsNumber( value ) )
                return $"{value}px";
            return value;
        }

        /// <summary>
        /// 配置高度
        /// </summary>
        public ImageBuilder Height() {
            var height = GetValue( _config.GetValue( UiConst.Height ));
            AttributeIfNotEmpty( "height", height );
            AttributeIfNotEmpty( "[height]", _config.GetValue( AngularConst.BindHeight ) );
            return this;
        }

        /// <summary>
        /// 配置文本描述
        /// </summary>
        public ImageBuilder Alt() {
            AttributeIfNotEmpty( "alt", _config.GetValue( UiConst.Alt ) );
            AttributeIfNotEmpty( "[alt]", _config.GetValue( AngularConst.BindAlt ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Src().Fallback().Placeholder().DisablePreview().CloseOnNavigation().Direction()
                .Width().Height().Alt();
        }
    }
}