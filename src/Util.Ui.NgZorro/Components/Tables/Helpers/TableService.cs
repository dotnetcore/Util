using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格服务
    /// </summary>
    public class TableService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        public TableShareConfig GetShareConfig() {
            return _shareConfig;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            CreateShareConfig();
            EnableExtend();
        }

        /// <summary>
        /// 创建共享配置
        /// </summary>
        private void CreateShareConfig() {
            _shareConfig = new TableShareConfig( GetTableId() );
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取表格标识
        /// </summary>
        private string GetTableId() {
            return _config.GetValue( UiConst.Id );
        }

        /// <summary>
        /// 启用基础扩展
        /// </summary>
        private void EnableExtend() {
            if ( GetEnableExtend() == true ) {
                _shareConfig.IsEnableExtend = true;
                return;
            }
            if ( GetEnableExtend() == false ) {
                _shareConfig.IsEnableExtend = false;
                return;
            }
            if ( GetUrl().IsEmpty() == false ) {
                _shareConfig.IsEnableExtend = true;
                return;
            }
            if ( GetBindUrl().IsEmpty() == false ) {
                _shareConfig.IsEnableExtend = true;
                return;
            }
        }

        /// <summary>
        /// 获取启用扩展属性
        /// </summary>
        private bool? GetEnableExtend() {
            return _config.GetValue<bool?>( UiConst.EnableExtend );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetUrl() {
            return _config.GetValue( UiConst.Url );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetBindUrl() {
            return _config.GetValue( AngularConst.BindUrl );
        }
    }
}
