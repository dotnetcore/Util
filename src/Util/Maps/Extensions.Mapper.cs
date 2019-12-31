using System;
using AutoMapper;
using System.Collections.Generic;
using Util.Helpers;

namespace Util.Maps {
    /// <summary>
    /// 对象映射
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Sync = new object();
        /// <summary>
        /// 配置提供器
        /// </summary>
        private static IConfigurationProvider _config;

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
            try {
                if( source == null )
                    return default( TDestination );
                if( destination == null )
                    return default( TDestination );
                var sourceType = GetType( source );
                var destinationType = GetType( destination );
                return GetResult( sourceType, destinationType, source, destination );
            }
            catch( AutoMapperMappingException ex ) {
                return GetResult( GetType( ex.MemberMap.SourceType ), GetType( ex.MemberMap.DestinationType ), source, destination );
            }
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        private static Type GetType( object obj ) {
            return GetType( obj.GetType() );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        private static Type GetType( Type type ) {
            return Reflection.GetElementType( type );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private static TDestination GetResult<TDestination>( Type sourceType, Type destinationType, object source, TDestination destination ) {
            if( Exists( sourceType, destinationType ) )
                return GetResult( source, destination );
            lock( Sync ) {
                if( Exists( sourceType, destinationType ) )
                    return GetResult( source, destination );
                Init( sourceType, destinationType );
            }
            return GetResult( source, destination );
        }

        /// <summary>
        /// 是否已存在映射配置
        /// </summary>
        private static bool Exists( Type sourceType, Type destinationType ) {
            return _config?.FindTypeMapFor( sourceType, destinationType ) != null;
        }

        /// <summary>
        /// 初始化映射配置
        /// </summary>
        private static void Init( Type sourceType, Type destinationType ) {
            if( _config == null ) {
                _config = new MapperConfiguration( t => t.CreateMap( sourceType, destinationType ) );
                return;
            }
            var maps = _config.GetAllTypeMaps();
            _config = new MapperConfiguration( t => t.CreateMap( sourceType, destinationType ) );
            foreach( var map in maps )
                _config.RegisterTypeMap( map );
        }

        /// <summary>
        /// 获取映射结果
        /// </summary>
        private static TDestination GetResult<TDestination>( object source, TDestination destination ) {
            return new Mapper( _config ).Map( source, destination );
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
