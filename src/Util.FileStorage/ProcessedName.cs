using System;

namespace Util.FileStorage {
    /// <summary>
    /// 已处理过的名称
    /// </summary>
    public class ProcessedName {
        /// <summary>
        /// 初始化已处理过的名称
        /// </summary>
        /// <param name="name">名称</param>
        public ProcessedName( string name ) {
            if ( name.IsEmpty() )
                throw new ArgumentNullException( name );
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }
    }
}
