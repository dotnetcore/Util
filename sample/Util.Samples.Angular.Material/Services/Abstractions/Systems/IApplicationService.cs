using Util.Applications;
using Util.Samples.Services.Dtos.Systems;
using Util.Samples.Services.Queries.Systems;

namespace Util.Samples.Services.Abstractions.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : ICrudService<ApplicationDto, ApplicationQuery> {
    }
}