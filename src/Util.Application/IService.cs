using Util.Aop;
using Util.Dependency;

namespace Util.Applications; 

/// <summary>
/// 应用服务
/// </summary>
public interface IService : IScopeDependency, IAopProxy {
}