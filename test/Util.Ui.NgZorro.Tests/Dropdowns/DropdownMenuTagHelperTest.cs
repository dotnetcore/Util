using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dropdowns;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Dropdowns {
    /// <summary>
    /// 下拉菜单测试
    /// </summary>
    public class DropdownMenuTagHelperTest {
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
        public DropdownMenuTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DropdownMenuTagHelper().ToWrapper();
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
            result.Append( "<nz-dropdown-menu><ul nz-menu=\"\"></ul></nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu #a=\"nzDropdownMenu\"><ul nz-menu=\"\"></ul></nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许选中
        /// </summary>
        [Fact]
        public void TestSelectable() {
            _wrapper.SetContextAttribute( UiConst.Selectable, false );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu>" );
            result.Append( "<ul nz-menu=\"\" [nzSelectable]=\"false\"></ul>" );
            result.Append( "</nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许选中
        /// </summary>
        [Fact]
        public void TestBindSelectable() {
            _wrapper.SetContextAttribute( AngularConst.BindSelectable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu>" );
            result.Append( "<ul nz-menu=\"\" [nzSelectable]=\"a\"></ul>" );
            result.Append( "</nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu>" );
            result.Append( "<ul nz-menu=\"\">" );
            result.Append( "a" );
            result.Append( "</ul>" );
            result.Append( "</nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不创建ul标签
        /// </summary>
        [Fact]
        public void TestNotCreateUl() {
            _wrapper.SetContextAttribute( UiConst.NotCreateUl, true );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu></nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容 - 不创建ul标签
        /// </summary>
        [Fact]
        public void TestNotCreateUl_Content() {
            _wrapper.SetContextAttribute( UiConst.NotCreateUl, true );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu>" );
            result.Append( "a" );
            result.Append( "</nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-dropdown-menu>" );
            result.Append( "<ul (nzClick)=\"a\" nz-menu=\"\"></ul>" );
            result.Append( "</nz-dropdown-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}