using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 步骤状态
    /// </summary>
    public enum StepStatus {
        /// <summary>
        /// 等待
        /// </summary>
        [Description( "wait" )]
        Wait,
        /// <summary>
        /// 处理
        /// </summary>
        [Description( "process" )]
        Process,
        /// <summary>
        /// 完成
        /// </summary>
        [Description( "finish" )]
        Finish,
        /// <summary>
        /// 错误
        /// </summary>
        [Description( "error" )]
        Error
    }
}
