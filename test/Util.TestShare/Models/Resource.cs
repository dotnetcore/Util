using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Auditing;
using Util.Domain.Extending;
using Util.Domain.Trees;

namespace Util.Tests.Models {
    /// <summary>
    /// 资源
    /// </summary>
    [Description( "资源" )]
    public class Resource : TreeEntityBase<Resource>,IDelete,IAudited,IExtraProperties {
        /// <summary>
        /// 初始化资源
        /// </summary>
        public Resource() : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化资源
        /// </summary>
        /// <param name="id">资源标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        public Resource( Guid id, string path, int level ) : base( id, path, level ) {
        }

        /// <summary>
        /// 资源标识符
        ///</summary>
        [DisplayName( "资源标识符" )]
        [MaxLength( 300 )]
        public string Uri { get; set; }
        /// <summary>
        /// 资源名称
        ///</summary>
        [DisplayName( "资源名称" )]
        [Required]
        [MaxLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        ///</summary>
        [DisplayName( "备注" )]
        [MaxLength( 500 )]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        ///</summary>
        [DisplayName( "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        ///</summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        ///</summary>
        [DisplayName( "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        ///</summary>
        [DisplayName( "是否删除" )]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Resource other ) {
            AddChange( t => t.Uri, other.Uri );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}