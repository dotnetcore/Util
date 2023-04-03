using System.Text.Json.Serialization;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
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
            Width = GetPixelValue( width );
            Height = GetPixelValue( height );
        }

        /// <summary>
        /// 获取像素值，如果传入数字，后加px，否则按原样返回
        /// </summary>
        private string GetPixelValue( string value ) {
            if ( value.IsEmpty() )
                return null;
            if ( Util.Helpers.Validation.IsNumber( value ) )
                return $"{value}px";
            return value;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        [JsonPropertyName( "x" )]
        public string Width { get; }

        /// <summary>
        /// 高度
        /// </summary>
        [JsonPropertyName( "y" )]
        public string Height { get; }

        /// <summary>
        /// 是否为空
        /// </summary>
        [JsonIgnore]
        public bool IsNull => Width.IsEmpty() && Height.IsEmpty();
    }
}
