using Newtonsoft.Json;

namespace Util.Ui.Zorro.Tables.Configs {
    /// <summary>
    /// 滚动信息
    /// </summary>
    public class ScrollInfo {
        /// <summary>
        /// 初始化滚动信息
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public ScrollInfo( string width, string height ) {
            Width = GetValue( width );
            Height = GetValue( height );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private string GetValue( string value ) {
            if ( value.IsEmpty() )
                return null;
            if( Util.Helpers.Validation.IsNumber( value ) )
                return $"{value}px";
            return value;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        [JsonProperty( "x", NullValueHandling = NullValueHandling.Ignore )]
        public string Width { get; }

        /// <summary>
        /// 高度
        /// </summary>
        [JsonProperty( "y", NullValueHandling = NullValueHandling.Ignore )]
        public string Height { get; }

        /// <summary>
        /// 是否为空
        /// </summary>
        [JsonIgnore]
        public bool IsNull => Width.IsEmpty() && Height.IsEmpty();
    }
}
