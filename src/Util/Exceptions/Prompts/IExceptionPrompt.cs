using System;

namespace Util.Exceptions.Prompts {
    /// <summary>
    /// 异常提示
    /// </summary>
    public interface IExceptionPrompt {
        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        string GetPrompt( Exception exception );
    }
}
