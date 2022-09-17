using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Lists {
    /// <summary>
    /// 列表测试
    /// </summary>
    public class ListTagHelperTest {
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
        public ListTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ListTagHelper().ToWrapper();
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
            result.Append( "<nz-list></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, true );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzBordered]=\"true\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBindBordered() {
            _wrapper.SetContextAttribute( AngularConst.BindBordered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzBordered]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表底部
        /// </summary>
        [Fact]
        public void TestFooter() {
            _wrapper.SetContextAttribute( UiConst.Footer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list nzFooter=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表底部
        /// </summary>
        [Fact]
        public void TestBindFooter() {
            _wrapper.SetContextAttribute( AngularConst.BindFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzFooter]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表头部
        /// </summary>
        [Fact]
        public void TestHeader() {
            _wrapper.SetContextAttribute( UiConst.Header, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list nzHeader=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表头部
        /// </summary>
        [Fact]
        public void TestBindHeader() {
            _wrapper.SetContextAttribute( AngularConst.BindHeader, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzHeader]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项布局方式
        /// </summary>
        [Fact]
        public void TestItemLayout() {
            _wrapper.SetContextAttribute( UiConst.ItemLayout, ListItemLayout.Horizontal );
            var result = new StringBuilder();
            result.Append( "<nz-list nzItemLayout=\"horizontal\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项布局方式
        /// </summary>
        [Fact]
        public void TestBindItemLayout() {
            _wrapper.SetContextAttribute( AngularConst.BindItemLayout, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzItemLayout]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzLoading]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, ListSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-list nzSize=\"small\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzSize]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示分割线
        /// </summary>
        [Fact]
        public void TestSplit() {
            _wrapper.SetContextAttribute( UiConst.Split, true );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzSplit]=\"true\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示分割线
        /// </summary>
        [Fact]
        public void TestBindSplit() {
            _wrapper.SetContextAttribute( AngularConst.BindSplit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list [nzSplit]=\"a\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格
        /// </summary>
        [Fact]
        public void TestGrid() {
            _wrapper.SetContextAttribute( UiConst.Grid, true );
            var result = new StringBuilder();
            result.Append( "<nz-list nzGrid=\"\"></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格 - 当设置为false不添加nzGrid属性
        /// </summary>
        [Fact]
        public void TestGrid_False() {
            _wrapper.SetContextAttribute( UiConst.Grid, false );
            var result = new StringBuilder();
            result.Append( "<nz-list></nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list>a</nz-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}