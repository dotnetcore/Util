using System.Text.Json;
using System.Text.Json.Serialization;
using Util.Helpers;

namespace Util.Ui.NgZorro.Components.Inputs.Helpers {
    /// <summary>
    /// 行高模型
    /// </summary>
    public class RowsModel {
        /// <summary>
        /// 最小行数
        /// </summary>
        public int? MinRows { get; set; }
        /// <summary>
        /// 最大行数
        /// </summary>
        public int? MaxRows { get; set; }

        /// <summary>
        /// 输出json
        /// </summary>
        public string ToJson() {
            var result = Json.ToJson( this, new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }, true );
            return result == "{}" ? null : result;
        }
    }
}
