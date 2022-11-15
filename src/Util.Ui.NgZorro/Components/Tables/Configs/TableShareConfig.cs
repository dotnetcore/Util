using System.Collections.Generic;
using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Configs {
    /// <summary>
    /// 表格共享配置
    /// </summary>
    public class TableShareConfig {
        /// <summary>
        /// 表格主体行标识
        /// </summary>
        private string _rowId;

        /// <summary>
        /// 初始化表格共享配置
        /// </summary>
        /// <param name="id">表格标识</param>
        public TableShareConfig( string id = null ) {
            Id = id.IsEmpty() ? Util.Helpers.Id.Create() : id;
            Columns = new List<ColumnInfo>();
            IsAutoCreateHead = true;
            IsAutoCreateHeadRow = true;
            IsAutoCreateHeadColumn = true;
            IsAutoCreateBody = true;
            IsAutoCreateBodyRow = true;
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// 表格扩展标识
        /// </summary>
        public string TableExtendId => $"x_{Id}";

        /// <summary>
        /// 表格编辑扩展标识
        /// </summary>
        public string TableEditId => $"e_{Id}";

        /// <summary>
        /// 表格主体行标识
        /// </summary>
        public string RowId => _rowId.IsEmpty() ? $"{Id}_row" : _rowId;

        /// <summary>
        /// 设置表格主体行标识
        /// </summary>
        /// <param name="rowId">行标识</param>
        public void SetRowId( string rowId ) {
            _rowId = rowId;
        }

        /// <summary>
        /// 表格总行数模板标识
        /// </summary>
        public string TotalTemplateId => $"total_{Id}";

        /// <summary>
        /// 列信息集合
        /// </summary>
        public List<ColumnInfo> Columns { get; }

        /// <summary>
        /// 表头列数
        /// </summary>
        public int HeadColumnNumber { get; set; }

        /// <summary>
        /// 是否自动创建表头thead
        /// </summary>
        public bool IsAutoCreateHead { get; set; }

        /// <summary>
        /// 表头thead已自动创建
        /// </summary>
        public bool HeadAutoCreated { get; set; }

        /// <summary>
        /// 是否自动创建表头行tr
        /// </summary>
        public bool IsAutoCreateHeadRow { get; set; }

        /// <summary>
        /// 表头行tr已自动创建
        /// </summary>
        public bool HeadRowAutoCreated { get; set; }

        /// <summary>
        /// 是否自动创建表头单元格th
        /// </summary>
        public bool IsAutoCreateHeadColumn { get; set; }

        /// <summary>
        /// 表头单元格th已自动创建
        /// </summary>
        public bool HeadColumnAutoCreated { get; set; }

        /// <summary>
        /// 是否自动创建表格主体tbody
        /// </summary>
        public bool IsAutoCreateBody { get; set; }

        /// <summary>
        /// 表格主体tbody已自动创建
        /// </summary>
        public bool BodyAutoCreated { get; set; }

        /// <summary>
        /// 是否自动创建表格主体行tr
        /// </summary>
        public bool IsAutoCreateBodyRow { get; set; }

        /// <summary>
        /// 表格主体行tr已自动创建
        /// </summary>
        public bool BodyRowAutoCreated { get; set; }

        /// <summary>
        /// 是否启用基础扩展
        /// </summary>
        public bool IsEnableExtend { get; set; }

        /// <summary>
        /// 是否启用自动省略
        /// </summary>
        public bool IsEnableEllipsis { get; set; }

        /// <summary>
        /// 是否启用编辑模式
        /// </summary>
        public bool IsEnableEdit { get; set; }

        /// <summary>
        /// 是否显示复选框
        /// </summary>
        public bool IsShowCheckbox { get; set; }

        /// <summary>
        /// 是否显示单选框
        /// </summary>
        public bool IsShowRadio { get; set; }

        /// <summary>
        /// 是否显示序号
        /// </summary>
        public bool IsShowLineNumber { get; set; }

        /// <summary>
        /// 是否树形表格
        /// </summary>
        public bool IsTreeTable { get; set; }

        /// <summary>
        /// 是否仅能选择单选框叶节点
        /// </summary>
        public bool IsCheckLeafOnly { get; set; }
    }
}
