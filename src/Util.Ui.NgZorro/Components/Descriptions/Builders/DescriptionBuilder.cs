using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Descriptions.Builders {
    /// <summary>
    /// 描述列表标签生成器
    /// </summary>
    public class DescriptionBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化描述列表标签生成器
        /// </summary>
        public DescriptionBuilder( Config config ) : base( "nz-descriptions" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public DescriptionBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置操作区域
        /// </summary>
        public DescriptionBuilder Extra() {
            AttributeIfNotEmpty( "nzExtra", _config.GetValue( UiConst.Extra ) );
            AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( AngularConst.BindExtra ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示边框
        /// </summary>
        public DescriptionBuilder Bordered() {
            AttributeIfNotEmpty( "[nzBordered]", _config.GetBoolValue( UiConst.Bordered ) );
            AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( AngularConst.BindBordered ) );
            return this;
        }

        /// <summary>
        /// 配置一行包含的描述列表项数量
        /// </summary>
        public DescriptionBuilder Column() {
            AttributeIfNotEmpty( "[nzColumn]", _config.GetValue( UiConst.Column ) );
            return this;
        }

        /// <summary>
        /// 配置列表大小
        /// </summary>
        public DescriptionBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<DescriptionSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示冒号
        /// </summary>
        public DescriptionBuilder Colon() {
            AttributeIfNotEmpty( "[nzColon]", _config.GetBoolValue( UiConst.Colon ) );
            AttributeIfNotEmpty( "[nzColon]", _config.GetValue( AngularConst.BindColon ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Title().Extra().Bordered().Column().Size().Colon();
        }
    }
}