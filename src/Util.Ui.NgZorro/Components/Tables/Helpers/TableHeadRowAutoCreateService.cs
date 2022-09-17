using System;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表头行嵌套结构自动创建服务
    /// </summary>
    public class TableHeadRowAutoCreateService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;
        /// <summary>
        /// 表格行标签生成器
        /// </summary>
        private readonly TableRowBuilder _rowBuilder;

        /// <summary>
        /// 初始化表头行嵌套结构自动创建服务
        /// </summary>
        /// <param name="rowBuilder">表格行标签生成器</param>
        public TableHeadRowAutoCreateService( TableRowBuilder rowBuilder ) {
            _rowBuilder = rowBuilder ?? throw new ArgumentNullException( nameof( rowBuilder ) );
            _config = _rowBuilder.GetConfig();
            _shareConfig = _rowBuilder.GetTableShareConfig();
        }

        /// <summary>
        /// 自动创建嵌套结构
        /// </summary>
        public void Init() {
            CancelAutoCreate();
            AddHeadColumns();
        }

        /// <summary>
        /// 取消自动创建
        /// </summary>
        private void CancelAutoCreate() {
            var result = _config.GetValueFromAttributes<bool?>( UiConst.EnableAutoCreate );
            if ( result == false ) {
                _shareConfig.IsAutoCreateHeadColumn = false;
            }
        }

        /// <summary>
        /// 添加表头单元格
        /// </summary>
        private void AddHeadColumns() {
            if ( _shareConfig.Columns.Count == 0 )
                return;
            if ( _shareConfig.IsAutoCreateHeadColumn == false )
                return;
            _shareConfig.HeadColumnAutoCreated = true;
            foreach ( var column in _shareConfig.Columns ) {
                var columnBuilder = new TableHeadColumnBuilder( _config );
                columnBuilder.AddComponents( column );
                _rowBuilder.AppendContent( columnBuilder );
            }
        }
    }
}
