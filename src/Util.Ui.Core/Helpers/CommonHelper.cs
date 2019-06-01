namespace Util.Ui.Helpers {
    /// <summary>
    /// 公共操作
    /// </summary>
    public static class CommonHelper {
        /// <summary>
        /// 获取像素值，如果传入数字，后加px，否则按原样返回
        /// </summary>
        /// <param name="value">值</param>
        public static string GetPixelValue( string value ) {
            if( value.IsEmpty() )
                return null;
            if( Util.Helpers.Validation.IsNumber( value ) )
                return $"{value}px";
            return value;
        }
    }
}
