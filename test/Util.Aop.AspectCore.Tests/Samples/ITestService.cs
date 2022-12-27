using Util.Dependency;

namespace Util.Aop.AspectCore.Tests.Samples {
    /// <summary>
    /// 测试服务
    /// </summary>
    public interface ITestService : ISingletonDependency{
        /// <summary>
        /// 获取值,值不能为空
        /// </summary>
        /// <param name="value">参数</param>
        string GetNotEmptyValue( [NotEmpty] string value );
        /// <summary>
        /// 获取值,值不能为null
        /// </summary>
        /// <param name="value">参数</param>
        string GetNotNullValue( [NotNull] string value );
    }
}
