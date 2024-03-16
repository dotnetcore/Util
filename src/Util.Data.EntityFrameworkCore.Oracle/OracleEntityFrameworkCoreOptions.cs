namespace Util.Data.EntityFrameworkCore;

/// <summary>
/// Oracle EF配置项
/// </summary>
public class OracleEntityFrameworkCoreOptions {
    /// <summary>
    /// 存储时是否将Guid类型转换为字符串类型
    /// </summary>
    public bool IsGuidToString { get; set; }
}