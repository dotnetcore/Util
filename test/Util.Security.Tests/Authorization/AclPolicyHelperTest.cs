using Util.Security.Authorization;
using Xunit;

namespace Util.Security.Tests.Authorization {
    /// <summary>
    /// 授权辅助操作测试
    /// </summary>
    public class AclPolicyHelperTest {
        /// <summary>
        /// 授权策略
        /// </summary>
        private const string Policy = "acl_{\"Ignore\":true,\"Uri\":\"test\"}";

        /// <summary>
        /// 测试获取授权策略
        /// </summary>
        [Fact]
        public void TestGetPolicy() {
            var result = AclPolicyHelper.GetPolicy( "test", true );
            Assert.Equal( Policy, result );
        }

        /// <summary>
        /// 测试获取授权要求
        /// </summary>
        [Fact]
        public void TestGetRequirement() {
            var result = AclPolicyHelper.GetRequirement( Policy );
            Assert.Equal( "test", result.Uri );
            Assert.True( result.Ignore );
        }
    }
}
