using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Paginations;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Paginations {
    /// <summary>
    /// 分页测试
    /// </summary>
    public class PaginationTagHelperTest {
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
        public PaginationTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new PaginationTagHelper().ToWrapper();
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
            result.Append( "<nz-pagination></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试总数
        /// </summary>
        [Fact]
        public void TestTotal() {
            _wrapper.SetContextAttribute( UiConst.Total, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzTotal]=\"1\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试总数
        /// </summary>
        [Fact]
        public void TestBindTotal() {
            _wrapper.SetContextAttribute( AngularConst.BindTotal, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzTotal]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestPageIndex() {
            _wrapper.SetContextAttribute( UiConst.PageIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzPageIndex]=\"1\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestBindPageIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindPageIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzPageIndex]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestBindonPageIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindonPageIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [(nzPageIndex)]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestPageSize() {
            _wrapper.SetContextAttribute( UiConst.PageSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzPageSize]=\"1\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestBindPageSize() {
            _wrapper.SetContextAttribute( AngularConst.BindPageSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzPageSize]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestBindonPageSize() {
            _wrapper.SetContextAttribute( AngularConst.BindonPageSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [(nzPageSize)]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示改变分页大小按钮
        /// </summary>
        [Fact]
        public void TestShowSizeChanger() {
            _wrapper.SetContextAttribute( UiConst.ShowSizeChanger, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzShowSizeChanger]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示改变分页大小按钮
        /// </summary>
        [Fact]
        public void TestBindShowSizeChanger() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSizeChanger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzShowSizeChanger]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示快速跳转
        /// </summary>
        [Fact]
        public void TestShowQuickJumper() {
            _wrapper.SetContextAttribute( UiConst.ShowQuickJumper, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzShowQuickJumper]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示快速跳转
        /// </summary>
        [Fact]
        public void TestBindShowQuickJumper() {
            _wrapper.SetContextAttribute( AngularConst.BindShowQuickJumper, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzShowQuickJumper]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzDisabled]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzDisabled]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, PaginationSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-pagination nzSize=\"small\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzSize]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示总行数和当前数据范围的模板
        /// </summary>
        [Fact]
        public void TestShowTotal() {
            _wrapper.SetContextAttribute( UiConst.ShowTotal, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzShowTotal]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试简单分页
        /// </summary>
        [Fact]
        public void TestSimple() {
            _wrapper.SetContextAttribute( UiConst.Simple, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzSimple]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试简单分页
        /// </summary>
        [Fact]
        public void TestBindSimple() {
            _wrapper.SetContextAttribute( AngularConst.BindSimple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzSimple]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试响应式
        /// </summary>
        [Fact]
        public void TestResponsive() {
            _wrapper.SetContextAttribute( UiConst.Responsive, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzResponsive]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试响应式
        /// </summary>
        [Fact]
        public void TestBindResponsive() {
            _wrapper.SetContextAttribute( AngularConst.BindResponsive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzResponsive]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页行数选择列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions() {
            _wrapper.SetContextAttribute( UiConst.PageSizeOptions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzPageSizeOptions]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义页码结构
        /// </summary>
        [Fact]
        public void TestItemRender() {
            _wrapper.SetContextAttribute( UiConst.ItemRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzItemRender]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只有一页时是否隐藏分页器
        /// </summary>
        [Fact]
        public void TestHideOnSinglePage() {
            _wrapper.SetContextAttribute( UiConst.HideOnSinglePage, true );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzHideOnSinglePage]=\"true\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只有一页时是否隐藏分页器
        /// </summary>
        [Fact]
        public void TestBindHideOnSinglePage() {
            _wrapper.SetContextAttribute( AngularConst.BindHideOnSinglePage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination [nzHideOnSinglePage]=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination>a</nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试页码改变事件
        /// </summary>
        [Fact]
        public void TestOnPageIndexChange() {
            _wrapper.SetContextAttribute( UiConst.OnPageIndexChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination (nzPageIndexChange)=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页行数改变事件
        /// </summary>
        [Fact]
        public void TestOnPageSizeChange() {
            _wrapper.SetContextAttribute( UiConst.OnPageSizeChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-pagination (nzPageSizeChange)=\"a\"></nz-pagination>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}