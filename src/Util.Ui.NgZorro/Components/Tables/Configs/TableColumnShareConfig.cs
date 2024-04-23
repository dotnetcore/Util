using Util.Helpers;
using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Configs;

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
        Index = _tableShareConfig.ColumnNumber;
        _tableShareConfig.ColumnNumber++;
        Column = Id.Create();
    }

    /// <summary>
    /// 表格设置组件标识
    /// </summary>
    public string TableSettingsId => _tableShareConfig.TableSettingsId;

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
    /// 是否启用表格设置
    /// </summary>
    public bool IsEnableTableSettings => _tableShareConfig.IsEnableTableSettings;

    /// <summary>
    /// 是否启用自定义列
    /// </summary>
    public bool IsEnableCustomColumn => _tableShareConfig.IsEnableCustomColumn;

    /// <summary>
    /// 表格设置是否启用固定列
    /// </summary>
    public bool IsEnableFixedColumn => _tableShareConfig.IsEnableFixedColumn;

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
    /// 标题
    /// </summary>
    public string Title {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column.Title;
        }
    }

    /// <summary>
    /// 列名
    /// </summary>
    public string Column { get; set; }

    /// <summary>
    /// 索引
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// 自定义列标识
    /// </summary>
    public string CellControl {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column.GetCellControl();
        }
    }

    /// <summary>
    /// 对齐方式
    /// </summary>
    public string Align {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column.Align;
        }
    }

    /// <summary>
    /// 固定左侧
    /// </summary>
    public string IsLeft {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column.IsLeft;
        }
    }

    /// <summary>
    /// 固定右侧
    /// </summary>
    public string IsRight {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column.IsRight;
        }
    }

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
    /// 固定复选框到左侧
    /// </summary>
    public string IsCheckboxLeft => _tableShareConfig.IsCheckboxLeft;

    /// <summary>
    /// 固定单选框到左侧
    /// </summary>
    public string IsRadioLeft => _tableShareConfig.IsRadioLeft;

    /// <summary>
    /// 固定序号到左侧
    /// </summary>
    public string IsLineNumberLeft => _tableShareConfig.IsLineNumberLeft;

    /// <summary>
    /// 是否第一列
    /// </summary>
    public bool IsFirst => Index == 0;

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
        column.Index = Index;
        Column = column.Column;
        var headColumn = _tableShareConfig.GetHeadColumn( Index );
        if ( headColumn != null ) {
            if ( headColumn.Title.IsEmpty() == false )
                column.Title = headColumn.Title;
            if ( headColumn.CellControl.IsEmpty() == false )
                column.CellControl = headColumn.CellControl;
            if ( headColumn.Align.IsEmpty() == false )
                column.Align = headColumn.Align;
            if ( headColumn.TitleAlign.IsEmpty() == false )
                column.TitleAlign = headColumn.TitleAlign;
            if ( headColumn.Width.IsEmpty() == false )
                column.Width = headColumn.Width;
            if ( headColumn.Ellipsis != null )
                column.Ellipsis = headColumn.Ellipsis;
            if ( headColumn.IsLeft != null )
                column.IsLeft = headColumn.IsLeft;
            if ( headColumn.IsRight != null )
                column.IsRight = headColumn.IsRight;
        }
        _tableShareConfig.Columns.Add( column );
        if ( column.IsEnableResizable )
            _tableShareConfig.IsEnableResizable = true;
        InitLeft();
    }

    /// <summary>
    /// 初始化左侧固定
    /// </summary>
    private void InitLeft() {
        if ( IsFirst && IsLeft == "true" ) {
            _tableShareConfig.IsCheckboxLeft = "true";
            _tableShareConfig.IsRadioLeft = "true";
            _tableShareConfig.IsLineNumberLeft = "true";
        }
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