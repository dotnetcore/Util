namespace Util.Ui.Helpers;

/// <summary>
/// 尺寸辅助操作
/// </summary>
public class SizeHelper {
    /// <summary>
    /// 获取尺寸,如果值为数值,则添加px
    /// </summary>
    public static string GetValue( string value ) {
        if ( value.IsEmpty() )
            return null;
        return Util.Helpers.Validation.IsNumber( value ) ? $"{value}px" : value;
    }
}