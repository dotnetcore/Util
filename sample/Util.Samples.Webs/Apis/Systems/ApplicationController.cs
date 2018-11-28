using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Datas.Sql.Queries;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Apis.Systems {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : CrudControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        /// <param name="sqlQuery">Sql查询对象</param>
        public ApplicationController( IApplicationService service, ISqlQuery sqlQuery ) : base( service ) {
            ApplicationService = service;
            SqlQuery = sqlQuery;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IApplicationService ApplicationService { get; }
        /// <summary>
        /// Sql查询对象
        /// </summary>
        public ISqlQuery SqlQuery { get; }

        /// <summary>
        /// 测试Sql查询对象
        /// </summary>
        [HttpGet]
        public override async Task<IActionResult> PagerQueryAsync( ApplicationQuery query ) {
            var result = await SqlQuery.Select<Application>( t => t.Id, "Id" )
                .Select<Application>( t => new object[] { t.Code, t.Comment, t.Enabled, t.Name, t.RegisterEnabled } )
                .From<Application>( "a" )
                .ToPagerListAsync<ApplicationDto>( query );
            return Success( result );
        }
    }
}