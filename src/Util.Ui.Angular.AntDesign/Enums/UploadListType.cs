using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 上传文件列表类型
    /// </summary>
    public enum UploadListType {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "text" )]
        Default,
        /// <summary>
        /// 图片列表
        /// </summary>
        [Description( "picture" )]
        Picture,
        /// <summary>
        /// 卡片
        /// </summary>
        [Description( "picture-card" )]
        PictureCard
    }
}
