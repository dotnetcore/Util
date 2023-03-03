using System.Text;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.TagHelpers;
using Util.Ui.Tests.Samples;
using Util.Ui.Tests.Samples.Containers;
using Util.Ui.Tests.Samples.Templates;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.TagHelpers {
    /// <summary>
    /// TagHelper包装器测试
    /// </summary>
    public class TagHelperWrapperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TagHelperWrapperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TestTagHelper().ToWrapper<Customer>();
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
            result.Append( "<test></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置上下文属性
        /// </summary>
        [Fact]
        public void TestSetContextAttribute() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<test #a=\"\"></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置输出属性
        /// </summary>
        [Fact]
        public void TestSetOutputAttribute() {
            _wrapper.SetOutputAttribute( "a", "1" ).SetOutputAttribute( "b", "2" );
            var result = new StringBuilder();
            result.Append( "<test a=\"1\" b=\"2\"></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置共享项
        /// </summary>
        [Fact]
        public void TestSetItem() {
            var shareConfig = new TestShareConfig( "abc" );
            _wrapper.SetItem( shareConfig );
            var result = new StringBuilder();
            result.Append( "<test #test_abc=\"\"></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加字符串内容
        /// </summary>
        [Fact]
        public void TestAppendContent_1() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<test>a</test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加两次字符串内容
        /// </summary>
        [Fact]
        public void TestAppendContent_2() {
            _wrapper.AppendContent( "a" ).AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<test>ab</test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加TagBuilder内容
        /// </summary>
        [Fact]
        public void TestAppendContent_3() {
            _wrapper.AppendContent( new H1Builder() );
            var result = new StringBuilder();
            result.Append( "<test><h1></h1></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加两次TagBuilder内容
        /// </summary>
        [Fact]
        public void TestAppendContent_4() {
            _wrapper.AppendContent( new H1Builder() ).AppendContent( new H2Builder() );
            var result = new StringBuilder();
            result.Append( "<test><h1></h1><h2></h2></test>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加TagHelper内容
        /// </summary>
        [Fact]
        public void TestAppendContent_5() {
            _wrapper.AppendContent( new ContainerTagHelper() );
            var result = new StringBuilder();
            result.Append( "<test><ng-container></ng-container></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 测试添加两次TagHelper内容
        /// </summary>
        [Fact]
        public void TestAppendContent_6() {
            _wrapper.AppendContent( new ContainerTagHelper() ).AppendContent( new TemplateTagHelper() );
            var result = new StringBuilder();
            result.Append( "<test><ng-container></ng-container><ng-template></ng-template></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 测试添加混合内容
        /// </summary>
        [Fact]
        public void TestAppendContent_7() {
            _wrapper.AppendContent( "a" ).AppendContent( new H1Builder() ).AppendContent( new ContainerTagHelper() );
            var result = new StringBuilder();
            result.Append( "<test>a<h1></h1><ng-container></ng-container></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 测试添加嵌套内容
        /// </summary>
        [Fact]
        public void TestAppendContent_8() {
            var container = new ContainerTagHelper().ToWrapper();
            container.AppendContent( "a" ).AppendContent( new TemplateTagHelper() );
            _wrapper.AppendContent( container );
            var result = new StringBuilder();
            result.Append( "<test><ng-container>a<ng-template></ng-template></ng-container></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 测试嵌套组件同时设置相同属性
        /// </summary>
        [Fact]
        public void TestAppendContent_9() {
            var container = new ContainerTagHelper().ToWrapper();
            container.SetContextAttribute( UiConst.Id, "b" );
            
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            _wrapper.AppendContent( container );
            
            var result = new StringBuilder();
            result.Append( "<test #a=\"\"><ng-container #b=\"\"></ng-container></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 测试父组件设置共享配置,子组件使用共享配置
        /// </summary>
        [Fact]
        public void TestAppendContent_10() {
            var container = new ContainerTagHelper().ToWrapper();
            container.SetItem( new TestShareConfig( "a" ) );
            container.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<ng-container><test #test_a=\"\"></test></ng-container>" );
            Assert.Equal( result.ToString(), container.GetResult() );
        }

        /// <summary>
        /// 测试嵌套组件同时设置相同输出属性
        /// </summary>
        [Fact]
        public void TestAppendContent_11() {
            var container = new ContainerTagHelper().ToWrapper();
            container.SetOutputAttribute( "a", 1 );
            _wrapper.AppendContent( container );
            _wrapper.SetOutputAttribute( "b", 2 );
            var result = new StringBuilder();
            result.Append( "<test b=\"2\"><ng-container a=\"1\"></ng-container></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }

        /// <summary>
        /// 设置表达式
        /// </summary>
        [Fact]
        public void TestSetExpression() {
            _wrapper.SetExpression( UiConst.For,t => t.Code );
            var result = new StringBuilder();
            result.Append( "<test name=\"code\" title=\"编码\"></test>" );
            Assert.Equal( result.ToString(), _wrapper.GetResult() );
        }
    }
}