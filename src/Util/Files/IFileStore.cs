namespace Util.Files {
    /// <summary>
    /// 文件存储服务
    /// </summary>
    public interface IFileStore {
        /// <summary>
        /// 保存文件,返回完整文件路径
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="fileName">文件名，必须包含扩展名，如果仅传入扩展名则生成随机文件名</param>
        string Save( byte[] stream, string fileName );
    }
}
