using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Grids.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Grids.Renders {
    /// <summary>
    /// 栅格列渲染器
    /// </summary>
    public class GridColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public GridColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new GridColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSpan( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置合并
        /// </summary>
        private void ConfigSpan( TagBuilder builder ) {
            builder.AddAttribute( "colspan", _config.GetValue( UiConst.Colspan ) );
            builder.AddAttribute( "rowspan", _config.GetValue( UiConst.Rowspan ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null )
                return;
            builder.SetContent( _config.Content );
        }
    }
}