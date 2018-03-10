using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 表格行渲染器
    /// </summary>
    public class TableRowRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化表格行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableRowRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderHeaderRow( writer, encoder );
            RenderRow( writer, encoder );
        }

        /// <summary>
        /// 渲染行头
        /// </summary>
        private void RenderHeaderRow( TextWriter writer, HtmlEncoder encoder ) {
            var headerRowBuilder = new TableHeaderRowBuilder();
            headerRowBuilder.AddColumns( _config.GetValue( UiConst.Columns ) );
            headerRowBuilder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染行
        /// </summary>
        private void RenderRow( TextWriter writer, HtmlEncoder encoder ) {
            Builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableRowBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TableRowBuilder builder ) {
            ConfigId( builder );
            ConfigColumns( builder );
        }

        /// <summary>
        /// 配置列集合
        /// </summary>
        private void ConfigColumns( TableRowBuilder builder ) {
            if( _config.Contains( UiConst.Columns ) )
                builder.AddColumns( _config.GetValue( UiConst.Columns ) );
        }
    }
}