using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using Hangfire;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire后台任务调度管理器扩展
    /// </summary>
    public static class ISchedulerManagerExtensions {
        /// <summary>
        /// 执行入队操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Enqueue( this ISchedulerManager source, Expression<Action> actionExpression ) {
            return BackgroundJob.Enqueue( actionExpression );
        }

        /// <summary>
        /// 执行入队操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Enqueue( this ISchedulerManager source, Expression<Func<Task>> actionExpression ) {
            return BackgroundJob.Enqueue( actionExpression );
        }

        /// <summary>
        /// 执行入队操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Enqueue<T>( this ISchedulerManager source, Expression<Action<T>> actionExpression ) {
            return BackgroundJob.Enqueue( actionExpression );
        }

        /// <summary>
        /// 执行入队操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Enqueue<T>( this ISchedulerManager source, Expression<Func<T, Task>> actionExpression ) {
            return BackgroundJob.Enqueue( actionExpression );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="delay">延迟执行时间间隔</param>
        public static string Schedule( this ISchedulerManager source, Expression<Action> actionExpression, TimeSpan delay ) {
            return BackgroundJob.Schedule( actionExpression, delay );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="delay">延迟执行时间间隔</param>
        public static string Schedule( this ISchedulerManager source, Expression<Func<Task>> actionExpression, TimeSpan delay ) {
            return BackgroundJob.Schedule( actionExpression, delay );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="dateTime">延迟执行时间</param>
        public static string Schedule( this ISchedulerManager source, Expression<Action> actionExpression, DateTimeOffset dateTime ) {
            return BackgroundJob.Schedule( actionExpression, dateTime );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="dateTime">延迟执行时间</param>
        public static string Schedule( this ISchedulerManager source, Expression<Func<Task>> actionExpression, DateTimeOffset dateTime ) {
            return BackgroundJob.Schedule( actionExpression, dateTime );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="delay">延迟执行时间间隔</param>
        public static string Schedule<T>( this ISchedulerManager source, Expression<Action<T>> actionExpression, TimeSpan delay ) {
            return BackgroundJob.Schedule( actionExpression, delay );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="dateTime">延迟执行时间</param>
        public static string Schedule<T>( this ISchedulerManager source, Expression<Action<T>> actionExpression, DateTimeOffset dateTime ) {
            return BackgroundJob.Schedule( actionExpression, dateTime );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="delay">延迟执行时间间隔</param>
        public static string Schedule<T>( this ISchedulerManager source, Expression<Func<T, Task>> actionExpression, TimeSpan delay ) {
            return BackgroundJob.Schedule( actionExpression, delay );
        }

        /// <summary>
        /// 执行延迟操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="dateTime">延迟执行时间</param>
        public static string Schedule<T>( this ISchedulerManager source, Expression<Func<T, Task>> actionExpression, DateTimeOffset dateTime ) {
            return BackgroundJob.Schedule( actionExpression, dateTime );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Continue( this ISchedulerManager source, string parentId, Expression<Action> actionExpression ) {
            return BackgroundJob.ContinueJobWith( parentId,actionExpression );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="options">配置</param>
        public static string Continue( this ISchedulerManager source, string parentId, Expression<Action> actionExpression, JobContinuationOptions options ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression, options );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Continue<T>( this ISchedulerManager source, string parentId, Expression<Action<T>> actionExpression ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="options">配置</param>
        public static string Continue<T>( this ISchedulerManager source, string parentId, Expression<Action<T>> actionExpression, JobContinuationOptions options ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression, options );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Continue( this ISchedulerManager source, string parentId, Expression<Func<Task>> actionExpression ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="options">配置</param>
        public static string Continue( this ISchedulerManager source, string parentId, Expression<Func<Task>> actionExpression, JobContinuationOptions options ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression, options );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        public static string Continue<T>( this ISchedulerManager source, string parentId, Expression<Func<T, Task>> actionExpression ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression );
        }

        /// <summary>
        /// 执行延续操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="parentId">父操作标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="options">配置</param>
        public static string Continue<T>( this ISchedulerManager source, string parentId, Expression<Func<T, Task>> actionExpression, JobContinuationOptions options ) {
            return BackgroundJob.ContinueJobWith( parentId, actionExpression, options );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat( this ISchedulerManager source, Expression<Action> actionExpression, string cron,string queue = "default" ) {
            RecurringJob.AddOrUpdate( actionExpression, cron,queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat( this ISchedulerManager source, Expression<Func<Task>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat<T>( this ISchedulerManager source, Expression<Action<T>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat<T>( this ISchedulerManager source, Expression<Func<T, Task>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( actionExpression, cron, queue: queue );
        }


        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="id">任务标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat( this ISchedulerManager source, string id, Expression<Action> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( id, actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="id">任务标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat( this ISchedulerManager source, string id, Expression<Func<Task>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( id, actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="id">任务标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat<T>( this ISchedulerManager source, string id, Expression<Action<T>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( id, actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 执行重复操作
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="id">任务标识</param>
        /// <param name="actionExpression">后台操作</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="queue">队列名称</param>
        public static void Repeat<T>( this ISchedulerManager source, string id, Expression<Func<T, Task>> actionExpression, string cron, string queue = "default" ) {
            RecurringJob.AddOrUpdate( id, actionExpression, cron, queue: queue );
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="source">后台任务调度管理器</param>
        /// <param name="id">任务标识</param>
        public static void Remove( this ISchedulerManager source, string id ) {
            var result = BackgroundJob.Delete( id );
            if ( result )
                return;
            RecurringJob.RemoveIfExists( id );
        }
    }
}
