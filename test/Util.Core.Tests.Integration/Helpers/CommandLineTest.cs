using System.Collections.Generic;
using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 命令行操作测试
    /// </summary>
    public class CommandLineTest {
        /// <summary>
        /// 测试设置命令参数 - 1个参数
        /// </summary>
        [Fact]
        public void TestArguments_1() {
            var command = new CommandLine().Command( "dapr" ).Arguments( "run" );
            Assert.Equal( "dapr run", command.GetDebugText());
        }

        /// <summary>
        /// 测试设置命令参数 - 多个参数
        /// </summary>
        [Fact]
        public void TestArguments_2() {
            var command = new CommandLine().Command( "dapr" ).Arguments( "run", "--app-id","80" );
            Assert.Equal( "dapr run --app-id 80", command.GetDebugText() );
        }

        /// <summary>
        /// 测试设置命令参数 - 数组参数
        /// </summary>
        [Fact]
        public void TestArguments_3() {
            var list = new List<string> {
                "run", 
                "--app-id", 
                "80"
            };
            var command = new CommandLine().Command( "dapr" ).Arguments( list );
            Assert.Equal( "dapr run --app-id 80", command.GetDebugText() );
        }

        /// <summary>
        /// 测试设置命令参数 - 多次调用Arguments
        /// </summary>
        [Fact]
        public void TestArguments_4() {
            var list = new List<string> {
                "--app-id",
                "80"
            };
            var command = new CommandLine().Command( "dapr" ).Arguments( "run" ).Arguments( list );
            Assert.Equal( "dapr run --app-id 80", command.GetDebugText() );
        }

        /// <summary>
        /// 测试根据条件设置命令参数
        /// </summary>
        [Fact]
        public void TestArgumentsIf() {
            var command = new CommandLine().Command( "dapr" ).ArgumentsIf( false,"run" );
            Assert.Equal( "dapr ", command.GetDebugText() );
        }
    }
}
