namespace Util.Configs; 

/// <summary>
/// 应用生成器
/// </summary>
public interface IAppBuilder {
    /// <summary>
    /// 主机生成器
    /// </summary>
    public IHostBuilder Host { get; }
    /// <summary>
    /// 构建
    /// </summary>
    public IHost Build();
}