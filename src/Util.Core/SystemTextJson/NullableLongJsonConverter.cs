namespace Util.SystemTextJson;

/// <summary>
/// 可空long格式Json转换器
/// </summary>
public class NullableLongJsonConverter : JsonConverter<long?> {
    /// <summary>
    /// 读取数据
    /// </summary>
    public override long? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options ) {
        if( reader.TokenType == JsonTokenType.String )
            return Util.Helpers.Convert.ToLongOrNull( reader.GetString() );
        return reader.TryGetInt64( out var value ) ? value : null;
    }

    /// <summary>
    /// 写入数据
    /// </summary>
    public override void Write( Utf8JsonWriter writer, long? value, JsonSerializerOptions options ) {
        writer.WriteStringValue( value.SafeString() );
    }
}