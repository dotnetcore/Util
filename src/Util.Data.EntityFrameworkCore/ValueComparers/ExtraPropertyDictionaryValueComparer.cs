using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Util.Domain.Extending;

namespace Util.Data.EntityFrameworkCore.ValueComparers {
    /// <summary>
    /// 扩展属性值比较器
    /// </summary>
    public class ExtraPropertyDictionaryValueComparer : ValueComparer<ExtraPropertyDictionary> {
        /// <summary>
        /// 初始化扩展属性值比较器
        /// </summary>
        public ExtraPropertyDictionaryValueComparer()
            : base(
                  ( extraProperties1, extraProperties2 ) => GetJson( extraProperties1 ) == GetJson( extraProperties2 ),
                  extraProperties => extraProperties.Aggregate( 0, ( key, value ) => HashCode.Combine( key, value.GetHashCode() ) ),
                  extraProperties => new ExtraPropertyDictionary( extraProperties ) ) {
        }

        /// <summary>
        /// 获取Json
        /// </summary>
        private static string GetJson( ExtraPropertyDictionary extraProperties ) {
            var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            return Util.Helpers.Json.ToJson( extraProperties, options );
        }
    }
}
