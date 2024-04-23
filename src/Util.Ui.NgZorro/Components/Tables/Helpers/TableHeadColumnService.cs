using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表头单元格服务
/// </summary>
public class TableHeadColumnService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格共享配置
    /// </summary>
    private TableHeadColumnShareConfig _shareConfig;

    /// <summary>
    /// 初始化表头单元格服务
    /// </summary>
    /// <param name="config">配置</param>
    public TableHeadColumnService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateTableHeadColumnShareConfig();
        LoadExpression();
        CancelAutoCreateHeadColumn();
        SetColumn();
    }

    /// <summary>
    /// 创建表头列共享配置
    /// </summary>
    private void CreateTableHeadColumnShareConfig() {
        _shareConfig = new TableHeadColumnShareConfig( GetTableShareConfig() );
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
        var expressionLoader = new TableHeadColumnExpressionLoader();
        expressionLoader.Load( _config );
    }

    /// <summary>
    /// 取消自动创建表头单元格
    /// </summary>
    private void CancelAutoCreateHeadColumn() {
        _shareConfig.IsAutoCreateHeadColumn = false;
    }

    /// <summary>
    /// 设置表头列
    /// </summary>
    public void SetColumn() {
        _shareConfig.AddColumn( new HeadColumnInfo {
            Title = GetTitle(), 
            Width = _config.GetValue( UiConst.Width ),
            Align = _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description(),
            TitleAlign = _config.GetValue<TableHeadColumnAlign?>( UiConst.TitleAlign )?.Description(),
            Ellipsis = _config.GetValue<bool?>( UiConst.Ellipsis ),
            IsLeft = _config.GetValue( UiConst.Left ),
            IsRight = _config.GetValue( UiConst.Right ),
            CellControl = _config.GetValue( UiConst.CellControl ),
            IsEnableResizable = _config.GetValue<bool?>( UiConst.EnableResizable )
        } );
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
}