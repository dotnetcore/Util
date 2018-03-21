using Util.Maps;
using Util.Samples.Webs.Domains.Models;

namespace Util.Samples.Webs.Services.Dtos.Systems {
    /// <summary>
    /// 应用程序数据传输对象扩展
    /// </summary>
    public static class ApplicationDtoExtension {
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序数据传输对象</param>
        public static Application ToEntity( this ApplicationDto dto ) {
            if( dto == null )
                return new Application();
            return dto.MapTo( new Application( dto.Id.ToGuid() ) );
        }

        /// <summary>
        /// 转换为应用程序数据传输对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto( this Application entity ) {
            if( entity == null )
                return new ApplicationDto();
            return entity.MapTo<ApplicationDto>();
        }
    }
}