using System;
using Microsoft.Extensions.Logging;
using Util.Exceptions;
using Xunit;

namespace Util.Tests.Exceptions {
    /// <summary>
    /// 应用程序异常测试
    /// </summary>
    public class WarningTest {
        /// <summary>
        /// 测试设置消息
        /// </summary>
        [Fact]
        public void TestMessage() {
            Warning warning = new Warning( "A" );
            Assert.Equal( "A", warning.Message );
        }

        /// <summary>
        /// 测试消息为空
        /// </summary>
        [Fact]
        public void TestMessage_Null() {
            Warning warning = new Warning( null, "A" );
            Assert.Equal( string.Empty, warning.Message );
        }

        /// <summary>
        /// 测试设置错误码
        /// </summary>
        [Fact]
        public void TestCode() {
            Warning warning = new Warning( "", "B" );
            Assert.Equal( "B", warning.Code );
        }

        /// <summary>
        /// 测试设置异常
        /// </summary>
        [Fact]
        public void TestException() {
            Warning warning = new Warning( new Exception( "A" ) );
            Assert.Equal( "A", warning.Message );
        }

        /// <summary>
        /// 测试设置错误消息和异常
        /// </summary>
        [Fact]
        public void TestMessageAndException() {
            Warning warning = new Warning( "A", "", new Exception( "C" ) );
            Assert.Equal( $"A{Environment.NewLine}C", warning.Message );
        }

        /// <summary>
        /// 测试设置2层异常
        /// </summary>
        [Fact]
        public void TestException_2Layer() {
            Warning warning = new Warning( "A", "",new Exception( "C", new Exception( "D" ) ) );
            Assert.Equal( $"A{Environment.NewLine}C{Environment.NewLine}D", warning.Message );
        }

        /// <summary>
        /// 测试设置Warning
        /// </summary>
        [Fact]
        public void TestWarning() {
            Warning warning = new Warning( new Warning( "A" ) );
            Assert.Equal( "A", warning.Message );
        }

        /// <summary>
        /// 测试设置2层Warning
        /// </summary>
        [Fact]
        public void TestWarning_2Layer() {
            Warning warning = new Warning( "A", "", new Warning( "B", "", new Warning( "C" ) ) );
            Assert.Equal( $"A{Environment.NewLine}B{Environment.NewLine}C", warning.Message );
        }

        /// <summary>
        /// 测试设置3层Warning
        /// </summary>
        [Fact]
        public void TestWarning_3Layer() {
            Warning warning = new Warning( "A", "", new Warning( "B", "", new Exception( "C", new Warning( "D" ) ) ) );
            Assert.Equal( $"A{Environment.NewLine}B{Environment.NewLine}C{Environment.NewLine}D", warning.Message );
        }

        /// <summary>
        /// 添加异常数据
        /// </summary>
        [Fact]
        public void TestAddData_1Layer() {
            Warning warning = new Warning( "A" );
            warning.Data.Add( "key1", "value1" );
            warning.Data.Add( "key2", "value2" );
            Assert.Equal( $"A{Environment.NewLine}key1:value1{Environment.NewLine}key2:value2{Environment.NewLine}", warning.Message );
        }

        /// <summary>
        /// 添加2级异常数据
        /// </summary>
        [Fact]
        public void TestAdd_2Layer() {
            Exception exception = new Exception( "A" );
            exception.Data.Add( "a", "a1" );
            exception.Data.Add( "b", "b1" );
            Warning warning = new Warning( exception );
            warning.Data.Add( "key1", "value1" );
            warning.Data.Add( "key2", "value2" );
            Assert.Equal( $"A{Environment.NewLine}a:a1{Environment.NewLine}b:b1{Environment.NewLine}key1:value1{Environment.NewLine}key2:value2{Environment.NewLine}", warning.Message );
        }
    }
}
