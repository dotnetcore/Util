using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Util.Applications.Locks;
using Util.Helpers;
using Util.Properties;
using Util.Sessions;

namespace Util.Applications.Filters {
    /// <summary>
    /// 请求锁过滤器,用于防止重复提交
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public class LockAttribute : ActionFilterAttribute {
        /// <summary>
        /// 业务标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 业务锁类型
        /// </summary>
        public LockType Type { get; set; } = LockType.User;
        /// <summary>
        /// 再次提交时间间隔，单位：秒
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public override async Task OnActionExecutionAsync( ActionExecutingContext context, ActionExecutionDelegate next ) {
            context.CheckNull( nameof( context ) );
            next.CheckNull( nameof( next ) );
            var @lock = CreateLock( context );
            var key = GetKey( context );
            var isSuccess = false;
            try {
                isSuccess = await @lock.LockAsync( key, GetExpiration() );
                if ( isSuccess == false ) {
                    context.Result = GetResult( context,StateCode.Fail, GetFailMessage( context ) );
                    return;
                }
                OnActionExecuting( context );
                if ( context.Result != null )
                    return;
                var executedContext = await next();
                OnActionExecuted( executedContext );
            }
            finally {
                if ( isSuccess ) {
                    await @lock.UnLockAsync();
                }
            }
        }

        /// <summary>
        /// 创建业务锁
        /// </summary>
        protected virtual ILock CreateLock( ActionExecutingContext context ) {
            return context.HttpContext.RequestServices.GetService<ILock>() ?? NullLock.Instance;
        }

        /// <summary>
        /// 获取锁定标识
        /// </summary>
        protected virtual string GetKey( ActionExecutingContext context ) {
            var userId = string.Empty;
            if ( Type == LockType.User )
                userId = $"{GetUserId( context )}_";
            return string.IsNullOrWhiteSpace( Key ) ? $"{userId}{Web.Request.Path}" : $"{userId}{Key}";
        }

        /// <summary>
        /// 获取用户标识
        /// </summary>
        protected string GetUserId( ActionExecutingContext context ) {
            var session = context.HttpContext.RequestServices.GetService<ISession>();
            return session?.UserId;
        }

        /// <summary>
        /// 获取到期时间间隔
        /// </summary>
        private TimeSpan? GetExpiration() {
            if ( Interval == 0 )
                return null;
            return TimeSpan.FromSeconds( Interval );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private IActionResult GetResult( ActionExecutingContext context,string code, string message ) {
            var resultFactory = context.HttpContext.RequestServices.GetService<IResultFactory>();
            if ( resultFactory == null )
                return new Result( code, message );
            return resultFactory.CreateResult( code, message, null, null );
        }

        /// <summary>
        /// 获取失败消息
        /// </summary>
        protected virtual string GetFailMessage( ActionExecutingContext context ) {
            if ( Type == LockType.User )
                return GetLocalizedMessage( context, R.UserDuplicateRequest );
            return GetLocalizedMessage( context, R.GlobalDuplicateRequest );
        }

        /// <summary>
        /// 获取本地化消息
        /// </summary>
        protected virtual string GetLocalizedMessage( ActionExecutingContext context, string message ) {
            var stringLocalizer = context.HttpContext.RequestServices.GetService<IStringLocalizer>();
            if ( stringLocalizer == null )
                return message;
            return stringLocalizer[message];
        }
    }
}
