using System;
using AutoMapper;
using AutoMapper.Internal;
using Util.Helpers;

namespace Util.ObjectMapping {
    /// <summary>
    /// AutoMapper对象映射器
    /// </summary>
    public class ObjectMapper : IObjectMapper {
        /// <summary>
        /// 最大递归获取结果次数
        /// </summary>
        private const int MaxGetResultCount = 16;
        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Sync = new();
        /// <summary>
        /// 配置表达式
        /// </summary>
        private readonly MapperConfigurationExpression _configExpression;
        /// <summary>
        /// 配置提供器
        /// </summary>
        private IConfigurationProvider _config;
        /// <summary>
        /// 对象映射器
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// 初始化AutoMapper对象映射器
        /// </summary>
        /// <param name="expression">配置表达式</param>
        public ObjectMapper( MapperConfigurationExpression expression ) {
            _configExpression = expression ?? throw new ArgumentNullException( nameof( expression ) );
            _config = new MapperConfiguration( expression ); 
            _mapper = _config.CreateMapper();
        }

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        public TDestination Map<TSource, TDestination>( TSource source ) {
            return Map<TSource, TDestination>( source, default );
        }

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="destination">目标对象</param>
        public TDestination Map<TSource, TDestination>( TSource source, TDestination destination ) {
            if ( source == null )
                return default;
            var sourceType = GetType( source );
            var destinationType = GetType( destination );
            return GetResult( sourceType, destinationType, source, destination,0 );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        private Type GetType<T>( T obj ) {
            if( obj == null )
                return GetType( typeof( T ) );
            return GetType( obj.GetType() );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        private Type GetType( Type type ) {
            return Reflection.GetElementType( type );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private TDestination GetResult<TDestination>( Type sourceType, Type destinationType, object source, TDestination destination,int i ) {
            try {
                if ( i >= MaxGetResultCount )
                    return default;
                i += 1;
                if ( Exists( sourceType, destinationType ) )
                    return GetResult( source, destination );
                lock ( Sync ) {
                    if ( Exists( sourceType, destinationType ) )
                        return GetResult( source, destination );
                    ConfigMap( sourceType, destinationType );
                }
                return GetResult( source, destination );
            }
            catch ( AutoMapperMappingException ex ) {
                if ( ex.InnerException != null && ex.InnerException.Message.StartsWith( "Missing type map configuration" ) )
                    return GetResult( GetType( ex.MemberMap.SourceType ), GetType( ex.MemberMap.DestinationType ), source, destination,i );
                throw;
            }
        }

        /// <summary>
        /// 是否已存在映射配置
        /// </summary>
        private bool Exists( Type sourceType, Type destinationType ) {
            return _config.Internal().FindTypeMapFor( sourceType, destinationType ) != null;
        }

        /// <summary>
        /// 获取映射结果
        /// </summary>
        private TDestination GetResult<TSource, TDestination>( TSource source, TDestination destination ) {
            return _mapper.Map( source, destination );
        }

        /// <summary>
        /// 动态配置映射
        /// </summary>
        private void ConfigMap( Type sourceType, Type destinationType ) {
            _configExpression.CreateMap( sourceType, destinationType );
            _config = new MapperConfiguration( _configExpression );
            _mapper = _config.CreateMapper();
        }
    }
}
