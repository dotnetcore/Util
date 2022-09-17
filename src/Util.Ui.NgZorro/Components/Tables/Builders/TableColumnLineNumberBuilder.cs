using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格行号单元格标签生成器
    /// </summary>
    public class TableColumnLineNumberBuilder : TableColumnBuilder {
        /// <summary>
        /// 初始化表格行号单元格标签生成器
        /// </summary>
        public TableColumnLineNumberBuilder( Config config ) : base( config ) {
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            base.AppendContent( "{{row.lineNumber}}" );
        }
    }
}