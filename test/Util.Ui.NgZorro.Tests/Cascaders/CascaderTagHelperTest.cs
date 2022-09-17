using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cascaders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Cascaders {
    /// <summary>
    /// 级联选择测试
    /// </summary>
    public class CascaderTagHelperTest {
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
        public CascaderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CascaderTagHelper().ToWrapper();
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
            result.Append( "<nz-cascader></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzAllowClear]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowClear() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowClear, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzAllowClear]=\"Ab\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzAutoFocus]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzAutoFocus]=\"Ab\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试变更函数
        /// </summary>
        [Fact]
        public void TestChangeOn() {
            _wrapper.SetContextAttribute( UiConst.ChangeOn, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzChangeOn]=\"Ab\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择变更
        /// </summary>
        [Fact]
        public void TestChangeOnSelect() {
            _wrapper.SetContextAttribute( UiConst.ChangeOnSelect, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzChangeOnSelect]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择变更
        /// </summary>
        [Fact]
        public void TestBindChangeOnSelect() {
            _wrapper.SetContextAttribute( AngularConst.BindChangeOnSelect, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzChangeOnSelect]=\"Ab\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列类名
        /// </summary>
        [Fact]
        public void TestColumnClassName() {
            _wrapper.SetContextAttribute( UiConst.ColumnClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzColumnClassName=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列类名
        /// </summary>
        [Fact]
        public void TestBindColumnClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindColumnClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzColumnClassName]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzDisabled]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzDisabled]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开图标
        /// </summary>
        [Fact]
        public void TestExpandIcon() {
            _wrapper.SetContextAttribute( UiConst.ExpandIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzExpandIcon=\"account-book\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开图标
        /// </summary>
        [Fact]
        public void TestBindExpandIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzExpandIcon]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开方式
        /// </summary>
        [Fact]
        public void TestExpandTrigger() {
            _wrapper.SetContextAttribute( UiConst.ExpandTrigger, CascaderExpandTrigger.Hover );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzExpandTrigger=\"hover\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开方式
        /// </summary>
        [Fact]
        public void TestBindExpandTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzExpandTrigger]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签属性名
        /// </summary>
        [Fact]
        public void TestLabelProperty() {
            _wrapper.SetContextAttribute( UiConst.LabelProperty, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzLabelProperty=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签属性名
        /// </summary>
        [Fact]
        public void TestBindLabelProperty() {
            _wrapper.SetContextAttribute( AngularConst.BindLabelProperty, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzLabelProperty]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签渲染模板
        /// </summary>
        [Fact]
        public void TestLabelRender() {
            _wrapper.SetContextAttribute( UiConst.LabelRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzLabelRender]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试动态加载函数
        /// </summary>
        [Fact]
        public void TestLoadData() {
            _wrapper.SetContextAttribute( UiConst.LoadData, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzLoadData]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试浮层类名
        /// </summary>
        [Fact]
        public void TestMenuClassName() {
            _wrapper.SetContextAttribute( UiConst.MenuClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzMenuClassName=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试浮层类名
        /// </summary>
        [Fact]
        public void TestBindMenuClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindMenuClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzMenuClassName]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试浮层样式
        /// </summary>
        [Fact]
        public void TestMenuStyle() {
            _wrapper.SetContextAttribute( UiConst.MenuStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzMenuStyle=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试浮层样式
        /// </summary>
        [Fact]
        public void TestBindMenuStyle() {
            _wrapper.SetContextAttribute( AngularConst.BindMenuStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzMenuStyle]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzNotFoundContent=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzNotFoundContent]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项渲染模板
        /// </summary>
        [Fact]
        public void TestOptionRender() {
            _wrapper.SetContextAttribute( UiConst.OptionRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzOptionRender]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可选项数据源
        /// </summary>
        [Fact]
        public void TestOptions() {
            _wrapper.SetContextAttribute( UiConst.Options, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzOptions]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzPlaceHolder=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzPlaceHolder]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示箭头
        /// </summary>
        [Fact]
        public void TestShowArrow() {
            _wrapper.SetContextAttribute( UiConst.ShowArrow, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowArrow]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示箭头
        /// </summary>
        [Fact]
        public void TestBindShowArrow() {
            _wrapper.SetContextAttribute( AngularConst.BindShowArrow, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowArrow]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示输入框
        /// </summary>
        [Fact]
        public void TestShowInput() {
            _wrapper.SetContextAttribute( UiConst.ShowInput, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowInput]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示输入框
        /// </summary>
        [Fact]
        public void TestBindShowInput() {
            _wrapper.SetContextAttribute( AngularConst.BindShowInput, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowInput]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestShowSearch() {
            _wrapper.SetContextAttribute( UiConst.ShowSearch, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowSearch]=\"true\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestBindShowSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzShowSearch]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzSize=\"large\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzSize]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzSuffixIcon=\"account-book\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzSuffixIcon]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值属性名
        /// </summary>
        [Fact]
        public void TestValueProperty() {
            _wrapper.SetContextAttribute( UiConst.ValueProperty, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader nzValueProperty=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值属性名
        /// </summary>
        [Fact]
        public void TestBindValueProperty() {
            _wrapper.SetContextAttribute( AngularConst.BindValueProperty, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader [nzValueProperty]=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader (ngModelChange)=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试清除值事件
        /// </summary>
        [Fact]
        public void TestOnClear() {
            _wrapper.SetContextAttribute( UiConst.OnClear, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader (nzClear)=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示状态改变事件
        /// </summary>
        [Fact]
        public void TestOnVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader (nzVisibleChange)=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中状态改变事件
        /// </summary>
        [Fact]
        public void TestOnSelectionChange() {
            _wrapper.SetContextAttribute( UiConst.OnSelectionChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader (nzSelectionChange)=\"a\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-cascader>a</nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-cascader *nzSpaceItem=\"\"></nz-cascader>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}