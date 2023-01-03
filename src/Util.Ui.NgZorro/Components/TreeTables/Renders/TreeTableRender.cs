using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.NgZorro.Components.TreeTables.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Renders {
    /// <summary>
    /// 树形表格渲染器
    /// </summary>
    public class TreeTableRender : TableRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树形表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeTableRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TreeTableBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TreeTableRender( _config.Copy() );
        }
    }
}