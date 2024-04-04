using Util.SystemTextJson;

namespace Util.Helpers;

/// <summary>
/// Json操作
/// </summary>
public static class Json {
    /// <summary>
    /// 将对象转换为Json字符串
    /// </summary>
    /// <param name="value">目标对象</param>
    /// <param name="options">Json配置</param>
    public static string ToJson<T>( T value, JsonOptions options ) {
        if ( options == null )
            return ToJson( value );
        var jsonSerializerOptions = ToJsonSerializerOptions( options );
        return ToJson( value, jsonSerializerOptions, options.RemoveQuotationMarks, options.ToSingleQuotes, options.IgnoreInterface );
    }

    /// <summary>
    /// 转换序列化配置
    /// </summary>
    private static JsonSerializerOptions ToJsonSerializerOptions( JsonOptions options ) {
        var jsonSerializerOptions = new JsonSerializerOptions();
        if ( options.IgnoreEmptyString ) {
            jsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver {
                Modifiers = { IgnoreEmptyString }
            };
        }
        if ( options.IgnoreNullValues )
            jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        if ( options.IgnoreCase )
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
        if ( options.ToCamelCase )
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        jsonSerializerOptions.Encoder = JavaScriptEncoder.Create( UnicodeRanges.All );
        jsonSerializerOptions.Converters.Add( new DateTimeJsonConverter() );
        jsonSerializerOptions.Converters.Add( new NullableDateTimeJsonConverter() );
        jsonSerializerOptions.Converters.Add( new LongJsonConverter() );
        jsonSerializerOptions.Converters.Add( new NullableLongJsonConverter() );
        return jsonSerializerOptions;
    }

    /// <summary>
    /// 忽略空字符串
    /// </summary>
    private static void IgnoreEmptyString( JsonTypeInfo jsonTypeInfo ) {
        if ( jsonTypeInfo.Kind != JsonTypeInfoKind.Object )
            return;
        foreach ( JsonPropertyInfo jsonPropertyInfo in jsonTypeInfo.Properties ) {
            if ( jsonPropertyInfo.PropertyType == typeof( string ) ) {
                jsonPropertyInfo.ShouldSerialize = static ( _, value ) => value.SafeString().IsEmpty() == false;
            }
        }
    }

    /// <summary>
    /// 将对象转换为Json字符串
    /// </summary>
    /// <param name="value">目标对象</param>
    /// <param name="options">序列化配置</param>
    /// <param name="removeQuotationMarks">是否移除双引号</param>
    /// <param name="toSingleQuotes">是否将双引号转成单引号</param>
    public static string ToJson<T>( T value, JsonSerializerOptions options = null, bool removeQuotationMarks = false, bool toSingleQuotes = false ) {
        return ToJson( value, options, removeQuotationMarks, toSingleQuotes, true );
    }

    /// <summary>
    /// 将对象转换为Json字符串
    /// </summary>
    private static string ToJson<T>( T value, JsonSerializerOptions options, bool removeQuotationMarks, bool toSingleQuotes, bool ignoreInterface ) {
        if ( value == null )
            return string.Empty;
        options = GetToJsonOptions( options );
        var result = Serialize( value, options, ignoreInterface );
        if ( removeQuotationMarks )
            result = result.Replace( "\"", "" );
        if ( toSingleQuotes )
            result = result.Replace( "\"", "'" );
        return result;
    }

    /// <summary>
    /// 获取对象转换为Json字符串的序列化配置
    /// </summary>
    private static JsonSerializerOptions GetToJsonOptions( JsonSerializerOptions options ) {
        if ( options != null )
            return options;
        return new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
                new LongJsonConverter(),
                new NullableLongJsonConverter()
            }
        };
    }

    /// <summary>
    /// Json序列化
    /// </summary>
    private static string Serialize<T>( T value, JsonSerializerOptions options, bool ignoreInterface ) {
        if ( ignoreInterface ) {
            object instance = value;
            if ( instance != null )
                return JsonSerializer.Serialize( instance, options );
        }
        return JsonSerializer.Serialize( value, options );
    }

    /// <summary>
    /// 将对象转换为Json字符串
    /// </summary>
    /// <param name="value">目标对象</param>
    /// <param name="options">序列化配置</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<string> ToJsonAsync<T>( T value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default ) {
        if ( value == null )
            return string.Empty;
        options = GetToJsonOptions( options );
        await using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync( stream, value, typeof( T ), options, cancellationToken );
        stream.Position = 0;
        using var reader = new StreamReader( stream );
        return await reader.ReadToEndAsync( cancellationToken );
    }

    /// <summary>
    /// 将Json字符串转换为对象
    /// </summary>
    /// <param name="json">Json字符串</param>
    /// <param name="options">序列化配置</param>
    public static T ToObject<T>( string json, JsonOptions options ) {
        if ( string.IsNullOrWhiteSpace( json ) )
            return default;
        if ( options == null )
            return ToObject<T>( json );
        return ToObject<T>( json, ToJsonSerializerOptions( options ) );
    }

    /// <summary>
    /// 将Json字符串转换为对象
    /// </summary>
    /// <param name="json">Json字符串</param>
    /// <param name="options">序列化配置</param>
    public static T ToObject<T>( string json, JsonSerializerOptions options = null ) {
        if ( string.IsNullOrWhiteSpace( json ) )
            return default;
        options = GetToObjectOptions( options );
        return JsonSerializer.Deserialize<T>( json, options );
    }

    /// <summary>
    /// 将Json字符串转换为对象
    /// </summary>
    /// <param name="json">Json字符串</param>
    /// <param name="returnType">返回类型</param>
    /// <param name="options">序列化配置</param>
    public static object ToObject( string json, Type returnType, JsonSerializerOptions options = null ) {
        if ( string.IsNullOrWhiteSpace( json ) )
            return default;
        options = GetToObjectOptions( options );
        return JsonSerializer.Deserialize( json, returnType, options );
    }

    /// <summary>
    /// 获取Json字符串转换为对象的序列化配置
    /// </summary>
    private static JsonSerializerOptions GetToObjectOptions( JsonSerializerOptions options ) {
        if ( options != null )
            return options;
        return new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
                new LongJsonConverter(),
                new NullableLongJsonConverter()
            }
        };
    }

    /// <summary>
    /// 将Json字节数组转换为对象
    /// </summary>
    /// <param name="json">Json字节数组</param>
    /// <param name="options">序列化配置</param>
    public static T ToObject<T>( byte[] json, JsonSerializerOptions options = null ) {
        if ( json == null )
            return default;
        options = GetToObjectOptions( options );
        return JsonSerializer.Deserialize<T>( json, options );
    }

    /// <summary>
    /// 将Json字节流转换为对象
    /// </summary>
    /// <param name="json">Json字节流</param>
    /// <param name="options">序列化配置</param>
    public static T ToObject<T>( Stream json, JsonSerializerOptions options = null ) {
        if ( json == null )
            return default;
        options = GetToObjectOptions( options );
        return JsonSerializer.Deserialize<T>( json, options );
    }

    /// <summary>
    /// 将Json字符串转换为对象
    /// </summary>
    /// <param name="json">Json字符串</param>
    /// <param name="options">序列化配置</param>
    /// <param name="encoding">Json字符编码,默认UTF8</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<T> ToObjectAsync<T>( string json, JsonSerializerOptions options = null, Encoding encoding = null, CancellationToken cancellationToken = default ) {
        if ( string.IsNullOrWhiteSpace( json ) )
            return default;
        encoding ??= Encoding.UTF8;
        byte[] bytes = encoding.GetBytes( json );
        await using var stream = new MemoryStream( bytes );
        return await ToObjectAsync<T>( stream, options, cancellationToken );
    }

    /// <summary>
    /// 将Json流转换为对象
    /// </summary>
    /// <param name="json">Json流</param>
    /// <param name="options">序列化配置</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<T> ToObjectAsync<T>( Stream json, JsonSerializerOptions options = null, CancellationToken cancellationToken = default ) {
        if ( json == null )
            return default;
        options = GetToObjectOptions( options );
        return await JsonSerializer.DeserializeAsync<T>( json, options, cancellationToken );
    }

    /// <summary>
    /// 将Json流转换为对象
    /// </summary>
    /// <param name="json">Json流</param>
    /// <param name="options">序列化配置</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<T> ToObjectAsync<T>( byte[] json, JsonSerializerOptions options = null, CancellationToken cancellationToken = default ) {
        if ( json == null )
            return default;
        await using var stream = new MemoryStream( json );
        return await ToObjectAsync<T>( stream, options, cancellationToken );
    }

    /// <summary>
    /// 将对象转换为字节数组
    /// </summary>
    /// <param name="value">目标对象</param>
    /// <param name="options">Json配置</param>
    public static byte[] ToBytes<T>( T value, JsonSerializerOptions options = null ) {
        options = GetToBytesOptions( options );
        return JsonSerializer.SerializeToUtf8Bytes( value, options );
    }

    /// <summary>
    /// 获取转换为字节数组的序列化配置
    /// </summary>
    private static JsonSerializerOptions GetToBytesOptions( JsonSerializerOptions options ) {
        if ( options != null )
            return options;
        return new JsonSerializerOptions {
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
                new LongJsonConverter(),
                new NullableLongJsonConverter()
            }
        };
    }
}