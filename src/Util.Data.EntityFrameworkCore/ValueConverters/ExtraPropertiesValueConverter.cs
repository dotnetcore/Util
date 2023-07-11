using Util.Domain.Extending;
using Util.SystemTextJson;

namespace Util.Data.EntityFrameworkCore.ValueConverters; 

/// <summary>
/// 扩展属性值转换器
/// </summary>
public class ExtraPropertiesValueConverter : ValueConverter<ExtraPropertyDictionary, string> {
    /// <summary>
    /// 初始化扩展属性值转换器
    /// </summary>
    public ExtraPropertiesValueConverter()
        : base( extraProperties => PropertiesToJson( extraProperties ), json => JsonToProperties( json ) ) {
    }

    /// <summary>
    /// 扩展属性转换为json
    /// </summary>
    private static string PropertiesToJson( ExtraPropertyDictionary extraProperties ) {
        var options = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            Converters = {
                new UtcDateTimeJsonConverter(),
                new UtcNullableDateTimeJsonConverter()
            }
        };
        return Util.Helpers.Json.ToJson( extraProperties, options );
    }

    /// <summary>
    /// json转换为扩展属性
    /// </summary>
    private static ExtraPropertyDictionary JsonToProperties( string json ) {
        if( json.IsEmpty() || json == "{}" )
            return new ExtraPropertyDictionary();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return Util.Helpers.Json.ToObject<ExtraPropertyDictionary>( json, options ) ?? new ExtraPropertyDictionary();
    }
}