using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格编辑列控件区域标签生成器
    /// </summary>
    public class TableColumnControlBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private readonly TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格编辑列控件区域标签生成器
        /// </summary>
        public TableColumnControlBuilder( Config config ) : base( config,"ng-template" ) {
            _config = config;
            _shareConfig = GetTableColumnShareConfig();
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        private TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }

        /// <inheritdoc />
        protected override void ConfigId( Config config ) {
            this.RawId( _config );
            if ( config.Contains( UiConst.Id ) ) {
                this.Id( _config.GetValue( UiConst.Id ) );
                return;
            }
            this.Id( _shareConfig?.ControlTemplateId );
        }
    }
}