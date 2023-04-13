using System;

namespace Util.FileStorage {
    /// <summary>
    /// 存储桶名称处理器
    /// </summary>
    public class BucketNameProcessor : IBucketNameProcessor {
        /// <inheritdoc />
        public ProcessedName Process( string bucketName ) {
            if ( bucketName.IsEmpty() )
                throw new ArgumentNullException( nameof( bucketName ) );
            var result = bucketName.ToLowerInvariant().Replace( "_","-" );
            return new ProcessedName( result );
        }
    }
}
