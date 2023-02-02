using System.Globalization;
using System.IO;
using Util.Helpers;
using Util.Localization.Json;
using Util.Localization.Resources.ResourceTypes;
using Xunit;
using Xunit.Abstractions;

namespace Util.Localization.Tests {
    /// <summary>
    /// 路径解析器测试
    /// </summary>
    public class PathResolverTest {
        /// <summary>
        /// 路径解析器
        /// </summary>
        private readonly PathResolver _resolver;
        /// <summary>
        /// 输出消息
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 初始化路径解析器
        /// </summary>
        public PathResolverTest( ITestOutputHelper output ) {
            _output = output;
            _resolver = new PathResolver();
        }

        /// <summary>
        /// 测试获取根命名空间 - 未设置RootNamespace特性,返回程序集名称
        /// </summary>
        [Fact]
        public void TestGetRootNamespace_AssemblyName() {
            var type = typeof(Resource101);
            Assert.Equal( "Util.Localization.Resources",  _resolver.GetRootNamespace( type.Assembly ));
        }

        /// <summary>
        /// 测试获取根命名空间 - 设置RootNamespace特性,返回特性值
        /// </summary>
        [Fact]
        public void TestGetRootNamespace_RootNamespace() {
            var type = typeof( PathResolverTest );
            Assert.Equal( "Util.Localization", _resolver.GetRootNamespace( type.Assembly ) );
        }

        /// <summary>
        /// 测试获取资源根目录路径 - 未设置ResourceLocation特性,返回传入的资源根路径
        /// </summary>
        [Fact]
        public void TestGetResourcesRootPath_ResourcesPath() {
            var type = typeof( PathResolverTest );
            Assert.Equal( "Resources", _resolver.GetResourcesRootPath( type.Assembly, "Resources" ) );
        }

        /// <summary>
        /// 测试获取资源根目录路径 - 设置ResourceLocation特性,返回特性值
        /// </summary>
        [Fact]
        public void TestGetResourcesRootPath_ResourceLocation() {
            var type = typeof( Resource101 );
            Assert.Equal( "Resources2", _resolver.GetResourcesRootPath( type.Assembly, "Resources" ) );
        }

        /// <summary>
        /// 测试获取资源基名称 - 未设置RootNamespace特性
        /// </summary>
        [Fact]
        public void TestGetResourcesBaseName_1() {
            var type = typeof( Resource101 );
            Assert.Equal( "ResourceTypes.Resource101", _resolver.GetResourcesBaseName( type.Assembly, type.FullName ) );
        }

        /// <summary>
        /// 测试获取资源基名称 - 设置RootNamespace特性
        /// </summary>
        [Fact]
        public void TestGetResourcesBaseName_2() {
            var type = typeof( PathResolverTest );
            Assert.Equal( "Tests.PathResolverTest", _resolver.GetResourcesBaseName( type.Assembly, type.FullName ) );
        }

        /// <summary>
        /// 测试获取Json资源文件绝对路径
        /// </summary>
        [Fact]
        public void TestGetJsonResourcePath() {
            var result = Path.Combine( Common.ApplicationBaseDirectory, "Resources", "Tests.PathResolverTest.zh-CN.json" );
            var path = _resolver.GetJsonResourcePath( "Resources", "Tests.PathResolverTest", new CultureInfo( "zh-CN" ) );
            _output.WriteLine( path );
            Assert.Equal( result,path );
        }

        /// <summary>
        /// 测试获取Json资源文件绝对路径 - 内部类带+
        /// </summary>
        [Fact]
        public void TestGetJsonResourcePath_InnerClass() {
            var result = Path.Combine( Common.ApplicationBaseDirectory, "Resources", "ResourceTypes.Resource4.Resource41.zh-CN.json" );
            var path = _resolver.GetJsonResourcePath( "Resources", "ResourceTypes.Resource4+Resource41", new CultureInfo( "zh-CN" ) );
            _output.WriteLine( path );
            Assert.Equal( result, path );
        }

        /// <summary>
        /// 测试获取Json资源文件绝对路径 - 基名称为空
        /// </summary>
        [Fact]
        public void TestGetJsonResourcePath_NullBaseName() {
            var result = Path.Combine( Common.ApplicationBaseDirectory, "Resources", "zh-CN.json" );
            var path = _resolver.GetJsonResourcePath( "Resources", null, new CultureInfo( "zh-CN" ) );
            _output.WriteLine( path );
            Assert.Equal( result, path );
        }
    }
}
