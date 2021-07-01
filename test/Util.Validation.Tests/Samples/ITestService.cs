using System.Collections.Generic;
using Util.Dependency;

namespace Util.Validation.Tests.Samples {
    /// <summary>
    /// 测试服务
    /// </summary>
    public interface ITestService : ISingletonDependency{
        /// <summary>
        /// 验证单个值
        /// </summary>
        /// <param name="value">参数</param>
        void Call( [Valid] Sample value );
        /// <summary>
        /// 验证集合
        /// </summary>
        /// <param name="value">参数</param>
        void CallCollection( [Valid] List<Sample> value );
    }
}
