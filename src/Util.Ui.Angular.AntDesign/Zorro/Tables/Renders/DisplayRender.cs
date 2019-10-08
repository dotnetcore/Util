using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格编辑列显示内容渲染器
    /// </summary>
    public class DisplayRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格编辑列显示内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DisplayRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var config = _config.GetValueFromItems<ColumnShareConfig>();
            var builder = EditColumnBuilderBase.CreateContainerBuilder( config?.EditTableId, config?.TemplateId );
            ConfigContent( builder );
            return builder;
        }
    }
}
