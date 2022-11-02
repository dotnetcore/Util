using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格编辑列控件区域服务
    /// </summary>
    public class TableColumnControlService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private readonly TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格编辑列控件区域服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableColumnControlService( Config config ) {
            _config = config;
            _shareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        private TableColumnShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>() ?? new TableColumnShareConfig(new TableShareConfig());
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            CancelAutoCreateControl();
            ConfigControlTemplateId();
        }

        /// <summary>
        /// 取消自动创建编辑列控件区域
        /// </summary>
        private void CancelAutoCreateControl() {
            _shareConfig.IsAutoCreateControl = false;
        }

        /// <summary>
        /// 配置编辑控件模板标识
        /// </summary>
        private void ConfigControlTemplateId() {
            var id = _config.GetValue( UiConst.Id );
            if ( id.IsEmpty() )
                return;
            _shareConfig.SetControlTemplateId( id );
        }
    }
}
