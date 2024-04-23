using System;
using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Segments;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Segments {
    /// <summary>
    /// 分段控制器测试
    /// </summary>
    public partial class SegmentedTagHelperTest : IDisposable {
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
        public SegmentedTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SegmentedTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-segmented></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [(ngModel)]=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [nzDisabled]=\"true\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-segmented nzSize=\"large\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [nzSize]=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项列表
        /// </summary>
        [Fact]
        public void TestOptions() {
            _wrapper.SetContextAttribute( UiConst.Options, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [nzOptions]=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试将宽度调整为父元素宽度
        /// </summary>
        [Fact]
        public void TestBlock() {
            _wrapper.SetContextAttribute( UiConst.Block, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [nzBlock]=\"true\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented>a</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented (ngModelChange)=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值变更事件
        /// </summary>
        [Fact]
        public void TestOnValueChange() {
            _wrapper.SetContextAttribute( UiConst.OnValueChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented (valueChange)=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}