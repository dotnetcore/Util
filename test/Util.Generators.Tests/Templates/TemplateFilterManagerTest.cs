using System;
using Moq;
using Util.Generators.Contexts;
using Util.Generators.Templates;
using Xunit;

namespace Util.Generators.Tests.Templates {
    /// <summary>
    /// 模板过滤器管理器测试
    /// </summary>
    public class TemplateFilterManagerTest : IDisposable{
        /// <summary>
        /// 模板过滤器管理器
        /// </summary>
        private readonly TemplateFilterManager _filterManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TemplateFilterManagerTest() {
            _filterManager = new TemplateFilterManager();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            TemplateFilterManager.Clear();
        }

        /// <summary>
        /// 测试是否过滤模板 - 1个过滤器返回true,结果为true
        /// </summary>
        [Fact]
        public void TestIsFilter_1() {
            //创建一个模板过滤器
            var mockFilter = new Mock<ITemplateFilter>();
            mockFilter.Setup( t => t.IsFilter( It.IsAny<string>(), It.IsAny<ProjectContext>() ) ).Returns( true );

            //添加到管理器
            TemplateFilterManager.AddFilter( mockFilter.Object );

            //验证
            Assert.True( _filterManager.IsFilter( null,null ) );
        }

        /// <summary>
        /// 测试是否过滤模板 - 2个过滤器,其中一个返回true,结果为true
        /// </summary>
        [Fact]
        public void TestIsFilter_2() {
            //创建2个模板过滤器
            var mockFilter = new Mock<ITemplateFilter>();
            mockFilter.Setup( t => t.IsFilter( It.IsAny<string>(), It.IsAny<ProjectContext>() ) ).Returns( false );
            var mockFilter2 = new Mock<ITemplateFilter>();
            mockFilter2.Setup( t => t.IsFilter( It.IsAny<string>(), It.IsAny<ProjectContext>() ) ).Returns( true );

            //添加到管理器
            TemplateFilterManager.AddFilter( mockFilter.Object );
            TemplateFilterManager.AddFilter( mockFilter2.Object );

            //验证
            Assert.True( _filterManager.IsFilter( null, null ) );
        }

        /// <summary>
        /// 测试是否过滤模板 - 2个过滤器,都返回false,结果为false
        /// </summary>
        [Fact]
        public void TestIsFilter_3() {
            //创建2个模板过滤器
            var mockFilter = new Mock<ITemplateFilter>();
            mockFilter.Setup( t => t.IsFilter( It.IsAny<string>(), It.IsAny<ProjectContext>() ) ).Returns( false );
            var mockFilter2 = new Mock<ITemplateFilter>();
            mockFilter2.Setup( t => t.IsFilter( It.IsAny<string>(), It.IsAny<ProjectContext>() ) ).Returns( false );

            //添加到管理器
            TemplateFilterManager.AddFilter( mockFilter.Object );
            TemplateFilterManager.AddFilter( mockFilter2.Object );

            //验证
            Assert.False( _filterManager.IsFilter( null, null ) );
        }
    }
}
