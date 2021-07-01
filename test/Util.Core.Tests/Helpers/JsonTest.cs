using System.Text;
using System.Threading.Tasks;
using Util.Helpers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// Json测试
    /// </summary>
    public class JsonTest {
        /// <summary>
        /// 测试转成Json
        /// </summary>
        [Fact]
        public void TestToJson() {
            var result = new StringBuilder();
            result.Append("{");
            result.Append("\"Name\":\"a\",");
            result.Append("\"nickname\":\"b\",");
            result.Append("\"firstName\":\"c\",");
            result.Append("\"Value\":null,");
            result.Append("\"Date\":\"2012/1/1 0:00:00\",");
            result.Append("\"Age\":1,");
            result.Append("\"IsShow\":true");
            result.Append("}");
            var sample = JsonTestSample.Create();
            Assert.Equal(result.ToString(), Json.ToJson(sample));
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
            result.Append( "Date:2012/1/1 0:00:00," );
            result.Append( "Age:1," );
            result.Append( "IsShow:true" );
            result.Append( "}" );
            var sample = JsonTestSample.Create();
            Assert.Equal( result.ToString(), Json.ToJson( sample,removeQuotationMarks:true ) );
        }

        /// <summary>
        /// 测试转成Json - 异步
        /// </summary>
        [Fact]
        public async Task TestToJsonAsync() {
            var result = new StringBuilder();
            result.Append("{");
            result.Append("\"Name\":\"a\",");
            result.Append("\"nickname\":\"b\",");
            result.Append("\"firstName\":\"c\",");
            result.Append("\"Value\":null,");
            result.Append("\"Date\":\"2012/1/1 0:00:00\",");
            result.Append("\"Age\":1,");
            result.Append("\"IsShow\":true");
            result.Append("}");
            var sample = JsonTestSample.Create();
            var json = await Json.ToJsonAsyc(sample);
            Assert.Equal(result.ToString(), json);
        }

        /// <summary>
        /// 测试转成对象
        /// </summary>
        [Fact]
        public void TestToObject() {
            var sample = Json.ToObject<JsonTestSample>("{\"Name\":\"a\"}");
            Assert.Equal("a", sample.Name);
        }

        /// <summary>
        /// 测试转成对象 - 异步
        /// </summary>
        [Fact]
        public async Task TestToObjectAsync() {
            var sample = await Json.ToObjectAsync<JsonTestSample>("{\"Name\":\"a\"}");
            Assert.Equal("a", sample.Name);
        }
    }
}
