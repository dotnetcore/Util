using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Util.Logging.Tests.Samples;
using Xunit;

namespace Util.Logging.Tests {
    /// <summary>
    /// ��־�������� - ���Ը��ټ���
    /// </summary>
    public partial class LogTest {
        /// <summary>
        /// ����д������־ - ��֤���ÿ���Ϣ
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_Validate_Empty() {
            _log.Message( "" ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( It.IsAny<EventId>(), It.IsAny<Exception>(), It.IsAny<string>() ), Times.Never );
        }

        /// <summary>
        /// ����д������־ - ���ü���Ϣ
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_1() {
            _log.Message( "a" ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0,null, "a" ) );
        }

        /// <summary>
        /// ����д������־ - ����־��Ϣ����1������
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_2() {
            _log.Message( "a{b}",1 ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}",1 ) );
        }

        /// <summary>
        /// ����д������־ - ����־��Ϣ����2������
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_3() {
            _log.Message( "a{b}{c}", 1,2 ).LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}{c}", 1,2 ) );
        }

        /// <summary>
        /// ����д������־ - ��ε���Message����������־��Ϣ
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_4() {
            _log.Message( "a{b}{c}", 1, 2 )
                .Message( "e{f}{g}", 3, 4 )
                .LogTrace();
            _mockLogger.Verify( t => t.LogTrace( 0, null, "a{b}{c}e{f}{g}", 1, 2,3,4 ) );
        }

        /// <summary>
        /// ����д������־ - ͬʱ�����Զ�����չ���Ժ���־��Ϣ
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
        /// ����д������־ - ͬʱ����״̬�������־��Ϣ
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
        /// ����д������־ - ͬʱ�����Զ�����չ����,״̬����,��־��Ϣ
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
        /// ����д������־ - ͬʱ����EventId,�쳣,��־��Ϣ
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
        /// ����д������־ - ����1���Զ�����չ����
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
        /// ����д������־ - ����2���Զ�����չ����
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
        /// ����д������־ - �����Զ�����չ���Ժ�״̬����
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
        /// ����д������־ - ����һ����ͨ״̬���� - ���Կ�ֵ����
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
        /// ����д������־ - ����һ���ֵ�״̬���� - ���Կ�ֵ����
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
