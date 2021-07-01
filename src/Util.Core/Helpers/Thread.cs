using System;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 线程操作
    /// </summary>
    public static class Thread {
        /// <summary>
        /// 并发执行多个操作
        /// </summary>
        /// <param name="actions">操作集合</param>
        public static void ParallelInvoke( params Action[] actions ) {
            Parallel.Invoke( actions );
        }

        /// <summary>
        /// 循环并发执行操作
        /// </summary>
        /// <param name="action">操作</param>
        /// <param name="count">执行次数</param>
        /// <param name="options">并发执行配置</param>
        public static void ParallelFor( Action action, int count = 1,ParallelOptions options = null ) {
            if ( options == null ) {
                Parallel.For( 0, count, i => action() );
                return;
            }
            Parallel.For( 0, count, options, i => action() );
        }
    }
}
