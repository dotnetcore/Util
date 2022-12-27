using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头单元格过滤器触发按钮测试
    /// </summary>
    public class FilterTriggerTagHelperTest {
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
        public FilterTriggerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FilterTriggerTagHelper().ToWrapper();
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
            result.Append( "<nz-filter-trigger></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单
        /// </summary>
        [Fact]
        public void TestExpand() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenu, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzDropdownMenu]=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示下拉菜单
        /// </summary>
        [Fact]
        public void TestVisible() {
            _wrapper.SetContextAttribute( UiConst.Visible, true );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzVisible]=\"true\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示下拉菜单
        /// </summary>
        [Fact]
        public void TestBindVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzVisible]=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示下拉菜单
        /// </summary>
        [Fact]
        public void TestBindonVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [(nzVisible)]=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否激活选中图标效果
        /// </summary>
        [Fact]
        public void TestActive() {
            _wrapper.SetContextAttribute( UiConst.Active, true );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzActive]=\"true\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否激活选中图标效果
        /// </summary>
        [Fact]
        public void TestBindActive() {
            _wrapper.SetContextAttribute( AngularConst.BindActive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzActive]=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否附带背景
        /// </summary>
        [Fact]
        public void TestHasBackdrop() {
            _wrapper.SetContextAttribute( UiConst.HasBackdrop, true );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzHasBackdrop]=\"true\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否附带背景
        /// </summary>
        [Fact]
        public void TestBindHasBackdrop() {
            _wrapper.SetContextAttribute( AngularConst.BindHasBackdrop, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger [nzHasBackdrop]=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger>a</nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-filter-trigger (nzVisibleChange)=\"a\"></nz-filter-trigger>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}