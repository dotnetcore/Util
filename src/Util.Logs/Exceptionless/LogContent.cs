using System.Collections.Generic;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志内容
    /// </summary>
    public class LogContent : Util.Logs.Contents.LogContent, ILogConvert {
        /// <summary>
        /// 转换
        /// </summary>
        public IDictionary<string, string> To() {
            return new Dictionary<string, string> {
                { LogResource.LogName, LogName },
                { LogResource.TraceId, TraceId },
                { LogResource.OperationTime, OperationTime },
                { LogResource.Duration, Duration },
                { LogResource.ThreadId, ThreadId },
                { "Url", Url },
                { LogResource.UserId, UserId },
                { LogResource.Operator, Operator },
                { LogResource.Role,Role  },
                { LogResource.BusinessId,BusinessId  },
                { LogResource.Tenant,Tenant  },
                { LogResource.Application,Application  },
                { LogResource.Module,Module  },
                { LogResource.Class,Class  },
                { LogResource.Method,Method  },
                { LogResource.Params,Params.ToString()  },
                { LogResource.Caption,Caption  },
                { LogResource.Content,Content.ToString()  },
                { LogResource.Sql,Sql.ToString()  },
                { LogResource.SqlParams,SqlParams.ToString()  },
                { LogResource.ErrorCode,Exception.Code }
            };
        }
    }
}
