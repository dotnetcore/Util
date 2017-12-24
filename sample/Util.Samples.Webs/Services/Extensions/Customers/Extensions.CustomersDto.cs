using Util;
using Util.Maps;
using Donau.Services.Dtos.Customers;
using Util.Datas.Tests.Samples.Domains.Models;

namespace Donau.Services.Extensions.Customers {
    /// <summary>
    /// 客户数据传输对象扩展
    /// </summary>
    public static class CustomersDtoExtension {
        /// <summary>
        /// 转换为客户实体
        /// </summary>
        /// <param name="dto">客户数据传输对象</param>
        public static Customer ToEntity( this CustomersDto dto ) {
            if ( dto == null )
                return new Customer();
            return dto.MapTo( new Customer( dto.Id ) );
        }
        
        /// <summary>
        /// 转换为客户数据传输对象
        /// </summary>
        /// <param name="entity">客户实体</param>
        public static CustomersDto ToDto(this Customer entity) {
            if( entity == null )
                return new CustomersDto();
            return entity.MapTo<CustomersDto>();
        }

    }
}
