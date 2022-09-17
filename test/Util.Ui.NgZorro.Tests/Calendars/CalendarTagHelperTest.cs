using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Calendars;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Calendars {
    /// <summary>
    /// 日历测试
    /// </summary>
    public class CalendarTagHelperTest {
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
        public CalendarTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CalendarTagHelper().ToWrapper();
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
            result.Append( "<nz-calendar></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [(ngModel)]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestBindNgModel() {
            _wrapper.SetContextAttribute( AngularConst.BindNgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [ngModel]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示模式
        /// </summary>
        [Fact]
        public void TestMode() {
            _wrapper.SetContextAttribute( UiConst.Mode, CalendarMode.Year );
            var result = new StringBuilder();
            result.Append( "<nz-calendar nzMode=\"year\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示模式
        /// </summary>
        [Fact]
        public void TestBindMode() {
            _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzMode]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示模式
        /// </summary>
        [Fact]
        public void TestBindonMode() {
            _wrapper.SetContextAttribute( AngularConst.BindonMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [(nzMode)]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否全屏显示
        /// </summary>
        [Fact]
        public void TestFullscreen() {
            _wrapper.SetContextAttribute( UiConst.Fullscreen, true );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzFullscreen]=\"true\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否全屏显示
        /// </summary>
        [Fact]
        public void TestBindFullscreen() {
            _wrapper.SetContextAttribute( AngularConst.BindFullscreen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzFullscreen]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义渲染日期单元格模板，模版内容会被追加到单元格
        /// </summary>
        [Fact]
        public void TestDateCell() {
            _wrapper.SetContextAttribute( UiConst.DateCell, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzDateCell]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义渲染日期单元格模板，模版内容覆盖单元格
        /// </summary>
        [Fact]
        public void TestDateFullCell() {
            _wrapper.SetContextAttribute( UiConst.DateFullCell, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzDateFullCell]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义渲染月单元格模板，模版内容会被追加到单元格
        /// </summary>
        [Fact]
        public void TestMonthCell() {
            _wrapper.SetContextAttribute( UiConst.MonthCell, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzMonthCell]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义渲染月单元格模板，模版内容覆盖单元格
        /// </summary>
        [Fact]
        public void TestMonthFullCell() {
            _wrapper.SetContextAttribute( UiConst.MonthFullCell, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzMonthFullCell]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不可选择日期函数
        /// </summary>
        [Fact]
        public void TestDisabledDate() {
            _wrapper.SetContextAttribute( UiConst.DisabledDate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar [nzDisabledDate]=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar>a</nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板变化事件
        /// </summary>
        [Fact]
        public void TestOnPanelChange() {
            _wrapper.SetContextAttribute( UiConst.OnPanelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar (nzPanelChange)=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择日期变化事件
        /// </summary>
        [Fact]
        public void TestOnSelectChange() {
            _wrapper.SetContextAttribute( UiConst.OnSelectChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-calendar (nzSelectChange)=\"a\"></nz-calendar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}