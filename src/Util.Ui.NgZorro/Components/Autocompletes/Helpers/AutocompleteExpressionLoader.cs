using Util.Ui.Expressions;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.Autocompletes.Helpers;

/// <summary>
/// 自动完成表达式加载器
/// </summary>
public class AutocompleteExpressionLoader : NgZorroExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        LoadId( config, info );
        LoadData( config, info );
    }

    /// <summary>
    /// 加载标识
    /// </summary>
    protected virtual void LoadId( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Id, $"auto_{GeKebaberizePropertyName( config, info )}", false );
    }

    /// <summary>
    /// 加载数据源
    /// </summary>
    protected virtual void LoadData( Config config, ModelExpressionInfo info ) {
        LoadBool( config, info );
        LoadEnum( config, info );
    }

    /// <summary>
    /// 加载布尔值
    /// </summary>
    protected virtual void LoadBool( Config config, ModelExpressionInfo info ) {
        if ( info.IsBool == false )
            return;
        config.SetAttribute( UiConst.Data, GetBoolData(), false );
    }

    /// <summary>
    /// 获取布尔类型数据
    /// </summary>
    private string GetBoolData() {
        var result = new StringBuilder();
        result.Append( "[{" );
        result.Append( $"'text':'{GetYes()}','value':true,'sortId':1" );
        result.Append( "}," );
        result.Append( "{" );
        result.Append( $"'text':'{GetNo()}','value':false,'sortId':2" );
        result.Append( "}]" );
        return result.ToString();
    }

    /// <summary>
    /// 获取yes文本
    /// </summary>
    private string GetYes() {
        var options = NgZorroOptionsService.GetOptions();
        return options.EnableI18n ? I18nKeys.Yes : "是";
    }

    /// <summary>
    /// 获取no文本
    /// </summary>
    private string GetNo() {
        var options = NgZorroOptionsService.GetOptions();
        return options.EnableI18n ? I18nKeys.No : "否";
    }

    /// <summary>
    /// 加载枚举值
    /// </summary>
    protected virtual void LoadEnum( Config config, ModelExpressionInfo info ) {
        if ( info.IsEnum == false )
            return;
        var items = Util.Helpers.Enum.GetItems( info.ModelType );
        var options = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All )
        };
        var result = Util.Helpers.Json.ToJson( items, options, toSingleQuotes: true );
        config.SetAttribute( UiConst.Data, result, false );
    }
}