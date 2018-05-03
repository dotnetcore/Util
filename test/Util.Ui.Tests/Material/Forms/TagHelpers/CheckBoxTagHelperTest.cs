using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms.TagHelpers {
    /// <summary>
    /// 复选框测试
    /// </summary>
    public class CheckBoxTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 复选框
        /// </summary>
        private readonly CheckBoxTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CheckBoxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CheckBoxTagHelper();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null,TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-checkbox></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox #a=\"\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox name=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox>a</mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLabel, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox>{{a}}</mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.Position, XPosition.Left } };
            var result = new String();
            result.Append( "<mat-checkbox labelPosition=\"before\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-checkbox [disabled]=\"true\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<mat-checkbox color=\"primary\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox [(ngModel)]=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置不确定样式
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            var attributes = new TagHelperAttributeList { { UiConst.Indeterminate, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox [indeterminate]=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-checkbox [required]=\"true\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-checkbox (change)=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
