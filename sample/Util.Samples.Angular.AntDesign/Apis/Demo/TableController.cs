using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Util.Domains.Repositories;
using Util.Samples.Models.Demo;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Demo {
    /// <summary>
    /// 表格控制器
    /// </summary>
    public class TableController : WebApiControllerBase {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        [HttpGet( "users" )]
        public IActionResult GetUsers() {
            var list = new List<UserModel> {
                new UserModel {Key = "1", Name = "John Brown", Age = 30, Address = "New York No. 1 Lake Park"},
                new UserModel {Key = "2", Name = "Jim Green", Age = 42, Address = "London No. 1 Lake Park"},
                new UserModel {Key = "3", Name = "Joe Black", Age = 55, Address = "Sidney No. 1 Lake Park"},
                new UserModel {Key = "4", Name = "A Black", Age = 44, Address = "A No. 1 Lake Park"},
                new UserModel {Key = "5", Name = "B Black", Age = 33, Address = "B No. 1 Lake Park"},
                new UserModel {Key = "6", Name = "C Black", Age = 23, Address = "C No. 1 Lake Park"},
                new UserModel {Key = "7", Name = "D Black", Age = 12, Address = "D No. 1 Lake Park"},
                new UserModel {Key = "8", Name = "E Black", Age = 64, Address = "E No. 1 Lake Park"},
                new UserModel {Key = "9", Name = "F Black", Age = 34, Address = "F No. 1 Lake Park"},
                new UserModel {Key = "10", Name = "G Black", Age = 56, Address = "G No. 1 Lake Park"},
                new UserModel {Key = "11", Name = "H Black", Age = 64, Address = "H No. 1 Lake Park"},
                new UserModel {Key = "12", Name = "J Black", Age = 87, Address = "J No. 1 Lake Park"},
                new UserModel {Key = "13", Name = "K Black", Age = 34, Address = "K No. 1 Lake Park"},
                new UserModel {Key = "14", Name = "Q Black", Age = 32, Address = "Q No. 1 Lake Park"},
                new UserModel {Key = "15", Name = "W Black", Age = 54, Address = "W No. 1 Lake Park"},
                new UserModel {Key = "16", Name = "Z Black", Age = 98, Address = "Z No. 1 Lake Park"},
                new UserModel {Key = "17", Name = "R Black", Age = 78, Address = "R No. 1 Lake Park"},
                new UserModel {Key = "18", Name = "T Black", Age = 67, Address = "T No. 1 Lake Park"},
                new UserModel {Key = "19", Name = "O Black", Age = 56, Address = "O No. 1 Lake Park"},
                new UserModel {Key = "20", Name = "P Black", Age = 54, Address = "P No. 1 Lake Park"},
                new UserModel {Key = "21", Name = "N Black", Age = 43, Address = "N No. 1 Lake Park"}
            };
            var result = new PagerList<UserModel>( 1,10,22, list );
            return Success( result );
        }
    }
}