using System;
using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选择器测试
    /// </summary>
    public partial class SelectTagHelperTest : IDisposable{
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SelectTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            NgZorroOptionsService.ClearOptions();
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
            result.Append( "<nz-select></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select #a=\"\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [(ngModel)]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试比较算法函数
        /// </summary>
        [Fact]
        public void TestCompareWith() {
            _wrapper.SetContextAttribute( UiConst.CompareWith, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [compareWith]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除搜索值
        /// </summary>
        [Fact]
        public void TestAutoClearSearchValue() {
            _wrapper.SetContextAttribute( UiConst.AutoClearSearchValue, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAutoClearSearchValue]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除搜索值
        /// </summary>
        [Fact]
        public void TestBindAutoClearSearchValue() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoClearSearchValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAutoClearSearchValue]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAllowClear]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowClear() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowClear, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAllowClear]=\"Ab\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试移除边框
        /// </summary>
        [Fact]
        public void TestBorderless() {
            _wrapper.SetContextAttribute( UiConst.Borderless, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzBorderless]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试移除边框
        /// </summary>
        [Fact]
        public void TestBindBorderless() {
            _wrapper.SetContextAttribute( AngularConst.BindBorderless, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzBorderless]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否打开下拉菜单
        /// </summary>
        [Fact]
        public void TestOpen() {
            _wrapper.SetContextAttribute( UiConst.Open, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzOpen]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否打开下拉菜单
        /// </summary>
        [Fact]
        public void TestBindOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzOpen]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否打开下拉菜单
        /// </summary>
        [Fact]
        public void TestBindonOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindonOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [(nzOpen)]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAutoFocus]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzAutoFocus]=\"Ab\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDisabled]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDisabled]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式类名
        /// </summary>
        [Fact]
        public void TestDropdownClassName() {
            _wrapper.SetContextAttribute( UiConst.DropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select nzDropdownClassName=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式类名
        /// </summary>
        [Fact]
        public void TestBindDropdownClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDropdownClassName]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式
        /// </summary>
        [Fact]
        public void TestDropdownStyle() {
            _wrapper.SetContextAttribute( UiConst.DropdownStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDropdownStyle]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单和选择器同宽
        /// </summary>
        [Fact]
        public void TestDropdownMatchSelectWidth() {
            _wrapper.SetContextAttribute( UiConst.DropdownMatchSelectWidth, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDropdownMatchSelectWidth]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单和选择器同宽
        /// </summary>
        [Fact]
        public void TestBindDropdownMatchSelectWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMatchSelectWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDropdownMatchSelectWidth]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义模板
        /// </summary>
        [Fact]
        public void TestCustomTemplate() {
            _wrapper.SetContextAttribute( UiConst.CustomTemplate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzCustomTemplate]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试服务端搜索
        /// </summary>
        [Fact]
        public void TestServerSearch() {
            _wrapper.SetContextAttribute( UiConst.ServerSearch, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzServerSearch]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试服务端搜索
        /// </summary>
        [Fact]
        public void TestBindServerSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindServerSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzServerSearch]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤项函数
        /// </summary>
        [Fact]
        public void TestFilterOption() {
            _wrapper.SetContextAttribute( UiConst.FilterOption, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzFilterOption]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大多选数量
        /// </summary>
        [Fact]
        public void TestMaxMultipleCount() {
            _wrapper.SetContextAttribute( UiConst.MaxMultipleCount, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-select nzMaxMultipleCount=\"1\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大多选数量
        /// </summary>
        [Fact]
        public void TestBindMaxMultipleCount() {
            _wrapper.SetContextAttribute( AngularConst.BindMaxMultipleCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzMaxMultipleCount]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestMode() {
            _wrapper.SetContextAttribute( UiConst.Mode, SelectMode.Multiple );
            var result = new StringBuilder();
            result.Append( "<nz-select nzMode=\"multiple\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestBindMode() {
            _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzMode]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select nzNotFoundContent=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzNotFoundContent]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select nzPlaceHolder=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzPlaceHolder]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示箭头
        /// </summary>
        [Fact]
        public void TestShowArrow() {
            _wrapper.SetContextAttribute( UiConst.ShowArrow, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzShowArrow]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示箭头
        /// </summary>
        [Fact]
        public void TestBindShowArrow() {
            _wrapper.SetContextAttribute( AngularConst.BindShowArrow, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzShowArrow]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestShowSearch() {
            _wrapper.SetContextAttribute( UiConst.ShowSearch, true );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzShowSearch]=\"true\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestBindShowSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzShowSearch]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-select nzSize=\"large\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzSize]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-select nzSuffixIcon=\"account-book\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzSuffixIcon]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除图标
        /// </summary>
        [Fact]
        public void TestRemoveIcon() {
            _wrapper.SetContextAttribute( UiConst.RemoveIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzRemoveIcon]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清空图标
        /// </summary>
        [Fact]
        public void TestClearIcon() {
            _wrapper.SetContextAttribute( UiConst.ClearIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzClearIcon]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中项图标
        /// </summary>
        [Fact]
        public void TestMenuItemSelectedIcon() {
            _wrapper.SetContextAttribute( UiConst.MenuItemSelectedIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzMenuItemSelectedIcon]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动分词分隔符
        /// </summary>
        [Fact]
        public void TestTokenSeparators() {
            _wrapper.SetContextAttribute( UiConst.TokenSeparators, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzTokenSeparators]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzLoading]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签数量
        /// </summary>
        [Fact]
        public void TestMaxTagCount() {
            _wrapper.SetContextAttribute( UiConst.MaxTagCount, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-select nzMaxTagCount=\"1\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签数量
        /// </summary>
        [Fact]
        public void TestBindMaxTagCount() {
            _wrapper.SetContextAttribute( AngularConst.BindMaxTagCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzMaxTagCount]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签占位符
        /// </summary>
        [Fact]
        public void TestMaxTagPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.MaxTagPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzMaxTagPlaceholder]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项列表
        /// </summary>
        [Fact]
        public void TestOptions() {
            _wrapper.SetContextAttribute( UiConst.Options, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzOptions]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项高度
        /// </summary>
        [Fact]
        public void TestOptionHeightPx() {
            _wrapper.SetContextAttribute( UiConst.OptionHeightPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-select nzOptionHeightPx=\"1\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项高度
        /// </summary>
        [Fact]
        public void TestBindOptionHeightPx() {
            _wrapper.SetContextAttribute( AngularConst.BindOptionHeightPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzOptionHeightPx]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大显示选项数量
        /// </summary>
        [Fact]
        public void TestOptionOverflowSize() {
            _wrapper.SetContextAttribute( UiConst.OptionOverflowSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-select nzOptionOverflowSize=\"1\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大显示选项数量
        /// </summary>
        [Fact]
        public void TestBindOptionOverflowSize() {
            _wrapper.SetContextAttribute( AngularConst.BindOptionOverflowSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzOptionOverflowSize]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置下拉扩展模板
        /// </summary>
        [Fact]
        public void TestDropdownRender() {
            _wrapper.SetContextAttribute( UiConst.DropdownRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [nzDropdownRender]=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select>a</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (ngModelChange)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单打开状态变更事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnOpenChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (nzOpenChange)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滚动到底部事件
        /// </summary>
        [Fact]
        public void TestOnScrollToBottom() {
            _wrapper.SetContextAttribute( UiConst.OnScrollToBottom, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (nzScrollToBottom)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索事件
        /// </summary>
        [Fact]
        public void TestOnSearch() {
            _wrapper.SetContextAttribute( UiConst.OnSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (nzOnSearch)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            _wrapper.SetContextAttribute( UiConst.OnFocus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (nzFocus)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            _wrapper.SetContextAttribute( UiConst.OnBlur, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select (nzBlur)=\"a\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-select *nzSpaceItem=\"\"></nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}