using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Util.Datas.Queries;
using Util.Ui.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Demo {
    /// <summary>
    /// 树形控制器
    /// </summary>
    public class TreeController : WebApiControllerBase {
        /// <summary>
        /// 获取树形列表
        /// </summary>
        [HttpGet]
        public IActionResult GetTreeNodes( QueryParameter parameter ) {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4(), GetNode5() };
            var result = new TreeResult( list ).GetResult();
            return Success( result );
        }

        /// <summary>
        /// 获取节点1
        /// </summary>
        private TreeDto GetNode1() {
            return new TreeDto {
                Id = "1",
                Text = "测试节点1"
            };
        }

        /// <summary>
        /// 获取节点2
        /// </summary>
        private TreeDto GetNode2() {
            return new TreeDto {
                Id = "2",
                ParentId = "1",
                Text = "测试节点2"
            };
        }

        /// <summary>
        /// 获取节点3
        /// </summary>
        private TreeDto GetNode3() {
            return new TreeDto {
                Id = "3",
                Text = "测试节点3"
            };
        }

        /// <summary>
        /// 获取节点4
        /// </summary>
        private TreeDto GetNode4() {
            return new TreeDto {
                Id = "4",
                ParentId = "1",
                Text = "测试节点4",
            };
        }

        /// <summary>
        /// 获取节点5
        /// </summary>
        private TreeDto GetNode5() {
            return new TreeDto {
                Id = "5",
                ParentId = "4",
                Text = "测试节点5"
            };
        }
    }
}