namespace Util.Generators.Resources {
    /// <summary>
    /// 静态资源
    /// </summary>
    public class Resource {
        /// <summary>
        /// 初始化静态资源
        /// </summary>
        /// <param name="from">资源路径</param>
        /// <param name="to">目标路径</param>
        public Resource( string from,string to ) {
            From = from;
            To = to;
        }

        /// <summary>
        /// 资源路径
        /// </summary>
        public string From { get; }

        /// <summary>
        /// 目标路径
        /// </summary>
        public string To { get; }
    }
}
