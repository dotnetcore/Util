using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格布尔单元格标签生成器
    /// </summary>
    public class TableColumnBoolBuilder : TableColumnBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表格布尔单元格标签生成器
        /// </summary>
        public TableColumnBoolBuilder( Config config ) : base( config ) {
            _config = config;
            _tableShareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 配置列名
        /// </summary>
        public TableColumnBoolBuilder Column() {
            var column = _config.GetValue( UiConst.Column );
            if ( column.IsEmpty() == false )
                AppendContent( $"{{{{row.{column}?'{_tableShareConfig.TableExtendId}.config.text.yes':'{_tableShareConfig.TableExtendId}.config.text.no'}}}}" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Column();
        }
    }
}