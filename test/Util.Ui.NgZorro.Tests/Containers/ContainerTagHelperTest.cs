using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Containers;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Containers {
    /// <summary>
    /// ng-container容器测试
    /// </summary>
    public class ContainerTagHelperTest {
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
        public ContainerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ContainerTagHelper().ToWrapper();
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
            result.Append( "<ng-container></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container #a=\"\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试原始标识
        /// </summary>
        [Fact]
        public void TestRawId() {
            _wrapper.SetContextAttribute( AngularConst.RawId, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container id=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试样式
        /// </summary>
        [Fact]
        public void TestStyle() {
            _wrapper.SetContextAttribute( UiConst.Style, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container style=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试样式类
        /// </summary>
        [Fact]
        public void TestClass() {
            _wrapper.SetContextAttribute( UiConst.Class, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container class=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏
        /// </summary>
        [Fact]
        public void TestHidden() {
            _wrapper.SetContextAttribute( UiConst.Hidden, "true" );
            var result = new StringBuilder();
            result.Append( "<ng-container [hidden]=\"true\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加其它未配置的属性
        /// </summary>
        [Fact]
        public void TestOutputAttributes() {
            _wrapper.SetOutputAttribute( "a", "1" ).SetOutputAttribute( "b", "2" );
            var result = new StringBuilder();
            result.Append( "<ng-container a=\"1\" b=\"2\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试*ngFor
        /// </summary>
        [Fact]
        public void TestNgFor() {
            _wrapper.SetContextAttribute( AngularConst.NgFor, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container *ngFor=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试*ngIf
        /// </summary>
        [Fact]
        public void TestNgIf() {
            _wrapper.SetContextAttribute( AngularConst.NgIf, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container *ngIf=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngSwitch
        /// </summary>
        [Fact]
        public void TestNgSwitch() {
            _wrapper.SetContextAttribute( AngularConst.NgSwitch, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container [ngSwitch]=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngSwitchCase
        /// </summary>
        [Fact]
        public void TestNgSwitchCase() {
            _wrapper.SetContextAttribute( AngularConst.NgSwitchCase, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container *ngSwitchCase=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试*ngSwitchDefault
        /// </summary>
        [Fact]
        public void TestNgSwitchDefault() {
            _wrapper.SetContextAttribute( AngularConst.NgSwitchDefault, true );
            var result = new StringBuilder();
            result.Append( "<ng-container *ngSwitchDefault=\"\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngClass
        /// </summary>
        [Fact]
        public void TestNgClass() {
            _wrapper.SetContextAttribute( AngularConst.NgClass, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container [ngClass]=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngStyle
        /// </summary>
        [Fact]
        public void TestNgStyle() {
            _wrapper.SetContextAttribute( AngularConst.NgStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container [ngStyle]=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提及建议
        /// </summary>
        [Fact]
        public void TestMentionSuggestion() {
            _wrapper.SetContextAttribute( UiConst.MentionSuggestion, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container *nzMentionSuggestion=\"a\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}