using System.ComponentModel;

namespace Util.Ui.Material.Enums {
    /// <summary>
    /// 按钮样式
    /// </summary>
    public enum ButtonStyle {
        /// <summary>
        /// mat-button
        /// </summary>
        [Description( "mat-button" )]
        Default,
        /// <summary>
        /// mat-raised-button
        /// </summary>
        [Description( "mat-raised-button" )]
        Raised,
        /// <summary>
        /// mat-icon-button
        /// </summary>
        [Description( "mat-icon-button" )]
        Icon,
        /// <summary>
        /// mat-fab
        /// </summary>
        [Description( "mat-fab" )]
        Fab,
        /// <summary>
        /// mat-mini-fab
        /// </summary>
        [Description( "mat-mini-fab" )]
        MiniFab
    }
}
