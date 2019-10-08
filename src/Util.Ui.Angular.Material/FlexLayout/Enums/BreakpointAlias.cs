using System.ComponentModel;

namespace Util.Ui.FlexLayout.Enums {
    /// <summary>
    /// 媒体查询断点别名
    /// </summary>
    public enum BreakpointAlias {
        /// <summary>
        /// max-width: 599px
        /// </summary>
        [Description( "xs" )]
        Xs,
        /// <summary>
        /// (min-width: 600px) and (max-width: 959px)
        /// </summary>
        [Description( "sm" )]
        Sm,
        /// <summary>
        /// (min-width: 960px) and (max-width: 1279px)
        /// </summary>
        [Description( "md" )]
        Md,
        /// <summary>
        /// (min-width: 1280px) and (max-width: 1919px)
        /// </summary>
        [Description( "lg" )]
        Lg,
        /// <summary>
        /// (min-width: 1920px) and (max-width: 5000px)
        /// </summary>
        [Description( "xl" )]
        Xl,
        /// <summary>
        /// max-width: 599px
        /// </summary>
        [Description( "lt-sm" )]
        LtSm,
        /// <summary>
        /// max-width: 959px
        /// </summary>
        [Description( "lt-md" )]
        LtMd,
        /// <summary>
        /// max-width: 1279px
        /// </summary>
        [Description( "lt-lg" )]
        LtLg,
        /// <summary>
        /// max-width: 1919px
        /// </summary>
        [Description( "lt-xl" )]
        LtXl,
        /// <summary>
        /// min-width: 600px
        /// </summary>
        [Description( "gt-xs" )]
        GtXs,
        /// <summary>
        /// min-width: 960px
        /// </summary>
        [Description( "gt-sm" )]
        GtSm,
        /// <summary>
        /// min-width: 1280px
        /// </summary>
        [Description( "gt-md" )]
        GtMd,
        /// <summary>
        /// min-width: 1920px
        /// </summary>
        [Description( "gt-lg" )]
        GtLg
    }
}
