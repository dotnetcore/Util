using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 线程操作
    /// </summary>
    public static partial class Thread {
        /// <summary>
        /// 执行多个操作，等待所有操作完成
        /// </summary>
        /// <param name="actions">操作集合</param>
        public static void WaitAll( params Action[] actions ) {
            if( actions == null )
                return;
            List<Task> tasks = new List<Task>();
            foreach( var action in actions )
                tasks.Add( Task.Factory.StartNew( action, TaskCreationOptions.None ) );
            Task.WaitAll( tasks.ToArray() );
        }

        /// <summary>
        /// 并发执行多个操作
        /// </summary>
        /// <param name="actions">操作集合</param>
        public static void ParallelExecute( params Action[] actions ) {
            Parallel.Invoke( actions );
        }

        /// <summary>
        /// 重复的并发执行操作
        /// </summary>
        /// <param name="action">操作</param>
        /// <param name="count">执行次数</param>
        /// <param name="options">并发执行配置</param>
        public static void ParallelExecute( Action action, int count = 1,ParallelOptions options = null ) {
            if ( options == null ) {
                Parallel.For( 0, count, i => action() );
                return;
            }
            Parallel.For( 0, count, options, i => action() );
        }
    }
}
