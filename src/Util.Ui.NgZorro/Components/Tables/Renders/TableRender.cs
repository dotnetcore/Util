using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表格渲染器
    /// </summary>
    public class TableRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">共享配置</param>
        public TableRender( Config config, TableShareConfig shareConfig = null ) {
            _config = config;
            _shareConfig = shareConfig ?? GetShareConfig();
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetShareConfig() {
            return _shareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <inheritdoc />
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            base.WriteTo( writer, encoder );
            RenderTotalTemplate( writer, encoder );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 渲染表格总行数模板
        /// </summary>
        protected void RenderTotalTemplate( TextWriter writer, HtmlEncoder encoder ) {
            if ( _shareConfig.IsEnableExtend == false )
                return;
            var builder = new TotalTemplateBuilder( _config );
            builder.Config();
            builder.WriteTo( writer, encoder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TableRender( _config.Copy(), _shareConfig.MapTo<TableShareConfig>() );
        }
    }
}