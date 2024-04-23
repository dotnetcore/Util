using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表格服务
/// </summary>
public class TableService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格共享配置
    /// </summary>
    private TableShareConfig _shareConfig;

    /// <summary>
    /// 初始化表格服务
    /// </summary>
    /// <param name="config">配置</param>
    public TableService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取共享配置
    /// </summary>
    public TableShareConfig GetShareConfig() {
        return _shareConfig;
    }

    /// <summary>
    /// 初始化树形表格标识
    /// </summary>
    public void InitTreeTable() {
        _shareConfig.IsTreeTable = true;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateShareConfig();
        SetTableSettings();
        SetScroll();
        SetIsShowCheckbox();
        SetIsShowRadio();
        SetIsCheckLeafOnly();
        SetIsShowLineNumber();
        SetOnClickRow();
        EnableExtend();
    }

    /// <summary>
    /// 创建共享配置
    /// </summary>
    private void CreateShareConfig() {
        _shareConfig = new TableShareConfig( GetTableId() );
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 获取表格标识
    /// </summary>
    private string GetTableId() {
        return _config.GetValue( UiConst.Id );
    }

    /// <summary>
    /// 设置表格设置参数
    /// </summary>
    private void SetTableSettings() {
        _shareConfig.Key = GetKey();
        if ( _config.GetValue<bool>( UiConst.EnableTableSettings ) ) {
            _shareConfig.IsEnableCustomColumn = true;
            _shareConfig.IsEnableResizable = true;
            _shareConfig.IsEnableFixedColumn = true;
            return;
        }
        _shareConfig.IsEnableCustomColumn = _config.GetValue<bool>( UiConst.EnableCustomColumn );
        _shareConfig.IsEnableResizable = _config.GetValue<bool>( UiConst.EnableResizable );
        _shareConfig.IsEnableFixedColumn = _config.GetValue<bool>( UiConst.EnableFixedColumn );
    }

    /// <summary>
    /// 获取表格参数存储标识
    /// </summary>
    private string GetKey() {
        var result = _config.GetValue( UiConst.Key );
        return result.IsEmpty() ? _config.GetValue( UiConst.Id ) : result;
    }

    /// <summary>
    /// 设置表格滚动参数
    /// </summary>
    private void SetScroll() {
        _shareConfig.ScrollWidth = _config.GetValue( UiConst.ScrollWidth );
        _shareConfig.ScrollHeight = _config.GetValue( UiConst.ScrollHeight );
    }

    /// <summary>
    /// 设置是否显示复选框
    /// </summary>
    private void SetIsShowCheckbox() {
        _shareConfig.IsShowCheckbox = _config.GetValue<bool>( UiConst.ShowCheckbox );
        _shareConfig.IsCheckboxLeft = _config.GetValue( UiConst.CheckboxLeft );
    }

    /// <summary>
    /// 设置是否显示单选框
    /// </summary>
    private void SetIsShowRadio() {
        _shareConfig.IsShowRadio = _config.GetValue<bool>( UiConst.ShowRadio );
        _shareConfig.IsRadioLeft = _config.GetValue( UiConst.RadioLeft );
    }

    /// <summary>
    /// 设置是否仅能选择单选框叶节点
    /// </summary>
    private void SetIsCheckLeafOnly() {
        _shareConfig.IsCheckLeafOnly = _config.GetValue<bool>( UiConst.CheckLeafOnly );
    }

    /// <summary>
    /// 设置是否显示序号
    /// </summary>
    private void SetIsShowLineNumber() {
        _shareConfig.IsShowLineNumber = _config.GetValue<bool>( UiConst.ShowLineNumber );
        _shareConfig.IsLineNumberLeft = _config.GetValue( UiConst.LineNumberLeft );
    }

    /// <summary>
    /// 设置单击行事件
    /// </summary>
    private void SetOnClickRow() {
        _shareConfig.OnClickRow = _config.GetValue( UiConst.OnClickRow );
        _shareConfig.SelectOnClickRow = _config.GetValue<bool>( UiConst.SelectOnClickRow );
        _shareConfig.SelectOnlyOnClickRow = _config.GetValue<bool>( UiConst.SelectOnlyOnClickRow );
        _shareConfig.CheckOnClickRow = _config.GetValue<bool>( UiConst.CheckOnClickRow );
    }

    /// <summary>
    /// 启用基础扩展
    /// </summary>
    private void EnableExtend() {
        if ( GetEnableExtend() == false ) {
            _shareConfig.IsEnableExtend = false;
            return;
        }
        if ( GetEnableExtend() == true ||
             GetUrl().IsEmpty() == false ||
             GetBindUrl().IsEmpty() == false ||
             GetLoadUrl().IsEmpty() == false ||
             GetBindLoadUrl().IsEmpty() == false ||
             GetQueryUrl().IsEmpty() == false ||
             GetBindQueryUrl().IsEmpty() == false ||
             GetLoadChildrenUrl().IsEmpty() == false ||
             GetBindLoadChildrenUrl().IsEmpty() == false ||
             _shareConfig.IsShowCheckbox ||
             _shareConfig.IsShowRadio ||
             _shareConfig.IsShowLineNumber ) {
            _shareConfig.IsEnableExtend = true;
        }
    }

    /// <summary>
    /// 获取启用扩展属性
    /// </summary>
    private bool? GetEnableExtend() {
        return _config.GetValue<bool?>( UiConst.EnableExtend );
    }

    /// <summary>
    /// 获取地址
    /// </summary>
    private string GetUrl() {
        return _config.GetValue( UiConst.Url );
    }

    /// <summary>
    /// 获取地址
    /// </summary>
    private string GetBindUrl() {
        return _config.GetValue( AngularConst.BindUrl );
    }

    /// <summary>
    /// 获取加载地址
    /// </summary>
    private string GetLoadUrl() {
        return _config.GetValue( UiConst.LoadUrl );
    }

    /// <summary>
    /// 获取加载地址
    /// </summary>
    private string GetBindLoadUrl() {
        return _config.GetValue( AngularConst.BindLoadUrl );
    }

    /// <summary>
    /// 获取查询地址
    /// </summary>
    private string GetQueryUrl() {
        return _config.GetValue( UiConst.QueryUrl );
    }

    /// <summary>
    /// 获取查询地址
    /// </summary>
    private string GetBindQueryUrl() {
        return _config.GetValue( AngularConst.BindQueryUrl );
    }

    /// <summary>
    /// 获取加载下级节点地址
    /// </summary>
    private string GetLoadChildrenUrl() {
        return _config.GetValue( UiConst.LoadChildrenUrl );
    }

    /// <summary>
    /// 获取加载下级节点地址
    /// </summary>
    private string GetBindLoadChildrenUrl() {
        return _config.GetValue( AngularConst.BindLoadChildrenUrl );
    }
}