using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TagBuilder builder ) {
            if( _config.Contains( UiConst.Column ) == false )
                return;
            builder.AppendContent( $"{{{{row.{_config.GetValue( UiConst.Column )}}}}}" );
        }
    }
}