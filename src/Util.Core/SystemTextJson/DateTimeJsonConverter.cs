using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Util.Helpers;

namespace Util.SystemTextJson {
    /// <summary>
    /// 日期格式Json转换器
    /// </summary>
    public class DateTimeJsonConverter : JsonConverter<DateTime> {
        /// <summary>
        /// 日期格式
        /// </summary>
        private readonly string _format;

        /// <summary>
        /// 初始化日期格式Json转换器
        /// </summary>
        public DateTimeJsonConverter() : this( "yyyy-MM-dd HH:mm:ss" ) {
        }

        /// <summary>
        /// 初始化日期格式Json转换器
        /// </summary>
        /// <param name="format">日期格式,默认值: yyyy-MM-dd HH:mm:ss</param>
        public DateTimeJsonConverter( string format ) {
            _format = format;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options ) {
            if ( reader.TokenType == JsonTokenType.String ) {
                return Time.Normalize( Util.Helpers.Convert.ToDateTime( reader.GetString() ) );
            }
            if ( reader.TryGetDateTime( out var date ) ) {
                return Time.Normalize( date );
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options ) {
            var date = Time.Normalize( value ).ToString( _format );
            writer.WriteStringValue( date );
        }
    }
}
