using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表格单元格渲染器
    /// </summary>
    public class TableColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = GetTableColumnBuilder();
            builder.Config();
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if ( _config.Content.IsEmpty() )
                return;
            builder.SetContent( _config.Content );
        }

        /// <summary>
        /// 获取表格单元格标签生成器
        /// </summary>
        protected virtual TableColumnBuilder GetTableColumnBuilder() {
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            switch ( type ) {
                case TableColumnType.LineNumber:
                    return new TableColumnLineNumberBuilder( _config );
                case TableColumnType.Checkbox:
                    return new TableColumnCheckboxBuilder( _config );
                case TableColumnType.Bool:
                    return new TableColumnBoolBuilder( _config );
            }
            return new TableColumnTextBuilder( _config );
        }
    }
}