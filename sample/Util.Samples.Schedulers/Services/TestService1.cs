using System;
using System.Threading.Tasks;

namespace Util.Samples.Schedulers.Services {
    /// <summary>
    /// 测试服务1
    /// </summary>
    public class TestService1 : ITestService1 {
        public async Task HelloAsync() {
            await Console.Out.WriteLineAsync( "Hello" );
        }
        public void Dispose() {
            Console.WriteLine( "TestService-1释放了" );
        }
    }
}
