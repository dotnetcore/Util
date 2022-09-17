using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 对话框自动聚焦
    /// </summary>
    public enum ModalAutofocus {
        /// <summary>
        /// 聚集到确认按钮
        /// </summary>
        [Description( "ok" )]
        Ok,
        /// <summary>
        /// 聚集到取消按钮
        /// </summary>
        [Description( "cancel" )]
        Cancel,
        /// <summary>
        /// 自动聚焦
        /// </summary>
        [Description( "auto" )]
        Auto
    }
}
