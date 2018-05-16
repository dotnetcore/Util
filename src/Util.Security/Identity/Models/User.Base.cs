using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Util.Domains;
using Util.Domains.Auditing;

namespace Util.Security.Identity.Models {
    /// <summary>
    /// 用户
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    [DisplayName( "用户" )]
    public abstract partial class User<TUser,TKey> : AggregateRoot<TUser, TKey>, IDelete, IAudited where TUser: User<TUser, TKey> {
        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="id">用户标识</param>
        protected User( TKey id ) : base( id ) {
            _claims = new List<Claim>();
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName( "用户名" )]
        [StringLength( 256, ErrorMessage = "用户名输入过长，不能超过256位" )]
        public string UserName { get; set; }
        /// <summary>
        /// 标准化用户名
        /// </summary>
        [DisplayName( "标准化用户名" )]
        [StringLength( 256, ErrorMessage = "标准化用户名输入过长，不能超过256位" )]
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [DisplayName( "安全邮箱" )]
        [StringLength( 256, ErrorMessage = "安全邮箱输入过长，不能超过256位" )]
        public string Email { get;set; }
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        [DisplayName( "标准化邮箱" )]
        [StringLength( 256, ErrorMessage = "标准化邮箱输入过长，不能超过256位" )]
        public string NormalizedEmail { get; set; }
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [DisplayName( "邮箱已确认" )]
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [DisplayName( "安全手机" )]
        [StringLength( 64, ErrorMessage = "安全手机输入过长，不能超过64位" )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机已确认
        /// </summary>
        [DisplayName( "手机已确认" )]
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName( "密码" )]
        [Required( ErrorMessage = "密码不能为空" )]
        [StringLength( 256, ErrorMessage = "密码输入过长，不能超过256位" )]
        public string Password { get; private set; }
        /// <summary>
        /// 密码散列
        /// </summary>
        [DisplayName( "密码散列" )]
        [StringLength( 1024, ErrorMessage = "密码散列输入过长，不能超过1024位" )]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        [DisplayName( "安全码" )]
        [StringLength( 256, ErrorMessage = "安全码输入过长，不能超过256位" )]
        public string SafePassword { get; private set; }
        /// <summary>
        /// 安全码散列
        /// </summary>
        [DisplayName( "安全码散列" )]
        [StringLength( 1024, ErrorMessage = "安全码散列输入过长，不能超过1024位" )]
        public string SafePasswordHash { get; set; }
        /// <summary>
        /// 启用锁定
        /// </summary>
        [DisplayName( "启用锁定" )]
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 锁定截止
        /// </summary>
        [DisplayName( "锁定截止" )]
        public DateTimeOffset? LockoutEnd { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        [DisplayName( "上次登陆时间" )]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [DisplayName( "上次登陆Ip" )]
        [StringLength( 30, ErrorMessage = "上次登陆Ip输入过长，不能超过30位" )]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        [DisplayName( "本次登陆时间" )]
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [DisplayName( "本次登陆Ip" )]
        [StringLength( 30, ErrorMessage = "本次登陆Ip输入过长，不能超过30位" )]
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [DisplayName( "登陆次数" )]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        [DisplayName( "登陆失败次数" )]
        public int AccessFailedCount { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        [DisplayName( "启用两阶段认证" )]
        public bool TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>
        [DisplayName( "冻结时间" )]
        public DateTime? DisabledTime { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>
        [DisplayName( "注册Ip" )]
        [StringLength( 30, ErrorMessage = "注册Ip输入过长，不能超过30位" )]
        public string RegisterIp { get; set; }
        /// <summary>
        /// 安全戳
        /// </summary>
        [DisplayName( "安全戳" )]
        [StringLength( 1024, ErrorMessage = "安全戳输入过长，不能超过1024位" )]
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        public string Comment { get; set; }
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
        /// 是否删除
        /// </summary>
        [DisplayName( "是否删除" )]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.UserName );
            AddDescription( t => t.NormalizedUserName );
            AddDescription( t => t.Email );
            AddDescription( t => t.NormalizedEmail );
            AddDescription( t => t.EmailConfirmed );
            AddDescription( t => t.PhoneNumber );
            AddDescription( t => t.PhoneNumberConfirmed );
            AddDescription( t => t.Password );
            AddDescription( t => t.PasswordHash );
            AddDescription( t => t.SafePassword );
            AddDescription( t => t.SafePasswordHash );
            AddDescription( t => t.LockoutEnabled );
            AddDescription( t => t.LockoutEnd );
            AddDescription( t => t.LastLoginTime );
            AddDescription( t => t.LastLoginIp );
            AddDescription( t => t.CurrentLoginTime );
            AddDescription( t => t.CurrentLoginIp );
            AddDescription( t => t.LoginCount );
            AddDescription( t => t.AccessFailedCount );
            AddDescription( t => t.TwoFactorEnabled );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.DisabledTime );
            AddDescription( t => t.RegisterIp );
            AddDescription( t => t.Comment );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( TUser other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.UserName, other.UserName );
            AddChange( t => t.NormalizedUserName, other.NormalizedUserName );
            AddChange( t => t.Email, other.Email );
            AddChange( t => t.NormalizedEmail, other.NormalizedEmail );
            AddChange( t => t.EmailConfirmed, other.EmailConfirmed );
            AddChange( t => t.PhoneNumber, other.PhoneNumber );
            AddChange( t => t.PhoneNumberConfirmed, other.PhoneNumberConfirmed );
            AddChange( t => t.Password, other.Password );
            AddChange( t => t.PasswordHash, other.PasswordHash );
            AddChange( t => t.SafePassword, other.SafePassword );
            AddChange( t => t.SafePasswordHash, other.SafePasswordHash );
            AddChange( t => t.LockoutEnabled, other.LockoutEnabled );
            AddChange( t => t.LockoutEnd, other.LockoutEnd );
            AddChange( t => t.LastLoginTime, other.LastLoginTime );
            AddChange( t => t.LastLoginIp, other.LastLoginIp );
            AddChange( t => t.CurrentLoginTime, other.CurrentLoginTime );
            AddChange( t => t.CurrentLoginIp, other.CurrentLoginIp );
            AddChange( t => t.LoginCount, other.LoginCount );
            AddChange( t => t.AccessFailedCount, other.AccessFailedCount );
            AddChange( t => t.TwoFactorEnabled, other.TwoFactorEnabled );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.DisabledTime, other.DisabledTime );
            AddChange( t => t.RegisterIp, other.RegisterIp );
            AddChange( t => t.Comment, other.Comment );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}