using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Drawers.Builders {
    /// <summary>
    /// 抽屉标签生成器
    /// </summary>
    public class DrawerBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化抽屉标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public DrawerBuilder( Config config ) : base( config,"nz-drawer" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否可关闭
        /// </summary>
        public DrawerBuilder Closable() {
            AttributeIfNotEmpty( "[nzClosable]", _config.GetBoolValue( UiConst.Closable ) );
            AttributeIfNotEmpty( "[nzClosable]", _config.GetValue( AngularConst.BindClosable ) );
            return this;
        }

        /// <summary>
        /// 配置关闭图标
        /// </summary>
        public DrawerBuilder CloseIcon() {
            AttributeIfNotEmpty( "nzCloseIcon", _config.GetValue<AntDesignIcon?>( UiConst.CloseIcon )?.Description() );
            AttributeIfNotEmpty( "[nzCloseIcon]", _config.GetValue( AngularConst.BindCloseIcon ) );
            return this;
        }

        /// <summary>
        /// 配置点击遮罩是否允许关闭
        /// </summary>
        public DrawerBuilder MaskClosable() {
            AttributeIfNotEmpty( "[nzMaskClosable]", _config.GetBoolValue( UiConst.MaskClosable ) );
            AttributeIfNotEmpty( "[nzMaskClosable]", _config.GetValue( AngularConst.BindMaskClosable ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示遮罩
        /// </summary>
        public DrawerBuilder Mask() {
            AttributeIfNotEmpty( "[nzMask]", _config.GetBoolValue( UiConst.Mask ) );
            AttributeIfNotEmpty( "[nzMask]", _config.GetValue( AngularConst.BindMask ) );
            return this;
        }

        /// <summary>
        /// 配置导航时是否关闭
        /// </summary>
        public DrawerBuilder CloseOnNavigation() {
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetBoolValue( UiConst.CloseOnNavigation ) );
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetValue( AngularConst.BindCloseOnNavigation ) );
            return this;
        }

        /// <summary>
        /// 配置遮罩样式
        /// </summary>
        public DrawerBuilder MaskStyle() {
            AttributeIfNotEmpty( "[nzMaskStyle]", _config.GetValue( UiConst.MaskStyle ) );
            return this;
        }

        /// <summary>
        /// 配置是否支持键盘ESC键关闭
        /// </summary>
        public DrawerBuilder Keyboard() {
            AttributeIfNotEmpty( "[nzKeyboard]", _config.GetBoolValue( UiConst.Keyboard ) );
            AttributeIfNotEmpty( "[nzKeyboard]", _config.GetValue( AngularConst.BindKeyboard ) );
            return this;
        }

        /// <summary>
        /// 配置主体样式
        /// </summary>
        public DrawerBuilder BodyStyle() {
            AttributeIfNotEmpty( "[nzBodyStyle]", _config.GetValue( UiConst.BodyStyle ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public DrawerBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置页脚
        /// </summary>
        public DrawerBuilder Footer() {
            AttributeIfNotEmpty( "nzFooter", _config.GetValue( UiConst.Footer ) );
            AttributeIfNotEmpty( "[nzFooter]", _config.GetValue( AngularConst.BindFooter ) );
            return this;
        }

        /// <summary>
        /// 配置是否可见
        /// </summary>
        public DrawerBuilder Visible() {
            AttributeIfNotEmpty( "[nzVisible]", _config.GetBoolValue( UiConst.Visible ) );
            AttributeIfNotEmpty( "[nzVisible]", _config.GetValue( AngularConst.BindVisible ) );
            AttributeIfNotEmpty( "[(nzVisible)]", _config.GetValue( AngularConst.BindonVisible ) );
            return this;
        }

        /// <summary>
        /// 配置抽屉方向
        /// </summary>
        public DrawerBuilder Placement() {
            AttributeIfNotEmpty( "nzPlacement", _config.GetValue<DrawerPlacement?>( UiConst.Placement )?.Description() );
            AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindPlacement ) );
            return this;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        public DrawerBuilder Width() {
            AttributeIfNotEmpty( "nzWidth", _config.GetValue( UiConst.Width ) );
            AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 配置高度
        /// </summary>
        public DrawerBuilder Height() {
            AttributeIfNotEmpty( "nzHeight", _config.GetValue( UiConst.Height ) );
            AttributeIfNotEmpty( "[nzHeight]", _config.GetValue( AngularConst.BindHeight ) );
            return this;
        }

        /// <summary>
        /// 配置X坐标偏移量
        /// </summary>
        public DrawerBuilder OffsetX() {
            AttributeIfNotEmpty( "nzOffsetX", _config.GetValue( UiConst.OffsetX ) );
            AttributeIfNotEmpty( "[nzOffsetX]", _config.GetValue( AngularConst.BindOffsetX ) );
            return this;
        }

        /// <summary>
        /// 配置Y坐标偏移量
        /// </summary>
        public DrawerBuilder OffsetY() {
            AttributeIfNotEmpty( "nzOffsetY", _config.GetValue( UiConst.OffsetY ) );
            AttributeIfNotEmpty( "[nzOffsetY]", _config.GetValue( AngularConst.BindOffsetY ) );
            return this;
        }

        /// <summary>
        /// 配置对话框外层容器样式类名
        /// </summary>
        public DrawerBuilder WrapClassName() {
            AttributeIfNotEmpty( "nzWrapClassName", _config.GetValue( UiConst.WrapClassName ) );
            AttributeIfNotEmpty( "[nzWrapClassName]", _config.GetValue( AngularConst.BindWrapClassName ) );
            return this;
        }

        /// <summary>
        /// 配置z-index
        /// </summary>
        public DrawerBuilder ZIndex() {
            AttributeIfNotEmpty( "nzZIndex", _config.GetValue( UiConst.ZIndex ) );
            AttributeIfNotEmpty( "[nzZIndex]", _config.GetValue( AngularConst.BindZIndex ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public DrawerBuilder Events() {
            AttributeIfNotEmpty( "(nzOnClose)", _config.GetValue( UiConst.OnClose ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Closable().CloseIcon().MaskClosable().Mask().CloseOnNavigation()
                .MaskStyle().Keyboard().BodyStyle().Title().Footer().Visible()
                .Placement().Width().Height().OffsetX().OffsetY().WrapClassName()
                .ZIndex().Events();
        }
    }
}