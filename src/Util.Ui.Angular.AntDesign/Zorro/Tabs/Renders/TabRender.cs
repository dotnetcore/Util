using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tabs.Builders;

namespace Util.Ui.Zorro.Tabs.Renders {
    /// <summary>
    /// 标签选项卡渲染器
    /// </summary>
    public class TabRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化标签选项卡渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            builder.AddAttribute( "nzTitle", _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                return;
            var lazy = _config.GetValue<bool?>( UiConst.Lazy );
            if ( lazy == true ) {
                var templateBuilder = new TemplateBuilder();
                templateBuilder.AddAttribute( "nz-tab" );
                templateBuilder.AppendContent( _config.Content );
                builder.AppendContent( templateBuilder );
                return;
            }
            builder.AppendContent( _config.Content );
        }
    }
}