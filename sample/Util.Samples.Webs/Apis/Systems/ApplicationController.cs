using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;
using Util.Ui.Datas;
using Util.Ui.Extensions;
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

        [HttpGet( "a" )]
        public IActionResult GetA() {
            var tests = new List<Test> {
                new Test { Id = "1",Name = "a", Size = "b", Type = "c" },
                new Test { Id = "2",ParentId = "1",Name = "a", Size = "b", Type = "c" },
                new Test { Id = "3",ParentId = "1", Name = "a", Size = "b", Type = "c" },
                new Test { Id = "4",Name = "a", Size = "b", Type = "c" },
                new Test { Id = "5",ParentId = "4",Name = "a", Size = "b", Type = "c" },
                new Test { Id = "6",ParentId = "4", Name = "a", Size = "b", Type = "c" }
            };
            return Success( tests.ToPrimeTreeNodes() );
        }
    }

    public class Test:ITreeNode {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Path { get; set; }
        public int? Level { get; set; }
    }
}