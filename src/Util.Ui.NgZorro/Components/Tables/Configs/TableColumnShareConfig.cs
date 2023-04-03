using Util.Helpers;
using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Configs {
    /// <summary>
    /// 表格列共享配置
    /// </summary>
    public class TableColumnShareConfig {
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;
        /// <summary>
        /// 编辑控件模板标识
        /// </summary>
        private string _controlTemplateId;

        /// <summary>
        /// 初始化表格列共享配置
        /// </summary>
        /// <param name="tableShareConfig">表格共享配置</param>
        public TableColumnShareConfig( TableShareConfig tableShareConfig ) {
            _tableShareConfig = tableShareConfig;
            IsAutoCreateControl = true;
            Column = Id.Create();
        }

        /// <summary>
        /// 是否树形表格
        /// </summary>
        public bool IsTreeTable => _tableShareConfig.IsTreeTable;

        /// <summary>
        /// 是否启用基础扩展
        /// </summary>
        public bool IsEnableExtend => _tableShareConfig.IsEnableExtend;

        /// <summary>
        /// 是否启用编辑模式
        /// </summary>
        public bool IsEnableEdit => _tableShareConfig.IsEnableEdit;

        /// <summary>
        /// 表格扩展标识
        /// </summary>
        public string TableExtendId => _tableShareConfig.TableExtendId;

        /// <summary>
        /// 表格编辑扩展标识
        /// </summary>
        public string TableEditId => _tableShareConfig.TableEditId;

        /// <summary>
        /// 表格主体行标识
        /// </summary>
        public string RowId => _tableShareConfig.RowId;

        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// 编辑控件模板标识
        /// </summary>
        public string ControlTemplateId => _controlTemplateId.IsEmpty() ? $"{TableEditId}_{Column}" : _controlTemplateId;

        /// <summary>
        /// 是否自动创建编辑列控件区域
        /// </summary>
        public bool IsAutoCreateControl { get; set; }

        /// <summary>
        /// 是否显示复选框
        /// </summary>
        public bool IsShowCheckbox => _tableShareConfig.IsShowCheckbox;

        /// <summary>
        /// 是否显示单选框
        /// </summary>
        public bool IsShowRadio => _tableShareConfig.IsShowRadio;

        /// <summary>
        /// 是否仅能选择单选框叶节点
        /// </summary>
        public bool IsCheckLeafOnly => _tableShareConfig.IsCheckLeafOnly;

        /// <summary>
        /// 是否显示序号
        /// </summary>
        public bool IsShowLineNumber => _tableShareConfig.IsShowLineNumber;

        /// <summary>
        /// 是否第一列
        /// </summary>
        public bool IsFirst { get; set; }

        /// <summary>
        /// 设置第一列
        /// </summary>
        public void SetIsFirst() {
            if ( _tableShareConfig.Columns.Count == 0 )
                IsFirst = true;
        }

        /// <summary>
        /// 设置编辑控件模板标识
        /// </summary>
        /// <param name="controlTemplateId">编辑控件模板标识</param>
        public void SetControlTemplateId( string controlTemplateId ) {
            _controlTemplateId = controlTemplateId;
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="column">列信息</param>
        public void AddColumn( ColumnInfo column ) {
            if ( column == null )
                return;
            Column = column.Column;
            _tableShareConfig.Columns.Add( column );
        }

        /// <summary>
        /// 启用编辑模式
        /// </summary>
        public void EnableEdit() {
            _tableShareConfig.IsEnableEdit = true;
        }

        /// <summary>
        /// 启用自动省略
        /// </summary>
        public void EnableEllipsis() {
            _tableShareConfig.IsEnableEllipsis = true;
        }
    }
}
