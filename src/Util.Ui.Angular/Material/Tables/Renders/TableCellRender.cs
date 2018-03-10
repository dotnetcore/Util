using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 表格单元格渲染器
    /// </summary>
    public class TableCellRender : RenderBase {
        /// <summary>
        /// 初始化表格单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableCellRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableCellBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}