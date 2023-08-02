using Util.SystemTextJson;

namespace Util.Applications; 

/// <summary>
/// 返回结果
/// </summary>
public class Result : JsonResult {
    /// <summary>
    /// 业务状态码
    /// </summary>
    public string Code { get; }
    /// <summary>
    /// 消息
    /// </summary>
    public string Message { get; }
    /// <summary>
    /// 数据
    /// </summary>
    public dynamic Data { get; }

    /// <summary>
    /// 初始化返回结果
    /// </summary>
    /// <param name="code">业务状态码</param>
    /// <param name="message">消息</param>
    /// <param name="data">数据</param>
    /// <param name="httpStatusCode">Http状态码</param>
    /// <param name="options">Json序列化配置</param>
    public Result( string code, string message, dynamic data = null, int? httpStatusCode = null, JsonSerializerOptions options = null ) : base( null ) {
        Code = code;
        Message = message;
        Data = data;
        SerializerSettings = GetOptions( options );
        StatusCode = httpStatusCode;
    }

    /// <summary>
    /// 获取Json序列化配置
    /// </summary>
    private JsonSerializerOptions GetOptions( JsonSerializerOptions options ) {
        if ( options != null )
            return options;
        return new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter()
            }
        };
    }

    /// <summary>
    /// 执行结果
    /// </summary>
    public override Task ExecuteResultAsync( ActionContext context ) {
        Value = new {
            Code,
            Message,
            Data
        };
        return base.ExecuteResultAsync( context );
    }
}