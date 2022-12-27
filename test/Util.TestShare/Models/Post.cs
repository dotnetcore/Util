using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Auditing;
using Util.Domain.Entities;

namespace Util.Tests.Models {
    /// <summary>
    /// 贴子
    /// </summary>
    [Description( "贴子" )]
    public class Post : AggregateRoot<Post>, IDelete, IAudited {
        /// <summary>
        /// 初始化贴子
        /// </summary>
        public Post() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化贴子
        /// </summary>
        /// <param name="id">贴子标识</param>
        public Post( Guid id ) : base( id ) {
            Tags = new List<Tag>();
        }

        /// <summary>
        /// 标题
        ///</summary>
        [Description( "标题" )]
        [MaxLength( 200 )]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        ///</summary>
        [Description( "内容" )]
        public string Content { get; set; }
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
        /// 标签列表
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Post other ) {
            AddChange( t => t.Title, other.Title );
            AddChange( t => t.Content, other.Content );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
            AddChange( t => t.ExtraProperties, other.ExtraProperties );
        }
    }
}