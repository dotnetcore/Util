using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Entities;

namespace Util.Applications.Models {
    /// <summary>
    /// 产品
    /// </summary>
    [Description( "产品" )]
    public class Product : AggregateRoot<Product>, IDelete {
        /// <summary>
        /// 初始化产品
        /// </summary>
        public Product() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化产品
        /// </summary>
        /// <param name="id">产品标识</param>
        public Product( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 产品编码
        ///</summary>
        [Description( "产品编码" )]
        [Required( ErrorMessage = "产品编码不能为空" )]
        [MaxLength( 50 )]
        public string Code { get; set; }
        /// <summary>
        /// 产品名称
        ///</summary>
        [Description( "产品名称" )]
        [Required( ErrorMessage = "产品名称不能为空" )]
        [MaxLength( 500 )]
        public string Name { get; set; }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
        [Required( ErrorMessage = "价格不能为空" )]
        public decimal Price { get; set; }
        /// <summary>
        /// 描述
        ///</summary>
        [Description( "描述" )]
        public string Description { get; set; }
        /// <summary>
        /// 启用
        ///</summary>
        [Description( "启用" )]
        public bool Enabled { get; set; }
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
        protected override void AddChanges( Product other ) {
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Price, other.Price );
            AddChange( t => t.Description, other.Description );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}