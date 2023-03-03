using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Typographies.Renders {
    /// <summary>
    /// 排版组件渲染器
    /// </summary>
    public class TypographyRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TagBuilder _builder;

        /// <summary>
        /// 初始化排版组件渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="builder">标签生成器</param>
        public TypographyRender( Config config, TagBuilder builder ) {
            _config = config;
            _builder = builder;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ConfigDefault();
            ConfigNzContent();
            ConfigEditable();
            ConfigEditIcon();
            ConfigEditTooltip();
            ConfigCopyable();
            ConfigCopyText();
            ConfigCopyIcons();
            ConfigCopyTooltips();
            ConfigType();
            ConfigDisabled();
            ConfigEllipsis();
            ConfigExpandable();
            ConfigEllipsisRows();
            ConfigSuffix();
            ConfigEvents();
            _builder.Tooltip( _config );
            _builder.ConfigBase(_config);
            ConfigContent( _builder );
            return _builder;
        }

        /// <summary>
        /// 配置默认设置
        /// </summary>
        private void ConfigDefault() {
            _builder.Attribute( "nz-typography" );
        }

        /// <summary>
        /// 配置内容属性
        /// </summary>
        private void ConfigNzContent() {
            _builder.AttributeIfNotEmpty( "nzContent", _config.GetValue( UiConst.Content ) );
            _builder.AttributeIfNotEmpty( "[nzContent]", _config.GetValue( AngularConst.BindContent ) );
            _builder.AttributeIfNotEmpty( "[(nzContent)]", _config.GetValue( AngularConst.BindonContent ) );
        }

        /// <summary>
        /// 配置可编辑
        /// </summary>
        private void ConfigEditable() {
            _builder.AttributeIfNotEmpty( "[nzEditable]", _config.GetBoolValue( UiConst.Editable ) );
            _builder.AttributeIfNotEmpty( "[nzEditable]", _config.GetValue( AngularConst.BindEditable ) );
        }

        /// <summary>
        /// 配置编辑图标
        /// </summary>
        private void ConfigEditIcon() {
            _builder.AttributeIfNotEmpty( "nzEditIcon", _config.GetValue<AntDesignIcon?>( UiConst.EditIcon )?.Description() );
            _builder.AttributeIfNotEmpty( "[nzEditIcon]", _config.GetValue( AngularConst.BindEditIcon ) );
        }

        /// <summary>
        /// 配置编辑按钮工具提示
        /// </summary>
        private void ConfigEditTooltip() {
            _builder.AttributeIfNotEmpty( "nzEditTooltip", _config.GetValue( UiConst.EditTooltip ) );
            _builder.AttributeIfNotEmpty( "[nzEditTooltip]", _config.GetValue( AngularConst.BindEditTooltip ) );
        }

        /// <summary>
        /// 配置可复制
        /// </summary>
        private void ConfigCopyable() {
            _builder.AttributeIfNotEmpty( "[nzCopyable]", _config.GetBoolValue( UiConst.Copyable ) );
            _builder.AttributeIfNotEmpty( "[nzCopyable]", _config.GetValue( AngularConst.BindCopyable ) );
        }

        /// <summary>
        /// 配置复制文本
        /// </summary>
        private void ConfigCopyText() {
            _builder.AttributeIfNotEmpty( "nzCopyText", _config.GetBoolValue( UiConst.CopyText ) );
            _builder.AttributeIfNotEmpty( "[nzCopyText]", _config.GetValue( AngularConst.BindCopyText ) );
        }

        /// <summary>
        /// 配置复制图标
        /// </summary>
        private void ConfigCopyIcons() {
            _builder.AttributeIfNotEmpty( "[nzCopyIcons]", _config.GetValue( UiConst.CopyIcons ) );
            if( _config.Contains( UiConst.CopyIcon ) )
                _builder.Attribute( "[nzCopyIcons]", $"['{_config.GetValue<AntDesignIcon?>( UiConst.CopyIcon )?.Description()}','check']" );
        }

        /// <summary>
        /// 配置复制提示
        /// </summary>
        private void ConfigCopyTooltips() {
            _builder.AttributeIfNotEmpty( "[nzCopyTooltips]", _config.GetValue( UiConst.CopyTooltips ) );
        }

        /// <summary>
        /// 配置文本类型
        /// </summary>
        private void ConfigType() {
            _builder.AttributeIfNotEmpty( "nzType", _config.GetValue<TextType?>( UiConst.Type )?.Description() );
            _builder.AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
        }

        /// <summary>
        /// 配置禁用文本
        /// </summary>
        private void ConfigDisabled() {
            _builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            _builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
        }

        /// <summary>
        /// 配置省略文本
        /// </summary>
        private void ConfigEllipsis() {
            _builder.AttributeIfNotEmpty( "[nzEllipsis]", _config.GetBoolValue( UiConst.Ellipsis ) );
            _builder.AttributeIfNotEmpty( "[nzEllipsis]", _config.GetValue( AngularConst.BindEllipsis ) );
        }

        /// <summary>
        /// 配置省略可展开
        /// </summary>
        private void ConfigExpandable() {
            _builder.AttributeIfNotEmpty( "[nzExpandable]", _config.GetBoolValue( UiConst.Expandable ) );
            _builder.AttributeIfNotEmpty( "[nzExpandable]", _config.GetValue( AngularConst.BindExpandable ) );
        }

        /// <summary>
        /// 配置省略行数
        /// </summary>
        private void ConfigEllipsisRows() {
            _builder.AttributeIfNotEmpty( "[nzEllipsisRows]", _config.GetBoolValue( UiConst.EllipsisRows ) );
            _builder.AttributeIfNotEmpty( "[nzEllipsisRows]", _config.GetValue( AngularConst.BindEllipsisRows ) );
        }

        /// <summary>
        /// 配置省略后缀
        /// </summary>
        private void ConfigSuffix() {
            _builder.AttributeIfNotEmpty( "nzSuffix", _config.GetBoolValue( UiConst.Suffix ) );
            _builder.AttributeIfNotEmpty( "[nzSuffix]", _config.GetValue( AngularConst.BindSuffix ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents() {
            _builder.AttributeIfNotEmpty( "(nzContentChange)", _config.GetValue( UiConst.OnContentChange ) );
            _builder.AttributeIfNotEmpty( "(nzExpandChange)", _config.GetValue( UiConst.OnExpandChange ) );
            _builder.AttributeIfNotEmpty( "(nzOnEllipsis)", _config.GetValue( UiConst.OnEllipsis ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected virtual void ConfigContent( TagBuilder builder ) {
            _config.Content.AppendTo( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TypographyRender( _config.Copy(), _builder );
        }
    }
}
