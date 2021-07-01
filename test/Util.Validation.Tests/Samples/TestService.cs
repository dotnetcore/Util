using System.Collections.Generic;

namespace Util.Validation.Tests.Samples {
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService : ITestService{
        /// <summary>
        /// 验证单个值
        /// </summary>
        /// <param name="value">参数</param>
        public void Call( Sample value ) {
        }

        /// <summary>
        /// 验证集合
        /// </summary>
        /// <param name="value">参数</param>
        public void CallCollection( List<Sample> value ) {
        }
    }
}
