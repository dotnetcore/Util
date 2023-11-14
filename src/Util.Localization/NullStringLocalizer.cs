namespace Util.Localization;

/// <summary>
/// 本地化资源查找器
/// </summary>
public class NullStringLocalizer : IStringLocalizer {
    /// <summary>
    /// 本地化资源查找器空实例
    /// </summary>
    public static readonly IStringLocalizer Instance = new NullStringLocalizer();

    /// <inheritdoc />
    public LocalizedString this[string name] => new( name, name,true );

    /// <inheritdoc />
    public LocalizedString this[ string name, params object[] arguments ] {
        get {
            var value = string.Format( name, arguments );
            return new LocalizedString( value, value, true );
        }
    }

    /// <inheritdoc />
    public IEnumerable<LocalizedString> GetAllStrings( bool includeParentCultures ) => new List<LocalizedString>();
}