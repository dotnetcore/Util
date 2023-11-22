using Util.Http;

namespace Util.Helpers; 

/// <summary>
/// Http操作
/// </summary>
public static class Http {
    /// <summary>
    /// Http客户端
    /// </summary>
    public static IHttpClient Client => Ioc.Create<IHttpClient>();
}