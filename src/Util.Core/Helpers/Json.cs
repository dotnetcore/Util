using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// Json操作
    /// </summary>
    public static class Json {
        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="value">目标对象</param>
        /// <param name="options">序列化配置</param>
        /// <param name="removeQuotationMarks">是否移除双引号</param>
        public static string ToJson<T>( T value, JsonSerializerOptions options = null,bool removeQuotationMarks = false ) {
            if ( value == null )
                return string.Empty;
            var result = JsonSerializer.Serialize( value, options );
            if ( removeQuotationMarks )
                result = result.Replace( "\"","" );
            return result;
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
            await using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync( stream, value, typeof( T ), options, cancellationToken );
            stream.Position = 0;
            using var reader = new StreamReader( stream );
            return await reader.ReadToEndAsync();
        }

        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <param name="options">序列化配置</param>
        public static T ToObject<T>( string json, JsonSerializerOptions options = null ) {
            if ( string.IsNullOrWhiteSpace( json ) )
                return default;
            return JsonSerializer.Deserialize<T>( json, options );
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
            return await JsonSerializer.DeserializeAsync<T>( json, options, cancellationToken );
        }
    }
}
