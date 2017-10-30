using Util.Signatures;
using Util.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Tests.Signatures {
    /// <summary>
    /// 签名服务测试
    /// </summary>
    public class SignManagerTest {
        /// <summary>
        /// 输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 签名服务
        /// </summary>
        private readonly SignManager _manager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SignManagerTest( ITestOutputHelper output ) {
            _output = output;
            _manager = new SignManager( new SignKey( EncryptTest.RsaKey ) );
        }

        /// <summary>
        /// 测试签名
        /// </summary>
        [Fact]
        public void TestSign_1() {
            const string result = "cFIjAWDAuNzRYzGOr65ux4e5GEOUvKUT0mLTpAJ89vem70IsdKCrs0IY2TANw3I6pBqdeG0Lz6kNeWHkurN+tj1+C/7ZpRgHIilV+sUU5Dv0Nw/cDVjvs4fyKJ4CEr8zcs1MB1ek0COuQ/kfHxbAr9sWE9a0nqxnZ/FnsDy5ogFP1LQStkms+e7Ph9CC/dyl6JRlpgZx7/NwnN9kF3zEnVwdPxxLq5as1EV7FmlpLcuI/tkCpL8G+vPJcB3xktM9EBBRMR+peDbusZ1fOAuxE7zbW3XVsgz7JzKUcHE5KNS3zzcov404zKT/8i/ezyCxRCWRHDy3O3zHg5bUUOluIQ==";
            _manager.Add( "sign_type", "RSA2" );
            _output.WriteLine( _manager.Sign() );
            Assert.Equal( result, _manager.Sign() );
        }

        /// <summary>
        /// 测试签名
        /// </summary>
        [Fact]
        public void TestSign_2() {
            const string result = "nGnJ0ANw7e17enJRGzMqsrLFQhObn6sKi+Po17H4ff+3VgqVNXsQC6L9TTzEzATz/0dfZ1w3Wbq+EeXJYC6RvAg86OBTztSOCr7TJDeGyriClftyDvSPXW07He3R0N46+kM8Yel16FP1wXon5cZS2JFvPpfmaQnyCWngW2de5HkXJmwZ4OJ44zqw4aD9rB8UNtq/R2Tu3078w+ux6FdLNVsC2TIq9kXHT2mG6yyUsJZxVX4DFwnc7gPXAOhiwEsLMqUnyBpW5QtiPi9DjdKwIr35f/+ZydheqnE9im4cl8WVwKHRyTElvgWIO31mvpNzkBwo0yaie65ENrPw7eVhrQ==";
            _manager.Add( "sign_type", "RSA2" );
            _manager.Add( "d", "" );
            _manager.Add( "c", "12" );
            _manager.Add( "a", "2" );
            _output.WriteLine( _manager.Sign() );
            Assert.Equal( result, _manager.Sign() );
        }
    }
}
