using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Lists.Builders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 选择列表项渲染器
    /// </summary>
    public class SelectListOptionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化选择列表项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SelectListOptionRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SelectListOptionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigValue( builder );
            ConfigCheckboxPosition( builder );
            ConfigSelected( builder );
            ConfigDisabled( builder );
        }

        /// <summary>
        /// 配置值
        /// </summary>
        private void ConfigValue( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Value, _config.GetValue( UiConst.Value ) );
            builder.AddAttribute( "[value]", _config.GetValue( AngularConst.BindValue ) );
        }

        /// <summary>
        /// 配置复选框位置
        /// </summary>
        private void ConfigCheckboxPosition( TagBuilder builder ) {
            builder.AddAttribute( "checkboxPosition", _config.GetValue<XPosition?>( MaterialConst.CheckboxPosition )?.Description() );
        }

        /// <summary>
        /// 配置选中状态
        /// </summary>
        private void ConfigSelected( TagBuilder builder ) {
            builder.AddAttribute( "[selected]", _config.GetBoolValue( UiConst.Selected ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }
    }
}