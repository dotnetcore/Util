namespace Util.Helpers {
    /// <summary>
    /// 上下文环境操作
    /// </summary>
    public interface IEnvironment {
        /// <summary>
        /// 根路径
        /// </summary>
        string RootPath { get; }
        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        string WebRootPath { get; }
        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        string GetPath( string relativePath );
    }
}
