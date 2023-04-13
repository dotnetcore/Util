using System.Text;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Security.Tests.Helpers {
    /// <summary>
    /// 加密测试
    /// </summary>
    public class EncryptTest {
        /// <summary>
        /// 私钥
        /// </summary>
        private const string PrivateKey = "MIIEowIBAAKCAQEAokcqBnZ6Q1JSdTr7Hqg9rd+JKB60JtZk4LOz3PSPmPppMO7M6/iaYnZgjhWXqGtSxP5yfFiiAFEx2JcTWkmS8kMBMQl3Fzl0AkSybi6Sr/JifMoUYAaGANbzNEpK9Qr9ARdiVeyxSPNbZX4h1HD7TbMx2n106In4C0mMoZukwVcPnEmxJut5FqIdFARiNb/HdlBcMUwGFtGPXM5YAFXBmc+5GCGTjpBOgnhd0OTYB0Cwg7o5aW1KYb1ivDI8AYEdKibl3VAOqMfX+idd77fJlEXeeMVrxFaZBucnn4eS9c0ES/gIqmLvPU3oJbXLopeTttVi75xnKU+FIXnbX2xPWQIDAQABAoIBAQCYf/AKasSzB2XeLTNYuBpej7dBMLlz1f6u+7GHb3yS8qBwD7ob92B+L2jFnZ0L9O+vmL7WBCUZzzPcqvzQ2Ftzt2wjPRXhiWhvyUc1LCdFma7cPruvEfJUT6v18+tFJLJmmCcdQHXKbIfzdPktv48qkb/D6Co5bY7gbJnwNWg7F6rJfsPWN240o9nISLcEHem5khOw7JsYi34QQyGtixFa/4uQBGg4D1Semok4vr4h9GoedK+NJBnWp8/gorowSoZ1t8HWLSpt0y9trb1kvgr9ZmyZYkDSbhJJRlWqODqHvgf50P90b/GqPYroLY5/uED2HmX/16wEZl1Y0tBMqvIBAoGBAMxu7SvJUduwtfoKgJlz3sDodgNVWuQdz6ZZ94faGDOmErl30d/WDau5iN/4n2aAnibRksmPPnUwxOVuX4sR0A2UeZPuoYUzKElYD9Trmw/lKgScZrFsL42lb36kjy3gYTpLk3xPlfm6jBsj6tY38ZAUOBes3EfqEURRMIzG7guJAoGBAMs2Gb4w+i4y9AqDKU4Zbk+Y08p9VdLKvdA4yZp+E2Tb8RzCA3wRzA5iYtTFkQQesPxw3cXN5baR+ugLhZkyk9plJr7+soZav3mdENrs0hbtqzsLT83+gaPQ9oJJtMEx+7XRRNYFcSve57AnFZndeiI8JbLAil5pSDBKRnFMLiFRAoGAEIBbsI8dhmgrKDW0z64kqtmYvQgkwAkP+9ODQXn/PhwHouTjEfhLPjNJsxp0c2eqXGPKP27KkdcP7Z0NJUKY0p/LeH9olkHc3J65GGy0JYJP8/NT7rpW1E4oQ8awr/lOn8/95aje6DuAl6g8inIVk5WuOWsAlOV141fSXWqpSFECgYB7z7ibkse7gjwCc6uk9AWr5ZeU1gyGZBSGWzMqOAqk9wTO2r64xzcmxHcm4EDc275F8JaOwEZnmEXhP7PkhVZkSCD1WcV36q6i8DmmyYevhJtBXEEBZ0Ghh93JwBKra0LLondoVuR/ME7FmuqkVrblSPRHFty3bToYggitWxb4IQKBgFc61S0ecneqV6NxpUZPlaEp81h+JW82Z1IgfCB/mrGty9SHAghhNCl8NGICIwwRGiTMEb1J3DYjAFVt+NxXxh1XyZZp5Gmh+ofRlD4YPieb1klPywTNPCOv2Rf/DyyUTekSwfwR64GvQoFrVgTpOaukFNqy58EWkoIbAJzDTzpG";
        /// <summary>
        /// 公钥
        /// </summary>
        private const string PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAokcqBnZ6Q1JSdTr7Hqg9rd+JKB60JtZk4LOz3PSPmPppMO7M6/iaYnZgjhWXqGtSxP5yfFiiAFEx2JcTWkmS8kMBMQl3Fzl0AkSybi6Sr/JifMoUYAaGANbzNEpK9Qr9ARdiVeyxSPNbZX4h1HD7TbMx2n106In4C0mMoZukwVcPnEmxJut5FqIdFARiNb/HdlBcMUwGFtGPXM5YAFXBmc+5GCGTjpBOgnhd0OTYB0Cwg7o5aW1KYb1ivDI8AYEdKibl3VAOqMfX+idd77fJlEXeeMVrxFaZBucnn4eS9c0ES/gIqmLvPU3oJbXLopeTttVi75xnKU+FIXnbX2xPWQIDAQAB";
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
        [InlineData( null, "", "" )]
        [InlineData( "", "", "" )]
        [InlineData( "1", "", "" )]
        [InlineData( "1", "2", "" )]
        public void TestDes_Validate( string input, string key, string result ) {
            Assert.Equal( result, Encrypt.DesEncrypt( input, key, Encoding.UTF8 ) );
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

        /// <summary>
        /// 测试Rsa签名和验签
        /// </summary>
        [Fact]
        public void TestRsaSign() {
            const string value = "哈楼,World";
            const string result = "bp8XUr2dFUEIo8q9yySRabuFjpSCChRzgL8+dDps16XscyyUtlPyCBRyRJOWrtDuucoC38knwqUK/XKbQvzdf0HAJrdWsP7k6se3ryeEEJm29zIhqDulefGOrDh9WbhBQSOMNC86mo7jMW+jqwPw8Uhc0aGMHJnEw6lETQ50Mmhqj5Jzq+rdQ5aQEd3WKrY3hU6h60yHyESsjObCEYcXFF0sIKHHT7hambbOxeywgeCd8FZDE0a7rMLE2KsJT+/lHiFizuP1fQS5E6LKK0P/hxecQVONgDENAKEMkS/fbCgp2nnsNph/jHKIlBDmbCI7EsAEiVVCe7LCB01ylsfX+A==";
            var sign = Encrypt.RsaSign( value, PrivateKey );
            _output.WriteLine( sign );
            Assert.Equal( result, sign );
            Assert.True( Encrypt.RsaVerify( value,PublicKey, sign ) );
        }

        /// <summary>
        /// 测试Rsa加密解密
        /// </summary>
        [Fact]
        public void TestRsaEncrypt() {
            const string value = "哈楼,World";
            var encryptValue = Util.Helpers.Encrypt.RsaEncrypt( value, PublicKey );
            var result = Util.Helpers.Encrypt.RsaDecrypt( encryptValue, PrivateKey );
            Assert.Equal( value, result );
        }
    }
}
