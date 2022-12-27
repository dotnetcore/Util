using System;
using System.ComponentModel;
using Util.Domain.Auditing;
using Util.Domain.Entities;

namespace Util.Domain.Tests.Samples.Auditing {
    /// <summary>
    /// int审计测试实体
    /// </summary>
    public class IntAuditedEntity : AggregateRoot<GuidAuditedEntity>,IAudited<int> {
        /// <summary>
        /// 初始化
        /// </summary>
        public IntAuditedEntity() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">实体标识</param>
        public IntAuditedEntity( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 创建时间
        ///</summary>
        [Description( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        ///</summary>
        [Description( "创建人" )]
        public int CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        ///</summary>
        [Description( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        ///</summary>
        [Description( "最后修改人" )]
        public int LastModifierId { get; set; }
    }
}