using System;
using AutoMapper;

namespace Util.Maps {
    /// <summary>
    /// 对象映射
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="destination">目标对象</param>
        public static TDestination MapTo<TSource, TDestination>( this TSource source, TDestination destination ) {
            return MapTo<TDestination>( source, destination );
        }

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        public static TDestination MapTo<TDestination>( this object source ) where TDestination : new() {
            return MapTo( source, new TDestination() );
        }

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        private static TDestination MapTo<TDestination>( object source, TDestination destination ) {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( destination == null )
                throw new ArgumentNullException( nameof( destination ) );
            var sourceType = source.GetType();
            var destinationType = typeof( TDestination );
            try {
                var map = Mapper.Configuration.FindTypeMapFor( sourceType, destinationType );
                if( map != null )
                    return Mapper.Map( source, destination );
                var maps = Mapper.Configuration.GetAllTypeMaps();
                Mapper.Initialize( config => {
                    foreach( var item in maps )
                        config.CreateMap( item.SourceType, item.DestinationType );
                    config.CreateMap( sourceType, destinationType );
                } );
            }
            catch( InvalidOperationException ) {
                Mapper.Initialize( config => {
                    config.CreateMap( sourceType, destinationType );
                } );
            }
            return Mapper.Map( source, destination );
        }
    }
}
