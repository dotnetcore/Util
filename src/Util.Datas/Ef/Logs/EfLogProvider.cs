using System;
using Microsoft.Extensions.Logging;
using Util.Datas.Ef.Configs;
using Util.Datas.Ef.Core;
using Util.Logs;

namespace Util.Datas.Ef.Logs {
    /// <summary>
    /// Ef日志提供器
    /// </summary>
    public class EfLogProvider : ILoggerProvider {
        /// <summary>
        /// 日志操作
        /// </summary>
        private readonly ILog _log;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly UnitOfWorkBase _unitOfWork;
        /// <summary>
        /// Ef配置
        /// </summary>
        private readonly EfConfig _config;

        /// <summary>
        /// 初始化Ef日志提供器
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="config">Ef配置</param>
        public EfLogProvider( ILog log, UnitOfWorkBase unitOfWork,EfConfig config ) {
            _log = log ?? throw new ArgumentNullException( nameof( log ) );
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
            _config = config;
        }

        /// <summary>
        /// 初始化Ef日志提供器
        /// </summary>
        /// <param name="category">日志分类</param>
        public ILogger CreateLogger( string category ) {
            return category.StartsWith( "Microsoft.EntityFrameworkCore" ) ? new EfLog( _log, _unitOfWork, category, _config ) : NullLogger.Instance;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose() {
        }
    }
}
