using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Util.Helpers;
using Util.Tests.Samples;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// Json测试
    /// </summary>
    public class JsonTest {
        /// <summary>
        /// 测试循环引用序列化
        /// </summary>
        [Fact]
        public void TestLoop() {
            A a = new A { Name = "a" };
            B b = new B { Name = "b" };
            C c = new C { Name = "c" };
            a.B = b;
            b.C = c;
            c.A = a;
            AssertHelper.Throws<JsonSerializationException>( () => Json.ToJson( c ) );
        }

        /// <summary>
        /// 转成Json,验证空
        /// </summary>
        [Fact]
        public void TestToJson_Null() {
            Assert.Empty( Json.ToJson( null ) );
        }

        /// <summary>
        /// 测试转成Json
        /// </summary>
        [Fact]
        public void TestToJson() {
            var result = new StringBuilder();
            result.Append( "{" );
            result.Append( "\"Name\":\"a\"," );
            result.Append( "\"nickname\":\"b\"," );
            result.Append( "\"Value\":null," );
            result.Append( "\"Date\":\"2012/1/1 0:00:00\"," );
            result.Append( "\"Age\":1," );
            result.Append( "\"isShow\":true" );
            result.Append( "}" );
            var actualData = JsonTestSample.Create();
            actualData.Date = DateTime.Parse(actualData.Date).ToString("yyyy/M/d 0:00:00");
            Assert.Equal( result.ToString(), Json.ToJson(actualData) );
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
            result.Append( "'Value':null," );
            result.Append( "'Date':'2012/1/1 0:00:00'," );
            result.Append( "'Age':1," );
            result.Append( "'isShow':true" );
            result.Append( "}" );

            var actualData = JsonTestSample.Create();
            actualData.Date = DateTime.Parse(actualData.Date).ToString("yyyy/M/d 0:00:00");
            Assert.Equal( result.ToString(), Json.ToJson(actualData, true ) );
        }

        /// <summary>
        /// 测试转换实体为Json
        /// </summary>
        [Fact]
        public void TestToJson_Entity() {
            AggregateRootSample entity = new AggregateRootSample();
            entity.Code = "a";
            entity.IntSamples.Add( new IntAggregateRootSample{Name = "b"} );
            var json = Util.Helpers.Json.ToJson( entity );
            entity = Util.Helpers.Json.ToObject<AggregateRootSample>( json );
            Assert.Equal( "a", entity.Code );
            Assert.Equal( "b", entity.IntSamples.First().Name );
        }

        /// <summary>
        /// 测试转成对象
        /// </summary>
        [Fact]
        public void TestToObject() {
            var customer = Json.ToObject<JsonTestSample>( "{\"Name\":\"a\"}" );
            Assert.Equal( "a", customer.Name );
        }
    }
}
