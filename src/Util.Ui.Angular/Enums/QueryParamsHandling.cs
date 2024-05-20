using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums;

/// <summary>
/// 路由器链接查询参数处理方式
/// </summary>
public enum QueryParamsHandling {
    /// <summary>
    /// merge, 将新参数与当前参数合并
    /// </summary>
    [Description( "merge" )]
    Merge,
    /// <summary>
    /// preserve, 保留当前参数
    /// </summary>
    [Description( "preserve" )]
    Preserve
}