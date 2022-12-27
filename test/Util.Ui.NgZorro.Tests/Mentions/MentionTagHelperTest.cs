using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Mentions;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Mentions {
    /// <summary>
    /// 提及测试
    /// </summary>
    public class MentionTagHelperTest {
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
        public MentionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new MentionTagHelper().ToWrapper();
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
            result.Append( "<nz-mention></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试建议内容
        /// </summary>
        [Fact]
        public void TestSuggestions() {
            _wrapper.SetContextAttribute( UiConst.Suggestions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzSuggestions]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzLoading]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取值函数
        /// </summary>
        [Fact]
        public void TestValueWith() {
            _wrapper.SetContextAttribute( UiConst.ValueWith, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzValueWith]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试触发前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            _wrapper.SetContextAttribute( UiConst.Prefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzPrefix]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试建议框位置
        /// </summary>
        [Fact]
        public void TestPlacement() {
            _wrapper.SetContextAttribute( UiConst.Placement, MentionPlacement.Top );
            var result = new StringBuilder();
            result.Append( "<nz-mention nzPlacement=\"top\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试建议框位置
        /// </summary>
        [Fact]
        public void TestBindPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzPlacement]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空建议默认内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention nzNotFoundContent=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空建议默认内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention [nzNotFoundContent]=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention>a</nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择事件
        /// </summary>
        [Fact]
        public void TestOnSelect() {
            _wrapper.SetContextAttribute( UiConst.OnSelect, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention (nzOnSelect)=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索改变事件
        /// </summary>
        [Fact]
        public void TestOnSearchChange() {
            _wrapper.SetContextAttribute( UiConst.OnSearchChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-mention (nzOnSearchChange)=\"a\"></nz-mention>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}