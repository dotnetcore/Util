using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Grid.Builders;

namespace Util.Ui.Zorro.Grid.Renders {
    /// <summary>
    /// 栅格列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSpan( builder );
            ConfigOffset( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        private void ConfigSpan( TagBuilder builder ) {
            builder.AddAttribute( "[nzSpan]", _config.GetValue( UiConst.Span ) );
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        private void ConfigOffset( TagBuilder builder ) {
            builder.AddAttribute( "[nzOffset]", _config.GetValue( UiConst.Offset ) );
        }
    }
}