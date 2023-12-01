using Util.Helpers;

namespace Util.Ui.NgZorro.Components.Grids.Helpers; 

/// <summary>
/// 栅格列模型
/// </summary>
public class ColumnModel {
    /// <summary>
    /// xs
    /// </summary>
    public int? Xs { get; set; }

    /// <summary>
    /// sm
    /// </summary>
    public int? Sm { get; set; }

    /// <summary>
    /// md
    /// </summary>
    public int? Md { get; set; }

    /// <summary>
    /// lg
    /// </summary>
    public int? Lg { get; set; }

    /// <summary>
    /// xl
    /// </summary>
    public int? Xl { get; set; }

    /// <summary>
    /// xxl
    /// </summary>
    public int? Xxl { get; set; }

    /// <summary>
    /// 输出json
    /// </summary>
    public string ToJson() {
        var result = Json.ToJson( this,new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        },true );
        return result == "{}" ? null : result;
    }
}