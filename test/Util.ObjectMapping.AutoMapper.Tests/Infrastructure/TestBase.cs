using Util.Helpers;
using Xunit;

namespace Util.ObjectMapping.AutoMapper.Tests.Infrastructure {
    /// <summary>
    /// 测试基类
    /// </summary>
    [Collection( "GlobalConfig" )]
    public abstract class TestBase {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        protected T GetService<T>() {
            return Ioc.Create<T>();
        }
    }
}
