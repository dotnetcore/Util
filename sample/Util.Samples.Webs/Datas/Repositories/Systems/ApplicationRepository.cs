using System.Threading.Tasks;
using Util.Datas.Ef.Core;
using Util.Domains.Repositories;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;
using Util.Samples.Webs.Services.Queries.Systems;

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

        /// <summary>
        /// 测试Sql查询对象
        /// </summary>
        public async Task<PagerList<Application>> TestSqlQuery( ApplicationQuery query ) {
            return await Sql
                .Select<Application>( t => t.Id, "Id" )
                .Select<Application>( t => new object[] { t.Code, t.Name, t.Comment, t.Enabled, t.RegisterEnabled, t.Version } )
                .From<Application>()
                .WhereIfNotEmpty<Application>( t => t.Code.Contains( query.Keyword ) )
                .ToPagerListAsync<Application>( query );
        }
    }
}
