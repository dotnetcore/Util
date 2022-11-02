using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Avatars.Builders {
    /// <summary>
    /// 头像标签生成器
    /// </summary>
    public class AvatarBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化头像标签生成器
        /// </summary>
        public AvatarBuilder( Config config ) : base( config,"nz-avatar" ) {
            _config = config;
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        public AvatarBuilder Icon() {
            AttributeIfNotEmpty( "nzIcon", _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            AttributeIfNotEmpty( "[nzIcon]", _config.GetValue( AngularConst.BindIcon ) );
            return this;
        }

        /// <summary>
        /// 配置形状
        /// </summary>
        public AvatarBuilder Shape() {
            AttributeIfNotEmpty( "nzShape", _config.GetValue<AvatarShape?>( UiConst.Shape )?.Description() );
            AttributeIfNotEmpty( "[nzShape]", _config.GetValue( AngularConst.BindShape ) );
            return this;
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        public AvatarBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<AvatarSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置文本距离两侧间距
        /// </summary>
        public AvatarBuilder Gap() {
            AttributeIfNotEmpty( "nzGap", _config.GetValue( UiConst.Gap ) );
            AttributeIfNotEmpty( "[nzGap]", _config.GetValue( AngularConst.BindGap ) );
            return this;
        }

        /// <summary>
        /// 配置图片头像地址
        /// </summary>
        public AvatarBuilder Src() {
            AttributeIfNotEmpty( "nzSrc", _config.GetValue( UiConst.Src ) );
            AttributeIfNotEmpty( "[nzSrc]", _config.GetValue( AngularConst.BindSrc ) );
            return this;
        }

        /// <summary>
        /// 配置图片头像响应式资源地址
        /// </summary>
        public AvatarBuilder SrcSet() {
            AttributeIfNotEmpty( "nzSrcSet", _config.GetValue( UiConst.SrcSet ) );
            AttributeIfNotEmpty( "[nzSrcSet]", _config.GetValue( AngularConst.BindSrcSet ) );
            return this;
        }

        /// <summary>
        /// 配置图片无法显示时的替代文本
        /// </summary>
        public AvatarBuilder Alt() {
            AttributeIfNotEmpty( "nzAlt", _config.GetValue( UiConst.Alt ) );
            AttributeIfNotEmpty( "[nzAlt]", _config.GetValue( AngularConst.BindAlt ) );
            return this;
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        public AvatarBuilder Text() {
            AttributeIfNotEmpty( "nzText", _config.GetValue( UiConst.Text ) );
            AttributeIfNotEmpty( "[nzText]", _config.GetValue( AngularConst.BindText ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public AvatarBuilder Events() {
            AttributeIfNotEmpty( "(nzError)", _config.GetValue( UiConst.OnError ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Icon().Shape().Size().Gap().Src().SrcSet().Alt().Text().Events();
        }
    }
}