using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Lists.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Lists {
    /// <summary>
    /// 选择列表测试
    /// </summary>
    public class SelectListTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选择列表
        /// </summary>
        private readonly SelectListTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectListTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SelectListTagHelper();
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
            result.Append( "<mat-selection-list></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list #a=\"\"></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list name=\"a\"></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list [disabled]=\"a\"></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list [(ngModel)]=\"a\"></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标题
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list><h3 mat-subheader=\"\">a</h3></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-selection-list (ngModelChange)=\"a\"></mat-selection-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试加载地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper url=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestDataSource_Id() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper #a=\"\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加名称
        /// </summary>
        [Fact]
        public void TestDataSource_Name() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper name=\"a\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDataSource_Disabled() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"a\" [disabled]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestDataSource_Model() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper [(model)]=\"a\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标题
        /// </summary>
        [Fact]
        public void TestDataSource_Label() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper label=\"a\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestDataSource_OnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper (onChange)=\"a\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试复选框位置
        /// </summary>
        [Fact]
        public void TestDataSource_CheckboxPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" }, { MaterialConst.CheckboxPosition, XPosition.Right } };
            var result = new String();
            result.Append( "<mat-select-list-wrapper checkboxPosition=\"after\" [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}