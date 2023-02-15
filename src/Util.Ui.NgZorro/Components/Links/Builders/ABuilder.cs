using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Links.Builders {
    /// <summary>
    /// a标签生成器
    /// </summary>
    public class ABuilder : ButtonBuilderBase<ABuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        
        /// <summary>
        /// 初始化a标签生成器
        /// </summary>
        public ABuilder( Config config ) : base( config,"a" ) {
            _config = config;
        }

        /// <summary>
        /// 配置链接地址
        /// </summary>
        public ABuilder Href() {
            AttributeIfNotEmpty( "href", _config.GetValue( UiConst.Href ) );
            AttributeIfNotEmpty( "[href]", _config.GetValue( AngularConst.BindHref ) );
            return this;
        }

        /// <summary>
        /// 配置链接打开目标
        /// </summary>
        public ABuilder Target() {
            AttributeIfNotEmpty( "target", _config.GetValue<ATarget?>( UiConst.Target )?.Description() );
            AttributeIfNotEmpty( "[target]", _config.GetValue( AngularConst.BindTarget ) );
            return this;
        }

        /// <summary>
        /// 配置链接关系
        /// </summary>
        public ABuilder Rel() {
            AttributeIfNotEmpty( "rel", _config.GetValue( UiConst.Rel ) );
            AttributeIfNotEmpty( "[rel]", _config.GetValue( AngularConst.BindRel ) );
            return this;
        }

        /// <summary>
        /// 配置危险按钮
        /// </summary>
        public override ABuilder Danger() {
            var result = _config.GetValue<bool?>( UiConst.Danger );
            if ( result == true ) {
                Class( "ant-btn-dangerous" );
            }
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigButton().Href().Target().Rel().RouterLink().DropdownMenu().DropdownMenuPlacement();
        }
    }
}
