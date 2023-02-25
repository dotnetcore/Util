using System.ComponentModel;

namespace Util.Images {
    /// <summary>
    /// 图片类型
    /// </summary>
    public enum ImageType {
        /// <summary>
        /// jpg,jpeg
        /// </summary>
        [Description( ".jpg,.jpeg" )]
        Jpg,
        /// <summary>
        /// png
        /// </summary>
        [Description( ".png" )]
        Png,
        /// <summary>
        /// gif
        /// </summary>
        [Description( ".gif" )]
        Gif,
        /// <summary>
        /// bmp
        /// </summary>
        [Description( ".bmp" )]
        Bmp
    }
}
