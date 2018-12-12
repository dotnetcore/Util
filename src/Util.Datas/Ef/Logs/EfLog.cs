using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Util.Datas.Ef.Configs;
using Util.Datas.Ef.Core;
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
        /// 日志操作
        /// </summary>
        private readonly ILog _log;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly UnitOfWorkBase _unitOfWork;
        /// <summary>
        /// 日志分类
        /// </summary>
        private readonly string _category;
        /// <summary>
        /// Ef配置
        /// </summary>
        private readonly EfConfig _config;

        /// <summary>
        /// 初始化Ef日志记录器
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="category">日志分类</param>
        /// <param name="config">Ef配置</param>
        public EfLog( ILog log, UnitOfWorkBase unitOfWork, string category, EfConfig config ) {
            _log = log ?? throw new ArgumentNullException( nameof( log ) );
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
            _category = category;
            _config = config;
        }

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
            if( IsEnabled( eventId ) == false )
                return;
            _log.Caption( $"执行Ef操作：{_category}" )
                .Content( $"工作单元跟踪号: {_unitOfWork.TraceId}" )
                .Content( $"事件Id: {eventId.Id}" )
                .Content( $"事件名称: {eventId.Name}" );
            AddContent( state );
            _log.Exception( exception ).Trace();
        }

        /// <summary>
        /// 是否启用Ef日志
        /// </summary>
        private bool IsEnabled( EventId eventId ) {
            if( _config.EfLogLevel == EfLogLevel.Off )
                return false;
            if( _config.EfLogLevel == EfLogLevel.All )
                return true;
            if( eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted" )
                return true;
            return false;
        }

        /// <summary>
        /// 添加日志内容
        /// </summary>
        private void AddContent<TState>( TState state ) {
            if( _config.EfLogLevel == EfLogLevel.All )
                _log.Content( "事件内容：" ).Content( state.SafeString() );
            if( !( state is IEnumerable list ) )
                return;
            var dictionary = new Dictionary<string, string>();
            foreach( KeyValuePair<string, object> item in list )
                dictionary.Add( item.Key, item.Value.SafeString() );
            AddDictionary( dictionary );
        }

        /// <summary>
        /// 添加字典内容
        /// </summary>
        private void AddDictionary( IDictionary<string, string> dictionary ) {
            AddElapsed( GetValue( dictionary, "elapsed" ) );
            var sqlParams = GetValue( dictionary, "parameters" );
            AddSql( GetValue( dictionary, "commandText" ) );
            AddSqlParams( sqlParams );
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
        private void AddElapsed( string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            _log.Content( $"执行时间: {value} 毫秒" );
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        private void AddSql( string sql ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            _log.Sql( $"{sql}{Common.Line}" );
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        private void AddSqlParams( string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            _log.SqlParams( value );
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
