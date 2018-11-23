using Util.Datas.Ef.Core;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;

namespace Util.Samples.Webs.Datas.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( ISampleUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
