using System;
using System.Collections.Generic;
using System.Diagnostics;
using Util.Helpers;
using Util.Logging.Tests.Samples;
using Xunit;

namespace Util.Logging.Tests {
    /// <summary>
    /// ExceptionLess��־��������
    /// </summary>
    public class LogTest {
        /// <summary>
        /// ��־����
        /// </summary>
        private readonly ILog<LogTest> _log;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        public LogTest( IServiceProvider serviceProvider, ILog<LogTest> log, ILogContextAccessor accessor ) {
            Ioc.SetServiceProviderAction( () => serviceProvider );
            _log = log;
            accessor.Context = new LogContext { Stopwatch = Stopwatch.StartNew(), TraceId = Id.Create() };
        }

        /// <summary>
        /// ����д������־ - ���ü���Ϣ
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_1() {
            _log.Message( $"TestTrace_Message_1_{Id.Create()}" ).LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����־��Ϣ����1������
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_2() {
            _log.Message( "TestTrace_Message_2_{ProductCode}",Id.Create() ).LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����־��Ϣ����2������
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_3() {
            _log.Message( "TestTrace_Message_3_{id}_{code}", $"id_{Id.Create()}", $"code_{Id.Create()}" ).LogTrace();
        }

        /// <summary>
        /// ����д������־ - ��ε���Message����������־��Ϣ
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_4() {
            _log.Message( "TestTrace_Message_4_{id}_{code}_", $"id_{Id.Create()}", $"code_{Id.Create()}" )
                .Message( "{name}_{note}", $"name_{Id.Create()}", $"note_{Id.Create()}" )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����@��Ϣ - ���� 
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_5() {
            _log.Message( "TestTrace_Message_5,@Product={@Product}", new Product{Code = "a",Name = "b",Price = 123} )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����$��Ϣ - ���� 
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_6() {
            _log.Message( "TestTrace_Message_6,$Product={$Product}", new Product { Code = "a", Name = "b", Price = 123 } )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����@��Ϣ - �ֵ�
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_7() {
            _log.Message( "TestTrace_Message_7,@Dictionary={@Dictionary}", new Dictionary<string,object> { {"Code","a"},{"Name","b"},{"Price",123} } )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - ����$��Ϣ - �ֵ�
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_8() {
            _log.Message( "TestTrace_Message_8,$Dictionary={$Dictionary}", new Dictionary<string, object> { { "Code", "a" }, { "Name", "b" }, { "Price", 123 } } )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - ͬʱ���ø�����
        /// </summary>
        [Fact]
        public void TestLogTrace_Message_9() {
            _log.EventId( 119 )
                .Message( "TestTrace_Message_9_{id}", $"id_{Id.Create()}" )
                .State( new Product { Code = "a", Name = "b", Price = 123 } )
                .Property( "Age", "18" )
                .Property( "Description", "hello" )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - �����Զ�����չ����
        /// </summary>
        [Fact]
        public void TestLogTrace_Property_1() {
            _log.EventId( 120 )
                .Property( "Age", "18" )
                .Property( "Description", "hello" )
                .LogTrace();
        }

        /// <summary>
        /// ����д������־ - �����Զ�����չ���Ժ�״̬����
        /// </summary>
        [Fact]
        public void TestLogTrace_Property_2() {
            _log.EventId( 121 )
                .Property( "Age", "18" )
                .Property( "Description", "hello" )
                .State( new Product { Code = "a", Name = "b", Price = 123 } )
                .LogTrace();
        }
    }
}
