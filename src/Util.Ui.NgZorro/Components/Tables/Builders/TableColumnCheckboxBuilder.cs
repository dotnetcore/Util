using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格复选框单元格标签生成器
    /// </summary>
    public class TableColumnCheckboxBuilder : TableColumnBuilder {
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表格复选框单元格标签生成器
        /// </summary>
        public TableColumnCheckboxBuilder( Config config ) : base( config ) {
            _tableShareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Attribute( "[nzShowCheckbox]", $"{_tableShareConfig.TableExtendId}.multiple" );
            Attribute( "(click)", "$event.stopPropagation()" );
            Attribute( "(nzCheckedChange)", $"{_tableShareConfig.TableExtendId}.checkedSelection.toggle(row)" );
            Attribute( "[nzChecked]", $"{_tableShareConfig.TableExtendId}.checkedSelection.isSelected(row)" );
        }
    }
}