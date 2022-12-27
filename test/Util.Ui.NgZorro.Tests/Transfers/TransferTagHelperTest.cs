using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Transfers;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Transfers {
    /// <summary>
    /// 穿梭框测试
    /// </summary>
    public class TransferTagHelperTest {
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
        public TransferTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TransferTagHelper().ToWrapper();
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
            result.Append( "<nz-transfer></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestDatasource() {
            _wrapper.SetContextAttribute( UiConst.Datasource, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzDataSource]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzDisabled]=\"true\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzDisabled]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题集合
        /// </summary>
        [Fact]
        public void TestTitles() {
            _wrapper.SetContextAttribute( UiConst.Titles, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzTitles]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作按钮标题集合
        /// </summary>
        [Fact]
        public void TestOperations() {
            _wrapper.SetContextAttribute( UiConst.Operations, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzOperations]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试样式
        /// </summary>
        [Fact]
        public void TestListStyle() {
            _wrapper.SetContextAttribute( UiConst.ListStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzListStyle]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单数项目单位
        /// </summary>
        [Fact]
        public void TestItemUnit() {
            _wrapper.SetContextAttribute( UiConst.ItemUnit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer nzItemUnit=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单数项目单位
        /// </summary>
        [Fact]
        public void TestBindItemUnit() {
            _wrapper.SetContextAttribute( AngularConst.BindItemUnit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzItemUnit]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复数项目单位
        /// </summary>
        [Fact]
        public void TestItemsUnit() {
            _wrapper.SetContextAttribute( UiConst.ItemsUnit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer nzItemsUnit=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复数项目单位
        /// </summary>
        [Fact]
        public void TestBindItemsUnit() {
            _wrapper.SetContextAttribute( AngularConst.BindItemsUnit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzItemsUnit]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试渲染列表
        /// </summary>
        [Fact]
        public void TestRenderList() {
            _wrapper.SetContextAttribute( UiConst.RenderList, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzRenderList]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行渲染模板
        /// </summary>
        [Fact]
        public void TestRender() {
            _wrapper.SetContextAttribute( UiConst.Render, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzRender]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部渲染模板
        /// </summary>
        [Fact]
        public void TestFooter() {
            _wrapper.SetContextAttribute( UiConst.Footer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzFooter]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestShowSearch() {
            _wrapper.SetContextAttribute( UiConst.ShowSearch, true );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzShowSearch]=\"true\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestBindShowSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzShowSearch]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤项函数
        /// </summary>
        [Fact]
        public void TestFilterOption() {
            _wrapper.SetContextAttribute( UiConst.FilterOption, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzFilterOption]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索框占位提示
        /// </summary>
        [Fact]
        public void TestSearchPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.SearchPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer nzSearchPlaceholder=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索框占位提示
        /// </summary>
        [Fact]
        public void TestBindSearchPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindSearchPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzSearchPlaceholder]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer nzNotFoundContent=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzNotFoundContent]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可移动项函数
        /// </summary>
        [Fact]
        public void TestCanMove() {
            _wrapper.SetContextAttribute( UiConst.CanMove, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzCanMove]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中项键列表
        /// </summary>
        [Fact]
        public void TestSelectedKeys() {
            _wrapper.SetContextAttribute( UiConst.SelectedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzSelectedKeys]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试目标项键列表
        /// </summary>
        [Fact]
        public void TestTargetKeys() {
            _wrapper.SetContextAttribute( UiConst.TargetKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer [nzTargetKeys]=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer>a</nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试转移改变事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer (nzChange)=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索改变事件
        /// </summary>
        [Fact]
        public void TestOnSearchChange() {
            _wrapper.SetContextAttribute( UiConst.OnSearchChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer (nzSearchChange)=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中状态改变事件
        /// </summary>
        [Fact]
        public void TestOnSelectChange() {
            _wrapper.SetContextAttribute( UiConst.OnSelectChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-transfer (nzSelectChange)=\"a\"></nz-transfer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}