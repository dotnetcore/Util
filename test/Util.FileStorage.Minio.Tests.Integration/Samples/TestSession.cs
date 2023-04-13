using System;
using Util.Sessions;

namespace Util.FileStorage.Minio.Samples {
    /// <summary>
    /// 测试用户会话
    /// </summary>
    public class TestSession : ISession {
        public static Guid TestUserId = new ( "2af5e99e-391c-451b-9112-f7a3eb9b0a55" );
        public bool IsAuthenticated => true;
        public string UserId => TestUserId.ToString();
    }
}
