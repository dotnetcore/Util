using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;

namespace Util.Biz.Addresses {
    /// <summary>
    /// 地址 - 不可变
    /// </summary>
    public class Address : ValueObjectBase<Address> {
        /// <summary>
        /// 初始化地址
        /// </summary>
        protected Address() {
        }

        /// <summary>
        /// 初始化地址
        /// </summary>
        /// <param name="provinceId">省份编号</param>
        /// <param name="cityId">城市编号</param>
        /// <param name="countyId">区县编号</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="county">区县</param>
        /// <param name="street">街道</param>
        /// <param name="zip">邮政编码</param>
        public Address( Guid? provinceId, Guid? cityId, Guid? countyId, string province, string city, string county, string street, string zip = "" ) {
            ProvinceId = provinceId;
            CityId = cityId;
            CountyId = countyId;
            Province = province;
            City = city;
            County = county;
            Street = street;
            Zip = zip;
        }

        /// <summary>
        /// 省份编号
        /// </summary>
        [Column( "ProvinceId" )]
        public Guid? ProvinceId { get; private set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        [Column( "CityId" )]
        public Guid? CityId { get; private set; }
        /// <summary>
        /// 区县编号
        /// </summary>
        [Column( "CountyId" )]
        public Guid? CountyId { get; private set; }
        /// <summary>
        /// 省份
        /// </summary>
        [Column( "Province" )]
        [StringLength( 100, ErrorMessage = "省份输入过长，不能超过100位" )]
        public string Province { get; private set; }
        /// <summary>
        /// 城市
        /// </summary>
        [Column( "City" )]
        [StringLength( 100, ErrorMessage = "城市输入过长，不能超过100位" )]
        public string City { get; private set; }
        /// <summary>
        /// 区县
        /// </summary>
        [Column( "County" )]
        [StringLength( 100, ErrorMessage = "区县输入过长，不能超过100位" )]
        public string County { get; private set; }
        /// <summary>
        /// 街道
        /// </summary>
        [Column( "Street" )]
        [StringLength( 200, ErrorMessage = "街道输入过长，不能超过200位" )]
        public string Street { get; private set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column( "Zip" )]
        [StringLength( 20, ErrorMessage = "邮政编码输入过长，不能超过20位" )]
        public string Zip { get; private set; }

        /// <summary>
        /// 地址描述
        /// </summary>
        public string Description => $"{Province}{City}{County}{Street}";

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "省份编号", ProvinceId );
            AddDescription( "城市编号", CityId );
            AddDescription( "区县编号", CountyId );
            AddDescription( "省份", Province );
            AddDescription( "城市", City );
            AddDescription( "区县", County );
            AddDescription( "街道", Street );
            AddDescription( "邮政编码", Zip );
        }

        /// <summary>
        /// 空地址
        /// </summary>
        public static readonly Address Null = new NullAddress();
    }
}
