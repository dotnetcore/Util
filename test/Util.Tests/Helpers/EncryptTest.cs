using System.Text;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 加密测试
    /// </summary>
    public class EncryptTest {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EncryptTest( ITestOutputHelper output ) {
            _output = output;
        }

        /// <summary>
        /// 测试Md5加密，返回16位结果
        /// </summary>
        [Theory]
        [InlineData(null,"")]
        [InlineData( "", "" )]
        [InlineData( " ", "" )]
        [InlineData( "a", "C0F1B6A831C399E2" )]
        [InlineData( "中国", "CB143ACD6C929826" )]
        public void TestMd5By16( string input, string result ) {
            Assert.Equal( result, Encrypt.Md5By16( input ) );
        }

        /// <summary>
        /// 测试Md5加密，返回32位结果
        /// </summary>
        [Theory]
        [InlineData( null, "" )]
        [InlineData( "", "" )]
        [InlineData( " ", "" )]
        [InlineData( "a", "0CC175B9C0F1B6A831C399E269772661" )]
        [InlineData( "中国", "C13DCEABCB143ACD6C9298265D618A9F" )]
        public void TestMd5By32( string input, string result ) {
            Assert.Equal( result, Encrypt.Md5By32( input ) );
        }

        /// <summary>
        /// 测试DES加密验证
        /// </summary>
        [Theory]
        [InlineData( null,"", "" )]
        [InlineData( "","", "" )]
        [InlineData( "1", "", "" )]
        [InlineData( "1", "2", "" )]
        public void TestDes_Validate( string input,string key, string result ) {
            Assert.Equal( result, Encrypt.DesEncrypt( input, key,Encoding.UTF8 ) );
            Assert.Equal( result, Encrypt.DesDecrypt( input, key, Encoding.UTF8 ) );
        }

        /// <summary>
        /// 测试DES加密
        /// </summary>
        [Fact]
        public void TestDes_1() {
            const double value = 100.123;
            var encode = Encrypt.DesEncrypt( value );
            _output.WriteLine( encode );
            Assert.Equal( value.SafeString(), Encrypt.DesDecrypt( encode ) );
        }

        /// <summary>
        /// 测试DES加密
        /// </summary>
        [Fact]
        public void TestDes_2() {
            const string value2 = @"~!@#$%^&*()_+|,./;[]'{}""}{?>:<> \\ qwe测 *试rtyuiopadE15R3JrMnByS3c9sdfghjklzxcvbnm1234567890-=\";
            var encode = Encrypt.DesEncrypt( value2 );
            _output.WriteLine( encode );
            Assert.Equal( value2, Encrypt.DesDecrypt( encode ) );
        }

        /// <summary>
        /// 测试AES加密验证
        /// </summary>
        [Theory]
        [InlineData( null, "", "" )]
        [InlineData( "", "", "" )]
        [InlineData( "1", "", "" )]
        public void TestAes_Validate( string input, string key, string result ) {
            Assert.Equal( result, Encrypt.AesEncrypt( input, key, Encoding.UTF8 ) );
            Assert.Equal( result, Encrypt.AesDecrypt( input, key, Encoding.UTF8 ) );
        }

        /// <summary>
        /// 测试AES加密
        /// </summary>
        [Fact]
        public void TestAes_1() {
            var encode = Encrypt.AesEncrypt( "a" );
            _output.WriteLine( encode );
            Assert.Equal( "a", Encrypt.AesDecrypt( encode ) );
        }

        /// <summary>
        /// 测试AES加密
        /// </summary>
        [Fact]
        public void TestAes_2() {
            var encode = Encrypt.AesEncrypt( "中国" );
            _output.WriteLine( encode );
            Assert.Equal( "中国", Encrypt.AesDecrypt( encode ) );
        }

        /// <summary>
        /// 测试Rsa签名验证
        /// </summary>
        [Theory]
        [InlineData( null, "", "" )]
        [InlineData( "", "", "" )]
        [InlineData( "1", "", "" )]
        public void TestRsaSign_Validate( string input, string key, string result ) {
            Assert.Equal( result, Encrypt.AesEncrypt( input, key, Encoding.UTF8 ) );
            Assert.Equal( result, Encrypt.AesDecrypt( input, key, Encoding.UTF8 ) );
        }

        /// <summary>
        /// Rsa私钥
        /// </summary>
        public const string RsaKey = "MIIEogIBAAKCAQEAuLbs8Jugb3qhzDu4rvMqQ8n1RS8TQCpJ3+Cg9qR/RgMcpBx8+0tUiYkfOOnzxGlBuIwGF7Hqyho2E1ICNoIeNY4GkUhxBk7/wz4M6/tbfKSmWp1PAi9gVOxT0Io1kNBAV0it+uiDA176qk2tIKPxQ7UBPRB6qVELHuM7Y9AVoOQbHe56+rEoTiRo13NTx01yg0xiZDzS5gAe/vu+rDAKBczm7ZQ0A4U//modw1/rV+GKiqJ8CIDHe7a8oW2rthDNTZ2C/CHug4QMEmhaNazvhzjyAE1rfvYLF0o92qEfkip3IQRJnFM4rrr9QvWjkSPO7sPu5rMyE4oeUZHJ8luhIwIDAQABAoIBAGE8ytaO1pJY+DvPZJWUpLcy5c8ZzQSGPoWAdrvgNK/ii31JEfIn4cTVTn5jilPnJRXFgJ+QpYzm53icP1X6gXSn44UvoXA0vidFzv+bProK4xfon+MCla+fCTBK0Y/+USChvhTLucxYf5SPd4grRaLi8lf3CNuBMl18OZN9wyUCicgcqOp2mwi46daqqqvNLJwzmiKVCMb82JKEVShkmRDp8+ST7imwtXypUzLnwRt00xobiO8Gi1B1jYE4xM0hmkVgEHHLMGUOlfECH/VcWFLRkwosM3P6PYwb/mfBiDrIzN2mbueKZxMZureUqll9uLWRwPEvTosqc+tl+a4jCkECgYEA784SWiUGoSBDuKu9wm2D5Almz0gZavMv15cYsTfbu6UzsLcIRLEqLG1Rv9bFnwR39Gd1Cl3JAKDlxhs8qxJhy5zi0TJUowF9/QAg7TgBkGZVU4p+6SKF4mPKKsC4tnpENM+FnylncpCjFs45+MNruUIq1OVkcfxGBaBxDB/SM6kCgYEAxTBozzAyfH+9HHNisCQ2x7iNWEuaydY39V8vAlGPRZSbbo8OoV3wlidZm2wAhRybUCg7wefdbMAJlH8Uq/HnwuwanEkMO4IH/t5WI/MKk4Wc55iwC1abqQZrAxNCfjG+fShr2AZHO1jTj4oyd3BuQFTQBdRtiB+g8ibrGYG1resCgYA/sJ2TL45JMQaLf6GQiAGliRGzL9UAYMJuIgU+3DUR61iFMLeTdvJahlZV+zbVexxY3zlonWwLLLCaIxXD4cfziiF7qkBsYrMRhP05w8w2i9dRrtDyHmcsr5A8Np9YZ7TByfQVR6vf86Y9IlynQ0/TDk3N6Xb6BySZzfj4XWM4sQKBgBKeW4cUme+/b++7xVm0UafR+SaZHOhp3abBcgLaCJkdSv/Jaiw6XnkPBhryu6nV5aRP6DSK3BFkoILw7Na/ZI63FFwlWY5U3MRn4eJLFHiRaRtFA3pOlywCeyAzNVgNAlt28ZfYH+munWs0NUepyf8xAuNKB32O3vd+TTx/TtQ5AoGAGgD1Rc2hTopjXI8P5K1wuEMrvUp2uo0apguHu2uzIUpFyQYgjp80hBsqDj6e22R0LDzQTPrj8i+KvLZ4Xu8iCCQrUMqOvE6oZbQ7ukJ+wZebLOnrI6/AzD/zza3LZMXt/lKFgbaiYFLOSPEwxg+VBxxe10aQ3ddp5NuBDjQXJW0=";
        
        /// <summary>
        /// 测试Rsa签名算法
        /// </summary>
        [Fact]
        public void TestRsaSign() {
            const string value = "sign_type=RSA";
            const string result = "b5jaOTwneLBLTXmemp2BvThFqpmgBsM60GX28MUERYx0vRGiWLw31sif7mlt6Sz063p9zo3quQ8hCwDy6Qssz7i50pqHaJuobpayQZJNHiYpzH07ZxkvJhqsG8IrXj4Q2rmyxpDayU3kg9lhT14VadnLflaypwTpvuy3nGpIoY62d5ciObwxJBDYeilIJag5iY/xTWqv1z4TAr5E6u4zo2aY4rGGKruIX4vsI58EmxzI82clz11uK964Eco/RXCZrha3Vthx5sa6yIPvr2xG95Va4UZglgX7c/wXyMyFp1t/MtKb/0IdQocuRtBmyJw5n0CdmTfw7WxcdNEecgwqjQ==";
            var encode = Encrypt.RsaSign( value, RsaKey );
            _output.WriteLine( encode );
            Assert.Equal( result, encode );
        }

        /// <summary>
        /// 测试Rsa2签名算法
        /// </summary>
        [Fact]
        public void TestRsa2Sign() {
            const string value = "sign_type=RSA2";
            const string result = "cFIjAWDAuNzRYzGOr65ux4e5GEOUvKUT0mLTpAJ89vem70IsdKCrs0IY2TANw3I6pBqdeG0Lz6kNeWHkurN+tj1+C/7ZpRgHIilV+sUU5Dv0Nw/cDVjvs4fyKJ4CEr8zcs1MB1ek0COuQ/kfHxbAr9sWE9a0nqxnZ/FnsDy5ogFP1LQStkms+e7Ph9CC/dyl6JRlpgZx7/NwnN9kF3zEnVwdPxxLq5as1EV7FmlpLcuI/tkCpL8G+vPJcB3xktM9EBBRMR+peDbusZ1fOAuxE7zbW3XVsgz7JzKUcHE5KNS3zzcov404zKT/8i/ezyCxRCWRHDy3O3zHg5bUUOluIQ==";
            var encode = Encrypt.Rsa2Sign( value, RsaKey );
            _output.WriteLine( encode );
            Assert.Equal( result, encode );
        }

        /// <summary>
        /// 测试HmacSha256加密
        /// </summary>
        [Theory]
        [InlineData( null, "" )]
        [InlineData( "", "" )]
        [InlineData( " ", "" )]
        [InlineData( "a", "780c3db4ce3de5b9e55816fba98f590631d96c075271b26976238d5f4444219b" )]
        [InlineData( "中国", "dde7619d5465b73d94c18e6d979ab3dd9e478cb91b00d312ece776b282b7e0a9" )]
        public void TestHmacSha256( string input, string result ) {
            var key = "key";
            _output.WriteLine( $"input:{input},result:{Encrypt.HmacSha256( input, key )}" );
            Assert.Equal( result, Encrypt.HmacSha256( input, key ) );
        }
    }
}
