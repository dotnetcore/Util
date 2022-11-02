using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tabs.Builders {
    /// <summary>
    /// 标签页标签生成器
    /// </summary>
    public class TabSetBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签页标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TabSetBuilder( Config config ) : base( config,"nz-tabset" ) {
            _config = config;
        }

        /// <summary>
        /// 配置选中标签索引
        /// </summary>
        public TabSetBuilder SelectedIndex() {
            AttributeIfNotEmpty( "nzSelectedIndex", _config.GetValue( UiConst.SelectedIndex ) );
            AttributeIfNotEmpty( "[nzSelectedIndex]", _config.GetValue( AngularConst.BindSelectedIndex ) );
            AttributeIfNotEmpty( "[(nzSelectedIndex)]", _config.GetValue( AngularConst.BindonSelectedIndex ) );
            return this;
        }

        /// <summary>
        /// 配置是否使用动画切换选项卡
        /// </summary>
        public TabSetBuilder Animated() {
            AttributeIfNotEmpty( "[nzAnimated]", _config.GetBoolValue( UiConst.Animated ) );
            AttributeIfNotEmpty( "[nzAnimated]", _config.GetValue( AngularConst.BindAnimated ) );
            return this;
        }

        /// <summary>
        /// 配置标签大小
        /// </summary>
        public TabSetBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<TabSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置标签栏附加内容
        /// </summary>
        public TabSetBuilder TabBarExtraContent() {
            AttributeIfNotEmpty( "[nzTabBarExtraContent]", _config.GetValue( UiConst.TabBarExtraContent ) );
            return this;
        }

        /// <summary>
        /// 配置标签栏样式
        /// </summary>
        public TabSetBuilder TabBarStyle() {
            AttributeIfNotEmpty( "[nzTabBarStyle]", _config.GetValue( UiConst.TabBarStyle ) );
            return this;
        }

        /// <summary>
        /// 配置标签位置
        /// </summary>
        public TabSetBuilder TabPosition() {
            AttributeIfNotEmpty( "nzTabPosition", _config.GetValue<TabPosition?>( UiConst.TabPosition )?.Description() );
            AttributeIfNotEmpty( "[nzTabPosition]", _config.GetValue( AngularConst.BindTabPosition ) );
            return this;
        }

        /// <summary>
        /// 配置标签类型
        /// </summary>
        public TabSetBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<TabType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置标签间隙
        /// </summary>
        public TabSetBuilder TabBarGutter() {
            AttributeIfNotEmpty( "nzTabBarGutter", _config.GetValue( UiConst.TabBarGutter ) );
            AttributeIfNotEmpty( "[nzTabBarGutter]", _config.GetValue( AngularConst.BindTabBarGutter ) );
            return this;
        }

        /// <summary>
        /// 配置是否隐藏全部标签
        /// </summary>
        public TabSetBuilder HideAll() {
            AttributeIfNotEmpty( "[nzHideAll]", _config.GetBoolValue( UiConst.HideAll ) );
            AttributeIfNotEmpty( "[nzHideAll]", _config.GetValue( AngularConst.BindHideAll ) );
            return this;
        }

        /// <summary>
        /// 配置是否支持路由联动
        /// </summary>
        public TabSetBuilder LinkRouter() {
            AttributeIfNotEmpty( "[nzLinkRouter]", _config.GetBoolValue( UiConst.LinkRouter ) );
            AttributeIfNotEmpty( "[nzLinkRouter]", _config.GetValue( AngularConst.BindLinkRouter ) );
            return this;
        }

        /// <summary>
        /// 配置是否以严格模式匹配路由联动
        /// </summary>
        public TabSetBuilder LinkExact() {
            AttributeIfNotEmpty( "[nzLinkExact]", _config.GetBoolValue( UiConst.LinkExact ) );
            AttributeIfNotEmpty( "[nzLinkExact]", _config.GetValue( AngularConst.BindLinkExact ) );
            return this;
        }

        /// <summary>
        /// 配置标签守卫函数
        /// </summary>
        public TabSetBuilder CanDeactivate() {
            AttributeIfNotEmpty( "[nzCanDeactivate]", _config.GetValue( UiConst.CanDeactivate ) );
            return this;
        }

        /// <summary>
        /// 配置标签是否居中显示
        /// </summary>
        public TabSetBuilder Centered() {
            AttributeIfNotEmpty( "[nzCentered]", _config.GetBoolValue( UiConst.Centered ) );
            AttributeIfNotEmpty( "[nzCentered]", _config.GetValue( AngularConst.BindCentered ) );
            return this;
        }

        /// <summary>
        /// 配置是否隐藏添加按钮
        /// </summary>
        public TabSetBuilder HideAdd() {
            AttributeIfNotEmpty( "[nzHideAdd]", _config.GetBoolValue( UiConst.HideAdd ) );
            AttributeIfNotEmpty( "[nzHideAdd]", _config.GetValue( AngularConst.BindHideAdd ) );
            return this;
        }

        /// <summary>
        /// 配置添加按钮图标
        /// </summary>
        public TabSetBuilder AddIcon() {
            AttributeIfNotEmpty( "nzAddIcon", _config.GetValue<AntDesignIcon?>( UiConst.AddIcon )?.Description() );
            AttributeIfNotEmpty( "[nzAddIcon]", _config.GetValue( AngularConst.BindAddIcon ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TabSetBuilder Events() {
            AttributeIfNotEmpty( "(nzSelectedIndexChange)", _config.GetValue( UiConst.OnSelectedIndexChange ) );
            AttributeIfNotEmpty( "(nzSelectChange)", _config.GetValue( UiConst.OnSelectChange ) );
            AttributeIfNotEmpty( "(nzAdd)", _config.GetValue( UiConst.OnAdd ) );
            AttributeIfNotEmpty( "(nzClose)", _config.GetValue( UiConst.OnClose ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            SelectedIndex().Animated().Size().Type()
                .TabBarExtraContent().TabBarStyle().TabPosition().TabBarGutter()
                .HideAll().LinkRouter().LinkExact().CanDeactivate().Centered()
                .HideAdd().AddIcon()
                .Events();
        }
    }
}