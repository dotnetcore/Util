using Xunit;

namespace Util.Validation.Tests.Infrastructure {
    /// <summary>
    /// 全局测试配置
    /// </summary>
    [CollectionDefinition( "GlobalConfig" )]
    public class GlobalConfig : ICollectionFixture<GlobalFixture> {
    }
}
