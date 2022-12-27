using System;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格嵌套结构自动创建服务
    /// </summary>
    public class TableAutoCreateService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;
        /// <summary>
        /// 表格标签生成器
        /// </summary>
        private readonly TableBuilder _tableBuilder;

        /// <summary>
        /// 初始化表格嵌套结构自动创建服务
        /// </summary>
        /// <param name="tableBuilder">表格标签生成器</param>
        public TableAutoCreateService( TableBuilder tableBuilder ) {
            _tableBuilder = tableBuilder ?? throw new ArgumentNullException( nameof( tableBuilder ) );
            _config = tableBuilder.GetConfig();
            _shareConfig = tableBuilder.GetShareConfig();
        }

        /// <summary>
        /// 自动创建嵌套结构
        /// </summary>
        public void Init() {
            if ( _shareConfig.Columns.Count == 0 )
                return;
            CancelAutoCreate();
            AddHead();
            AddBody();
        }

        /// <summary>
        /// 取消自动创建
        /// </summary>
        private void CancelAutoCreate() {
            var result = _config.GetValueFromAttributes<bool?>( UiConst.EnableAutoCreate );
            if ( result == false ) {
                _shareConfig.IsAutoCreateHead = false;
                _shareConfig.IsAutoCreateHeadRow = false;
                _shareConfig.IsAutoCreateHeadColumn = false;
                _shareConfig.IsAutoCreateBody = false;
                _shareConfig.IsAutoCreateBodyRow = false;
            }
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        private void AddHead() {
            if ( _shareConfig.IsAutoCreateHead == false )
                return;
            _shareConfig.HeadAutoCreated = true;
            var headBuilder = _tableBuilder.CreateTableHeadBuilder();
            _tableBuilder.AppendContent( headBuilder );
            headBuilder.ConfigAutoCreate();
            headBuilder.ConfigContent();
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        private void AddBody() {
            if ( _shareConfig.IsAutoCreateBody == false )
                return;
            _shareConfig.BodyAutoCreated = true;
            var bodyBuilder = _tableBuilder.CreateTableBodyBuilder();
            _tableBuilder.AppendContent( bodyBuilder );
            bodyBuilder.ConfigAutoCreate();
            bodyBuilder.ConfigContent();
        }
    }
}
