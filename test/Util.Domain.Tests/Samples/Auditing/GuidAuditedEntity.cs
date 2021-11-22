using System;
using System.ComponentModel;
using Util.Domain.Auditing;
using Util.Domain.Entities;

namespace Util.Domain.Tests.Samples.Auditing {
    /// <summary>
    /// Guid审计测试实体
    /// </summary>
    public class GuidAuditedEntity : AggregateRoot<GuidAuditedEntity>,IAudited<Guid> {
        /// <summary>
        /// 初始化
        /// </summary>
        public GuidAuditedEntity() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">实体标识</param>
        public GuidAuditedEntity( Guid id ) : base( id ) {
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
        public Guid CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        ///</summary>
        [Description( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        ///</summary>
        [Description( "最后修改人" )]
        public Guid LastModifierId { get; set; }
    }
}