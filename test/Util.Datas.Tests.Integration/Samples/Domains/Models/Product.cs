using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Util.Datas.Tests.Samples.Domains.Models {
    /// <summary>
    /// 商品 - int标识
    /// </summary>
    [Description( "商品" )]
    public class Product : AggregateRoot<Product, int> {
        /// <summary>
        /// 初始化商品
        /// </summary>
        public Product() : this( 0 ) {
        }

        /// <summary>
        /// 初始化商品
        /// </summary>
        /// <param name="id">商品标识</param>
        public Product( int id ) : base( id ) {
        }

        /// <summary>
        /// 商品编码
        /// </summary>
        [Required( ErrorMessage = "商品编码不能为空" )]
        [StringLength( 30, ErrorMessage = "商品编码输入过长，不能超过30位" )]
        public string Code { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required( ErrorMessage = "商品名称不能为空" )]
        [StringLength( 200, ErrorMessage = "商品名称输入过长，不能超过200位" )]
        public string Name { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "商品编号", Id );
            AddDescription( "商品编码", Code );
            AddDescription( "商品名称", Name );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Product other ) {
            AddChange( "Id", "商品编号", Id, other.Id );
            AddChange( "Code", "商品编码", Code, other.Code );
            AddChange( "Name", "商品名称", Name, other.Name );
        }
    }
}