using Util.AspNetCore;
using Util.SystemTextJson;

namespace Util.Applications;

/// <summary>
/// Json序列化配置工厂
/// </summary>
public class JsonSerializerOptionsFactory : IJsonSerializerOptionsFactory {
    /// <summary>
    /// 创建Json序列化配置
    /// </summary>
    public JsonSerializerOptions CreateOptions() {
        return new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
                new LongJsonConverter(),
                new NullableLongJsonConverter()
            }
        };
    }
}