using System;

namespace Util.Dependency {
    /// <summary>
    /// 依赖关系配置,用于覆盖实现类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IocAttribute : Attribute {
        /// <summary>
        /// 初始化依赖关系配置
        /// </summary>
        /// <param name="priority">优先级,值越大优先级越高</param>
        public IocAttribute( int priority ) {
            Priority = priority;
        }

        /// <summary>
        /// 优先级,值越大优先级越高
        /// </summary>
        public int Priority { get; set; }
    }
}
