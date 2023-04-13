namespace Util.FileStorage {
    /// <summary>
    /// 默认文件名处理器,不作任何修改
    /// </summary>
    public class FileNameProcessor : IFileNameProcessor {
        /// <inheritdoc />
        public ProcessedName Process( string fileName ) {
            return new ProcessedName( fileName );
        }
    }
}
