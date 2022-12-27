using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Localization;
using Util.Localization.Resources.ResourceTypes;
using Util.Localization.ResourceTypes;
using Xunit;

namespace Util.Localization.Tests {
    /// <summary>
    /// Json字符串定位器测试
    /// </summary>
    public class StringLocalizerTest {
        /// <summary>
        /// Json资源文件字符串定位器1
        /// </summary>
        private readonly IStringLocalizer<Resource1> _resource1Localizer;
        /// <summary>
        /// Json资源文件字符串定位器101
        /// </summary>
        private readonly IStringLocalizer<Resource101> _resource101Localizer;
        /// <summary>
        /// Json资源文件字符串定位器2
        /// </summary>
        private readonly IStringLocalizer<Resource2> _resource2Localizer;
        /// <summary>
        /// Json资源文件字符串定位器102
        /// </summary>
        private readonly IStringLocalizer<Resource102> _resource102Localizer;
        /// <summary>
        /// Json资源文件字符串定位器3
        /// </summary>
        private readonly IStringLocalizer<Resource3> _resource3Localizer;
        /// <summary>
        /// Json资源文件字符串定位器4
        /// </summary>
        private readonly IStringLocalizer<Resource4> _resource4Localizer;
        /// <summary>
        /// Json资源文件字符串定位器41
        /// </summary>
        private readonly IStringLocalizer<Resource4.Resource41> _resource41Localizer;
        /// <summary>
        /// Json资源文件字符串定位器5
        /// </summary>
        private readonly IStringLocalizer<Resource5> _resource5Localizer;
        /// <summary>
        /// Json资源文件字符串定位器 - 非泛型
        /// </summary>
        private readonly IStringLocalizer _localizer;
        /// <summary>
        /// Json资源文件字符串定位器6
        /// </summary>
        private readonly IStringLocalizer<Resource6> _resource6Localizer;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public StringLocalizerTest( IStringLocalizer<Resource1> resource1Localizer, IStringLocalizer<Resource101> resource101Localizer,
            IStringLocalizer<Resource2> resource2Localizer, IStringLocalizer<Resource102> resource102Localizer,
            IStringLocalizer<Resource3> resource3Localizer, IStringLocalizer<Resource4> resource4Localizer,
            IStringLocalizer<Resource4.Resource41> resource41Localizer, IStringLocalizer<Resource5> resource5Localizer,
            IStringLocalizer localizer, IStringLocalizer<Resource6> resource6Localizer ) {
            _resource1Localizer = resource1Localizer;
            _resource101Localizer = resource101Localizer;
            _resource2Localizer = resource2Localizer;
            _resource102Localizer = resource102Localizer;
            _resource3Localizer = resource3Localizer;
            _resource4Localizer = resource4Localizer;
            _resource41Localizer = resource41Localizer;
            _resource5Localizer = resource5Localizer;
            _localizer = localizer;
            _resource6Localizer = resource6Localizer;
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes.Resource1.en-US.json
        /// </summary>
        [Fact]
        public void Test_1() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var value = _resource1Localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes.Resource1.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_2() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource1Localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources2\ResourceTypes.Resource101.en-US.json
        /// </summary>
        [Fact]
        public void Test_3() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var value = _resource101Localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources2\ResourceTypes.Resource101.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_4() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource101Localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource2.en-US.json
        /// </summary>
        [Fact]
        public void Test_5() {
            CultureInfo.CurrentUICulture = new CultureInfo( "en-US" );
            var value = _resource2Localizer["Hello"];
            Assert.Equal( "hi", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource2.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_6() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource2Localizer["Hello"];
            Assert.Equal( "哈楼", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources2\ResourceTypes\Resource102.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_7() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource102Localizer["Hello"];
            Assert.Equal( "哈罗", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource3.zh-Hans.json
        /// </summary>
        [Fact]
        public void Test_8() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource3Localizer["Hello"];
            Assert.Equal( "哈哈", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource4.zh.json
        /// </summary>
        [Fact]
        public void Test_9() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource4Localizer["Hello"];
            Assert.Equal( "嘿嘿", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\ResourceTypes\Resource4.Resource41.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_10() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource41Localizer["Hello"];
            Assert.Equal( "嘻嘻", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 带参数 - 读取 Resources\ResourceTypes\Resource2.zh-CN.json
        /// </summary>
        [Fact]
        public void Test_11() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource2Localizer["Hello,{0},{1},World", "你", "我"];
            Assert.Equal( "哈楼,你,我,世界", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 读取 Resources\zh.json
        /// </summary>
        [Fact]
        public void Test_12() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _localizer["Hello"];
            Assert.Equal( "呜呜", value );
        }

        /// <summary>
        /// 测试获取本地化字符串值 - 资源6未设置, 读取 Resources\zh.json
        /// </summary>
        [Fact]
        public void Test_13() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource6Localizer["Hello"];
            Assert.Equal( "呜呜", value );
        }

        /// <summary>
        /// 测试获取全部本地化字符串 - 不包含父区域
        /// </summary>
        [Fact]
        public void TestGetAllStrings_1() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource5Localizer.GetAllStrings( false ).ToList();
            Assert.Equal( 2, value.Count );
            var resource = value.Find( t => t.Name == "Hello" );
            Assert.Equal( "哈楼", resource?.Value );
            Assert.Equal( "Resources.ResourceTypes.Resource5", resource?.SearchedLocation );
            Assert.False( resource?.ResourceNotFound );
        }

        /// <summary>
        /// 测试获取全部本地化字符串 - 包含父区域
        /// </summary>
        [Fact]
        public void TestGetAllStrings_2() {
            CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
            var value = _resource5Localizer.GetAllStrings( true ).ToList();
            Assert.Equal( 6, value.Count );
            var resource = value.Find( t => t.Name == "Hello3" );
            Assert.Equal( "哈楼3", resource?.Value );
            Assert.Equal( "Resources.ResourceTypes.Resource5", resource?.SearchedLocation );
            Assert.False( resource?.ResourceNotFound );
        }
    }
}
