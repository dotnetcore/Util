using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Auditing;
using Util.Domain.Entities;

namespace Util.Tests.Models {
    /// <summary>
    /// 标签
    /// </summary>
    [Description( "标签" )]
    public class Tag : AggregateRoot<Tag>,IDelete,IAudited{
        /// <summary>
        /// 初始化标签
        /// </summary>
        public Tag() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化标签
        /// </summary>
        /// <param name="id">标签标识</param>
        public Tag( Guid id ) : base( id ) {
            Posts = new List<Post>();
        }

        /// <summary>
        /// 标签名称
        ///</summary>
        [Description( "标签名称" )]
        [MaxLength( 200 )]
        public string Name { get; set; }
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
        /// 贴子列表
        /// </summary>
        public ICollection<Post> Posts { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Tag other ) {
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}