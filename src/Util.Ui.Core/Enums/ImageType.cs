using System.ComponentModel;
using Util.Ui.Helpers;

namespace Util.Ui.Enums {
    /// <summary>
    /// 图片类型
    /// </summary>
    public enum ImageType {
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
    /// 图片类型枚举扩展
    /// </summary>
    public static class ImageTypeExtensions {
        /// <summary>
        /// 获取图片类型扩展名列表
        /// </summary>
        public static string GetExtensions( this ImageType fileType ) {
            var name = Util.Helpers.Enum.GetName<ImageType>( fileType );
            return ImageTypeHelper.GetExtensions( name );
        }
    }
}
