﻿using System.Text;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.TagHelpers {
    /// <summary>
    /// ng-template模板测试
    /// </summary>
    public class TemplateTagHelperTest {
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
        public TemplateTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TemplateTagHelper().ToWrapper();
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
            result.Append( "<ng-template></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}