using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Util.Datas.Ef.Configs;
using Util.Datas.Ef.Core;
using Util.Datas.UnitOfWorks;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Datas.Ef.Logs {
    /// <summary>
    /// Ef日志记录器
    /// </summary>
    public class EfLog : ILogger {
        /// <summary>
        /// Ef跟踪日志名
        /// </summary>
        public const string TraceLogName = "EfTraceLog";

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <typeparam name="TState">状态类型</typeparam>
        /// <param name="logLevel">日志级别</param>
        /// <param name="eventId">事件编号</param>
        /// <param name="state">状态</param>
        /// <param name="exception">异常</param>
        /// <param name="formatter">日志内容</param>
        public void Log<TState>( LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter ) {
            var config = GetConfig();
            var log = GetLog();
            if( IsEnabled( eventId, config ) == false )
                return;
            log.Caption( $"执行Ef操作：" )
                .Content( $"工作单元跟踪号: {GetUnitOfWork()?.TraceId}" )
                .Content( $"事件Id: {eventId.Id}" )
                .Content( $"事件名称: {eventId.Name}" );
            AddContent( state, config, log );
            log.Exception( exception ).Trace();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private EfConfig GetConfig() {
            try {
                var options = Ioc.Create<IOptionsSnapshot<EfConfig>>();
                return options.Value;
            }
            catch {
                return new EfConfig { EfLogLevel = EfLogLevel.Sql };
            }
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Util.Logs.Log.GetLog( TraceLogName );
            }
            catch {
                return Util.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected virtual UnitOfWorkBase GetUnitOfWork() {
            try {
                var unitOfWork = Ioc.Create<IUnitOfWork>();
                return unitOfWork as UnitOfWorkBase;
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// 是否启用Ef日志
        /// </summary>
        private bool IsEnabled( EventId eventId, EfConfig config ) {
            if( config.EfLogLevel == EfLogLevel.Off )
                return false;
            if( config.EfLogLevel == EfLogLevel.All )
                return true;
            if( eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted" )
                return true;
            return false;
        }

        /// <summary>
        /// 添加日志内容
        /// </summary>
        private void AddContent<TState>( TState state, EfConfig config, ILog log ) {
            if( config.EfLogLevel == EfLogLevel.All )
                log.Content( "事件内容：" ).Content( state.SafeString() );
            if( !( state is IEnumerable list ) )
                return;
            var dictionary = new Dictionary<string, string>();
            foreach( KeyValuePair<string, object> item in list )
                dictionary.Add( item.Key, item.Value.SafeString() );
            AddDictionary( dictionary, log );
        }

        /// <summary>
        /// 添加字典内容
        /// </summary>
        private void AddDictionary( IDictionary<string, string> dictionary, ILog log ) {
            AddElapsed( GetValue( dictionary, "elapsed" ), log );
            var sqlParams = GetValue( dictionary, "parameters" );
            AddSql( GetValue( dictionary, "commandText" ), log );
            AddSqlParams( sqlParams, log );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private string GetValue( IDictionary<string, string> dictionary, string key ) {
            if( dictionary.ContainsKey( key ) )
                return dictionary[key];
            return string.Empty;
        }

        /// <summary>
        /// 添加执行时间
        /// </summary>
        private void AddElapsed( string value, ILog log ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            log.Content( $"执行时间: {value} 毫秒" );
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        private void AddSql( string sql, ILog log ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            log.Sql( $"{sql}{Common.Line}" );
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        private void AddSqlParams( string value, ILog log ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            log.SqlParams( value );
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        public bool IsEnabled( LogLevel logLevel ) {
            return true;
        }

        /// <summary>
        /// 起始范围
        /// </summary>
        public IDisposable BeginScope<TState>( TState state ) {
            return null;
        }
    }
}
