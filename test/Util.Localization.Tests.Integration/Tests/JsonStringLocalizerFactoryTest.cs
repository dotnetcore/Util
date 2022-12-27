using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Util.Localization.Resources.ResourceTypes;
using Util.Localization.ResourceTypes;
using Xunit;

namespace Util.Localization.Tests {
    /// <summary>
    /// Json字符串定位器工厂测试
    /// </summary>
    public class JsonStringLocalizerFactoryTest {
        /// <summary>
        /// Json字符串定位器工厂
        /// </summary>
        private readonly IStringLocalizerFactory _factory;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="factory">Json字符串定位器工厂</param>
        public JsonStringLocalizerFactoryTest( IStringLocalizerFactory factory ) {
            _factory = factory;
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes.Resource1.en-US.json
        /// </summary>
        [Fact]
        public void Test_1() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var assemblyName = new AssemblyName( GetType().Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource1", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes.Resource1.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_2() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var assemblyName = new AssemblyName( GetType().Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource1", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources2\ResourceTypes.Resource101.en-US.json
        /// </summary>
        [Fact]
        public void Test_3() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var assemblyName = new AssemblyName( typeof( Resource101 ).Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource101", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources2\ResourceTypes.Resource101.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_4() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var assemblyName = new AssemblyName( typeof( Resource101 ).Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource101", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource2.en-US.json
        /// </summary>
        [Fact]
        public void Test_5() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var assemblyName = new AssemblyName( typeof( Resource2 ).Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource2", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource2.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_6() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var assemblyName = new AssemblyName( typeof( Resource2 ).Assembly.FullName );
            var localizer = _factory.Create( "ResourceTypes.Resource2", assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\zh.json
        /// </summary>
        [Fact]
        public void Test_7() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var assemblyName = new AssemblyName( GetType().Assembly.FullName );
            var localizer = _factory.Create( null, assemblyName.Name );
            var value = localizer["Hello"];
            Assert.Equal( "呜呜", value );
        }
    }
}
