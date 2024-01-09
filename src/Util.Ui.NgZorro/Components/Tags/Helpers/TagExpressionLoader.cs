using Util.Ui.Expressions;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.Tags.Helpers; 

/// <summary>
/// 标签表达式加载器
/// </summary>
public class TagExpressionLoader : NgZorroExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        LoadData( config, info );
    }

    /// <summary>
    /// 加载数据源
    /// </summary>
    protected virtual void LoadData( Config config, ModelExpressionInfo info ) {
        LoadEnum( config, info );
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