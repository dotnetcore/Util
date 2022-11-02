using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Modals.Builders {
    /// <summary>
    /// 对话框标签生成器
    /// </summary>
    public class ModalBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化对话框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ModalBuilder( Config config ) : base( config,"nz-modal" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否显示遮罩
        /// </summary>
        public ModalBuilder Mask() {
            AttributeIfNotEmpty( "[nzMask]", _config.GetBoolValue( UiConst.Mask ) );
            AttributeIfNotEmpty( "[nzMask]", _config.GetValue( AngularConst.BindMask ) );
            return this;
        }

        /// <summary>
        /// 配置点击遮罩是否允许关闭
        /// </summary>
        public ModalBuilder MaskClosable() {
            AttributeIfNotEmpty( "[nzMaskClosable]", _config.GetBoolValue( UiConst.MaskClosable ) );
            AttributeIfNotEmpty( "[nzMaskClosable]", _config.GetValue( AngularConst.BindMaskClosable ) );
            return this;
        }

        /// <summary>
        /// 配置导航时是否关闭
        /// </summary>
        public ModalBuilder CloseOnNavigation() {
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetBoolValue( UiConst.CloseOnNavigation ) );
            AttributeIfNotEmpty( "[nzCloseOnNavigation]", _config.GetValue( AngularConst.BindCloseOnNavigation ) );
            return this;
        }

        /// <summary>
        /// 配置是否可见
        /// </summary>
        public ModalBuilder Visible() {
            AttributeIfNotEmpty( "[(nzVisible)]", _config.GetBoolValue( UiConst.Visible ) );
            return this;
        }

        /// <summary>
        /// 配置是否可关闭
        /// </summary>
        public ModalBuilder Closable() {
            AttributeIfNotEmpty( "[nzClosable]", _config.GetBoolValue( UiConst.Closable ) );
            AttributeIfNotEmpty( "[nzClosable]", _config.GetValue( AngularConst.BindClosable ) );
            return this;
        }

        /// <summary>
        /// 配置确定按钮是否加载状态
        /// </summary>
        public ModalBuilder OkLoading() {
            AttributeIfNotEmpty( "[nzOkLoading]", _config.GetValue( UiConst.OkLoading ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用确定按钮
        /// </summary>
        public ModalBuilder OkDisabled() {
            AttributeIfNotEmpty( "[nzOkDisabled]", _config.GetBoolValue( UiConst.OkDisabled ) );
            AttributeIfNotEmpty( "[nzOkDisabled]", _config.GetValue( AngularConst.BindOkDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置取消按钮是否加载状态
        /// </summary>
        public ModalBuilder CancelLoading() {
            AttributeIfNotEmpty( "[nzCancelLoading]", _config.GetValue( UiConst.CancelLoading ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用取消按钮
        /// </summary>
        public ModalBuilder CancelDisabled() {
            AttributeIfNotEmpty( "[nzCancelDisabled]", _config.GetBoolValue( UiConst.CancelDisabled ) );
            AttributeIfNotEmpty( "[nzCancelDisabled]", _config.GetValue( AngularConst.BindCancelDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置是否支持键盘ESC键关闭
        /// </summary>
        public ModalBuilder Keyboard() {
            AttributeIfNotEmpty( "[nzKeyboard]", _config.GetBoolValue( UiConst.Keyboard ) );
            AttributeIfNotEmpty( "[nzKeyboard]", _config.GetValue( AngularConst.BindKeyboard ) );
            return this;
        }

        /// <summary>
        /// 配置是否垂直居中显示
        /// </summary>
        public ModalBuilder Centered() {
            AttributeIfNotEmpty( "[nzCentered]", _config.GetBoolValue( UiConst.Centered ) );
            AttributeIfNotEmpty( "[nzCentered]", _config.GetValue( AngularConst.BindCentered ) );
            return this;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public ModalBuilder Content() {
            AttributeIfNotEmpty( "[nzContent]", _config.GetValue( UiConst.Content ) );
            return this;
        }

        /// <summary>
        /// 配置组件参数
        /// </summary>
        public ModalBuilder ComponentParams() {
            AttributeIfNotEmpty( "[nzComponentParams]", _config.GetValue( UiConst.ComponentParams ) );
            return this;
        }

        /// <summary>
        /// 配置底部内容
        /// </summary>
        public ModalBuilder Footer() {
            AttributeIfNotEmpty( "[nzFooter]", _config.GetValue( UiConst.Footer ) );
            return this;
        }

        /// <summary>
        /// 配置z-index
        /// </summary>
        public ModalBuilder ZIndex() {
            AttributeIfNotEmpty( "nzZIndex", _config.GetValue( UiConst.ZIndex ) );
            AttributeIfNotEmpty( "[nzZIndex]", _config.GetValue( AngularConst.BindZIndex ) );
            return this;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        public ModalBuilder Width() {
            AttributeIfNotEmpty( "nzWidth", _config.GetValue( UiConst.Width ) );
            AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 配置对话框外层容器样式类名
        /// </summary>
        public ModalBuilder WrapClassName() {
            AttributeIfNotEmpty( "nzWrapClassName", _config.GetValue( UiConst.WrapClassName ) );
            AttributeIfNotEmpty( "[nzWrapClassName]", _config.GetValue( AngularConst.BindWrapClassName ) );
            return this;
        }

        /// <summary>
        /// 配置对话框样式类名
        /// </summary>
        public ModalBuilder ClassName() {
            AttributeIfNotEmpty( "nzClassName", _config.GetValue( UiConst.ClassName ) );
            AttributeIfNotEmpty( "[nzClassName]", _config.GetValue( AngularConst.BindClassName ) );
            return this;
        }

        /// <summary>
        /// 配置浮层样式
        /// </summary>
        public ModalBuilder Style() {
            AttributeIfNotEmpty( "[nzStyle]", _config.GetValue( UiConst.ModalStyle ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public ModalBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置关闭图标
        /// </summary>
        public ModalBuilder CloseIcon() {
            AttributeIfNotEmpty( "nzCloseIcon", _config.GetValue<AntDesignIcon?>( UiConst.CloseIcon )?.Description() );
            AttributeIfNotEmpty( "[nzCloseIcon]", _config.GetValue( AngularConst.BindCloseIcon ) );
            return this;
        }

        /// <summary>
        /// 配置遮罩样式
        /// </summary>
        public ModalBuilder MaskStyle() {
            AttributeIfNotEmpty( "[nzMaskStyle]", _config.GetValue( UiConst.MaskStyle ) );
            return this;
        }

        /// <summary>
        /// 配置主体样式
        /// </summary>
        public ModalBuilder BodyStyle() {
            AttributeIfNotEmpty( "[nzBodyStyle]", _config.GetValue( UiConst.BodyStyle ) );
            return this;
        }

        /// <summary>
        /// 配置确认按钮文字
        /// </summary>
        public ModalBuilder OkText() {
            AttributeIfNotEmpty( "nzOkText", _config.GetValue( UiConst.OkText ) );
            AttributeIfNotEmpty( "[nzOkText]", _config.GetValue( AngularConst.BindOkText ) );
            return this;
        }

        /// <summary>
        /// 配置取消按钮文字
        /// </summary>
        public ModalBuilder CancelText() {
            AttributeIfNotEmpty( "nzCancelText", _config.GetValue( UiConst.CancelText ) );
            AttributeIfNotEmpty( "[nzCancelText]", _config.GetValue( AngularConst.BindCancelText ) );
            return this;
        }

        /// <summary>
        /// 配置确认按钮类型
        /// </summary>
        public ModalBuilder OkType() {
            AttributeIfNotEmpty( "nzOkType", _config.GetValue<ButtonType?>( UiConst.OkType )?.Description() );
            AttributeIfNotEmpty( "[nzOkType]", _config.GetValue( AngularConst.BindOkType ) );
            return this;
        }

        /// <summary>
        /// 配置确认按钮是否危险按钮
        /// </summary>
        public ModalBuilder OkDanger() {
            AttributeIfNotEmpty( "[nzOkDanger]", _config.GetBoolValue( UiConst.OkDanger ) );
            AttributeIfNotEmpty( "[nzOkDanger]", _config.GetValue( AngularConst.BindOkDanger ) );
            return this;
        }

        /// <summary>
        /// 配置图标类型
        /// </summary>
        public ModalBuilder IconType() {
            AttributeIfNotEmpty( "nzIconType", _config.GetValue<AntDesignIcon?>( UiConst.IconType )?.Description() );
            AttributeIfNotEmpty( "[nzIconType]", _config.GetValue( AngularConst.BindIconType ) );
            return this;
        }

        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public ModalBuilder Autofocus() {
            AttributeIfNotEmpty( "nzAutofocus", _config.GetValue<ModalAutofocus?>( UiConst.Autofocus )?.Description() );
            AttributeIfNotEmpty( "[nzAutofocus]", _config.GetValue( AngularConst.BindAutofocus ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public ModalBuilder Events() {
            AttributeIfNotEmpty( "(nzOnOk)", _config.GetValue( UiConst.OnOk ) );
            AttributeIfNotEmpty( "(nzOnCancel)", _config.GetValue( UiConst.OnCancel ) );
            AttributeIfNotEmpty( "(nzAfterOpen)", _config.GetValue( UiConst.OnAfterOpen ) );
            AttributeIfNotEmpty( "(nzAfterClose)", _config.GetValue( UiConst.OnAfterClose ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Mask().MaskClosable().CloseOnNavigation().Visible().Closable()
                .OkLoading().OkDisabled().CancelLoading().CancelDisabled()
                .Keyboard().Centered().Content().ComponentParams().Footer()
                .ZIndex().Width().WrapClassName().ClassName().Style()
                .Title().CloseIcon().MaskStyle().BodyStyle().OkText()
                .CancelText().OkType().OkDanger().IconType().Autofocus()
                .Events();
        }
    }
}