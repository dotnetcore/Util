using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格编辑列显示区域标签生成器
    /// </summary>
    public class TableColumnDisplayBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private readonly TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格编辑列显示区域标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TableColumnDisplayBuilder( Config config ) : base( config, "ng-container" ) {
            _config = config;
            _shareConfig = GetTableColumnShareConfig();
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        private TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            if ( _shareConfig == null )
                return;
            this.NgIf( $"{_shareConfig.TableEditId}.editId !== row.id;else {_shareConfig.ControlTemplateId}" );
        }
    }
}