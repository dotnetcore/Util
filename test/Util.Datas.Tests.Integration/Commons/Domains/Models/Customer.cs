using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;
using Util.Domains.Auditing;

namespace Util.Datas.Tests.Commons.Domains.Models {
    /// <summary>
    /// 客户 - 字符串类型标识
    /// </summary>
    [DisplayName( "客户" )]
    public class Customer : AggregateRoot<Customer, string>, IAudited {
        /// <summary>
        /// 初始化客户
        /// </summary>
        public Customer() : this( string.Empty ) {
        }

        /// <summary>
        /// 初始化客户
        /// </summary>
        /// <param name="id">客户标识</param>
        public Customer( string id ) : base( id ) {
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        [DisplayName( "客户名称" )]
        [Required( ErrorMessage = "客户名称不能为空" )]
        [StringLength( 20, ErrorMessage = "客户名称输入过长，不能超过20位" )]
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName( "昵称" )]
        [StringLength( 30, ErrorMessage = "昵称输入过长，不能超过30位" )]
        public string Nickname { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        [DisplayName( "余额" )]
        [Required( ErrorMessage = "余额不能为空" )]
        public decimal Balance { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName( "性别" )]
        public int? Gender { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName( "联系电话" )]
        [StringLength( 20, ErrorMessage = "联系电话输入过长，不能超过20位" )]
        public string Tel { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName( "手机号" )]
        [StringLength( 20, ErrorMessage = "手机号输入过长，不能超过20位" )]
        public string Mobile { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [DisplayName( "电子邮件" )]
        [StringLength( 100, ErrorMessage = "电子邮件输入过长，不能超过100位" )]
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [DisplayName( "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [DisplayName( "最后修改人" )]
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "客户编号", Id );
            AddDescription( "客户名称", Name );
            AddDescription( "昵称", Nickname );
            AddDescription( "余额", Balance );
            AddDescription( "性别", Gender );
            AddDescription( "联系电话", Tel );
            AddDescription( "手机号", Mobile );
            AddDescription( "电子邮件", Email );
            AddDescription( "创建时间", CreationTime );
            AddDescription( "创建人", CreatorId );
            AddDescription( "最后修改时间", LastModificationTime );
            AddDescription( "最后修改人", LastModifierId );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Customer other ) {
            AddChange( "Id", "客户编号", Id, other.Id );
            AddChange( "Name", "客户名称", Name, other.Name );
            AddChange( "Nickname", "昵称", Nickname, other.Nickname );
            AddChange( "Balance", "余额", Balance, other.Balance );
            AddChange( "Gender", "性别", Gender, other.Gender );
            AddChange( "Tel", "联系电话", Tel, other.Tel );
            AddChange( "Mobile", "手机号", Mobile, other.Mobile );
            AddChange( "Email", "电子邮件", Email, other.Email );
            AddChange( "CreationTime", "创建时间", CreationTime, other.CreationTime );
            AddChange( "CreatorId", "创建人", CreatorId, other.CreatorId );
            AddChange( "LastModificationTime", "最后修改时间", LastModificationTime, other.LastModificationTime );
            AddChange( "LastModifierId", "最后修改人", LastModifierId, other.LastModifierId );
        }

        /// <summary>
        /// 添加客户集合
        /// </summary>
        public static List<Customer> CreateCustomers() {
            return new List<Customer> {
                new Customer( Util.Helpers.Id.ObjectId() ) {Name = "A",Nickname = "A1",Mobile = "1"},
                new Customer( Util.Helpers.Id.ObjectId() ) {Name = "A",Nickname = "A2",Mobile = "2"},
                new Customer( Util.Helpers.Id.ObjectId() ) {Name = "B",Nickname = "B1",Mobile = "3"},
                new Customer( Util.Helpers.Id.ObjectId() ) {Name = "B",Nickname = "B2",Mobile = "4"},
                new Customer( Util.Helpers.Id.ObjectId() ) {Name = "C",Mobile = "5"}
            };
        }
    }
}