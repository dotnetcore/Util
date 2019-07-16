using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格列编辑控件渲染器
    /// </summary>
    public class ControlRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格列编辑控件渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ControlRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder();
            var config = _config.GetValueFromItems<ColumnShareConfig>();
            ConfigId( builder, config?.TemplateId );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( TagBuilder builder,string templateId ) {
            var id = _config.GetValue( UiConst.Id );
            if( id.IsEmpty() == false ) {
                ConfigId( builder );
                return;
            }
            if ( templateId.IsEmpty() )
                return;
            builder.AddAttribute( $"#{templateId}" );
        }
    }
}
