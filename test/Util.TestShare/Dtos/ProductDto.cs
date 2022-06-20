using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;
using Util.Tests.Models;

namespace Util.Tests.Dtos {
    /// <summary>
    /// 产品参数
    /// </summary>
    public class ProductDto : DtoBase {
        /// <summary>
        /// 产品参数
        /// </summary>
        public ProductDto() {
            TestProperty2 = new ProductItem();
            TestProperties = new List<ProductItem2>();
        }

        /// <summary>
        /// 产品编码
        ///</summary>
        [Description( "产品编码" )]
        [MaxLength( 50 )]
        public string Code { get; set; }
        /// <summary>
        /// 产品名称
        ///</summary>
        [Description( "产品名称" )]
        [MaxLength( 500 )]
        public string Name { get; set; }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
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
        /// 版本号
        ///</summary>
        [Description( "版本号" )]
        public byte[] Version { get; set; }
        /// <summary>
        /// 简单扩展属性
        /// </summary>
        public string TestProperty1 { get; set; }
        /// <summary>
        /// 对象扩展属性
        /// </summary>
        public ProductItem TestProperty2 { get; set; }
        /// <summary>
        /// 对象集合扩展属性
        /// </summary>
        public List<ProductItem2> TestProperties { get; set; }
    }
}