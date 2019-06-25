using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Messages;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Messages {
    /// <summary>
    /// 警告提示测试
    /// </summary>
    public class AlertTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 警告提示
        /// </summary>
        private readonly AlertTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlertTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new AlertTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<nz-alert></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-alert #a=\"\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试警告提示样式
        /// </summary>
        [Fact]
        public void TestType() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, AlertType.Error } };
            var result = new String();
            result.Append( "<nz-alert nzType=\"error\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示图标
        /// </summary>
        [Fact]
        public void TestShowIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowIcon, true } };
            var result = new String();
            result.Append( "<nz-alert [nzShowIcon]=\"true\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试警告提示内容
        /// </summary>
        [Fact]
        public void TestMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.Message, "a" } };
            var result = new String();
            result.Append( "<nz-alert nzMessage=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试警告提示内容
        /// </summary>
        [Fact]
        public void TestBindMessage() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindMessage, "a" } };
            var result = new String();
            result.Append( "<nz-alert [nzMessage]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}