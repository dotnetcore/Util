using System.Collections.Generic;
using System.Reflection;

namespace Util.Reflections {
    /// <summary>
    /// 程序集查找器
    /// </summary>
    public interface IAssemblyFinder {
        /// <summary>
        /// 程序集过滤模式
        /// </summary>
        public string AssemblySkipPattern { get; set; }
        /// <summary>
        /// 查找程序集列表
        /// </summary>
        List<Assembly> Find();
    }
}
