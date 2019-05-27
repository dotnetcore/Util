using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 单元格渲染器
    /// </summary>
    public class CellRender : AngularRenderBase {
        /// <summary>
        /// 初始化单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CellRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CellBuilder();
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