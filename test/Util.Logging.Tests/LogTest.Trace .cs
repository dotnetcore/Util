using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Util.Logging.Tests.Samples;
using Xunit;

namespace Util.Logging.Tests {
    /// <summary>
    /// 日志操作测试 - 测试跟踪级别
    /// </summary>
    public partial class LogTest {
        /// <summary>
        /// 测试写跟踪日志 - 验证设置空消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_Validate_Empty() {
            _log.Message( "" ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( It.IsAny<EventId>(), It.IsAny<Exception>(), It.IsAny<string>() ), Times.Never );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置简单消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_1() {
            _log.Message( "a" ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0,null, "a" ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 给日志消息传递1个参数
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_2() {
            _log.Message( "a{b}",1 ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}",1 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 给日志消息传递2个参数
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_3() {
            _log.Message( "a{b}{c}", 1,2 ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}{c}", 1,2 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 多次调用Message方法设置日志消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_4() {
            _log.Message( "a{b}{c}", 1, 2 )
                .Message( "e{f}{g}", 3, 4 )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}{c}e{f}{g}", 1, 2,3,4 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 同时设置自定义扩展属性和日志消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_5() {
            _log.Message( "a{b}{c}", 1, 2 )
                .Property( "d","3" )
                .Property( "e", "4" )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "[d:{d},e:{e}]a{b}{c}", "3","4", 1, 2 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 同时设置状态对象和日志消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_6() {
            var product = new Product {Code = "a", Name = "b", Price = 123 };
            _log.Message( "a{b}{c}", 1, 2 )
                .State( product )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "[Code:{Code},Name:{Name},Price:{Price}]a{b}{c}", "a","b",123,1,2 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 同时设置自定义扩展属性,状态对象,日志消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_7() {
            var product = new Product { Code = "a", Name = "b", Price = 123 };
            _log.Message( "a{b}{c}", 1, 2 )
                .Property( "d", "3" )
                .Property( "e", "4" )
                .State( product )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "[d:{d},e:{e},Code:{Code},Name:{Name},Price:{Price}]a{b}{c}", "3", "4", "a", "b", 123, 1, 2 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 同时设置EventId,异常,日志消息
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_8() {
            _log.EventId( 110 )
                .Exception( new Exception( "a" ) )
                .Message( "a{b}{c}", 1, 2 )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 110, It.Is<Exception>( e => e.Message == "a" ), "a{b}{c}", 1, 2 ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置1个自定义扩展属性
        /// </summary>
        [Fact]
        public void TestLogTrace_Property_1() {
            _log.Property( "a","1" ).LogTrace();
            _mockLogger.Verify( t => t.Log( LogLevel.Trace, 0, 
                It.Is<IDictionary<string, object>>( dic => dic.Count == 1 && dic["a"].ToString()=="1" ),
                null,
                It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置2个自定义扩展属性
        /// </summary>
        [Fact]
        public void TestLogTrace_Property_2() {
            _log.Property( "a", "1" ).Property( "b","2" ).LogTrace();
            _mockLogger.Verify( t => t.Log( LogLevel.Trace, 0,
                It.Is<IDictionary<string, object>>( dic => dic.Count == 2 && dic["a"].ToString() == "1" && dic["b"].ToString() =="2" ),
                null,
                It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置自定义扩展属性和状态对象
        /// </summary>
        [Fact]
        public void TestLogTrace_Property_3() {
            var product = new Product { Code = "a", Name = "b", Price = 123 };
            _log.Property( "Age", "18" ).State( product ).LogTrace();
            _mockLogger.Verify( t => t.Log( LogLevel.Trace, 0,
                It.Is<IDictionary<string, object>>( dic => dic.Count == 4 && dic["Age"].ToString() == "18" && dic["Name"].ToString() == "b" ),
                null,
                It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置一个普通状态对象 - 忽略空值属性
        /// </summary>
        [Fact]
        public void TestLogTrace_Sate_1() {
            var product = new Product { Code = "a" };
            _log.State( product ).LogTrace();
            _mockLogger.Verify( t => t.Log( LogLevel.Trace, 0,
                It.Is<IDictionary<string, object>>( dic => dic.Count == 2 && dic["Code"].ToString() == "a" && dic["Price"].ToString() == "0" ),
                null,
                It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
        }

        /// <summary>
        /// 测试写跟踪日志 - 设置一个字典状态对象 - 忽略空值属性
        /// </summary>
        [Fact]
        public void TestLogTrace_Sate_2() {
            var content = new Dictionary<string, object> {
                { "Code", "a" },
                { "Name", "" },
                { "Price", 0 }
            };
            _log.State( content ).LogTrace();
            _mockLogger.Verify( t => t.Log( LogLevel.Trace, 0,
                It.Is<IDictionary<string, object>>( dic => dic.Count == 2 && dic["Code"].ToString() == "a" && dic["Price"].ToString() == "0" ),
                null,
                It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
        }
    }
}
