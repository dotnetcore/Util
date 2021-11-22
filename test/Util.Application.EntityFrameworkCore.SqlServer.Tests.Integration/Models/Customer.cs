using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Biz.Enums;
using Util.Domain.Entities;

namespace Util.Applications.Models {
    /// <summary>
    /// 客户
    /// </summary>
    [Description( "客户" )]
    public class Customer : AggregateRoot<Customer,int>,IDelete{
        /// <summary>
        /// 初始化客户
        /// </summary>
        public Customer() : this( 0 ) {
        }

        /// <summary>
        /// 初始化客户
        /// </summary>
        /// <param name="id">客户标识</param>
        public Customer( int id ) : base( id ) {
        }

        /// <summary>
        /// 编码
        ///</summary>
        [Description( "编码" )]
        [MaxLength( 100 )]
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
        public Gender? Gender { get; set; }
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
        [MaxLength( 50 )]
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮件
        ///</summary>
        [Description( "电子邮件" )]
        [MaxLength( 500 )]
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
        [Description( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        ///</summary>
        [Description( "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        ///</summary>
        [Description( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        ///</summary>
        [Description( "最后修改人" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        ///</summary>
        [Description( "是否删除" )]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Customer other ) {
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Nickname, other.Nickname );
            AddChange( t => t.Gender, other.Gender );
            AddChange( t => t.Birthday, other.Birthday );
            AddChange( t => t.Nation, other.Nation );
            AddChange( t => t.Phone, other.Phone );
            AddChange( t => t.Email, other.Email );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}