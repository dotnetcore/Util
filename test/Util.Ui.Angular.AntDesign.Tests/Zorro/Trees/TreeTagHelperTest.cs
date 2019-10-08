using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Trees;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Trees {
    /// <summary>
    /// 树形测试
    /// </summary>
    public class TreeTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 树形
        /// </summary>
        private readonly TreeTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TreeTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TreeTagHelper();
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
            result.Append( "<x-tree></x-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-tree #a=\"\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试请求地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<x-tree url=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试请求地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<x-tree [url]=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<x-tree [(queryParam)]=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [Fact]
        public void TestShowCheckbox() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowCheckbox, true } };
            var result = new String();
            result.Append( "<x-tree showCheckbox=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示展开图标
        /// </summary>
        [Fact]
        public void TestShowExpand() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowExpand, false } };
            var result = new String();
            result.Append( "<x-tree showExpand=\"false\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示连接线
        /// </summary>
        [Fact]
        public void TestShowLine() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowLine, true } };
            var result = new String();
            result.Append( "<x-tree showLine=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试展开所有节点
        /// </summary>
        [Fact]
        public void TestExpandAll() {
            var attributes = new TagHelperAttributeList { { UiConst.ExpandAll, true } };
            var result = new String();
            result.Append( "<x-tree expandAll=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试节点是否占据一行
        /// </summary>
        [Fact]
        public void TestBlockNode() {
            var attributes = new TagHelperAttributeList { { UiConst.BlockNode, true } };
            var result = new String();
            result.Append( "<x-tree blockNode=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中多个节点
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<x-tree multiple=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示图标
        /// </summary>
        [Fact]
        public void TestShowIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowIcon, true } };
            var result = new String();
            result.Append( "<x-tree showIcon=\"true\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<x-tree (onClick)=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试双击事件
        /// </summary>
        [Fact]
        public void TestOnDblClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnDblClick, "a" } };
            var result = new String();
            result.Append( "<x-tree (onDblClick)=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试展开事件
        /// </summary>
        [Fact]
        public void TestOnExpand() {
            var attributes = new TagHelperAttributeList { { UiConst.OnExpand, "a" } };
            var result = new String();
            result.Append( "<x-tree (onExpand)=\"a\"></x-tree>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
