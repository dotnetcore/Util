using System;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格头嵌套结构自动创建服务
    /// </summary>
    public class TableHeadAutoCreateService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;
        /// <summary>
        /// 表格头标签生成器
        /// </summary>
        private readonly TableHeadBuilder _headBuilder;

        /// <summary>
        /// 初始化表格头嵌套结构自动创建服务
        /// </summary>
        /// <param name="headBuilder">表格头标签生成器</param>
        public TableHeadAutoCreateService( TableHeadBuilder headBuilder ) {
            _headBuilder = headBuilder ?? throw new ArgumentNullException( nameof( headBuilder ) );
            _config = _headBuilder.GetConfig();
            _shareConfig = _headBuilder.GetTableShareConfig();
        }

        /// <summary>
        /// 自动创建嵌套结构
        /// </summary>
        public void Init() {
            CancelAutoCreate();
            AddHeadRow();
        }

        /// <summary>
        /// 取消自动创建
        /// </summary>
        private void CancelAutoCreate() {
            var result = _config.GetValueFromAttributes<bool?>( UiConst.EnableAutoCreate );
            if ( result == false ) {
                _shareConfig.IsAutoCreateHeadRow = false;
                _shareConfig.IsAutoCreateHeadColumn = false;
            }
        }

        /// <summary>
        /// 添加表头行
        /// </summary>
        private void AddHeadRow() {
            if ( _shareConfig.Columns.Count == 0 && _config.Content.IsEmpty() )
                return;
            if ( _shareConfig.IsAutoCreateHeadRow == false )
                return;
            _shareConfig.HeadRowAutoCreated = true;
            var rowBuilder = _headBuilder.CreateTableHeadRowBuilder();
            _headBuilder.AppendContent( rowBuilder );
            rowBuilder.ConfigAutoCreate();
            rowBuilder.ConfigContent();
        }
    }
}
