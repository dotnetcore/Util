using System;
using System.Collections.Generic;
using Util.ObjectMapping;

namespace Util {
    /// <summary>
    /// 对象映射扩展
    /// </summary>
    public static class ObjectMapperExtensions {
        /// <summary>
        /// 对象映射器
        /// </summary>
        private static IObjectMapper _mapper;

        /// <summary>
        /// 设置对象映射器
        /// </summary>
        /// <param name="mapper">对象映射器</param>
        public static void SetMapper( IObjectMapper mapper ) {
            _mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
        }

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        public static TDestination MapTo<TDestination>( this object source ) {
            if ( _mapper == null )
                throw new ArgumentNullException( nameof(_mapper) );
            return _mapper.Map<object, TDestination>( source );
        }
        
        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="destination">目标对象</param>
        public static TDestination MapTo<TSource, TDestination>( this TSource source, TDestination destination ) {
            if( _mapper == null )
                throw new ArgumentNullException( nameof( _mapper ) );
            return _mapper.Map( source, destination );
        }

        /// <summary>
        /// 将源集合映射到目标集合
        /// </summary>
        /// <typeparam name="TDestination">目标元素类型,范例：Sample,不要加List</typeparam>
        /// <param name="source">源集合</param>
        public static List<TDestination> MapToList<TDestination>( this System.Collections.IEnumerable source ) {
            return MapTo<List<TDestination>>( source );
        }
    }
}
;
