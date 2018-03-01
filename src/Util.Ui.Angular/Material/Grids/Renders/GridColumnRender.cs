using System.IO;
using System.Text.Encodings.Web;
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
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBeforeColumn( writer, encoder );
            Builder.WriteTo( writer, encoder );
            RenderAfterColumn( writer, encoder );
        }

        /// <summary>
        /// 渲染左侧占位列
        /// </summary>
        private void RenderBeforeColumn( TextWriter writer, HtmlEncoder encoder ) {
            if ( _config.Contains( UiConst.BeforeColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.BeforeColspan );
            builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染右侧占位列
        /// </summary>
        private void RenderAfterColumn( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.AfterColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.AfterColspan );
            builder.WriteTo( writer, encoder );
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
            ConfigSpan( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置合并
        /// </summary>
        private void ConfigSpan( GridColumnBuilder builder ) {
            builder.AddColspan( _config, UiConst.Colspan );
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