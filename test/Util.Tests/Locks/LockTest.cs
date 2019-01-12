using System;
using System.Collections.Generic;
using Util.Helpers;
using Xunit;

namespace Util.Tests.Locks {
    /// <summary>
    /// 业务锁测试
    /// </summary>
    public class LockTest : IDisposable {
        /// <summary>
        /// 业务锁测试服务
        /// </summary>
        private readonly LockTestService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LockTest() {
            _service = new LockTestService();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
            _service.UnLock();
        }

        /// <summary>
        /// 执行一个服务
        /// </summary>
        [Fact]
        public void Test_1() {
            Assert.Equal( "ok", _service.Execute( "Test_1" ) );
        }

        /// <summary>
        /// 并发执行服务
        /// </summary>
        [Fact]
        public void Test_2() {
            var key = "Test_2";
            var result = new List<string>();
            Util.Helpers.Thread.ParallelExecute( () => result.Add( _service.Execute( key ) ), 20 );
            Assert.Single( result.FindAll( t => t == "ok" ));
        }

        /// <summary>
        /// 测试解锁
        /// </summary>
        [Fact]
        public void Test_3() {
            var key = "Test_3";

            //执行，被锁定
            _service.Execute( key );

            //未解锁，无法执行
            var result = new List<string>();
            Util.Helpers.Thread.ParallelExecute( () => result.Add( _service.Execute( key ) ), 20 );
            Assert.Empty( result.FindAll( t => t == "ok" ) );

            //解锁
            _service.UnLock();

            //再次执行
            Util.Helpers.Thread.ParallelExecute( () => result.Add( _service.Execute( key ) ), 20 );
            Assert.Single( result.FindAll( t => t == "ok" ));
        }

        /// <summary>
        /// 延迟1秒才允许执行 - 设置延迟时间后，UnLock无效
        /// </summary>
        [Fact]
        public void Test_4() {
            var key = "Test_4";
            Assert.Equal( "ok", _service.Execute( key, TimeSpan.FromSeconds( 1 ) ) );
            _service.UnLock();
            Assert.Equal( "fail", _service.Execute( key ) );
            System.Threading.Thread.Sleep( 1100 );
            Assert.Equal( "ok", _service.Execute( key ) );
        }
    }
}
