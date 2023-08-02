namespace Util.Microservices.Polly.Tests;

/// <summary>
/// 弹性处理策略测试
/// </summary>
public partial class PolicyTest {
    /// <summary>
    /// 弹性处理策略
    /// </summary>
    private readonly IPolicy _policy;
    /// <summary>
    /// 输出
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public PolicyTest( IPolicy policy, ITestOutputHelper output ) {
        _policy = policy;
        _output = output;
    }
}