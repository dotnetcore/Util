using System.Threading.Tasks;
using Util.Helpers;
using Util.Templates.Razor.Tests.Samples.Models;
using Xunit;

namespace Util.Templates.Razor.Tests {
    /// <summary>
    /// Razor模板引擎测试 - 渲染模板文件
    /// </summary>
    public partial class RazorTemplateEngineTest {
        /// <summary>
        /// 测试通过路径渲染模板
        /// </summary>
        [Fact]
        public void TestRenderByPath() {
            var model = new TestModel { Name = "util" };
            var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
            var result = _templateEngine.RenderByPath( path, model );
            Assert.Equal( "hello,util", result );
        }

        /// <summary>
        /// 测试通过路径渲染模板
        /// </summary>
        [Fact]
        public void TestRenderByPath_2() {
            var model = new TestModel { Name = "a", Model2 = new TestModel2 { Name = "b", Model3 = new TestModel3 { Name = "c" } } };
            var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate2.cshtml" );
            var result = _templateEngine.RenderByPath( path, model );
            Assert.Equal( "a,b,c", result );
        }

        /// <summary>
        /// 测试通过路径渲染模板
        /// </summary>
        [Fact]
        public async Task TestRenderByPathAsync() {
            var model = new TestModel { Name = "util" };
            var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
            var result = await _templateEngine.RenderByPathAsync( path, model );
            Assert.Equal( "hello,util", result );
        }

        /// <summary>
        /// 测试通过路径渲染模板
        /// </summary>
        [Fact]
        public async Task TestRenderByPathAsync_2() {
            var model = new TestModel { Name = "a", Model2 = new TestModel2 { Name = "b", Model3 = new TestModel3 { Name = "c" } } };
            var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate2.cshtml" );
            var result = await _templateEngine.RenderByPathAsync( path, model );
            Assert.Equal( "a,b,c", result );
        }

        /// <summary>
        /// 测试通过路径渲染模板并保存到文件
        /// </summary>
        [Fact]
        public void TestSaveByPath() {
            var filePath = Common.GetPhysicalPath( "result/SaveByPath.txt" );
            Util.Helpers.File.Delete( filePath );
            var model = new TestModel { Name = "util" };
            var templatePath = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
            _templateEngine.SaveByPath( templatePath, model, filePath );
            var result = Util.Helpers.File.ReadToString( filePath );
            Assert.Equal( "hello,util", result );
        }

        /// <summary>
        /// 测试通过路径渲染模板并保存到文件
        /// </summary>
        [Fact]
        public async Task TestSaveByPathAsync() {
            var filePath = Common.GetPhysicalPath( "result/SaveByPathAsync.txt" );
            Util.Helpers.File.Delete( filePath );
            var model = new TestModel { Name = "util" };
            var templatePath = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
            await _templateEngine.SaveByPathAsync( templatePath, model, filePath );
            var result = await Util.Helpers.File.ReadToStringAsync( filePath );
            Assert.Equal( "hello,util", result );
        }
    }
}
