using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表头单元格过滤器触发按钮标签生成器
    /// </summary>
    public class FilterTriggerBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表头单元格过滤器触发按钮标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FilterTriggerBuilder( Config config ) : base( config,"nz-filter-trigger" ) {
            _config = config;
        }

        /// <summary>
        /// 配置下拉菜单
        /// </summary>
        public FilterTriggerBuilder DropdownMenu() {
            AttributeIfNotEmpty( "[nzDropdownMenu]", _config.GetValue( UiConst.DropdownMenu ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示下拉菜单
        /// </summary>
        public FilterTriggerBuilder Visible() {
            AttributeIfNotEmpty( "[nzVisible]", _config.GetBoolValue( UiConst.Visible ) );
            AttributeIfNotEmpty( "[nzVisible]", _config.GetValue( AngularConst.BindVisible ) );
            AttributeIfNotEmpty( "[(nzVisible)]", _config.GetValue( AngularConst.BindonVisible ) );
            return this;
        }

        /// <summary>
        /// 配置是否激活选中图标效果
        /// </summary>
        public FilterTriggerBuilder Active() {
            AttributeIfNotEmpty( "[nzActive]", _config.GetBoolValue( UiConst.Active ) );
            AttributeIfNotEmpty( "[nzActive]", _config.GetValue( AngularConst.BindActive ) );
            return this;
        }

        /// <summary>
        /// 配置是否附带背景
        /// </summary>
        public FilterTriggerBuilder HasBackdrop() {
            AttributeIfNotEmpty( "[nzHasBackdrop]", _config.GetBoolValue( UiConst.HasBackdrop ) );
            AttributeIfNotEmpty( "[nzHasBackdrop]", _config.GetValue( AngularConst.BindHasBackdrop ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public FilterTriggerBuilder Events() {
            AttributeIfNotEmpty( "(nzVisibleChange)", _config.GetValue( UiConst.OnVisibleChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            DropdownMenu().Visible().Active().HasBackdrop().Events();
        }
    }
}