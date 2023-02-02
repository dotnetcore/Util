using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Enums;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgAlain.Components.Tinymce.Builders {
    /// <summary>
    /// Tinymce富文本标签生成器
    /// </summary>
    public class TinymceBuilder : FormControlBuilderBase<TinymceBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标识
        /// </summary>
        private string _id;

        /// <summary>
        /// 初始化Tinymce富文本标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TinymceBuilder( Config config ) : base( config, "tinymce" ) {
            _config = config;
        }

        /// <summary>
        /// 扩展标识
        /// </summary>
        public string ExtendId => $"x_{GetId()}";

        /// <summary>
        /// 获取标识
        /// </summary>
        private string GetId() {
            if ( _id.IsEmpty() == false )
                return _id;
            _id = _config.GetValue( UiConst.Id );
            if ( _id.IsEmpty() )
                _id = Util.Helpers.Id.Create();
            return _id;
        }

        /// <summary>
        /// 配置品牌
        /// </summary>
        public TinymceBuilder Branding() {
            AttributeIfNotEmpty( "[branding]", _config.GetBoolValue( UiConst.Branding ) );
            return this;
        }

        /// <summary>
        /// 配置是否允许粘贴图片
        /// </summary>
        public TinymceBuilder PasteDataImages() {
            AttributeIfNotEmpty( "[pasteDataImages]", _config.GetBoolValue( UiConst.PasteDataImages ) );
            return this;
        }

        /// <summary>
        /// 配置菜单栏
        /// </summary>
        public TinymceBuilder Menubar() {
            AttributeIfNotEmpty( "menubar", _config.GetValue( UiConst.Menubar ) );
            return this;
        }

        /// <summary>
        /// 配置工具栏模式
        /// </summary>
        public TinymceBuilder ToolbarMode() {
            AttributeIfNotEmpty( "toolbarMode", _config.GetValue<TinymceToolbarMode?>( UiConst.ToolbarMode )?.Description() );
            return this;
        }

        /// <summary>
        /// 配置插件列表
        /// </summary>
        public TinymceBuilder Plugins() {
            AttributeIfNotEmpty( "plugins", _config.GetValue( UiConst.Plugins ) );
            return this;
        }

        /// <summary>
        /// 配置工具栏
        /// </summary>
        public TinymceBuilder Toolbar() {
            AttributeIfNotEmpty( "toolbar", _config.GetValue( UiConst.Toolbar ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public TinymceBuilder Disabled() {
            AttributeIfNotEmpty( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[disabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        public TinymceBuilder Placeholder() {
            AttributeIfNotEmpty( "placeholder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[placeholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置内容变更事件
        /// </summary>
        public TinymceBuilder OnChange() {
            AttributeIfNotEmpty( "[change]", _config.GetValue( UiConst.OnChange ) );
            return this;
        }

        /// <summary>
        /// 配置config
        /// </summary>
        private void ConfigConfig() {
            var config = _config.GetValue( UiConst.Config );
            if ( config.IsEmpty() ) {
                config = $"{ExtendId}.config";
            }
            AttributeIfNotEmpty( "[config]", config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            NgModel().FormControl().SpaceItem().OnModelChange()
                .Required().RequiredMessage()
                .TableEdit().ValidationExtend()
                .Name().Branding().PasteDataImages()
                .Menubar().ToolbarMode().Plugins().Toolbar()
                .Disabled().Placeholder()
                .OnChange();
            ConfigConfig();
            EnableExtend();
        }

        /// <summary>
        /// 启用扩展
        /// </summary>
        public void EnableExtend() {
            Attribute( $"#{ExtendId}", "xTinymceExtend" );
            Attribute( "x-tinymce-extend" );
        }
    }
}