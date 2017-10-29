using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Domains;

namespace Util.Biz.Addresses {
    /// <summary>
    /// 地址信息 - 可变
    /// </summary>
    [DataContract]
    public class AddressInfo : ValueObjectBase<AddressInfo> {
        /// <summary>
        /// 省份编号
        /// </summary>
        [DataMember]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        [DataMember]
        public string CityId { get; set; }

        /// <summary>
        /// 区县编号
        /// </summary>
        [DataMember]
        public string CountyId { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [StringLength( 100, ErrorMessage = "省份输入过长，不能超过100位" )]
        [Display( Name = "省份" )]
        [DataMember]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [StringLength( 100, ErrorMessage = "城市输入过长，不能超过100位" )]
        [Display( Name = "城市" )]
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        [StringLength( 100, ErrorMessage = "区县输入过长，不能超过100位" )]
        [Display( Name = "区县" )]
        [DataMember]
        public string County { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [StringLength( 200, ErrorMessage = "街道输入过长，不能超过200位" )]
        [Display( Name = "街道" )]
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "邮政编码输入过长，不能超过20位" )]
        [Display( Name = "邮政编码" )]
        [DataMember]
        public string Zip { get; set; }

        /// <summary>
        /// 地址描述
        /// </summary>
        [Display( Name = "地址描述" )]
        [DataMember]
        public string Description { get; set; }
    }
}
