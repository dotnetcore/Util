namespace Util.Localization;

/// <summary>
/// 本地化资源查找器
/// </summary>
internal class StringLocalizer : IStringLocalizer {
    /// <summary>
    /// 本地化资源查找器
    /// </summary>
    private readonly IStringLocalizer _localizer;

    /// <summary>
    /// 初始化本地化资源查找器
    /// </summary>
    /// <param name="factory">本地化资源查找器工厂</param>
    public StringLocalizer( IStringLocalizerFactory factory ) {
        var assemblyName = new AssemblyName( GetType().Assembly.FullName! );
        _localizer = factory.Create( string.Empty, assemblyName.FullName );
    }

    /// <inheritdoc />
    public LocalizedString this[string name] => _localizer[name];

    /// <inheritdoc />
    public LocalizedString this[string name, params object[] arguments] => _localizer[name, arguments];

    /// <inheritdoc />
    public IEnumerable<LocalizedString> GetAllStrings( bool includeParentCultures ) => _localizer.GetAllStrings( includeParentCultures );
}