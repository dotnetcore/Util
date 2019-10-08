using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Samples {
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main( string[] args ) {
            try {
                WebHost.CreateDefaultBuilder( args )
                    .UseStartup<Startup>()
                    .Build()
                    .Run();
            }
            catch( Exception ex ) {
                ex.Log( Log.GetLog().Caption( "应用程序启动失败" ) );
            }
        }
    }
}