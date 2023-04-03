using System;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Util.Aop;

namespace Util.Caching {
    /// <summary>
    /// 缓存拦截器
    /// </summary>
    public class CacheAttribute : InterceptorBase {
        /// <summary>
        /// 缓存键前缀
        /// </summary>
        public string CacheKeyPrefix { get; set; }
        /// <summary>
        /// 缓存过期间隔,单位:秒,默认值:36000
        /// </summary>
        public int Expiration { get; set; } = 36000;

        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke( AspectContext context, AspectDelegate next ) {
            var cache = GetCache( context );
            var returnType = GetReturnType( context );
            var key = CreateCacheKey( context );
            var value = await GetCacheValue( cache, returnType, key );
            if ( value != null ) {
                SetReturnValue( context, returnType, value );
                return;
            }
            await next( context );
            await SetCache( context, cache, key );
        }

        /// <summary>
        /// 获取缓存服务
        /// </summary>
        protected virtual ICache GetCache( AspectContext context ) {
            return context.ServiceProvider.GetService<ICache>();
        }

        /// <summary>
        /// 获取返回类型
        /// </summary>
        private Type GetReturnType( AspectContext context ) {
            return context.IsAsync() ? context.ServiceMethod.ReturnType.GetGenericArguments().First() : context.ServiceMethod.ReturnType;
        }

        /// <summary>
        /// 创建缓存键
        /// </summary>
        private string CreateCacheKey( AspectContext context ) {
            var keyGenerator = context.ServiceProvider.GetService<ICacheKeyGenerator>();
            return keyGenerator.CreateCacheKey( context.ServiceMethod, context.Parameters, CacheKeyPrefix );
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        private async Task<object> GetCacheValue( ICache cache, Type returnType, string key ) {
            return await cache.GetAsync( key, returnType );
        }

        /// <summary>
        /// 设置返回值
        /// </summary>
        private void SetReturnValue( AspectContext context, Type returnType, object value ) {
            if ( context.IsAsync() ) {
                context.ReturnValue = typeof( Task ).GetMethods()
                    .First( p => p.Name == "FromResult" && p.ContainsGenericParameters )
                    .MakeGenericMethod( returnType ).Invoke( null, new[] { value } );
                return;
            }
            context.ReturnValue = value;
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        private async Task SetCache( AspectContext context, ICache cache, string key ) {
            var options = new CacheOptions { Expiration = TimeSpan.FromSeconds( Expiration ) };
            var returnValue = context.IsAsync() ? await context.UnwrapAsyncReturnValue() : context.ReturnValue;
            await cache.SetAsync( key, returnValue, options );
        }
    }
}
