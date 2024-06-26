﻿using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Textareas {
    /// <summary>
    /// 文本域测试 - 事件测试
    /// </summary>
    public partial class TextareaTagHelperTest {
        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea (ngModelChange)=\"a\" nz-input=\"\"></textarea>" );
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
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            _wrapper.SetContextAttribute( UiConst.OnBlur, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea (blur)=\"a\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试回车事件
        /// </summary>
        [Fact]
        public void TestOnKeyupEnter() {
            _wrapper.SetContextAttribute( UiConst.OnKeyupEnter, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea (keyup.enter)=\"a\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试回车事件
        /// </summary>
        [Fact]
        public void TestOnKeydownEnter() {
            _wrapper.SetContextAttribute( UiConst.OnKeydownEnter, "a" );
            var result = new StringBuilder();
            result.Append( "<textarea (keydown.enter)=\"a\" nz-input=\"\"></textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}