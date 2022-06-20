using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace Util.Localization.Json {
    /// <summary>
    /// Json字符串定位器
    /// </summary>
    internal class StringLocalizer : IStringLocalizer {
        /// <summary>
        /// Json字符串定位器
        /// </summary>
        private readonly IStringLocalizer _localizer;

        /// <summary>
        /// 初始化Json字符串定位器
        /// </summary>
        /// <param name="factory">Json字符串定位器工厂</param>
        public StringLocalizer( IStringLocalizerFactory factory ) {
            var assemblyName = new AssemblyName( GetType().Assembly.FullName );
            _localizer = factory.Create( null, assemblyName.FullName );
        }

        /// <summary>
        /// 获取本地化字符串
        /// </summary>
        /// <param name="name">本地化字符串名称</param>
        public LocalizedString this[string name] => _localizer[name];

        /// <summary>
        /// 获取本地化字符串
        /// </summary>
        /// <param name="name">本地化字符串名称</param>
        /// <param name="arguments">参数列表</param>
        public LocalizedString this[string name, params object[] arguments] => _localizer[name, arguments];

        /// <summary>
        /// 获取全部本地化字符串
        /// </summary>
        /// <param name="includeParentCultures">是否包含父区域</param>
        public IEnumerable<LocalizedString> GetAllStrings( bool includeParentCultures ) => _localizer.GetAllStrings( includeParentCultures );
    }
}
