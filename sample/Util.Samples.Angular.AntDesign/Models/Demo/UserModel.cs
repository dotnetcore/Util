using System.ComponentModel.DataAnnotations;

namespace Util.Samples.Models.Demo {
    /// <summary>
    /// 用户视图模型
    /// </summary>
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
        /// 地址
        /// </summary>
        [Display( Name = "地址" )]
        public string Address { get; set; }
    }
}
