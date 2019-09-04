using System.Collections.Generic;
using Util.Logs.Properties;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志内容
    /// </summary>
    public class LogContent : Util.Logs.Contents.LogContent, ILogConvert {
        /// <summary>
        /// 转换
        /// </summary>
        public List<Item> To() {
            return new List<Item> {
                { new Item( LogResource.LogId, LogId,0) },
                { new Item( LogResource.LogName, LogName,1) },
                { new Item(LogResource.TraceId, TraceId,2) },
                { new Item(LogResource.OperationTime, OperationTime,3) },
                { new Item(LogResource.Duration, Duration,4) },
                { new Item(LogResource.ThreadId, ThreadId,5) },
                { new Item("Url", Url,6) },
                { new Item(LogResource.UserId, UserId,7) },
                { new Item(LogResource.Operator, Operator,8 ) },
                { new Item(LogResource.Role,Role,9)  },
                { new Item(LogResource.BusinessId,BusinessId,10) },
                { new Item(LogResource.Tenant,Tenant,11)  },
                { new Item(LogResource.Application,Application,12) },
                { new Item(LogResource.Module,Module ,13) },
                { new Item(LogResource.Class,Class ,14) },
                { new Item(LogResource.Method,Method ,15) },
                { new Item(LogResource.Params,Params.ToString(),16) },
                { new Item(LogResource.Caption,Caption ,17) },
                { new Item(LogResource.Content,Content.ToString(),18) },
                { new Item(LogResource.Sql,Sql.ToString(),19)  },
                { new Item(LogResource.SqlParams,SqlParams.ToString(),20) },
                { new Item(LogResource.ErrorCode,ErrorCode,21) }
            };
        }
    }
}
