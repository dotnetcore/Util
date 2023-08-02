using Util.Dependency;

namespace Util.Microservices.Polly;

/// <summary>
/// Polly弹性处理策略
/// </summary>
[Ioc(1)]
public class PollyPolicy : IPolicy {
    /// <inheritdoc />
    public IRetryPolicyHandler Retry() {
        return new PollyRetryPolicyHandler();
    }

    /// <inheritdoc />
    public IRetryPolicyHandler Retry( int count ) {
        return new PollyRetryPolicyHandler( count );
    }
}