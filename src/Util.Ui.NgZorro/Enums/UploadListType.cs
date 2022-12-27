using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 上传列表类型
    /// </summary>
    public enum UploadListType {
        /// <summary>
        /// 文本列表
        /// </summary>
        [Description( "text" )]
        Text,
        /// <summary>
        /// 图片列表
        /// </summary>
        [Description( "picture" )]
        Picture,
        /// <summary>
        /// 照片墙
        /// </summary>
        [Description( "picture-card" )]
        PictureCard
    }
}
