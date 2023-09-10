using Util.Configs;
using Util.Helpers;
using Util.SystemTextJson;

namespace Util.Microservices.Dapr;

/// <summary>
/// Dapr微服务操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Dapr微服务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddDapr( this IAppBuilder builder ) {
        return builder.AddDapr( null );
    }

    /// <summary>
    /// 配置Dapr微服务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Dapr配置操作</param>
    public static IAppBuilder AddDapr( this IAppBuilder builder, Action<DaprOptions> setupAction ) {
        return builder.AddDapr( setupAction, null );
    }

    /// <summary>
    /// 配置Dapr微服务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Dapr配置操作</param>
    /// <param name="buildAction">Dapr客户端生成操作</param>
    public static IAppBuilder AddDapr( this IAppBuilder builder, Action<DaprOptions> setupAction, Action<DaprClientBuilder> buildAction ) {
        builder.CheckNull( nameof( builder ) );
        var options = new DaprOptions();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.AddDaprClient( clientBuilder => {
                clientBuilder.UseJsonSerializationOptions( GetJsonSerializerOptions() );
                buildAction?.Invoke( clientBuilder );
            } );
            if( setupAction != null )
                services.Configure( setupAction );
        } );
        builder.Host.ConfigureAppConfiguration( ( context, configurationBuilder ) => {
            AddDaprSecretStore( configurationBuilder, options, buildAction );
        } );
        return builder;
    }

    /// <summary>
    /// 获取Json序列化配置
    /// </summary>
    private static JsonSerializerOptions GetJsonSerializerOptions() {
        return new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
                new EnumJsonConverterFactory()
            }
        };
    }

    /// <summary>
    /// 配置Dapr机密存储器
    /// </summary>
    private static void AddDaprSecretStore( IConfigurationBuilder configurationBuilder , DaprOptions options, Action<DaprClientBuilder> buildAction ) {
        if ( options.SecretStoreName.IsEmpty() )
            return;
        try {
            configurationBuilder.AddDaprSecretStore( options.SecretStoreName, CreateDaprClient( buildAction ) );
        }
        catch ( Exception ) {
            if ( Common.IsLinux )
                throw;
        }
    }

    /// <summary>
    /// 创建Dapr客户端
    /// </summary>
    private static DaprClient CreateDaprClient( Action<DaprClientBuilder> buildAction ) {
        var clientBuilder = new DaprClientBuilder();
        clientBuilder.UseJsonSerializationOptions( GetJsonSerializerOptions() );
        buildAction?.Invoke( clientBuilder );
        return clientBuilder.Build();
    }
}