namespace Util.Ui.NgZorro.Enums; 

/// <summary>
/// 二维码状态
/// </summary>
public enum QrCodeStatus {
    /// <summary>
    /// active, 正常
    /// </summary>
    [Description( "active" )]
    Active,
    /// <summary>
    /// expired,已过期
    /// </summary>
    [Description( "expired" )]
    Expired,
    /// <summary>
    /// loading, 加载中
    /// </summary>
    [Description( "loading" )]
    Loading
}