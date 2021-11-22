using System;
using System.ComponentModel;
using Util.Data.Queries;

namespace Util.Applications.Queries {
    /// <summary>
    /// 产品查询参数
    /// </summary>
    public class ProductQuery : QueryParameter {
        /// <summary>
        /// 产品标识
        ///</summary>
        [Description( "产品标识" )]
        public Guid? ProductId { get; set; }
        /// <summary>
        /// 产品编码
        ///</summary>
        [Description( "产品编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 产品名称
        ///</summary>
        [Description( "产品名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
        public decimal? Price { get; set; }
        /// <summary>
        /// 描述
        ///</summary>
        [Description( "描述" )]
        public string Description { get; set; }
        /// <summary>
        /// 启用
        ///</summary>
        [Description( "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 创建人
        ///</summary>
        [Description( "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        ///</summary>
        [Description( "最后修改人" )]
        public Guid? LastModifierId { get; set; }
    }
}