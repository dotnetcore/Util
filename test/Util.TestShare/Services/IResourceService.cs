using Util.Applications.Trees;
using Util.Tests.Dtos;
using Util.Tests.Queries;

namespace Util.Tests.Services {
    /// <summary>
    /// 资源服务
    /// </summary>
    public interface IResourceService : ITreeService<ResourceDto,ResourceQuery> {
    }
}