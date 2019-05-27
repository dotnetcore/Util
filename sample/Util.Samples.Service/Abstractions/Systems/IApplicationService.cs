using Util.Applications;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;

namespace Util.Samples.Service.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}