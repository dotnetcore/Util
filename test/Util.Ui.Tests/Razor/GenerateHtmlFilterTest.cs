using Util.Ui.Razor;
using Xunit;

namespace Util.Ui.Tests.Razor {
    /// <summary>
    /// 生成Html静态页面过滤器测试
    /// </summary>
    public class GenerateHtmlFilterTest {
        /// <summary>
        /// 生成到根路径
        /// </summary>
        [Fact]
        public void TestGetPath_1() {
            var result = GenerateHtmlFilter.GetPath( "a" );
            Assert.Equal( "/ClientApp/src/app/a.component.html",result );
        }

        /// <summary>
        /// 生成到根路径 - 路径前面有 /
        /// </summary>
        [Fact]
        public void TestGetPath_2() {
            var result = GenerateHtmlFilter.GetPath( "/a" );
            Assert.Equal( "/ClientApp/src/app/a.component.html", result );
        }

        /// <summary>
        /// 生成到根路径 - 路径后面有 /
        /// </summary>
        [Fact]
        public void TestGetPath_3() {
            var result = GenerateHtmlFilter.GetPath( "a/" );
            Assert.Equal( "/ClientApp/src/app/a.component.html", result );
        }

        /// <summary>
        /// 生成到根路径 - 路径前后有 \
        /// </summary>
        [Fact]
        public void TestGetPath_4() {
            var result = GenerateHtmlFilter.GetPath( "\\a\\" );
            Assert.Equal( "/ClientApp/src/app/a.component.html", result );
        }

        /// <summary>
        /// 设置基路径
        /// </summary>
        [Fact]
        public void TestGetPath_5() {
            var result = GenerateHtmlFilter.GetPath( "b","a" );
            Assert.Equal( "a/b.component.html", result );
        }

        /// <summary>
        /// 设置基路径 - 基路径后面有 /
        /// </summary>
        [Fact]
        public void TestGetPath_6() {
            var result = GenerateHtmlFilter.GetPath( "b", "a/" );
            Assert.Equal( "a/b.component.html", result );
        }

        /// <summary>
        /// 生成到多级路径
        /// </summary>
        [Fact]
        public void TestGetPath_7() {
            var result = GenerateHtmlFilter.GetPath( "a/b" );
            Assert.Equal( "/ClientApp/src/app/a/html/b.component.html", result );
        }

        /// <summary>
        /// 生成到多级路径 - 路径前后有 /
        /// </summary>
        [Fact]
        public void TestGetPath_8() {
            var result = GenerateHtmlFilter.GetPath( "/a/b/" );
            Assert.Equal( "/ClientApp/src/app/a/html/b.component.html", result );
        }

        /// <summary>
        /// 生成到多级路径
        /// </summary>
        [Fact]
        public void TestGetPath_9() {
            var result = GenerateHtmlFilter.GetPath( "/a/b/c" );
            Assert.Equal( "/ClientApp/src/app/a/b/html/c.component.html", result );
        }

        /// <summary>
        /// 路径中包含词组
        /// </summary>
        [Fact]
        public void TestGetPath_10() {
            var result = GenerateHtmlFilter.GetPath( "FetchData/Test/NavMenu" );
            Assert.Equal( "/ClientApp/src/app/fetch-data/test/html/nav-menu.component.html", result );
        }

        /// <summary>
        /// 设置html文件后缀
        /// </summary>
        [Fact]
        public void TestGetPath_11() {
            var result = GenerateHtmlFilter.GetPath( "FetchData/Test/NavMenu","/a","html" );
            Assert.Equal( "/a/fetch-data/test/html/nav-menu.html", result );
        }
    }
}
