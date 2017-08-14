using System;
using Util.Datas.Persistence;
namespace Util.Tests.Samples {
    /// <summary>
    /// 持久化对象测试样例
    /// </summary>
    public class PersistentObjectSample : PersistentObjectBase<Guid> {
        /// <summary>
        /// 初始化持久化对象测试样例
        /// </summary>
        public PersistentObjectSample() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化持久化对象测试样例
        /// </summary>
        /// <param name="id">标识</param>
        public PersistentObjectSample( Guid id ) {
            Id = id;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// 持久化对象测试样例2
    /// </summary>
    public class PersistentObjectSample2 : PersistentObjectBase<Guid> {
        /// <summary>
        /// 初始化持久化对象测试样例2
        /// </summary>
        public PersistentObjectSample2() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化持久化对象测试样例2
        /// </summary>
        /// <param name="id">标识</param>
        public PersistentObjectSample2( Guid id ) {
            Id = id;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}