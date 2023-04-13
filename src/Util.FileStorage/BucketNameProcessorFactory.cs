using System;

namespace Util.FileStorage {
    /// <summary>
    /// 存储桶名称处理器工厂
    /// </summary>
    public class BucketNameProcessorFactory : IBucketNameProcessorFactory {
        /// <inheritdoc />
        public IBucketNameProcessor CreateProcessor( string policy ) {
            if ( policy.IsEmpty() )
                return new BucketNameProcessor();
            throw new NotImplementedException( $"存储桶名称处理策略 {policy} 未实现." );
        }
    }
}
