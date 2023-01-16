using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Biz.Enums;

namespace Util.Ui.Tests.Samples {
	/// <summary>
	/// 客户
	/// </summary>
	public class Customer {
		/// <summary>
		/// 编码
		///</summary>
		[Description( "编码" )]
		[Required( ErrorMessage = "编码不能是空值" )]
		[StringLength( 50, MinimumLength = 5, ErrorMessage = "编码不能超过50位,也不能小于5位" )]
		public string Code { get; set; }
		/// <summary>
		/// 姓名
		///</summary>
		[Description( "姓名" )]
		[MaxLength( 200, ErrorMessage = "姓名不能超过200位" )]
		[MinLength( 2, ErrorMessage = "姓名不能少于2位" )]
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
		public Gender? Gender { get; set; }
		/// <summary>
		/// 密码
		///</summary>
		[Description( "密码" )]
		[DataType( DataType.Password )]
		public string Password { get; set; }
		/// <summary>
		/// 出生日期
		///</summary>
		[Description( "出生日期" )]
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
		[Phone( ErrorMessage = "手机号无效" )]
		public string Phone { get; set; }
		/// <summary>
		/// 电话
		///</summary>
		[Description( "电话" )]
		public int Tel { get; set; }
		/// <summary>
		/// 年龄
		///</summary>
		[Description( "年龄" )]
		[Range( 1.1, 99.99, ErrorMessage = "年龄从1.1到99.99" )]
		public double Age { get; set; }
		/// <summary>
		/// 电子邮件
		///</summary>
		[Description( "电子邮件" )]
		[EmailAddress( ErrorMessage = "电子邮件无效" )]
		public string Email { get; set; }
		/// <summary>
		/// 身份证
		///</summary>
		[Description( "身份证" )]
		[IdCard( ErrorMessage = "身份证无效" )]
		public string IdCard { get; set; }
		/// <summary>
		/// 网址
		///</summary>
		[Description( "网址" )]
		[Url( ErrorMessage = "网址无效" )]
		public string Url { get; set; }
		/// <summary>
		/// 正则表达式
		///</summary>
		[Description( "正则表达式" )]
		[RegularExpression( "a", ErrorMessage = "正则表达式无效" )]
		public string Regular { get; set; }
		/// <summary>
		/// 启用
		///</summary>
		[Description( "启用" )]
		public bool Enabled { get; set; }
		/// <summary>
		/// 员工
		/// </summary>
		public Employee Employee { get; set; }
	}
}