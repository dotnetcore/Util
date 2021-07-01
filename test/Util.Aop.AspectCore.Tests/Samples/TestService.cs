namespace Util.Aop.AspectCore.Tests.Samples {
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService : ITestService{
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="value">参数</param>
        public string GetNotEmptyValue( string value ) {
            return value;
        }

        /// <summary>
        /// 获取值,值不能为null
        /// </summary>
        /// <param name="value">参数</param>
        public string GetNotNullValue( [NotNull] string value ) {
            return value;
        }
    }
}
