using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domain;
using Util.Domain.Auditing;
using Util.Domain.Entities;
using Util.Domain.Extending;

namespace Util.Tests.Models {
    /// <summary>
    /// 产品
    /// </summary>
    [Description( "产品" )]
    public class Product : AggregateRoot<Product>, IDelete, IAudited, IExtraProperties {
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
            TestProperty2 = new ProductItem();
            TestProperty4 = new ProductItem2();
            TestProperties = new List<ProductItem>();
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
        /// 价格
        ///</summary>
        [Description( "价格" )]
        public int IntPrice { get; set; }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
        public long LongPrice { get; set; }
        /// <summary>
        /// 价格
        ///</summary>
        [Description( "价格" )]
        public float FloatPrice { get; set; }
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
        /// 简单扩展属性
        /// </summary>
        [NotMapped]
        public string TestProperty1 {
            get => ExtraProperties.GetProperty<string>( nameof( TestProperty1 ) );
            set => ExtraProperties.SetProperty( nameof(TestProperty1), value );
        }

        private readonly ExtraProperty<ProductItem> _property2 = new(nameof( TestProperty2 ) );
        /// <summary>
        /// 对象扩展属性
        /// </summary>
        [NotMapped]
        public ProductItem TestProperty2 {
            get => _property2.GetProperty( ExtraProperties );
            set => _property2.SetProperty( ExtraProperties,value );
        }

        /// <summary>
        /// 枚举扩展属性
        /// </summary>
        [NotMapped]
        public ProductEnum? TestProperty3 {
            get => ExtraProperties.GetProperty<ProductEnum?>( nameof( TestProperty3 ) );
            set => ExtraProperties.SetProperty( nameof( TestProperty3 ), value );
        }

        private readonly ExtraProperty<ProductItem2> _property4 = new( nameof( TestProperty4 ) );
        /// <summary>
        /// 不可变对象扩展属性
        /// </summary>
        [NotMapped]
        public ProductItem2 TestProperty4 {
            get => _property4.GetProperty( ExtraProperties );
            set => _property4.SetProperty( ExtraProperties, value );
        }

        private readonly ExtraProperty<List<ProductItem>>  _properties = new( nameof( TestProperties ) );
        /// <summary>
        /// 对象集合扩展属性
        /// </summary>
        [NotMapped]
        public List<ProductItem> TestProperties {
            get => _properties.GetProperty( ExtraProperties );
            set => _properties.SetProperty( ExtraProperties,value );
        }

        private readonly ExtraProperty<ApplicationExtend> _property5 = new( nameof( TestProperty5 ) );
        /// <summary>
        /// 不可变对象扩展属性
        /// </summary>
        [NotMapped]
        public ApplicationExtend TestProperty5 {
            get => _property5.GetProperty( ExtraProperties );
            set => _property5.SetProperty( ExtraProperties, value );
        }

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