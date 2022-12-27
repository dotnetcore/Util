using System;
using System.ComponentModel;
using Util.Data.Queries;

namespace Util.Tests.Queries {
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
        /// </summary>
        private string _code = string.Empty;
        /// <summary>
        /// 产品编码
        /// </summary>
        [Description( "产品编码" )]
        public string Code { 
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        private string _name = string.Empty;
        /// <summary>
        /// 产品名称
        /// </summary>
        [Description( "产品名称" )]
        public string Name { 
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
        public decimal? Price { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        private string _description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        [Description( "描述" )]
        public string Description { 
            get => _description == null ? string.Empty : _description.Trim();
            set => _description = value;
        }
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