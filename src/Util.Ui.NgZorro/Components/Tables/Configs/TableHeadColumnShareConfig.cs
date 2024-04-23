using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Configs;

/// <summary>
/// 表头列共享配置
/// </summary>
public class TableHeadColumnShareConfig {
    /// <summary>
    /// 表格共享配置
    /// </summary>
    private readonly TableShareConfig _tableShareConfig;

    /// <summary>
    /// 初始化表头列共享配置
    /// </summary>
    /// <param name="tableShareConfig">表格共享配置</param>
    public TableHeadColumnShareConfig( TableShareConfig tableShareConfig ) {
        _tableShareConfig = tableShareConfig;
        Index = _tableShareConfig.HeadColumnNumber;
        _tableShareConfig.HeadColumnNumber++;
    }

    /// <summary>
    /// 是否树形表格
    /// </summary>
    public bool IsTreeTable => _tableShareConfig.IsTreeTable;

    /// <summary>
    /// 表格扩展标识
    /// </summary>
    public string TableExtendId => _tableShareConfig.TableExtendId;

    /// <summary>
    /// 表格编辑扩展标识
    /// </summary>
    public string TableEditId => _tableShareConfig.TableEditId;

    /// <summary>
    /// 是否显示复选框
    /// </summary>
    public bool IsShowCheckbox => _tableShareConfig.IsShowCheckbox;

    /// <summary>
    /// 是否显示单选框
    /// </summary>
    public bool IsShowRadio => _tableShareConfig.IsShowRadio;

    /// <summary>
    /// 是否显示序号
    /// </summary>
    public bool IsShowLineNumber => _tableShareConfig.IsShowLineNumber;

    /// <summary>
    /// 表头行数
    /// </summary>
    public int HeadRowNumber => _tableShareConfig.HeadRowNumber;

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
    /// 是否自动创建表头单元格th
    /// </summary>
    public bool IsAutoCreateHeadColumn {
        get => _tableShareConfig.IsAutoCreateHeadColumn;
        set => _tableShareConfig.IsAutoCreateHeadColumn = value;
    }

    /// <summary>
    /// 索引
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// 是否第一列
    /// </summary>
    public bool IsFirst => Index == 0;

    /// <summary>
    /// 是否最后一列
    /// </summary>
    public bool IsLast => _tableShareConfig.Columns.Count == Index + 1;

    /// <summary>
    /// 是否启用自定义列
    /// </summary>
    public bool IsEnableCustomColumn => _tableShareConfig.IsEnableCustomColumn;

    /// <summary>
    /// 表格设置是否启用固定列
    /// </summary>
    public bool IsEnableFixedColumn => _tableShareConfig.IsEnableFixedColumn;

    /// <summary>
    /// 是否启用拖动调整列宽
    /// </summary>
    public bool IsEnableResizable {
        get {
            var headColumn = _tableShareConfig.GetHeadColumn( Index );
            if ( headColumn is { IsEnableResizable: true } )
                return true;
            if ( _tableShareConfig.IsEnableResizable == false )
                return false;
            if ( _tableShareConfig.IsEnableCustomColumn )
                return true;
            return _tableShareConfig.Columns.Count <= 1 || IsLast == false;
        }
    }

    /// <summary>
    /// 是否启用表格设置
    /// </summary>
    public bool IsEnableTableSettings {
        get {
            if ( _tableShareConfig.ColumnNumber == 0 )
                return false;
            if ( IsEnableCustomColumn )
                return true;
            if ( IsEnableFixedColumn )
                return true;
            var headColumn = _tableShareConfig.GetHeadColumn( Index );
            if ( headColumn is { IsEnableResizable: true } )
                return true;
            return _tableShareConfig.IsEnableResizable;
        }
    }

    /// <summary>
    /// 自定义列标识
    /// </summary>
    public string CellControl {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column?.GetCellControl();
        }
    }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column?.Title;
        }
    }

    /// <summary>
    /// 对齐方式
    /// </summary>
    public string Align {
        get {
            var column = _tableShareConfig.GetColumn( Index );
            return column?.Align;
        }
    }

    /// <summary>
    /// 标题对齐方式
    /// </summary>
    public string TitleAlign {
        get {
            var column = _tableShareConfig.GetHeadColumn( Index );
            return column?.TitleAlign;
        }
    }

    /// <summary>
    /// 表格设置组件标识
    /// </summary>
    public string TableSettingsId => _tableShareConfig.TableSettingsId;

    /// <summary>
    /// 添加列
    /// </summary>
    /// <param name="column">列信息</param>
    public void AddColumn( HeadColumnInfo column ) {
        if ( column == null )
            return;
        column.Index = Index;
        _tableShareConfig.HeadColumns.Add( column );
        if ( column.IsEnableResizable == true )
            _tableShareConfig.IsEnableResizable = true;
        InitLeft( column );
    }

    /// <summary>
    /// 初始化左侧固定
    /// </summary>
    private void InitLeft( HeadColumnInfo column ) {
        if ( IsFirst && column.IsLeft == "true" ) {
            _tableShareConfig.IsCheckboxLeft = "true";
            _tableShareConfig.IsRadioLeft = "true";
            _tableShareConfig.IsLineNumberLeft = "true";
        }
    }
}