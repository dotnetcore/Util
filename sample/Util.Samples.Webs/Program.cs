using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Util.Samples.Webs {
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main( string[] args ) {
            WebHost.CreateDefaultBuilder( args )
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
