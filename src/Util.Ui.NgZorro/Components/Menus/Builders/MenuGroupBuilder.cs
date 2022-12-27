using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单组标签生成器
    /// </summary>
    public class MenuGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单组标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuGroupBuilder( Config config ) : base( config,"li" ) {
            _config = config;
            base.Attribute( "nz-menu-group" );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public MenuGroupBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title();
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected override void ConfigContent( Config config ) {
            var ulBuilder = new UlBuilder();
            SetContent( ulBuilder );
            _config.Content.AppendTo( ulBuilder );
        }
    }
}