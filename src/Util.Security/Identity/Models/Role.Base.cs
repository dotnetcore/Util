using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Trees;

namespace Util.Security.Identity.Models {
    /// <summary>
    /// 角色
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TKey">角色标识类型</typeparam>
    /// <typeparam name="TParentId">角色父标识类型</typeparam>
    [Description( "角色" )]
    public abstract partial class Role<TRole,TKey, TParentId> : TreeEntityBase<TRole, TKey, TParentId>, IDelete, IAudited where TRole: Role<TRole, TKey, TParentId> {
        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="id">角色标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        protected Role( TKey id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// 角色编码
        /// </summary>
        [Required( ErrorMessage = "角色编码不能为空" )]
        [StringLength( 256, ErrorMessage = "角色编码输入过长，不能超过256位" )]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required( ErrorMessage = "角色名称不能为空" )]
        [StringLength( 256, ErrorMessage = "角色名称输入过长，不能超过256位" )]
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Required( ErrorMessage = "标准化角色名称不能为空" )]
        [StringLength( 256, ErrorMessage = "标准化角色名称输入过长，不能超过256位" )]
        public string NormalizedName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Required( ErrorMessage = "角色类型不能为空" )]
        [StringLength( 80, ErrorMessage = "角色类型输入过长，不能超过80位" )]
        public string Type { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public bool IsAdmin { get; private set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        public string Comment { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength( 200, ErrorMessage = "拼音简码输入过长，不能超过200位" )]
        public string PinYin { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [StringLength( 256, ErrorMessage = "签名输入过长，不能超过256位" )]
        public string Sign { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Code );
            AddDescription( t => t.Name );
            AddDescription( t => t.NormalizedName );
            AddDescription( t => t.Type );
            AddDescription( t => t.IsAdmin );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Path );
            AddDescription( t => t.Level );
            AddDescription( t => t.SortId );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.Comment );
            AddDescription( t => t.PinYin );
            AddDescription( t => t.Sign );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( TRole other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.NormalizedName, other.NormalizedName );
            AddChange( t => t.Type, other.Type );
            AddChange( t => t.IsAdmin, other.IsAdmin );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.Comment, other.Comment );
            AddChange( t => t.PinYin, other.PinYin );
            AddChange( t => t.Sign, other.Sign );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}