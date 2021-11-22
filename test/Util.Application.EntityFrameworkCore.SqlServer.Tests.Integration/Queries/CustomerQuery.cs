using System;
using System.ComponentModel;
using Util.Data.Queries;
using Util.Domain.Biz.Enums;

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
        /// </summary>
        private string _code = string.Empty;
        /// <summary>
        /// 编码
        /// </summary>
        [Description( "编码" )]
        public string Code { 
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private string _name = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        [Description( "姓名" )]
        public string Name { 
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        /// <summary>
        /// 昵称
        /// </summary>
        private string _nickname = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [Description( "昵称" )]
        public string Nickname { 
            get => _nickname == null ? string.Empty : _nickname.Trim();
            set => _nickname = value;
        }
        /// <summary>
        /// 性别
        ///</summary>
        [Description( "性别" )]
        public Gender? Gender { get; set; }
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
        public Nation? Nation { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        private string _phone = string.Empty;
        /// <summary>
        /// 手机号
        /// </summary>
        [Description( "手机号" )]
        public string Phone { 
            get => _phone == null ? string.Empty : _phone.Trim();
            set => _phone = value;
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        private string _email = string.Empty;
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Description( "电子邮件" )]
        public string Email { 
            get => _email == null ? string.Empty : _email.Trim();
            set => _email = value;
        }
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