using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using Util.SystemTextJson;

namespace Util.Helpers
{
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
            options ??= new JsonOptions();
            var jsonSerializerOptions = new JsonSerializerOptions();
            if ( options.IgnoreNullValues )
                jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            return ToJson( value, jsonSerializerOptions, options.RemoveQuotationMarks, options.ToSingleQuotes );
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="value">目标对象</param>
        /// <param name="options">序列化配置</param>
        /// <param name="removeQuotationMarks">是否移除双引号</param>
        /// <param name="toSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJson<T>( T value, JsonSerializerOptions options = null,bool removeQuotationMarks = false, bool toSingleQuotes = false ) {
            if ( value == null )
                return string.Empty;
            options = GetToJsonOptions( options );
            var result = JsonSerializer.Serialize( value, options );
            if ( removeQuotationMarks )
                result = result.Replace( "\"","" );
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
                Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
                Converters = {
                    new DateTimeJsonConverter(),
                    new NullableDateTimeJsonConverter()
                }
            };
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="value">目标对象</param>
        /// <param name="options">序列化配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<string> ToJsonAsyc<T>( T value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default ) {
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
        /// <param name="options">序列化配置</param>
        /// <param name="returnType">序列化配置</param>
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
                    new NullableDateTimeJsonConverter()
                }
            };
        }

        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <param name="options">序列化配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <param name="encoding">Json字符编码,默认UTF8</param>
        public static async Task<T> ToObjectAsync<T>( string json, JsonSerializerOptions options = null, CancellationToken cancellationToken = default,Encoding encoding = null ) {
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
    }
}
