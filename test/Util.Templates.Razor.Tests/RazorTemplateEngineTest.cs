using System.Text;
using System.Threading.Tasks;
using Util.Helpers;
using Util.Templates.Razor.Tests.Samples.Models;
using Xunit;

namespace Util.Templates.Razor.Tests {
    /// <summary>
    /// Razor模板引擎测试 - 渲染模板字符串
    /// </summary>
    public partial class RazorTemplateEngineTest {
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        private readonly ITemplateEngine _templateEngine;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RazorTemplateEngineTest( ITemplateEngine templateEngine ) {
            _templateEngine = templateEngine;
            _templateEngine.ClearTemplateCache();
        }

        /// <summary>
        /// 测试渲染模板 - 渲染没有数据的模板
        /// </summary>
        [Fact]
        public void TestRender_1() {
            var result = _templateEngine.Render( "a" );
            Assert.Equal( "a", result );
        }

        /// <summary>
        /// 测试渲染模板 - 渲染带变量模板,使用匿名对象传递数据
        /// </summary>
        [Fact]
        public void TestRender_2() {
            var result = _templateEngine.Render( "hello @Model.Name", new { Name = "util" } );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试渲染模板 - 渲染带变量模板,传递TestModel对象
        /// </summary>
        [Fact]
        public void TestRender_3() {
            var model = new TestModel { Name = "util" };
            var result = _templateEngine.Render( "hello @Model.Name", model );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试渲染模板 - 添加程序集引用
        /// </summary>
        [Fact]
        public void TestRender_4() {
            RazorTemplateEngine.DisableAutoLoadAssemblies();
            var template = new StringBuilder();
            template.Append( "@using Util.Templates.Razor.Tests.Samples.Models\n" );
            template.Append( "@inherits RazorEngineCore.RazorEngineTemplateBase<TestModel>\n" );
            template.Append( "hello,@Model.Name" );
            var model = new TestModel { Name = "util" };
            var result = _templateEngine.Render( template.ToString(), model, builder => builder.AddAssemblyReference( GetType() ) );
            Assert.Equal( "hello,util", result );
        }

        /// <summary>
        /// 测试渲染模板 
        /// </summary>
        [Fact]
        public async Task TestRenderAsync_1() {
            var result = await _templateEngine.RenderAsync( "a" );
            Assert.Equal( "a", result );
        }

        /// <summary>
        /// 测试渲染模板 - 渲染带变量模板,使用匿名对象传递数据
        /// </summary>
        [Fact]
        public async Task TestRenderAsync_2() {
            var result = await _templateEngine.RenderAsync( "hello @Model.Name", new { Name = "util" } );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试渲染模板 - 渲染带变量模板,传递TestModel对象
        /// </summary>
        [Fact]
        public async Task TestRenderAsync_3() {
            var model = new TestModel { Name = "util" };
            var result = await _templateEngine.RenderAsync( "hello @Model.Name", model );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试渲染模板 - 添加程序集引用
        /// </summary>
        [Fact]
        public async Task TestRenderAsync_4() {
            RazorTemplateEngine.DisableAutoLoadAssemblies();
            var template = new StringBuilder();
            template.Append( "@using Util.Templates.Razor.Tests.Samples.Models\n" );
            template.Append( "@inherits RazorEngineCore.RazorEngineTemplateBase<TestModel>\n" );
            template.Append( "hello,@Model.Name" );
            var model = new TestModel { Name = "util" };
            var result = await _templateEngine.RenderAsync( template.ToString(), model, builder => builder.AddAssemblyReference( GetType() ) );
            Assert.Equal( "hello,util", result );
        }

        /// <summary>
        /// 测试渲染模板并保存到文件
        /// </summary>
        [Fact]
        public void TestSave() {
            var filePath = Common.GetPhysicalPath( "result/save.txt" );
            Util.Helpers.File.Delete( filePath );
            var model = new TestModel { Name = "util" };
            _templateEngine.Save( "hello @Model.Name", model, filePath );
            var result = Util.Helpers.File.ReadToString( filePath );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试渲染模板并保存到文件
        /// </summary>
        [Fact]
        public async Task TestSaveAsync() {
            var filePath = Common.GetPhysicalPath( "result/saveasync.txt" );
            Util.Helpers.File.Delete( filePath );
            var model = new TestModel { Name = "util" };
            await _templateEngine.SaveAsync( "hello @Model.Name", model, filePath );
            var result = await Util.Helpers.File.ReadToStringAsync( filePath );
            Assert.Equal( "hello util", result );
        }
    }
}
