using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType {
        /// <summary>
        /// jpg,jpeg
        /// </summary>
        [Description( "image/jpeg" )]
        Jpg,
        /// <summary>
        /// png
        /// </summary>
        [Description( "image/png" )]
        Png,
        /// <summary>
        /// gif
        /// </summary>
        [Description( "image/gif" )]
        Gif,
        /// <summary>
        /// bmp
        /// </summary>
        [Description( "image/bmp" )]
        Bmp
    }

    /// <summary>
    /// 文件类型枚举扩展
    /// </summary>
    public static class FileTypeExtensions {
        /// <summary>
        /// 获取文件类型名称列表
        /// </summary>
        public static string GetNames( this FileType fileType ) {
            if( fileType == FileType.Jpg )
                return ".jpg,.jpeg";
            var name = Util.Helpers.Enum.GetName<FileType>( fileType );
            return $".{name.ToLower()}";
        }
    }
}
