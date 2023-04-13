using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Util.FileStorage {
    /// <summary>
    /// 文件存储服务操作扩展
    /// </summary>
    public static class IFileStoreExtensions {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileStore">文件存储服务</param>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<FileResult> SaveFileAsync( this IFileStore fileStore, FileInfo fileInfo, string policy = null, CancellationToken cancellationToken = default ) {
            fileStore.CheckNull( nameof( fileStore ) );
            var path = fileInfo.FullName;
            if ( System.IO.File.Exists( path ) == false )
                throw new FileNotFoundException( "保存文件失败,文件路径不正确.", path );
            var fileName = System.IO.Path.GetFileName( path );
            await using var stream = Util.Helpers.File.ReadToStream( path );
            return await fileStore.SaveFileAsync( stream, fileName, policy, cancellationToken );
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileStore">文件存储服务</param>
        /// <param name="bytes">文件流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<FileResult> SaveFileAsync( this IFileStore fileStore,byte[] bytes, string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            fileStore.CheckNull( nameof( fileStore ) );
            await using var stream = new MemoryStream( bytes );
            return await fileStore.SaveFileAsync( stream, fileName, policy, cancellationToken );
        }

        /// <summary>
        /// 获取文件字节流
        /// </summary>
        /// <param name="fileStore">文件存储服务</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<byte[]> GetFileBytesAsync( this IFileStore fileStore, string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var stream = await fileStore.GetFileStreamAsync( fileName, policy, cancellationToken );
            await using ( stream ) {
                return await Util.Helpers.File.ToBytesAsync( stream, cancellationToken );
            }
        }
    }
}
