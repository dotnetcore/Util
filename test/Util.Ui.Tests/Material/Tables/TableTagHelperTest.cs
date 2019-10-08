using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tables {
    /// <summary>
    /// 表格测试
    /// </summary>
    public class TableTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格
        /// </summary>
        private readonly TableTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TableTagHelper();
            Id.SetId( "id" );
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
            result.Append( "<mat-table-wrapper #m_id=\"\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #a=\"\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"a.dataSource\" " );
            result.Append( "[style.max-height]=\"a.maxHeight?a.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"a.minHeight?a.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加还原查询标识
        /// </summary>
        [Fact]
        public void TestKey() {
            var attributes = new TagHelperAttributeList { { UiConst.Key, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" key=\"a\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" [(queryParam)]=\"a\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试基地址
        /// </summary>
        [Fact]
        public void TestBaseUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.BaseUrl, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" baseUrl=\"a\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" url=\"a\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestDeleteUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.DeleteUrl, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" deleteUrl=\"a\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Sort, "a" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\">" );
            result.Append( "<mat-table matSort=\"\" matSortActive=\"a\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试排序方向
        /// </summary>
        [Fact]
        public void TestSortDirection() {
            var attributes = new TagHelperAttributeList { { UiConst.SortDirection, SortDirection.Desc } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\">" );
            result.Append( "<mat-table matSort=\"\" matSortDirection=\"desc\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大高度
        /// </summary>
        [Fact]
        public void TestMaxHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxHeight, 1 } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" maxHeight=\"1\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小高度
        /// </summary>
        [Fact]
        public void TestMinHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.MinHeight, 1 } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" minHeight=\"1\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, 1 } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" width=\"1\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动加载
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoLoad, false } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" [autoLoad]=\"false\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页长度列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions() {
            var attributes = new TagHelperAttributeList { { UiConst.PageSizeOptions, "1,2" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" [pageSizeOptions]=\"[1,2]\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页长度列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions_2() {
            var attributes = new TagHelperAttributeList { { UiConst.PageSizeOptions, "[1,2]" } };
            var result = new String();
            result.Append( "<mat-table-wrapper #m_id=\"\" [pageSizeOptions]=\"[1,2]\">" );
            result.Append( "<mat-table matSort=\"\" matSortDisableClear=\"\" [dataSource]=\"m_id.dataSource\" " );
            result.Append( "[style.max-height]=\"m_id.maxHeight?m_id.maxHeight+'px':null\" " );
            result.Append( "[style.min-height]=\"m_id.minHeight?m_id.minHeight+'px':null\">" );
            result.Append( "</mat-table>" );
            result.Append( "</mat-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}