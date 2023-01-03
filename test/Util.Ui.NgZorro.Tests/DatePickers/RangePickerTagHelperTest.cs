using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.DatePickers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.DatePickers {
    /// <summary>
    /// 日期范围选择测试
    /// </summary>
    public partial class RangePickerTagHelperTest {
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
        public RangePickerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new RangePickerTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-range-picker></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzAllowClear]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowClear() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowClear, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzAllowClear]=\"Ab\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzAutoFocus]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzAutoFocus]=\"Ab\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认面板日期
        /// </summary>
        [Fact]
        public void TestDefaultPickerValue() {
            _wrapper.SetContextAttribute( UiConst.DefaultPickerValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzDefaultPickerValue=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认面板日期
        /// </summary>
        [Fact]
        public void TestBindDefaultPickerValue() {
            _wrapper.SetContextAttribute( AngularConst.BindDefaultPickerValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzDefaultPickerValue]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzDisabled]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzDisabled]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不可选择日期函数
        /// </summary>
        [Fact]
        public void TestDisabledDate() {
            _wrapper.SetContextAttribute( UiConst.DisabledDate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzDisabledDate]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出日历样式类名
        /// </summary>
        [Fact]
        public void TestDropdownClassName() {
            _wrapper.SetContextAttribute( UiConst.DropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzDropdownClassName=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出日历样式类名
        /// </summary>
        [Fact]
        public void TestBindDropdownClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzDropdownClassName]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出日历样式
        /// </summary>
        [Fact]
        public void TestPopupStyle() {
            _wrapper.SetContextAttribute( UiConst.PopupStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzPopupStyle=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出日历样式
        /// </summary>
        [Fact]
        public void TestBindPopupStyle() {
            _wrapper.SetContextAttribute( AngularConst.BindPopupStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzPopupStyle]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试日期格式
        /// </summary>
        [Fact]
        public void TestFormat() {
            _wrapper.SetContextAttribute( UiConst.Format, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzFormat=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试日期格式
        /// </summary>
        [Fact]
        public void TestBindFormat() {
            _wrapper.SetContextAttribute( AngularConst.BindFormat, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzFormat]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestInputReadOnly() {
            _wrapper.SetContextAttribute( UiConst.InputReadonly, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzInputReadOnly]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestBindInputReadOnly() {
            _wrapper.SetContextAttribute( AngularConst.BindInputReadonly, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzInputReadOnly]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试国际化
        /// </summary>
        [Fact]
        public void TestLocale() {
            _wrapper.SetContextAttribute( UiConst.Locale, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzLocale]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestMode() {
            _wrapper.SetContextAttribute( UiConst.Mode, DatePickerMode.Month );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzMode=\"month\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestBindMode() {
            _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzMode]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzPlaceHolder=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzPlaceHolder]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外页脚
        /// </summary>
        [Fact]
        public void TestRenderExtraFooter() {
            _wrapper.SetContextAttribute( UiConst.RenderExtraFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzRenderExtraFooter=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外页脚
        /// </summary>
        [Fact]
        public void TestBindRenderExtraFooter() {
            _wrapper.SetContextAttribute( AngularConst.BindRenderExtraFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzRenderExtraFooter]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzSize=\"large\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzSize]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzSuffixIcon=\"account-book\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzSuffixIcon]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试移除边框
        /// </summary>
        [Fact]
        public void TestBorderless() {
            _wrapper.SetContextAttribute( UiConst.Borderless, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzBorderless]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试移除边框
        /// </summary>
        [Fact]
        public void TestBindBorderless() {
            _wrapper.SetContextAttribute( AngularConst.BindBorderless, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzBorderless]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试预设时间范围
        /// </summary>
        [Fact]
        public void TestRanges() {
            _wrapper.SetContextAttribute( UiConst.Ranges, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzRanges]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [Fact]
        public void TestSeparator() {
            _wrapper.SetContextAttribute( UiConst.Separator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker nzSeparator=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [Fact]
        public void TestBindSeparator() {
            _wrapper.SetContextAttribute( AngularConst.BindSeparator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzSeparator]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示时间选择
        /// </summary>
        [Fact]
        public void TestShowTime() {
            _wrapper.SetContextAttribute( UiConst.ShowTime, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzShowTime]=\"true\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示时间选择
        /// </summary>
        [Fact]
        public void TestBindShowTime() {
            _wrapper.SetContextAttribute( AngularConst.BindShowTime, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker [nzShowTime]=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker>a</nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出关闭日历事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnOpenChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker (nzOnOpenChange)=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试待选日期改变事件
        /// </summary>
        [Fact]
        public void TestOnCalendarChange() {
            _wrapper.SetContextAttribute( UiConst.OnCalendarChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker (nzOnCalendarChange)=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确定事件
        /// </summary>
        [Fact]
        public void TestOnOk() {
            _wrapper.SetContextAttribute( UiConst.OnOk, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker (nzOnOk)=\"a\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-range-picker *nzSpaceItem=\"\"></nz-range-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}