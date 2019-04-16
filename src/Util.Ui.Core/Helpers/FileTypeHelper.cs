namespace Util.Ui.Helpers {
    /// <summary>
    /// 文件类型操作类
    /// </summary>
    public class FileTypeHelper {
        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <param name="name">文件类型枚举名称</param>
        public static string GetExtensions( string name ) {
            if( name.IsEmpty() )
                return string.Empty;
            if( name == "Xls" )
                return ".xls,.xlsx";
            if( name == "Doc" )
                return ".doc,.docx";
            if( name == "Jpg" )
                return ".jpg,.jpeg";
            return $".{name.ToLower()}";
        }
    }
}
