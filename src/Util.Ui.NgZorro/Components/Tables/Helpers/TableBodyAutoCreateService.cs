using System;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格主体嵌套结构自动创建服务
    /// </summary>
    public class TableBodyAutoCreateService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;
        /// <summary>
        /// 表格主体标签生成器
        /// </summary>
        private readonly TableBodyBuilder _bodyBuilder;

        /// <summary>
        /// 初始化表格主体嵌套结构自动创建服务
        /// </summary>
        /// <param name="bodyBuilder">表格主体标签生成器</param>
        public TableBodyAutoCreateService( TableBodyBuilder bodyBuilder ) {
            _bodyBuilder = bodyBuilder ?? throw new ArgumentNullException( nameof( bodyBuilder ) );
            _config = _bodyBuilder.GetConfig();
            _shareConfig = _bodyBuilder.GetTableShareConfig();
        }

        /// <summary>
        /// 自动创建嵌套结构
        /// </summary>
        public void Init() {
            if ( _shareConfig.Columns.Count == 0 )
                return;
            CancelAutoCreate();
            AddBodyRow();
        }

        /// <summary>
        /// 取消自动创建
        /// </summary>
        private void CancelAutoCreate() {
            var result = _config.GetValueFromAttributes<bool?>( UiConst.EnableAutoCreate );
            if ( result == false )
                _shareConfig.IsAutoCreateBodyRow = false;
        }

        /// <summary>
        /// 添加表格主体行
        /// </summary>
        private void AddBodyRow() {
            if ( _shareConfig.IsAutoCreateBodyRow == false )
                return;
            _shareConfig.BodyRowAutoCreated = true;
            var rowBuilder = _bodyBuilder.CreateTableBodyRowBuilder();
            _bodyBuilder.AppendContent( rowBuilder );
            rowBuilder.Config();
        }
    }
}
