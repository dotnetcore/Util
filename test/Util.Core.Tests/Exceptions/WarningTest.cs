using System;
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
            Warning warning = new Warning( "" );
            Assert.Equal( string.Empty, warning.Message );
        }

        /// <summary>
        /// 测试设置错误码
        /// </summary>
        [Fact]
        public void TestCode() {
            Warning warning = new Warning( "", code:"B" );
            Assert.Equal( "B", warning.Code );
        }

        /// <summary>
        /// 测试设置异常
        /// </summary>
        [Fact]
        public void TestException() {
            Warning warning = new Warning( new Exception( "A" ) );
            Assert.Empty( warning.Message );
            Assert.Equal( "A", warning.GetMessage() );
        }

        /// <summary>
        /// 测试设置错误消息和异常
        /// </summary>
        [Fact]
        public void TestMessageAndException() {
            Warning warning = new Warning( "A", new Exception( "C" ) );
            Assert.Equal( "A", warning.Message );
            Assert.Equal( $"A{Environment.NewLine}C", warning.GetMessage() );
        }

        /// <summary>
        /// 测试设置2层异常
        /// </summary>
        [Fact]
        public void TestException_2Layer() {
            Warning warning = new Warning( "A", new Exception( "C", new NotImplementedException( "D" ) ) );
            Assert.Equal( 3, warning.GetExceptions().Count );
            Assert.Equal( typeof( Warning ), warning.GetExceptions()[0].GetType() );
            Assert.Equal( typeof( Exception ), warning.GetExceptions()[1].GetType() );
            Assert.Equal( typeof( NotImplementedException ), warning.GetExceptions()[2].GetType() );
            Assert.Equal( "A", warning.GetExceptions()[0].Message );
            Assert.Equal( "C", warning.GetExceptions()[1].Message );
            Assert.Equal( "D", warning.GetExceptions()[2].Message );
            Assert.Equal( $"A{Environment.NewLine}C{Environment.NewLine}D", warning.GetMessage() );
        }

        /// <summary>
        /// 测试获取异常列表
        /// </summary>
        [Fact]
        public void TestGetExceptions_1() {
            var exception = new Exception( "A" );
            var list = Warning.GetExceptions( exception );
            Assert.Single( list );
            Assert.Equal( "A", list[0].Message );
        }

        /// <summary>
        /// 测试获取异常列表
        /// </summary>
        [Fact]
        public void TestGetExceptions_2() {
            var exceptionB = new Exception( "B" );
            var exceptionA = new Exception( "A", exceptionB );
            var list = Warning.GetExceptions( exceptionA );
            Assert.Equal( 2, list.Count );
            Assert.Equal( "A", list[0].Message );
            Assert.Equal( "B", list[1].Message );
        }
    }
}
