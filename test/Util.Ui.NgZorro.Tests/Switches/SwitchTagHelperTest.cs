using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Switches;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Switches {
    /// <summary>
    /// 开关测试
    /// </summary>
    public partial class SwitchTagHelperTest {
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
        public SwitchTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SwitchTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-switch></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch #a=\"\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            _wrapper.SetContextAttribute( UiConst.Name, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch name=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            _wrapper.SetContextAttribute( AngularConst.BindName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [name]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzDisabled]=\"true\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzDisabled]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [(ngModel)]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中显示标签
        /// </summary>
        [Fact]
        public void TestCheckedChildren() {
            _wrapper.SetContextAttribute( UiConst.CheckedChildren, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch nzCheckedChildren=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中显示标签
        /// </summary>
        [Fact]
        public void TestBindCheckedChildren() {
            _wrapper.SetContextAttribute( AngularConst.BindCheckedChildren, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzCheckedChildren]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试未选中显示标签
        /// </summary>
        [Fact]
        public void TestUncheckedChildren() {
            _wrapper.SetContextAttribute( UiConst.UncheckedChildren, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch nzUnCheckedChildren=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试未选中显示标签
        /// </summary>
        [Fact]
        public void TestBindUncheckedChildren() {
            _wrapper.SetContextAttribute( AngularConst.BindUncheckedChildren, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzUnCheckedChildren]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, SwitchSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-switch nzSize=\"small\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzSize]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzLoading]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试用户控制状态
        /// </summary>
        [Fact]
        public void TestControl() {
            _wrapper.SetContextAttribute( UiConst.Control, true );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzControl]=\"true\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试用户控制状态
        /// </summary>
        [Fact]
        public void TestBindControl() {
            _wrapper.SetContextAttribute( AngularConst.BindControl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch [nzControl]=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch>a</nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch (ngModelChange)=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-switch (click)=\"a\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-switch *nzSpaceItem=\"\"></nz-switch>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
