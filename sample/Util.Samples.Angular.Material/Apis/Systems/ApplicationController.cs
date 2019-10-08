using Util.Samples.Service.Abstractions.Systems;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Systems {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : CrudControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) {
        }
    }
}