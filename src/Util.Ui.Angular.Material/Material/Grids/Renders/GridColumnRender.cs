using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Grids.Builders;

namespace Util.Ui.Material.Grids.Renders {
    /// <summary>
    /// 网格列渲染器
    /// </summary>
    public class GridColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化网格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public GridColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            Builder.WriteTo( writer, encoder );
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
        protected void Config( GridColumnBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigSpan( builder );
        }

        /// <summary>
        /// 配置合并
        /// </summary>
        private void ConfigSpan( GridColumnBuilder builder ) {
            builder.AddColspan( _config, UiConst.Colspan );
            builder.AddAttribute( "rowspan", _config.GetValue( UiConst.Rowspan ) );
        }
    }
}