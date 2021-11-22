using System;
using System.ComponentModel;
using Util.Data.Queries;

namespace Util.Applications.Queries {
    /// <summary>
    /// 客户查询参数
    /// </summary>
    public class CustomerQuery : QueryParameter {
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
        /// 性别
        ///</summary>
        [Description( "性别" )]
        public int? Gender { get; set; }
        /// <summary>
        /// 起始出生日期
        /// </summary>
        public DateTime? BeginBirthday { get; set; }
        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? EndBirthday { get; set; }
        /// <summary>
        /// 民族
        ///</summary>
        [Description( "民族" )]
        public int? Nation { get; set; }
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
        /// <summary>
        /// 起始创建时间
        /// </summary>
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 创建人
        ///</summary>
        [Description( "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        ///</summary>
        [Description( "最后修改人" )]
        public Guid? LastModifierId { get; set; }
    }
}