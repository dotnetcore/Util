using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tags.Builders {
    /// <summary>
    /// 标签标签生成器
    /// </summary>
    public class TagTagBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TagTagBuilder( Config config ) : base( config,"nz-tag" ) {
            _config = config;
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        public TagTagBuilder Mode() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<TagMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            return this;
        }

        /// <summary>
        /// 配置是否选中
        /// </summary>
        public TagTagBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( AngularConst.BindChecked ) );
            AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
            return this;
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        public TagTagBuilder Color() {
            AttributeIfNotEmpty( "nzColor", _config.GetValue<AntDesignColor?>( UiConst.ColorType )?.Description() );
            AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
            AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TagTagBuilder Events() {
            AttributeIfNotEmpty( "(nzOnClose)", _config.GetValue( UiConst.OnClose ) );
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Mode().Checked().Color().Events();
        }
    }
}