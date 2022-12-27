using System;
using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Components.Mentions;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Textareas {
    /// <summary>
    /// 文本域测试
    /// </summary>
    public partial class TextareaTagHelperTest : IDisposable {
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
        public TextareaTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TextareaTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Id.Reset();
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
            result.Append( "<textarea nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [disabled]=\"true\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [disabled]=\"a\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadonly() {
            _wrapper.SetContextAttribute( UiConst.Readonly, true );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [readOnly]=\"true\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestBindReadonly() {
            _wrapper.SetContextAttribute( AngularConst.BindReadonly, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [readOnly]=\"a\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置占位符提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" placeholder=\"a\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置占位符提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [placeholder]=\"a\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行数
        /// </summary>
        [Fact]
        public void TestRows() {
            _wrapper.SetContextAttribute( UiConst.Rows, 1 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" rows=\"1\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行数
        /// </summary>
        [Fact]
        public void TestBindRows() {
            _wrapper.SetContextAttribute( AngularConst.BindRows, 1 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [rows]=\"1\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumns() {
            _wrapper.SetContextAttribute( UiConst.Columns, 1 );
            var result = new StringBuilder();
            result.Append( "<textarea cols=\"1\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestBindColumns() {
            _wrapper.SetContextAttribute( AngularConst.BindColumns, 1 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [cols]=\"1\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自适应内容高度
        /// </summary>
        [Fact]
        public void TestAutosize() {
            _wrapper.SetContextAttribute( UiConst.Autosize, true );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [nzAutosize]=\"true\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自适应内容高度
        /// </summary>
        [Fact]
        public void TestBindAutosize() {
            _wrapper.SetContextAttribute( AngularConst.BindAutosize, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [nzAutosize]=\"a\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小行数
        /// </summary>
        [Fact]
        public void TestMinRows() {
            _wrapper.SetContextAttribute( UiConst.MinRows, 3 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [nzAutosize]=\"{minRows:3}\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大行数
        /// </summary>
        [Fact]
        public void TestMaxRows() {
            _wrapper.SetContextAttribute( UiConst.MaxRows, 3 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [nzAutosize]=\"{maxRows:3}\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置最大行数和最小行数
        /// </summary>
        [Fact]
        public void TestMaxRows_MinRows() {
            _wrapper.SetContextAttribute( UiConst.MinRows, 1 ).SetContextAttribute( UiConst.MaxRows, 2 );
            var result = new StringBuilder();
            result.Append( "<textarea nz-input=\"\" [nzAutosize]=\"{minRows:1,maxRows:2}\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-group class=\"ant-input-affix-wrapper-textarea-with-clear-btn\" [nzSuffix]=\"clear_id\">" );
            result.Append( "<textarea #model_id=\"ngModel\" nz-input=\"\"></textarea>" );
            result.Append( "</nz-input-group>" );
            result.Append( "<ng-template #clear_id=\"\">" );
            result.Append( "<i (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-textarea-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></i>" );
            result.Append( "</ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入事件
        /// </summary>
        [Fact]
        public void TestOnInput() {
            _wrapper.SetContextAttribute( UiConst.OnInput, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea (input)=\"a\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提及触发元素
        /// </summary>
        [Fact]
        public void TestMentionTrigger() {
            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-mention>" );
            result.Append( "<textarea nz-input=\"\" nzMentionTrigger=\"\"></textarea>" );
            result.Append( "</nz-mention>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<textarea *nzSpaceItem=\"\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}