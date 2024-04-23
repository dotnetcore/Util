using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;

namespace Util.Ui.NgZorro.Components.Grids.Builders;

/// <summary>
/// 栅格列生成器
/// </summary>
public class ColumnBuilder : ColumnBuilderBase<ColumnBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表单共享配置
    /// </summary>
    private FormShareConfig _formShareConfig;
    /// <summary>
    /// 标识
    /// </summary>
    private readonly string _id;

    /// <summary>
    /// 初始化栅格列生成器
    /// </summary>
    public ColumnBuilder( Config config, string id ) : base( config, "div" ) {
        _config = config;
        _formShareConfig = GetFormShareConfig();
        _id = id;
        base.Attribute( "nz-col" );
    }

    /// <summary>
    /// 获取表单共享配置
    /// </summary>
    public FormShareConfig GetFormShareConfig() {
        return _formShareConfig ??= _config.GetValueFromItems<FormShareConfig>() ?? new FormShareConfig();
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        ConfigSearchForm();
        base.Config();
        ConfigColumn();
    }

    /// <summary>
    /// 配置搜索表单
    /// </summary>
    protected virtual void ConfigSearchForm() {
        if ( _formShareConfig == null )
            return;
        if ( _formShareConfig.IsSearch.SafeValue() == false )
            return;
        if ( _formShareConfig.IsActionColumn( _id ) ) {
            ConfigSearchFormActionColumn();
            return;
        }
        ConfigSearchFormConditionColumn();
        ConfigHideSearchFormItem();
    }

    /// <summary>
    /// 配置搜索表单操作区域栅格属性
    /// </summary>
    protected virtual void ConfigSearchFormActionColumn() {
        _config.SetAttribute( UiConst.Xs, 24 );
        _config.SetAttribute( UiConst.Sm, 24 );
        _config.SetAttribute( UiConst.Md, GetSearchFormActionMd() );
        _config.SetAttribute( UiConst.Lg, GetSearchFormActionLg() );
        _config.SetAttribute( UiConst.Xl, GetSearchFormActionXl() );
        _config.SetAttribute( UiConst.Xxl, GetSearchFormActionXxl() );
    }

    /// <summary>
    /// 获取搜索表单操作区域中尺寸栅格值
    /// </summary>
    protected virtual string GetSearchFormActionMd() {
        var result = GetMd();
        if ( result.IsEmpty() == false )
            return result;
        return "{" + $"span:expand?{GetSearchFormActionSpan( 2 )}:{GetSearchFormActionSpan( 2, false )}" + "}";
    }

    /// <summary>
    /// 获取搜索表单操作区域宽尺寸栅格值
    /// </summary>
    protected virtual string GetSearchFormActionLg() {
        var result = GetLg();
        if ( result.IsEmpty() == false )
            return result;
        return "{" + $"span:expand?{GetSearchFormActionSpan( 3 )}:{GetSearchFormActionSpan( 3, false )}" + "}";
    }

    /// <summary>
    /// 获取搜索表单操作区域超宽尺寸栅格值
    /// </summary>
    protected virtual string GetSearchFormActionXl() {
        var result = GetXl();
        if ( result.IsEmpty() == false )
            return result;
        return "{" + $"span:expand?{GetSearchFormActionSpan( 3 )}:{GetSearchFormActionSpan( 3, false )}" + "}";
    }

    /// <summary>
    /// 获取搜索表单操作区域极宽尺寸栅格值
    /// </summary>
    protected virtual string GetSearchFormActionXxl() {
        var result = GetXxl();
        if ( result.IsEmpty() == false )
            return result;
        return "{" + $"span:expand?{GetSearchFormActionSpan( GetXxlColumnNumber() )}:{GetSearchFormActionSpan( GetXxlColumnNumber(), false )}" + "}";
    }

    /// <summary>
    /// 获取搜索表单操作区域跨度
    /// </summary>
    /// <param name="columnNumber">一行几列</param>
    /// <param name="expand">是否展开</param>
    protected virtual int GetSearchFormActionSpan( int columnNumber, bool expand = true ) {
        var count = GetConditionCount( expand );
        var remainder = count % columnNumber;
        return 24 - remainder * 24 / columnNumber;
    }

    /// <summary>
    /// 获取有效的查询条件数量
    /// </summary>
    private int GetConditionCount( bool expand ) {
        if ( expand )
            return _formShareConfig.GetConditionCount();
        if ( _formShareConfig.GetConditionCount() > _formShareConfig.SearchFormShowNumber )
            return _formShareConfig.SearchFormShowNumber.SafeValue();
        return _formShareConfig.GetConditionCount();
    }

    /// <summary>
    /// 获取Xxl宽度每行列数
    /// </summary>
    private int GetXxlColumnNumber() {
        return _formShareConfig.SearchFormColumnsNumber.SafeValue() >= 6 ? 6 : 4;
    }

    /// <summary>
    /// 配置搜索表单查询条件栅格属性
    /// </summary>
    protected virtual void ConfigSearchFormConditionColumn() {
        _config.SetAttribute( UiConst.Xs, 24 );
        _config.SetAttribute( UiConst.Sm, 24 );
        _config.SetAttribute( UiConst.Md, 12 );
        _config.SetAttribute( UiConst.Lg, 8 );
        _config.SetAttribute( UiConst.Xl, 8 );
        _config.SetAttribute( UiConst.Xxl, 24 / GetXxlColumnNumber() );
    }

    /// <summary>
    /// 隐藏查询条件
    /// </summary>
    protected virtual void ConfigHideSearchFormItem() {
        if ( _formShareConfig.IsHide( _id ) == false )
            return;
        this.NgIf( "expand" );
    }
}