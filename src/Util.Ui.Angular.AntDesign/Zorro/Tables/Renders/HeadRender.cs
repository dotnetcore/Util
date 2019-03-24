using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格头渲染器
    /// </summary>
    public class HeadRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化表格头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public HeadRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadBuilder();
            var rowBuilder = new TableRowBuilder();
            builder.AppendContent( rowBuilder );
            Config( rowBuilder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TableRowBuilder builder ) {
            InitBuilder( builder );
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}