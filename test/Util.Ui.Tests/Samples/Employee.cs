using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 员工
    /// </summary>
    [Model( "employee" )]
    public class Employee {
        /// <summary>
        /// 编码
        ///</summary>
        [Description( "编码" )]
        [MaxLength( 100 )]
        [Required(ErrorMessage = "编码不能是空值" )]
        public string Code { get; set; }
        /// <summary>
        /// 姓名
        ///</summary>
        [Description( "姓名" )]
        [MaxLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        ///</summary>
        [Description( "昵称" )]
        [MaxLength( 50 )]
        public string Nickname { get; set; }
        /// <summary>
        /// 性别
        ///</summary>
        [Description( "性别" )]
        public int? Gender { get; set; }
        /// <summary>
        /// 出生日期
        ///</summary>
        [Description( "出生日期" )]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 民族
        ///</summary>
        [Description( "民族" )]
        public int? Nation { get; set; }
        /// <summary>
        /// 手机号
        ///</summary>
        [Description( "手机号" )]
        [MaxLength( 50 )]
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮件
        ///</summary>
        [Description( "电子邮件" )]
        [MaxLength( 500 )]
        public string Email { get; set; }
    }
}