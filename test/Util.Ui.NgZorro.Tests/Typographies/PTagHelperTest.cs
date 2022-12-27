using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Typographies;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Typographies {
    /// <summary>
    /// 段落组件测试
    /// </summary>
    public class PTagHelperTest {
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
        public PTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new PTagHelper().ToWrapper();
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
            result.Append( "<p nz-typography=\"\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容属性
        /// </summary>
        [Fact]
        public void TestNzContent() {
            _wrapper.SetContextAttribute( UiConst.Content, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzContent=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容属性
        /// </summary>
        [Fact]
        public void TestBindContent() {
            _wrapper.SetContextAttribute( AngularConst.BindContent, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzContent]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容属性
        /// </summary>
        [Fact]
        public void TestBindonContent() {
            _wrapper.SetContextAttribute( AngularConst.BindonContent, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [(nzContent)]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可编辑
        /// </summary>
        [Fact]
        public void TestEditable() {
            _wrapper.SetContextAttribute( UiConst.Editable, true );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEditable]=\"true\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可编辑
        /// </summary>
        [Fact]
        public void TestBindEditable() {
            _wrapper.SetContextAttribute( AngularConst.BindEditable, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEditable]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试编辑图标
        /// </summary>
        [Fact]
        public void TestEditIcon() {
            _wrapper.SetContextAttribute( UiConst.EditIcon, AntDesignIcon.Highlight );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzEditIcon=\"highlight\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试编辑图标
        /// </summary>
        [Fact]
        public void TestBindEditIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindEditIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEditIcon]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试编辑按钮工具提示
        /// </summary>
        [Fact]
        public void TestEditTooltip() {
            _wrapper.SetContextAttribute( UiConst.EditTooltip, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzEditTooltip=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试编辑按钮工具提示
        /// </summary>
        [Fact]
        public void TestBindEditTooltip() {
            _wrapper.SetContextAttribute( AngularConst.BindEditTooltip, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEditTooltip]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可复制
        /// </summary>
        [Fact]
        public void TestCopyable() {
            _wrapper.SetContextAttribute( UiConst.Copyable, true );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyable]=\"true\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可复制
        /// </summary>
        [Fact]
        public void TestBindCopyable() {
            _wrapper.SetContextAttribute( AngularConst.BindCopyable, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyable]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制文本
        /// </summary>
        [Fact]
        public void TestCopyText() {
            _wrapper.SetContextAttribute( UiConst.CopyText, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzCopyText=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制文本
        /// </summary>
        [Fact]
        public void TestBindCopyText() {
            _wrapper.SetContextAttribute( AngularConst.BindCopyText, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyText]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制图标
        /// </summary>
        [Fact]
        public void TestCopyIcons() {
            _wrapper.SetContextAttribute( UiConst.CopyIcons, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyIcons]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制图标
        /// </summary>
        [Fact]
        public void TestCopyIcon() {
            _wrapper.SetContextAttribute( UiConst.CopyIcon, AntDesignIcon.Smile );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyIcons]=\"['smile','check']\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制提示
        /// </summary>
        [Fact]
        public void TestCopyTooltips() {
            _wrapper.SetContextAttribute( UiConst.CopyTooltips, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzCopyTooltips]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, TextType.Success );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzType=\"success\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzType]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用文本
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzDisabled]=\"true\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用文本
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzDisabled]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略文本
        /// </summary>
        [Fact]
        public void TestEllipsis() {
            _wrapper.SetContextAttribute( UiConst.Ellipsis, true );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEllipsis]=\"true\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略文本
        /// </summary>
        [Fact]
        public void TestBindEllipsis() {
            _wrapper.SetContextAttribute( AngularConst.BindEllipsis, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEllipsis]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略可展开
        /// </summary>
        [Fact]
        public void TestExpandable() {
            _wrapper.SetContextAttribute( UiConst.Expandable, true );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzExpandable]=\"true\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略可展开
        /// </summary>
        [Fact]
        public void TestBindExpandable() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandable, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzExpandable]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略行数
        /// </summary>
        [Fact]
        public void TestEllipsisRows() {
            _wrapper.SetContextAttribute( UiConst.EllipsisRows, 2 );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEllipsisRows]=\"2\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略行数
        /// </summary>
        [Fact]
        public void TestBindEllipsisRows() {
            _wrapper.SetContextAttribute( AngularConst.BindEllipsisRows, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzEllipsisRows]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略后缀
        /// </summary>
        [Fact]
        public void TestSuffix() {
            _wrapper.SetContextAttribute( UiConst.Suffix, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" nzSuffix=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略后缀
        /// </summary>
        [Fact]
        public void TestBindSuffix() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffix, "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\" [nzSuffix]=\"a\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容更改事件
        /// </summary>
        [Fact]
        public void TestOnContentChange() {
            _wrapper.SetContextAttribute( UiConst.OnContentChange, "a" );
            var result = new StringBuilder();
            result.Append( "<p (nzContentChange)=\"a\" nz-typography=\"\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略展开更改事件
        /// </summary>
        [Fact]
        public void TestOnExpandChange() {
            _wrapper.SetContextAttribute( UiConst.OnExpandChange, "a" );
            var result = new StringBuilder();
            result.Append( "<p (nzExpandChange)=\"a\" nz-typography=\"\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试省略更改事件
        /// </summary>
        [Fact]
        public void TestOnEllipsis() {
            _wrapper.SetContextAttribute( UiConst.OnEllipsis, "a" );
            var result = new StringBuilder();
            result.Append( "<p (nzOnEllipsis)=\"a\" nz-typography=\"\"></p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容元素
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<p nz-typography=\"\">a</p>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}