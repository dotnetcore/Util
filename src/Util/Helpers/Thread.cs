﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 线程操作
    /// </summary>
    public static class Thread {
        /// <summary>
        /// 执行多个操作，等待所有操作完成
        /// </summary>
        /// <param name="actions">操作集合</param>
        public static void WaitAll( params Action[] actions ) {
            if ( actions == null )
                return;
            List<Task> tasks = new List<Task>();
            foreach ( var action in actions )
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
    }
}
