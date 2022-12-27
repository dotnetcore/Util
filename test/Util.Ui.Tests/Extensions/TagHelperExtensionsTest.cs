using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Extensions;
using Util.Ui.Tests.Samples;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.Extensions {
    /// <summary>
    /// TagHelper扩展测试
    /// </summary>
    public class TagHelperExtensionsTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TagHelperExtensionsTest( ITestOutputHelper output ) {
            _output = output;
        }

        /// <summary>
        /// 测试从items中获取值
        /// </summary>
        [Fact]
        public void TestGetValueFromItems_1() {
            var items = new Dictionary<object, object> { { "key", 1 } };
            var context = new TagHelperContext( new TagHelperAttributeList(), items, Id.Create() );
            Assert.Equal( 1, context.GetValueFromItems<int>( "key" ) );
        }

        /// <summary>
        /// 测试从items中获取值,泛型键
        /// </summary>
        [Fact]
        public void TestGetValueFromItems_2() {
            var items = new Dictionary<object, object> { { typeof( TestShareConfig ), new TestShareConfig( "1" ) } };
            var context = new TagHelperContext( new TagHelperAttributeList(), items, Id.Create() );
            Assert.Equal( "1", context.GetValueFromItems<TestShareConfig>().Id );
        }

        /// <summary>
        /// 测试从items中获取值,值为TagHelperAttribute类型
        /// </summary>
        [Fact]
        public void TestGetValueFromItems_3() {
            var items = new Dictionary<object, object> { { "key", new TagHelperAttribute( "", 1 ) } };
            var context = new TagHelperContext( new TagHelperAttributeList(), items, Id.Create() );
            Assert.Equal( 1, context.GetValueFromItems<int>( "key" ) );
        }

        /// <summary>
        /// 测试在items中设置值
        /// </summary>
        [Fact]
        public void TestSetValueToItems_1() {
            var context = new TagHelperContext( new TagHelperAttributeList(), new Dictionary<object, object>(), Id.Create() );
            context.SetValueToItems( "key", 1 );
            Assert.Equal( 1, context.GetValueFromItems<int>( "key" ) );
        }

        /// <summary>
        /// 测试在items中设置值,泛型
        /// </summary>
        [Fact]
        public void TestSetValueToItems_2() {
            var context = new TagHelperContext( new TagHelperAttributeList(), new Dictionary<object, object>(), Id.Create() );
            context.SetValueToItems( new TestShareConfig( "1" ) );
            Assert.Equal( "1", context.GetValueFromItems<TestShareConfig>().Id );
        }

        /// <summary>
        /// 测试在items中设置值,覆盖已存在的项
        /// </summary>
        [Fact]
        public void TestSetValueToItems_3() {
            var items = new Dictionary<object, object> { { "key", 1 } };
            var context = new TagHelperContext( new TagHelperAttributeList(), items, Id.Create() );
            context.SetValueToItems( "key", 2 );
            Assert.Equal( 2, context.GetValueFromItems<int>( "key" ) );
        }

        /// <summary>
        /// 测试从属性集合获取值
        /// </summary>
        [Fact]
        public void TestGetValueFromAttributes_1() {
            TagHelperAttributeList attributes = new TagHelperAttributeList { { "a", 1 }, { "b", true } };
            TagHelperContext context = new TagHelperContext( attributes, new Dictionary<object, object>(), Id.Create() );
            Assert.Equal( 1, context.GetValueFromAttributes<int>( "a" ) );
        }

        /// <summary>
        /// 测试从属性集合获取值
        /// </summary>
        [Fact]
        public void TestGetValueFromAttributes_2() {
            TagHelperAttributeList attributes = new TagHelperAttributeList { new TagHelperAttribute( "a",1 ), { "b", true } };
            TagHelperContext context = new TagHelperContext( attributes, new Dictionary<object, object>(), Id.Create() );
            Assert.Equal( 1, context.GetValueFromAttributes<int>( "a" ) );
        }
    }
}