using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using Util.Helpers;
using Util.SystemTextJson;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// Json测试
    /// </summary>
    public class JsonTest {
        /// <summary>
        /// 测试转成Json - 转换为本地日期
        /// </summary>
        [Fact]
        public void TestToJson_Local() {
            Time.UseUtc( false );
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "\"Name\":\"a\"," );
            result.Append( "\"nickname\":\"b\"," );
            result.Append( "\"firstName\":\"c\"," );
            result.Append( "\"Value\":null," );
            result.Append( "\"Date\":\"2012-12-12 20:12:12\"," );
            result.Append( "\"UtcDate\":\"2012-12-12 20:12:12\"," );
            result.Append( "\"Age\":1," );
            result.Append( "\"IsShow\":true" );
            result.Append( "}" );
            var sample = JsonTestSample.Create();
            Assert.Equal( result.ToString(), Json.ToJson( sample ) );
        }

        /// <summary>
        /// 测试转成Json,移除双引号
        /// </summary>
        [Fact]
        public void TestToJson_RemoveQuotationMarks() {
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "Name:a," );
            result.Append( "nickname:b," );
            result.Append( "firstName:c," );
            result.Append( "Value:null," );
            result.Append( "Date:2012-12-12 20:12:12," );
            result.Append( "UtcDate:2012-12-12 20:12:12," );
            result.Append( "Age:1," );
            result.Append( "IsShow:true" );
            result.Append( "}" );
            var sample = JsonTestSample.Create();
            Assert.Equal( result.ToString(), Json.ToJson( sample,removeQuotationMarks: true ) );
        }

        /// <summary>
        /// 测试转成Json，将双引号转成单引号
        /// </summary>
        [Fact]
        public void TestToJson_ToSingleQuotes() {
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "'Name':'a'," );
            result.Append( "'nickname':'b'," );
            result.Append( "'firstName':'c'," );
            result.Append( "'Value':null," );
            result.Append( "'Date':'2012-12-12 20:12:12'," );
            result.Append( "'UtcDate':'2012-12-12 20:12:12'," );
            result.Append( "'Age':1," );
            result.Append( "'IsShow':true" );
            result.Append( "}" );
            var sample = JsonTestSample.Create();
            Assert.Equal( result.ToString(), Json.ToJson( sample,toSingleQuotes: true ) );
        }

        /// <summary>
        /// 测试转成Json - 异步
        /// </summary>
        [Fact]
        public async Task TestToJsonAsync() {
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "\"Name\":\"a\"," );
            result.Append( "\"nickname\":\"b\"," );
            result.Append( "\"firstName\":\"c\"," );
            result.Append( "\"Value\":null," );
            result.Append( "\"Date\":\"2012-12-12 20:12:12\"," );
            result.Append( "\"UtcDate\":\"2012-12-12 20:12:12\"," );
            result.Append( "\"Age\":1," );
            result.Append( "\"IsShow\":true" );
            result.Append( "}" );
            var sample = JsonTestSample.Create();
            var json = await Json.ToJsonAsyc( sample );
            Assert.Equal( result.ToString(), json );
        }

        /// <summary>
        /// 测试转成对象
        /// </summary>
        [Fact]
        public void TestToObject() {
            var sample = Json.ToObject<JsonTestSample>( "{\"Name\":\"a\"}" );
            Assert.Equal( "a", sample.Name );
        }

        /// <summary>
        /// 测试转成对象 - 异步
        /// </summary>
        [Fact]
        public async Task TestToObjectAsync() {
            var sample = await Json.ToObjectAsync<JsonTestSample>( "{\"Name\":\"a\"}" );
            Assert.Equal( "a", sample.Name );
        }

        /// <summary>
        /// 测试转成Json - 不转义中文字符
        /// </summary>
        [Fact]
        public void TestToJson_Encoder() {
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "\"Name\":\"哈哈\"," );
            result.Append( "\"nickname\":\"b\"," );
            result.Append( "\"firstName\":\"c\"," );
            result.Append( "\"Date\":\"2012-12-12 12:12:12\"," );
            result.Append( "\"Age\":1," );
            result.Append( "\"IsShow\":true" );
            result.Append( "}" );
            var sample = new JsonTestSample() {
                Name = "哈哈",
                nickname = "b",
                FirstName = "c",
                Value = null,
                Date = Util.Helpers.Convert.ToDateTime( "2012-12-12 12:12:12" ),
                Age = 1,
                IsShow = true
            };
            Assert.Equal( result.ToString(), Json.ToJson( sample, new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
                Converters = { new NullableDateTimeJsonConverter() }
            } ) );
        }
    }
}
