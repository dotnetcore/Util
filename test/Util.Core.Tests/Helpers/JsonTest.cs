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

namespace Util.Tests.Helpers;

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
        result.Append( "\"Date\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"UtcDate\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"Age\":1," );
        result.Append( "\"IsShow\":true," );
        result.Append( "\"Enum\":0" );
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
        result.Append( "Date:2012-12-12 20:12:12," );
        result.Append( "UtcDate:2012-12-12 20:12:12," );
        result.Append( "Age:1," );
        result.Append( "IsShow:true," );
        result.Append( "Enum:0" );
        result.Append( "}" );
        var sample = JsonTestSample.Create();
        Assert.Equal( result.ToString(), Json.ToJson( sample, removeQuotationMarks: true ) );
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
        result.Append( "'Date':'2012-12-12 20:12:12'," );
        result.Append( "'UtcDate':'2012-12-12 20:12:12'," );
        result.Append( "'Age':1," );
        result.Append( "'IsShow':true," );
        result.Append( "'Enum':0" );
        result.Append( "}" );
        var sample = JsonTestSample.Create();
        Assert.Equal( result.ToString(), Json.ToJson( sample, toSingleQuotes: true ) );
    }

    /// <summary>
    /// 测试转成Json - 序列化接口
    /// </summary>
    [Fact]
    public void TestToJson_Interface() {
        Time.UseUtc( false );
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"Name\":\"a\"," );
        result.Append( "\"nickname\":\"b\"," );
        result.Append( "\"firstName\":\"c\"," );
        result.Append( "\"Date\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"UtcDate\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"Age\":1," );
        result.Append( "\"IsShow\":true," );
        result.Append( "\"Enum\":0" );
        result.Append( "}" );
        var sample = JsonTestSample.CreateToInterface();
        Assert.Equal( result.ToString(), Json.ToJson( sample ) );
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
        result.Append( "\"Date\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"UtcDate\":\"2012-12-12 20:12:12\"," );
        result.Append( "\"Age\":1," );
        result.Append( "\"IsShow\":true," );
        result.Append( "\"Enum\":0" );
        result.Append( "}" );
        var sample = JsonTestSample.Create();
        var json = await Json.ToJsonAsync( sample );
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
        result.Append( "\"IsShow\":true," );
        result.Append( "\"Enum\":0" );
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

    /// <summary>
    /// 测试转成Json - 枚举转换器
    /// </summary>
    [Fact]
    public void Test_Enum() {
        var sample = new JsonTestSample() {
            Enum = TestEnum.Test2,
            NullableEnum = TestEnum.Test2
        };
        var json = Json.ToJson( sample,
            new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new EnumJsonConverterFactory() }
            } );

        var result = Json.ToObject<JsonTestSample>( json, new JsonSerializerOptions() {
            Converters = { new EnumJsonConverterFactory() }
        } );
        Assert.True( result.Enum == TestEnum.Test2 );
        Assert.True( result.NullableEnum == TestEnum.Test2 );
    }

    /// <summary>
    /// 测试转成Json - long类型
    /// </summary>
    [Fact]
    public void TestToJson_Long() {
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"Long\":\"123456789123456789\"" );
        result.Append( "}" );
        var sample = new JsonTestSample2 { Long = 123456789123456789 };
        var json = Json.ToJson( sample );
        Assert.Equal( result.ToString(), json );

        var obj = Json.ToObject<JsonTestSample2>( json );
        Assert.Equal( 123456789123456789, obj.Long );
    }

    /// <summary>
    /// 测试转成Json - long?类型
    /// </summary>
    [Fact]
    public void TestToJson_NullableLong() {
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"Long\":\"0\"," );
        result.Append( "\"NullableLong\":\"123456789123456789\"" );
        result.Append( "}" );
        var sample = new JsonTestSample2 { NullableLong = 123456789123456789 };
        var json = Json.ToJson( sample );
        Assert.Equal( result.ToString(), json );

        var obj = Json.ToObject<JsonTestSample2>( json );
        Assert.Equal( 123456789123456789, obj.NullableLong );
    }

    /// <summary>
    /// 测试转成Json - 忽略空字符串
    /// </summary>
    [Fact]
    public void TestToJson_IgnoreEmpty() {
        var sample = new JsonTestSample3 { Name = "" };
        var json = Json.ToJson( sample, new JsonOptions { IgnoreEmptyString = true } );
        Assert.Equal( "{}", json );
    }
}