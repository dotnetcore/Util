using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表格列服务
/// </summary>
public class TableColumnService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格列共享配置
    /// </summary>
    private TableColumnShareConfig _shareConfig;

    /// <summary>
    /// 初始化表格列服务
    /// </summary>
    /// <param name="config">配置</param>
    public TableColumnService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateTableColumnShareConfig();
        LoadExpression();
        EnableEdit();
        EnableEllipsis();
        AddToColumns();
    }

    /// <summary>
    /// 创建表格列共享配置
    /// </summary>
    private void CreateTableColumnShareConfig() {
        _shareConfig = new TableColumnShareConfig( GetTableShareConfig() );
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 获取表格共享配置
    /// </summary>
    private TableShareConfig GetTableShareConfig() {
        return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var expressionLoader = new TableColumnExpressionLoader();
        expressionLoader.Load( _config );
    }

    /// <summary>
    /// 启用编辑模式
    /// </summary>
    private void EnableEdit() {
        var result = _config.GetValue<bool>( UiConst.IsEdit );
        if ( result )
            _shareConfig.EnableEdit();
    }

    /// <summary>
    /// 启用自动省略
    /// </summary>
    private void EnableEllipsis() {
        var result = _config.GetValue<bool>( UiConst.Ellipsis );
        if ( result )
            _shareConfig.EnableEllipsis();
    }

    /// <summary>
    /// 将当前列添加到表格列集合中
    /// </summary>
    private void AddToColumns() {
        _shareConfig.AddColumn( GetColumnInfo() );
    }

    /// <summary>
    /// 获取列信息
    /// </summary>
    private ColumnInfo GetColumnInfo() {
        var result = new ColumnInfo {
            Title = GetTitle(),
            Column = _config.GetValue( UiConst.Column ),
            CellControl = _config.GetValue( UiConst.CellControl ),
            Align = _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description(),
            Width = _config.GetValue( UiConst.Width ),
            Ellipsis = _config.GetValue<bool?>( UiConst.Ellipsis ),
            IsSort = _config.GetValue<bool>( UiConst.Sort ),
            IsFirst = _shareConfig.IsFirst,
            IsLeft = _config.GetValue( UiConst.Left ),
            IsRight = _config.GetValue( UiConst.Right ),
            Acl = _config.GetValue( UiConst.Acl ),
            AclElseTemplateId = _config.GetValue( UiConst.AclElseTemplateId ),
            IsEnableResizable = _config.GetValue<bool>( UiConst.EnableResizable )
        };
        if ( IsInColumnDisplay() )
            result.IsInner = true;
        return result;
    }

    /// <summary>
    /// 获取标题
    /// </summary>
    private string GetTitle() {
        var result = _config.GetValue( UiConst.Title );
        if ( result.IsEmpty() == false )
            return result;
        return GetOperationTitle();
    }

    /// <summary>
    /// 获取Operation标题
    /// </summary>
    private string GetOperationTitle() {
        var value = _config.GetValue<bool?>( UiConst.TitleOperation );
        if ( value != true )
            return null;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n )
            return "util.operation";
        return "Operation";
    }

    /// <summary>
    /// 是否包含在显示列中
    /// </summary>
    private bool IsInColumnDisplay() {
        var displayShareConfig = _config.GetValueFromItems<TableColumnDisplayShareConfig>();
        return displayShareConfig != null;
    }
}