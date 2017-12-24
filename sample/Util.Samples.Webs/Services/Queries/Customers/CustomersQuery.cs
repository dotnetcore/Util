using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace Donau.Services.Queries.Customers {
    /// <summary>
    /// 客户查询实体
    /// </summary>
    public class CustomersQuery : QueryParameter {
        
        private string _customerId = string.Empty;
        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name="客户编号")]
        public string CustomerId {
            get => _customerId == null ? string.Empty : _customerId.Trim();
            set => _customerId=value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name="客户名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name=value;
        }
        
        private string _nickname = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name="昵称")]
        public string Nickname {
            get => _nickname == null ? string.Empty : _nickname.Trim();
            set => _nickname=value;
        }
        /// <summary>
        /// 余额
        /// </summary>
        [Display(Name="余额")]
        public decimal? Balance { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name="性别")]
        public int? Gender { get; set; }
        
        private string _tel = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name="联系电话")]
        public string Tel {
            get => _tel == null ? string.Empty : _tel.Trim();
            set => _tel=value;
        }
        
        private string _mobile = string.Empty;
        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name="手机号")]
        public string Mobile {
            get => _mobile == null ? string.Empty : _mobile.Trim();
            set => _mobile=value;
        }
        
        private string _email = string.Empty;
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Display(Name="电子邮件")]
        public string Email {
            get => _email == null ? string.Empty : _email.Trim();
            set => _email=value;
        }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreationTime { get; set; }        
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        [Display( Name = "起始最后修改时间" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        [Display( Name = "结束最后修改时间" )]
        public DateTime? EndLastModificationTime { get; set; }        
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Display(Name="最后修改人")]
        public Guid? LastModifierId { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            base.AddDescriptions();
            AddDescription( "客户编号", CustomerId );
            AddDescription( "客户名称", Name );
            AddDescription( "昵称", Nickname );
            AddDescription( "余额", Balance );
            AddDescription( "性别", Gender );
            AddDescription( "联系电话", Tel );
            AddDescription( "手机号", Mobile );
            AddDescription( "电子邮件", Email );
            AddDescription( "起始创建时间", BeginCreationTime );
            AddDescription( "结束创建时间", EndCreationTime );
            AddDescription( "创建人", CreatorId );
            AddDescription( "起始最后修改时间", BeginLastModificationTime );
            AddDescription( "结束最后修改时间", EndLastModificationTime );
            AddDescription( "最后修改人", LastModifierId );
        } 
    }
}
