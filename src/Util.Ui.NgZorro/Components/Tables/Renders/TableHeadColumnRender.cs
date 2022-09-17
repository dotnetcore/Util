using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表头单元格渲染器
    /// </summary>
    public class TableHeadColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表头单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableHeadColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadColumnBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}