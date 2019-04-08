namespace Util.Ui.Helpers {
    /// <summary>
    /// 图片类型操作类
    /// </summary>
    public class ImageTypeHelper {
        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <param name="name">图片类型枚举名称</param>
        public static string GetExtensions( string name ) {
            if( name.IsEmpty() )
                return string.Empty;
            if( name == "Jpg" )
                return ".jpg,.jpeg";
            return $".{name.ToLower()}";
        }
    }
}
