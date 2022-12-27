using System;
using Util.Sessions;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 测试用户会话
    /// </summary>
    public class TestSession : ISession {
        public TestSession() {
            UserId = TestUserId.ToString();
        }

        public bool IsAuthenticated => true;
        public string UserId { get; set; }

        /// <summary>
        /// 测试用户标识
        /// </summary>
        public static Guid TestUserId = Guid.NewGuid();

        /// <summary>
        /// 测试用户标识2
        /// </summary>
        public static Guid TestUserId2 = Guid.NewGuid();
    }
}
