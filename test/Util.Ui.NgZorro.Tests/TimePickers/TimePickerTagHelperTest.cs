using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TimePickers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TimePickers {
    /// <summary>
    /// 时间选择测试
    /// </summary>
    public partial class TimePickerTagHelperTest {
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
        public TimePickerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TimePickerTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-time-picker></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部自定义内容
        /// </summary>
        [Fact]
        public void TestAddOn() {
            _wrapper.SetContextAttribute( UiConst.AddOn, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzAddOn]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowEmpty() {
            _wrapper.SetContextAttribute( UiConst.AllowEmpty, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzAllowEmpty]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowEmpty() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowEmpty, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzAllowEmpty]=\"Ab\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除按钮显示文本
        /// </summary>
        [Fact]
        public void TestClearText() {
            _wrapper.SetContextAttribute( UiConst.ClearText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzClearText=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除按钮显示文本
        /// </summary>
        [Fact]
        public void TestBindClearText() {
            _wrapper.SetContextAttribute( AngularConst.BindClearText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzClearText]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzAutoFocus]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzAutoFocus]=\"Ab\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [Fact]
        public void TestDefaultOpenValue() {
            _wrapper.SetContextAttribute( UiConst.DefaultOpenValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzDefaultOpenValue=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [Fact]
        public void TestBindDefaultOpenValue() {
            _wrapper.SetContextAttribute( AngularConst.BindDefaultOpenValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDefaultOpenValue]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDisabled]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDisabled]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不可选择小时函数
        /// </summary>
        [Fact]
        public void TestDisabledHours() {
            _wrapper.SetContextAttribute( UiConst.DisabledHours, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDisabledHours]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不可选择分钟函数
        /// </summary>
        [Fact]
        public void TestDisabledMinutes() {
            _wrapper.SetContextAttribute( UiConst.DisabledMinutes, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDisabledMinutes]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不可选择秒函数
        /// </summary>
        [Fact]
        public void TestDisabledSeconds() {
            _wrapper.SetContextAttribute( UiConst.DisabledSeconds, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzDisabledSeconds]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试时间格式
        /// </summary>
        [Fact]
        public void TestFormat() {
            _wrapper.SetContextAttribute( UiConst.Format, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzFormat=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试时间格式
        /// </summary>
        [Fact]
        public void TestBindFormat() {
            _wrapper.SetContextAttribute( AngularConst.BindFormat, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzFormat]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏禁止选择的选项
        /// </summary>
        [Fact]
        public void TestHideDisabledOptions() {
            _wrapper.SetContextAttribute( UiConst.HideDisabledOptions, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzHideDisabledOptions]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏禁止选择的选项
        /// </summary>
        [Fact]
        public void TestBindHideDisabledOptions() {
            _wrapper.SetContextAttribute( AngularConst.BindHideDisabledOptions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzHideDisabledOptions]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试小时选项间隔
        /// </summary>
        [Fact]
        public void TestHourStep() {
            _wrapper.SetContextAttribute( UiConst.HourStep, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzHourStep=\"1\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试小时选项间隔
        /// </summary>
        [Fact]
        public void TestBindHourStep() {
            _wrapper.SetContextAttribute( AngularConst.BindHourStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzHourStep]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分钟选项间隔
        /// </summary>
        [Fact]
        public void TestMinuteStep() {
            _wrapper.SetContextAttribute( UiConst.MinuteStep, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzMinuteStep=\"1\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分钟选项间隔
        /// </summary>
        [Fact]
        public void TestBindMinuteStep() {
            _wrapper.SetContextAttribute( AngularConst.BindMinuteStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzMinuteStep]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试秒选项间隔
        /// </summary>
        [Fact]
        public void TestSecondStep() {
            _wrapper.SetContextAttribute( UiConst.SecondStep, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzSecondStep=\"1\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试秒选项间隔
        /// </summary>
        [Fact]
        public void TestBindSecondStep() {
            _wrapper.SetContextAttribute( AngularConst.BindSecondStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzSecondStep]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板是否打开
        /// </summary>
        [Fact]
        public void TestOpen() {
            _wrapper.SetContextAttribute( UiConst.Open, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzOpen]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板是否打开
        /// </summary>
        [Fact]
        public void TestBindOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzOpen]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板是否打开
        /// </summary>
        [Fact]
        public void TestBindonOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindonOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [(nzOpen)]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzPlaceHolder=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzPlaceHolder]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出层样式类名
        /// </summary>
        [Fact]
        public void TestPopupClassName() {
            _wrapper.SetContextAttribute( UiConst.PopupClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzPopupClassName=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出层样式类名
        /// </summary>
        [Fact]
        public void TestBindPopupClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopupClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzPopupClassName]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试12小时制
        /// </summary>
        [Fact]
        public void TestUse12Hours() {
            _wrapper.SetContextAttribute( UiConst.Use12Hours, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzUse12Hours]=\"true\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试12小时制
        /// </summary>
        [Fact]
        public void TestBindUse12Hours() {
            _wrapper.SetContextAttribute( AngularConst.BindUse12Hours, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzUse12Hours]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker nzSuffixIcon=\"account-book\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker [nzSuffixIcon]=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker>a</nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker (ngModelChange)=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试打开关闭面板事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnOpenChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker (nzOpenChange)=\"a\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-time-picker *nzSpaceItem=\"\"></nz-time-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}