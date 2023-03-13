using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Display;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Display {
    /// <summary>
    /// 数据项展示测试
    /// </summary>
    public class DisplayTagHelperTest {
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
        public DisplayTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DisplayTagHelper().ToWrapper<Customer>();
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
            result.Append( "<span></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{a}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "a" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示标签
        /// </summary>
        [Fact]
        public void TestShowLabel() {
            _wrapper.SetContextAttribute( UiConst.ShowLabel, true );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<span class=\"mr-sm\">a.nickname:</span>" );
            result.Append( "<span>{{model.nickname}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示标签 - 多语言
        /// </summary>
        [Fact]
        public void TestShowLabel_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.ShowLabel, true );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<span class=\"mr-sm\">{{'a.nickname'|i18n}}:</span>" );
            result.Append( "<span>{{model.nickname}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示标签 - 放入form中,自动创建form-item
        /// </summary>
        [Fact]
        public void TestShowLabel_Form() {
            _wrapper.SetItem( new FormShareConfig { LabelSpan = "4", ControlSpan = "20", Gutter = "16" } );
            _wrapper.SetContextAttribute( UiConst.ShowLabel, true );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzGutter]=\"16\">" );
            result.Append( "<nz-form-label [nzSpan]=\"4\">a.nickname</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"20\">" );
            result.Append( "<span>{{model.nickname}}</span>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示标签 - 放入form中,自动创建form-item - 设置value覆盖
        /// </summary>
        [Fact]
        public void TestShowLabel_Form_2() {
            _wrapper.SetItem( new FormShareConfig { LabelSpan = "4", ControlSpan = "20", Gutter = "16" } );
            _wrapper.SetContextAttribute( UiConst.ShowLabel, true );
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzGutter]=\"16\">" );
            result.Append( "<nz-form-label [nzSpan]=\"4\">a.nickname</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"20\">" );
            result.Append( "<span>{{a}}</span>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示标签 - 放入form中,自动创建form-item - 多语言
        /// </summary>
        [Fact]
        public void TestShowLabel_Form_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetItem( new FormShareConfig { LabelSpan = "4", ControlSpan = "20", Gutter = "16" } );
            _wrapper.SetContextAttribute( UiConst.ShowLabel, true );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzGutter]=\"16\">" );
            result.Append( "<nz-form-label [nzSpan]=\"4\">{{'a.nickname'|i18n}}</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"20\">" );
            result.Append( "<span>{{model.nickname}}</span>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<span>{{model.code}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 设置value覆盖
        /// </summary>
        [Fact]
        public void TestFor_2() {
            _wrapper.SetExpression( t => t.Code );
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<span>{{a}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 布尔类型
        /// </summary>
        [Fact]
        public void TestFor_3() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{model.enabled?'是':'否'}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 布尔类型 - 多语言
        /// </summary>
        [Fact]
        public void TestFor_3_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{(model.enabled?'util.yes':'util.no')|i18n}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 日期类型
        /// </summary>
        [Fact]
        public void TestFor_4() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{model.birthday|date:\"yyyy-MM-dd HH:mm\"}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 日期类型 - 设置日期格式
        /// </summary>
        [Fact]
        public void TestFor_5() {
            _wrapper.SetContextAttribute( UiConst.DateFormat, "yyyy-MM" );
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{model.birthday|date:\"yyyy-MM\"}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}