using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Zorro.Tables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 布尔列生成器测试
    /// </summary>
    public class BoolColumnBuilderTest {
        /// <summary>
        /// 布尔列生成器
        /// </summary>
        private BoolColumnBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public BoolColumnBuilderTest() {
            _builder = new BoolColumnBuilder( "a", null );
            _builder.Init();
        }

        /// <summary>
        /// 测试空值
        /// </summary>
        [Fact]
        public void TestEmpty() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "</td>" );

            _builder = new BoolColumnBuilder( "", null );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 测试设置列名
        /// </summary>
        [Fact]
        public void TestColumn() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "{{row.a?'是':'否'}}" );
            result.Append( "</td>" );

            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "content" );
            result.Append( "</td>" );

            var content = new DefaultTagHelperContent();
            content.AppendHtml( "content" );
            _builder = new BoolColumnBuilder( "a", content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
