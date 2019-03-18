using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 行渲染器
    /// </summary>
    public class RowRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// 表格标识
        /// </summary>
        private readonly string _tableId;

        /// <summary>
        /// 初始化行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tableId">表格标识</param>
        public RowRender( IConfig config, string tableId ) : base( config ) {
            _config = config;
            _tableId = tableId;
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
        /// 渲染表头
        /// </summary>
        private void RenderHeaderRow( TextWriter writer, HtmlEncoder encoder ) {
            var headerRowBuilder = new HeaderRowBuilder();
            headerRowBuilder.AddColumns( _config.GetValue( UiConst.Columns ), _config.GetValue( UiConst.StickyHeader ).ToBoolOrNull() );
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
            var builder = new RowBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( RowBuilder builder ) {
            ConfigId( builder );
            ConfigColumns( builder );
            ConfigEvents( builder );
            builder.AddSelected( _tableId );
        }

        /// <summary>
        /// 配置列集合
        /// </summary>
        private void ConfigColumns( RowBuilder builder ) {
            if( _config.Contains( UiConst.Columns ) )
                builder.AddColumns( _config.GetValue( UiConst.Columns ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( RowBuilder builder ) {
            builder.OnClick( _config.GetValue( UiConst.OnClick ) );
        }
    }
}