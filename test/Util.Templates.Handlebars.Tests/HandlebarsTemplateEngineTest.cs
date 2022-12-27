using System.Threading.Tasks;
using Xunit;

namespace Util.Templates.Handlebars.Tests {
    /// <summary>
    /// Razor模板引擎测试 - 渲染模板字符串
    /// </summary>
    public class HandlebarsTemplateEngineTest {
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        private readonly ITemplateEngine _templateEngine;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public HandlebarsTemplateEngineTest( ITemplateEngine templateEngine ) {
            _templateEngine = templateEngine;
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
            var result = _templateEngine.Render( "hello {{Name}}", new { Name = "util" } );
            Assert.Equal( "hello util", result );
        }

        /// <summary>
        /// 测试异步渲染模板 
        /// </summary>
        [Fact]
        public async Task TestRenderAsync() {
            var result = await _templateEngine.RenderAsync( "a" );
            Assert.Equal( "a", result );
        }

        /// <summary>
        /// 测试渲染模板 - 渲染带变量模板,使用匿名对象传递数据
        /// </summary>
        [Fact]
        public async Task TestRenderAsync_2() {
            var result = await _templateEngine.RenderAsync( "hello {{Name}}", new { Name = "util" } );
            Assert.Equal( "hello util", result );
        }
    }
}