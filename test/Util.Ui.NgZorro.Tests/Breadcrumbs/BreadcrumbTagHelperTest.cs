using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Breadcrumbs;
using Util.Ui.NgZorro.Components.PageHeaders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Breadcrumbs {
    /// <summary>
    /// 面包屑测试
    /// </summary>
    public class BreadcrumbTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public BreadcrumbTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new BreadcrumbTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [Fact]
        public void TestSeparator() {
            _wrapper.SetContextAttribute( UiConst.Separator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb nzSeparator=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [Fact]
        public void TestBindSeparator() {
            _wrapper.SetContextAttribute( AngularConst.BindSeparator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb [nzSeparator]=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动生成
        /// </summary>
        [Fact]
        public void TestAutoGenerate() {
            _wrapper.SetContextAttribute( UiConst.AutoGenerate, true );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb [nzAutoGenerate]=\"true\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动生成
        /// </summary>
        [Fact]
        public void TestBindAutoGenerate() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoGenerate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb [nzAutoGenerate]=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由属性名
        /// </summary>
        [Fact]
        public void TestRouteLabel() {
            _wrapper.SetContextAttribute( AntDesignConst.RouteLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb nzRouteLabel=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由属性名
        /// </summary>
        [Fact]
        public void TestBindRouteLabel() {
            _wrapper.SetContextAttribute( AntDesignConst.BindRouteLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb [nzRouteLabel]=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由属性名转换函数
        /// </summary>
        [Fact]
        public void TestRouteLabelFn() {
            _wrapper.SetContextAttribute( AntDesignConst.RouteLabelFn, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb [nzRouteLabelFn]=\"a\"></nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb>" );
            result.Append( "a" );
            result.Append( "</nz-breadcrumb>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试页头面包屑
        /// </summary>
        [Fact]
        public void TestPageHeader() {
            var pageHeader = new PageHeaderTagHelper().ToWrapper();
            pageHeader.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-page-header>" );
            result.Append( "<nz-breadcrumb nz-page-header-breadcrumb=\"\"></nz-breadcrumb>" );
            result.Append( "</nz-page-header>" );
            Assert.Equal( result.ToString(), pageHeader.GetResult() );
        }
    }
}