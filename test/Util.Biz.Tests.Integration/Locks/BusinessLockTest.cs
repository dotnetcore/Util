using System.Collections.Generic;
using Xunit;

namespace Util.Biz.Tests.Integration.Locks {
    /// <summary>
    /// 业务锁测试
    /// </summary>
    public class BusinessLockTest {
        /// <summary>
        /// 业务锁测试服务
        /// </summary>
        private readonly BusinessLockTestService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public BusinessLockTest() {
            _service = new BusinessLockTestService();
        }

        /// <summary>
        /// 执行一个服务
        /// </summary>
        [Fact]
        public void Test_1() {
            Assert.Equal( "ok", _service.Execute( "Test_1" ) );
        }

        /// <summary>
        /// 并发执行2个服务
        /// </summary>
        [Fact]
        public void Test_2() {
            var key = "Test_2";
            var result = new List<string>();
            Util.Helpers.Thread.ParallelExecute( () => {
                result.Add( _service.Execute( key ) );
            }, () => {
                result.Add( _service.Execute( key ) );
            } );
            Assert.Single( result.FindAll( t => t == "ok" ) );
            Assert.Equal( "ok", result[0] );
            Assert.Equal( "fail", result[1] );
        }

        /// <summary>
        /// 测试解锁
        /// </summary>
        [Fact]
        public void Test_3() {
            var key = "Test_3";
            
            //先锁定
            Util.Helpers.Thread.ParallelExecute( () => _service.Execute( key ), () => _service.Execute( key ) );

            //未解锁，无法执行
            var result = new List<string>();
            Util.Helpers.Thread.ParallelExecute( () => {
                result.Add( _service.Execute( key ) );
            }, () => {
                result.Add( _service.Execute( key ) );
            } );
            Assert.Empty( result.FindAll( t => t == "ok" ) );

            //解锁
            _service.UnLock( key );

            //再次执行
            Util.Helpers.Thread.ParallelExecute( () => {
                result.Add( _service.Execute( key ) );
            }, () => {
                result.Add( _service.Execute( key ) );
            } );
            Assert.Single( result.FindAll( t => t == "ok" ) );
        }
    }
}
