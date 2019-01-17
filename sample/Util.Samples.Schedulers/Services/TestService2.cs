using System;
using System.Threading.Tasks;

namespace Util.Samples.Schedulers.Services {
    /// <summary>
    /// 测试服务2
    /// </summary>
    public class TestService2 : ITestService2 {
        public async Task WorldAsync() {
            await Console.Out.WriteLineAsync( "World" );
        }
        public void Dispose() {
            Console.WriteLine( "TestService-2释放了" );
        }
    }
}
