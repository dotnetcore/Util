using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 骨架屏元素类型
    /// </summary>
    public enum SkeletonElementType {
        /// <summary>
        /// 按钮
        /// </summary>
        [Description( "button" )]
        Button,
        /// <summary>
        /// 头像
        /// </summary>
        [Description( "avatar" )]
        Avatar,
        /// <summary>
        /// 输入框
        /// </summary>
        [Description( "input" )]
        Input,
        /// <summary>
        /// 图片
        /// </summary>
        [Description( "image" )]
        Image
    }
}
