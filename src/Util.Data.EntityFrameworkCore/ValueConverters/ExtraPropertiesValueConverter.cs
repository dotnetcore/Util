using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Util.Domain.Extending;

namespace Util.Data.EntityFrameworkCore.ValueConverters {
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
            return Util.Helpers.Json.ToJson( extraProperties );
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
}
