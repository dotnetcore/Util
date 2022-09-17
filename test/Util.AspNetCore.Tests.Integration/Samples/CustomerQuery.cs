using System.ComponentModel;

namespace Util.AspNetCore.Tests.Samples {
    /// <summary>
    /// 客户查询参数
    /// </summary>
    public class CustomerQuery {
        /// <summary>
        /// 客户标识
        ///</summary>
        [Description( "客户标识" )]
        public int? CustomerId { get; set; }
        /// <summary>
        /// 编码
        ///</summary>
        [Description( "编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 姓名
        ///</summary>
        [Description( "姓名" )]
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        ///</summary>
        [Description( "昵称" )]
        public string Nickname { get; set; }
        /// <summary>
        /// 手机号
        ///</summary>
        [Description( "手机号" )]
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮件
        ///</summary>
        [Description( "电子邮件" )]
        public string Email { get; set; }
    }
}