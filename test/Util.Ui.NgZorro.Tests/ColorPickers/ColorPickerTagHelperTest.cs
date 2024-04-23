using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.ColorPickers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.ColorPickers {
    /// <summary>
    /// 颜色选择测试
    /// </summary>
    public partial class ColorPickerTagHelperTest {
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
        public ColorPickerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ColorPickerTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-color-picker></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzTitle=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzTitle]=\"'a'|i18n\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzTitle]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色默认值
        /// </summary>
        [Fact]
        public void TestDefaultValue() {
            _wrapper.SetContextAttribute( UiConst.DefaultValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzDefaultValue=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色默认值
        /// </summary>
        [Fact]
        public void TestBindDefaultValue() {
            _wrapper.SetContextAttribute( AngularConst.BindDefaultValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzDefaultValue]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzValue=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzValue]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示颜色文本
        /// </summary>
        [Fact]
        public void TestShowText() {
            _wrapper.SetContextAttribute( UiConst.ShowText, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzShowText]=\"true\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzSize=\"large\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzSize]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzDisabled]=\"true\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用透明度
        /// </summary>
        [Fact]
        public void TestDisabledAlpha() {
            _wrapper.SetContextAttribute( UiConst.DisabledAlpha, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzDisabledAlpha]=\"true\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试触发模式
        /// </summary>
        [Fact]
        public void TestTrigger() {
            _wrapper.SetContextAttribute( UiConst.Trigger, ColorPickerTrigger.Hover );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzTrigger=\"hover\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试触发模式
        /// </summary>
        [Fact]
        public void TestBindTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzTrigger]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzAllowClear]=\"true\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色格式
        /// </summary>
        [Fact]
        public void TestFormat() {
            _wrapper.SetContextAttribute( UiConst.Format, ColorPickerFormat.Hsb );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker nzFormat=\"hsb\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色格式
        /// </summary>
        [Fact]
        public void TestBindFormat() {
            _wrapper.SetContextAttribute( AngularConst.BindFormat, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzFormat]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示弹出窗口
        /// </summary>
        [Fact]
        public void TestOpen() {
            _wrapper.SetContextAttribute( UiConst.Open, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker [nzOpen]=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker>a</nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色变化事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker (nzOnChange)=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除事件
        /// </summary>
        [Fact]
        public void TestOnClear() {
            _wrapper.SetContextAttribute( UiConst.OnClear, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker (nzOnClear)=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色格式变化事件
        /// </summary>
        [Fact]
        public void TestOnFormatChange() {
            _wrapper.SetContextAttribute( UiConst.OnFormatChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker (nzOnFormatChange)=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试打开颜色面板事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnOpenChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-picker (nzOnOpenChange)=\"a\"></nz-color-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}