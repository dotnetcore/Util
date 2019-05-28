using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Biz.Enums;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Samples.Models.Demo;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Demo {
    /// <summary>
    /// 表格控制器
    /// </summary>
    public class TableController : WebApiControllerBase {
        /// <summary>
        /// 获取空分页列表
        /// </summary>
        [HttpGet( "empty-page-list" )]
        public async Task<IActionResult> GetEmptyPageList( QueryParameter parameter ) {
            await Task.Delay( 1000 );
            var result = new PagerList<UserModel>( parameter.Page, parameter.PageSize, CreateList().Count );
            return Success( result );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        [HttpGet( "page-list" )]
        public async Task<IActionResult> GetPageList( QueryParameter parameter ) {
            await Task.Delay( 1000 );
            parameter.TotalCount = CreateList().Count;
            var list = CreateList().Skip( parameter.GetSkipCount() ).Take( parameter.PageSize );
            var result = new PagerList<UserModel>( parameter, list );
            return Success( result );
        }

        /// <summary>
        /// 获取空列表
        /// </summary>
        [HttpGet( "empty-list" )]
        public IActionResult GetEmptyList() {
            return Success();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpGet( "list" )]
        public async Task<IActionResult> GetList() {
            await Task.Delay( 1000 );
            return Success( CreateList() );
        }

        /// <summary>
        /// 创建列表
        /// </summary>
        private List<UserModel> CreateList() {
            return new List<UserModel> {
                new UserModel {Key = "1", Name = "John Brown",Nation = Nation.Hz, Age = 30, Address = "New York No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate() },
                new UserModel {Key = "2", Name = "Jim Green", Nation = Nation.Mz,Age = 42, Address = "London No. 1 Lake Park",Birthday="1990-2-1 2:2:2".ToDate()},
                new UserModel {Key = "3", Name = "Joe Black",Nation = Nation.Byz, Age = 55, Address = "Sidney No. 1 Lake Park",Birthday="1990-2-1 2:2:2".ToDate()},
                new UserModel {Key = "4", Name = "A Black", Nation = Nation.Daz,Age = 44, Address = "宇宙银河系太阳系地球中国四川成都宇宙银河系太阳系地球中国四川成都宇宙银河系太阳系地球中国四川成都宇宙银河系太阳系地球中国四川成都宇宙银河系太阳系地球中国四川成都宇宙银河系太阳系地球中国四川成都",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "5", Name = "B Black",Nation = Nation.Hnz, Age = 33, Address = "B No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "6", Name = "C Black", Nation = Nation.Baz,Age = 23, Address = "C No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "7", Name = "D Black",Nation = Nation.Baz, Age = 12, Address = "D No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "8", Name = "E Black",Nation = Nation.Baz, Age = 64, Address = "E No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "9", Name = "F Black", Nation = Nation.Baz,Age = 34, Address = "F No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "10", Name = "G Black",Nation = Nation.Baz, Age = 56, Address = "G No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "11", Name = "H Black",Nation = Nation.Baz, Age = 64, Address = "H No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "12", Name = "J Black",Nation = Nation.Baz, Age = 87, Address = "J No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "13", Name = "K Black",Nation = Nation.Baz, Age = 34, Address = "K No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "14", Name = "Q Black",Nation = Nation.Baz, Age = 32, Address = "Q No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "15", Name = "W Black",Nation = Nation.Baz, Age = 54, Address = "W No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "16", Name = "Z Black",Nation = Nation.Baz, Age = 98, Address = "Z No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "17", Name = "R Black",Nation = Nation.Baz, Age = 78, Address = "R No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "18", Name = "T Black", Nation = Nation.Baz,Age = 67, Address = "T No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "19", Name = "O Black",Nation = Nation.Baz, Age = 56, Address = "O No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "20", Name = "P Black", Nation = Nation.Baz,Age = 54, Address = "P No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()},
                new UserModel {Key = "21", Name = "N Black", Nation = Nation.Baz,Age = 43, Address = "N No. 1 Lake Park",Birthday="1990-1-1 2:2:2".ToDate()}
            };
        }
    }
}