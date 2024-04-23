using Util.Ui.Angular.Configs;

namespace Util.Ui.NgZorro.Configs;

/// <summary>
/// 配置扩展
/// </summary>
public static class ConfigExtensions {
    /// <summary>
    /// 复制并移除属性,保留部分属性
    /// </summary>
    /// <param name="config">配置</param>
    public static Config CopyRemoveAttributes( this Config config ) {
        var result = config.Copy();
        result.OutputAttributes.Clear();
        result.AllAttributes.Clear();
        LoadConfig( config, result, UiConst.Required );
        LoadConfig( config, result, UiConst.RequiredMessage );
        LoadConfig( config, result, UiConst.Suffix );
        LoadConfig( config, result, AngularConst.BindSuffix );
        LoadConfig( config, result, UiConst.Extra );
        LoadConfig( config, result, AngularConst.BindExtra );
        LoadConfig( config, result, UiConst.ErrorTip );
        LoadConfig( config, result, AngularConst.BindErrorTip );
        LoadConfig( config, result, UiConst.SuccessTip );
        LoadConfig( config, result, AngularConst.BindSuccessTip );
        LoadConfig( config, result, UiConst.ValidatingTip );
        LoadConfig( config, result, AngularConst.BindValidatingTip );
        LoadConfig( config, result, UiConst.WarningTip );
        LoadConfig( config, result, AngularConst.BindWarningTip );
        return result;
    }

    /// <summary>
    /// 加载配置
    /// </summary>
    private static void LoadConfig( Config from, Config to, string name ) {
        var value = from.GetValue( name );
        to.SetAttribute( name, value );
    }
}