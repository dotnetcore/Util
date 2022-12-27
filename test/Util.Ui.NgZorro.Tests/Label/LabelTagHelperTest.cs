using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Label;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Label {
    /// <summary>
    /// 标签测试
    /// </summary>
    public class LabelTagHelperTest {
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
        public LabelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new LabelTagHelper().ToWrapper<Customer>();
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
        /// 测试属性表达式 - 显示标题
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetContextAttribute( UiConst.Type, LabelType.Title );
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<span>编码</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 显示值 - 文本类型
        /// </summary>
        [Fact]
        public void TestFor_2() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<span>{{model.code}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 显示值 - 布尔类型
        /// </summary>
        [Fact]
        public void TestFor_3() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "<i *ngIf=\"model.enabled\" nz-icon=\"\" nzType=\"check\"></i>" );
            result.Append( "<i *ngIf=\"!(model.enabled)\" nz-icon=\"\" nzType=\"close\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 显示值 - 日期类型
        /// </summary>
        [Fact]
        public void TestFor_4() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<span>{{model.birthday | date:\"yyyy-MM-dd HH:mm\"}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 显示值 - 日期类型 - 设置日期格式
        /// </summary>
        [Fact]
        public void TestFor_5() {
            _wrapper.SetContextAttribute( UiConst.DateFormat, "yyyy-MM" );
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<span>{{model.birthday | date:\"yyyy-MM\"}}</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}