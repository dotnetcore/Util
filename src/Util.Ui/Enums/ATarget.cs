using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 链接打开目标
    /// </summary>
    public enum ATarget {
        /// <summary>
        /// _self,在相同框架中打开
        /// </summary>
        [Description( "_self" )]
        Self,
        /// <summary>
        /// _blank,在新窗口中打开
        /// </summary>
        [Description( "_blank" )]
        Blank,
        /// <summary>
        /// _parent,在父框架中打开
        /// </summary>
        [Description( "_parent" )]
        Parent,
        /// <summary>
        /// _top,在窗口主体中打开
        /// </summary>
        [Description( "_top" )]
        Top
    }
}
