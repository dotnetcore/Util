using System.Text.Json;
using System.Text.Json.Serialization;
using Util.Helpers;

namespace Util.Ui.NgZorro.Components.Grids.Helpers {
    /// <summary>
    /// 栅格参数实体
    /// </summary>
    public class GridModel {
        /// <summary>
        /// 占位格数
        /// </summary>
        public int? Span { get; set; }

        /// <summary>
        /// 向右偏移的格数
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// 向左移动的格数
        /// </summary>
        public int? Pull { get; set; }

        /// <summary>
        /// 向右移动的格数
        /// </summary>
        public int? Push { get; set; }

        /// <summary>
        /// 输出json
        /// </summary>
        public string ToJson() {
            var result = Json.ToJson( this,new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            },true );
            return result == "{}" ? null : result;
        }
    }
}
