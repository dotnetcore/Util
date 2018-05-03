using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms.TagHelpers {
    /// <summary>
    /// 单选框测试
    /// </summary>
    public class RadioTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 单选框
        /// </summary>
        private readonly RadioTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RadioTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new RadioTagHelper();
            Config.IsValidate = false;
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
            result.Append( "<mat-radio-wrapper></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper #a=\"\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper name=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否垂直布局
        /// </summary>
        [Fact]
        public void TestVertical() {
            var attributes = new TagHelperAttributeList { { UiConst.Vertical, true } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [vertical]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper label=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLabel, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [label]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.Position, XPosition.Left } };
            var result = new String();
            result.Append( "<mat-radio-wrapper labelPosition=\"before\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [disabled]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper url=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [(model)]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-radio-wrapper [required]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-radio-wrapper (onChange)=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}