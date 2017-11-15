using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Util.Datas.Ef.Configs;
using Util.Datas.Ef.Core;
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
        /// 初始化Ef日志记录器
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="category">日志分类</param>
        public EfLog( ILog log, UnitOfWorkBase unitOfWork, string category ) {
            _log = log ?? throw new ArgumentNullException( nameof( log ) );
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
            _category = category;
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
            _log.Trace();
        }

        /// <summary>
        /// 是否启用Ef日志
        /// </summary>
        private bool IsEnabled( EventId eventId ) {
            if( EfConfig.LogLevel == EfLogLevel.Off )
                return false;
            if( EfConfig.LogLevel == EfLogLevel.All )
                return true;
            if( eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted" )
                return true;
            return false;
        }

        /// <summary>
        /// 添加日志内容
        /// </summary>
        private void AddContent<TState>( TState state ) {
            if( EfConfig.LogLevel == EfLogLevel.All )
                _log.Content().Content( "事件内容：" ).Content( state.SafeString() ).Content();
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
            var sql = GetValue( dictionary, "commandText" );
            var sqlParams = GetValue( dictionary, "parameters" );
            AddSql( sql );
            AddSqlParams( sqlParams );
            AddSql( sql, sqlParams );
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
            _log.Content( $"执行时间: {value} 毫秒" ).Content();
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        private void AddSql( string sql ) {
            _log.Content( "原始Sql语句: " ).Content( sql ).Content();
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        private void AddSqlParams( string value ) {
            _log.Content( "Sql参数: " ).Content( value ).Content();
        }

        /// <summary>
        /// 添加调试Sql
        /// </summary>
        private void AddSql( string sql, string sqlParams ) {
            sql = sql.Replace( "SET NOCOUNT ON;", "" );
            _log.Content( $"调试Sql语句: {GetSql( sql, sqlParams )}" );
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

        /// <summary>
        /// 获取Sql
        /// </summary>
        public static string GetSql( string sql, string sqlParams ) {
            var parameters = GetSqlParameters( sqlParams );
            foreach( var parameter in parameters ) {
                var regex = new Regex( $@"{parameter.Key}\b", RegexOptions.Compiled );
                sql = regex.Replace( sql, parameter.Value );
            }
            return sql;
        }

        /// <summary>
        /// 获取Sql参数字典
        /// </summary>
        /// <param name="sqlParams">Sql参数</param>
        public static IDictionary<string, string> GetSqlParameters( string sqlParams ) {
            var result = new Dictionary<string, string>();
            if( sqlParams == null )
                return result;
            var parameters = sqlParams.Split( ',' );
            foreach( var parameter in parameters )
                AddSqlParameter( result, parameter );
            return result;
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        private static void AddSqlParameter( Dictionary<string, string> result, string parameter ) {
            var items = parameter.Split( '=' );
            if( items.Length < 2 )
                return;
            result.Add( items[0].Trim(), GetValue( parameter, items[1] ) );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private static string GetValue( string parameter, string value ) {
            value = value.Substring( 0, value.IndexOf( "'", 1, StringComparison.Ordinal ) + 1 ).Trim();
            if( value == "''" && parameter.Contains( "DbType = Guid" ) )
                return "null";
            return value;
        }
    }
}
