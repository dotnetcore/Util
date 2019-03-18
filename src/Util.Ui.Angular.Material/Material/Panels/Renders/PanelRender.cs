using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Builders;

namespace Util.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板渲染器
    /// </summary>
    public class PanelRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化面板渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PanelBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigHideToggle( builder );
            ConfigExpanded( builder );
            ConfigDisabled( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置隐藏折叠开关
        /// </summary>
        private void ConfigHideToggle( TagBuilder builder ) {
            builder.AddAttribute( "hideToggle", _config.GetBoolValue( MaterialConst.HideToggle ) );
        }

        /// <summary>
        /// 配置展开
        /// </summary>
        private void ConfigExpanded( TagBuilder builder ) {
            builder.AddAttribute( "[expanded]", _config.GetValue( UiConst.Expanded ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(opened)", _config.GetValue( UiConst.OnOpen ) );
            builder.AddAttribute( "(closed)", _config.GetValue( UiConst.OnClose ) );
        }
    }
}