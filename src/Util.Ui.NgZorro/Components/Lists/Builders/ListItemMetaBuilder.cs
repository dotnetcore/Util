using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项元信息标签生成器
    /// </summary>
    public class ListItemMetaBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项元信息标签生成器
        /// </summary>
        public ListItemMetaBuilder( Config config ) : base( config,"nz-list-item-meta" ) {
            _config = config;
        }

        /// <summary>
        /// 配置头像图标
        /// </summary>
        public ListItemMetaBuilder Avatar() {
            AttributeIfNotEmpty( "nzAvatar", _config.GetValue( UiConst.Avatar ) );
            AttributeIfNotEmpty( "[nzAvatar]", _config.GetValue( AngularConst.BindAvatar ) );
            return this;
        }

        /// <summary>
        /// 配置描述
        /// </summary>
        public ListItemMetaBuilder Description() {
            AttributeIfNotEmpty( "nzDescription", _config.GetValue( UiConst.Description ) );
            AttributeIfNotEmpty( "[nzDescription]", _config.GetValue( AngularConst.BindDescription ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public ListItemMetaBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Avatar().Description().Title();
        }
    }
}