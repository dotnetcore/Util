using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Tests.Repositories;
using Xunit;

namespace Util.Scheduling.Hangfire.Tests {
    /// <summary>
    /// 调度器测试
    /// </summary>
    public class SchedulerTest {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ICustomerRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SchedulerTest( ICustomerRepository repository ) {
            _repository = repository;
        }

        /// <summary>
        /// 测试后台任务1
        /// </summary>
        [Fact]
        public async Task TestJob1() {
            await Task.Delay( TimeSpan.FromSeconds( 2 ) );
            var result = await _repository.Find().Where( t => t.Name == "TestJob1" ).CountAsync();
            Assert.Equal( 1, result );
        }

        /// <summary>
        /// 测试后台任务2
        /// </summary>
        [Fact]
        public async Task TestJob2() {
            await Task.Delay( TimeSpan.FromSeconds( 2 ) );
            var result = await _repository.Find().Where( t => t.Name == "TestJob2" ).CountAsync();
            Assert.Equal( 1, result );
        }
    }
}
