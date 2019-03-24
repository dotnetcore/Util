using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 标题列渲染器
    /// </summary>
    public class HeadColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化标题列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public HeadColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TableHeadColumnBuilder builder ) {
            ConfigId( builder );
            ConfigHeader( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列头
        /// </summary>
        private void ConfigHeader( TableHeadColumnBuilder builder ) {
            ConfigTitle( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TableHeadColumnBuilder builder ) {
            builder.Title( _config.GetValue( UiConst.Title ) );
        }
    }
}