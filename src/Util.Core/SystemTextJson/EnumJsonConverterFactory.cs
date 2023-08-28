namespace Util.SystemTextJson; 

/// <summary>
/// 枚举Json转换器工厂
/// </summary>
public class EnumJsonConverterFactory : JsonConverterFactory {
    /// <summary>
    /// 是否允许转换为枚举
    /// </summary>
    /// <param name="type">转换类型</param>
    public override bool CanConvert( Type type ) {
        return type.IsEnum;
    }

    /// <summary>
    /// 创建枚举Json转换器
    /// </summary>
    /// <param name="type">转换类型</param>
    /// <param name="options">Json序列化配置</param>
    public override JsonConverter CreateConverter( Type type, JsonSerializerOptions options ) {
        return (JsonConverter)Activator.CreateInstance( GetEnumConverterType( type ) );
    }

    /// <summary>
    /// 获取枚举Json转换器类型
    /// </summary>
    /// <param name="enumType">枚举类型</param>
    private static Type GetEnumConverterType( Type enumType ) => typeof( EnumJsonConverter<> ).MakeGenericType( enumType );
}

