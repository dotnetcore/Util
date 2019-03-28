using System;
using System.ComponentModel.DataAnnotations;
using Util.Biz.Enums;
using Util.Ui.Attributes;

namespace Util.Samples.Models.Demo {
    /// <summary>
    /// 用户视图模型
    /// </summary>
    [Model]
    public class UserModel {
        /// <summary>
        /// 标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名" )]
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Display( Name = "年龄" )]
        public double Age { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        [Display( Name = "出生年月" )]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Display( Name = "地址" )]
        public string Address { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [Display( Name = "民族" )]
        public Nation Nation { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [Display( Name = "民族" )]
        public string NationDescription => Nation.Description();
    }
}
