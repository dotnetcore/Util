using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格主体行标签生成器
    /// </summary>
    public class TableBodyRowBuilder : TableRowBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格主体行标签生成器
        /// </summary>
        public TableBodyRowBuilder( Config config ) : base( config ) {
            _config = config;
            _shareConfig = GetShareConfig();
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetShareConfig() {
            return _shareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 行标识
        /// </summary>
        public string RowId => _shareConfig.RowId;

        /// <summary>
        /// 表格编辑扩展标识
        /// </summary>
        public string EditId => _shareConfig.TableEditId;

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigTableExted();
            ConfigEdit();
            ConfigContent();
        }

        /// <summary>
        /// 配置表格主体行基础扩展属性
        /// </summary>
        public void ConfigTableExted() {
            if ( TableShareConfig.IsAutoCreateBodyRow == false )
                return;
            if ( TableShareConfig.IsEnableExtend == false )
                return;
            this.NgFor( $"let row of {TableShareConfig.TableExtendId}.dataSource;index as index" );
        }

        /// <summary>
        /// 配置行编辑模式
        /// </summary>
        public void ConfigEdit() {
            if ( TableShareConfig.IsEnableEdit == false )
                return;
            Attribute( "[x-edit-row]", "row" );
            Attribute( $"#{RowId}", "xEditRow",true );
            Attribute( "(click)", $"{EditId}.clickEdit(row.id)", append: true );
            Attribute( "(dblclick)", $"{EditId}.dblClickEdit(row.id)", append: true );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public void ConfigContent() {
            _config.Content.AppendTo( this );
        }
    }
}