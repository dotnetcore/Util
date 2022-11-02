using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Selects.Builders {
    /// <summary>
    /// 选项标签生成器
    /// </summary>
    public class OptionBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选项标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public OptionBuilder( Config config ) : base( config,"nz-option" ) {
            _config = config;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public OptionBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public OptionBuilder Label() {
            AttributeIfNotEmpty( "nzLabel", _config.GetValue( UiConst.Label ) );
            AttributeIfNotEmpty( "[nzLabel]", _config.GetValue( AngularConst.BindLabel ) );
            return this;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public OptionBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置隐藏
        /// </summary>
        public OptionBuilder Hide() {
            AttributeIfNotEmpty( "[nzHide]", _config.GetBoolValue( UiConst.Hide ) );
            AttributeIfNotEmpty( "[nzHide]", _config.GetValue( AngularConst.BindHide ) );
            return this;
        }

        /// <summary>
        /// 配置是否自定义内容
        /// </summary>
        public OptionBuilder CustomContent() {
            AttributeIfNotEmpty( "[nzCustomContent]", _config.GetBoolValue( UiConst.CustomContent ) );
            AttributeIfNotEmpty( "[nzCustomContent]", _config.GetValue( AngularConst.BindCustomContent ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Disabled().Label().Value().Hide().CustomContent();
        }
    }
}