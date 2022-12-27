using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 操作日志模拟数据服务
    /// </summary>
    public static class OperationLogFakeService {
        /// <summary>
        /// 获取操作日志
        /// </summary>
        public static OperationLog GetOperationLog() {
            return GetOperationLogs( 1 ).First();
        }

        /// <summary>
        /// 获取操作日志列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<OperationLog> GetOperationLogs( int count ) {
            return new AutoFaker<OperationLog>()
                .RuleFor( t => t.LogName, t => t.Random.String2( 1, 50 ) )
                .Generate( count );
        }
    }
}