using Microsoft.AspNetCore.Mvc;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;
using Util.Ui.Datas;
using Util.Ui.Prime.Datas;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Apis.Systems {
    /// <summary>
    /// 应用程序Api控制器
    /// </summary>
    public class ApplicationController : CrudControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序Api控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) {
            ApplicationService = service;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IApplicationService ApplicationService { get; }

        [HttpGet("a")]
        public IActionResult GetA() {
            PrimeTreeNode<Test> node = new PrimeTreeNode<Test>();
            node.Data = new Test {Name = "a",Size = "b",Type = "c"};
            node.Children = new []{  new PrimeTreeNode<Test>(){ Data = new Test { Name = "a", Size = "b", Type = "c" }}};
            PrimeTreeNode<Test> node2 = new PrimeTreeNode<Test>();
            node2.Data = new Test { Name = "a", Size = "b", Type = "c" };
            node2.Children = new[] { new PrimeTreeNode<Test>() { Data = new Test { Name = "a", Size = "b", Type = "c" } } };
            return Success( new[]{ node, node2 } );
        }
    }

    public class Test {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
    }
}