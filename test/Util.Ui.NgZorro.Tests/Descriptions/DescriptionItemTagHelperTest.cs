using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表项测试
    /// </summary>
    public partial class DescriptionItemTagHelperTest {
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
        public DescriptionItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DescriptionItemTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
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
            result.Append( "<nz-descriptions-item></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            _wrapper.SetContextAttribute( UiConst.Span, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzSpan=\"1\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestBindSpan() {
            _wrapper.SetContextAttribute( AngularConst.BindSpan, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzSpan]=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"'a'|i18n\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>{{a}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值 - 多语言
        /// </summary>
        [Fact]
        public void TestValueI18n() {
            _wrapper.SetContextAttribute( UiConst.ValueI18n, true );
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>{{a|i18n}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制到剪贴板
        /// </summary>
        [Fact]
        public void TestClipboard() {
            _wrapper.SetContextAttribute( UiConst.Value, "model.code" );
            _wrapper.SetContextAttribute( UiConst.Clipboard, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>" );
            result.Append( "{{model.code}}" );
            result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(model.code)\" *ngIf=\"model.code\" " );
            result.Append( "nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"复制到剪贴板\" nzType=\"text\" x-button-extend=\"\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
            result.Append( "</button>" );
            result.Append( "</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复制到剪贴板 - 多语言
        /// </summary>
        [Fact]
        public void TestClipboard_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Value, "model.code" );
            _wrapper.SetContextAttribute( UiConst.Clipboard, true );
            _wrapper.SetContextAttribute( UiConst.ValueI18n, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>" );
            result.Append( "{{model.code|i18n}}" );
            result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(model.code)\" *ngIf=\"model.code\" " );
            result.Append( "nz-button=\"\" nz-tooltip=\"\" nzType=\"text\" x-button-extend=\"\" [nzTooltipTitle]=\"'util.copyToClipboard'|i18n\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
            result.Append( "</button>" );
            result.Append( "</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>a</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}