using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Biz.Enums;

namespace Util.Ui.NgAlain.Tests.Samples {
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer {
        /// <summary>
        /// 编码
        ///</summary>
        [Description( "编码" )]
        [MaxLength( 100 )]
        [MinLength( 10, ErrorMessage = "编码最小为10位" )]
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
		/// 密码
		///</summary>
		[Description( "密码" )]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 性别
        ///</summary>
        [Description( "性别" )]
        public Gender? Gender { get; set; }
		/// <summary>
		/// 出生日期
		///</summary>
		[Description( "出生日期" )]
        [Required]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 民族
        ///</summary>
        [Description( "民族" )]
        public Nation? Nation { get; set; }
        /// <summary>
        /// 手机号
        ///</summary>
        [Description( "手机号" )]
        [Phone( ErrorMessage = "手机号错误" )]
        public int Phone { get; set; }
        /// <summary>
        /// 身份证
        ///</summary>
        [Description( "身份证" )]
        [IdCard( ErrorMessage = "身份证错误" )]
        public int IdCard { get; set; }
        /// <summary>
        /// 年龄
        ///</summary>
        [Description( "年龄" )]
        [Required]
        [Range( 5.5,8.8 )]
        public double Age { get; set; }
        /// <summary>
        /// 电子邮件
        ///</summary>
        [Description( "电子邮件" )]
        [EmailAddress(ErrorMessage = "email错误")]
        public string Email { get; set; }
        /// <summary>
        /// 启用
        ///</summary>
        [Description( "启用" )]
        public bool Enabled { get; set; }
    }
}