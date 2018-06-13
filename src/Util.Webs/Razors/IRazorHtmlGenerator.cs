using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Util.Webs.Razors
{
    /// <summary>
    /// Razor Html生成器
    /// </summary>
    public interface IRazorHtmlGenerator
    {
        /// <summary>
        /// 生成Html文件
        /// </summary>
        /// <returns></returns>
        Task Generate();
    }
}
