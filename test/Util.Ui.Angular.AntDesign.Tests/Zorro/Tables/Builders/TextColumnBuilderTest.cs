using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Zorro.Tables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 文本列生成器测试
    /// </summary>
    public class TextColumnBuilderTest {
        /// <summary>
        /// 文本列生成器
        /// </summary>
        private TextColumnBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextColumnBuilderTest() {
            _builder = new TextColumnBuilder( "a",null, null );
            _builder.Init();
        }

        /// <summary>
        /// 测试空列
        /// </summary>
        [Fact]
        public void TestEmpty() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "</td>" );

            _builder = new TextColumnBuilder( "", null, null );
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
            result.Append( "{{row.a}}" );
            result.Append( "</td>" );

            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 测试截断
        /// </summary>
        [Fact]
        public void TestTrancate() {
            var result = new String();
            result.Append( "<td nz-tooltip=\"\" [nzTitle]=\"(row.a|isTruncate:3)?row.a:''\">" );
            result.Append( "{{row.a|truncate:3}}" );
            result.Append( "</td>" );

            _builder = new TextColumnBuilder( "a",3, null );
            _builder.Init();
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
            _builder = new TextColumnBuilder( "a", null, content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
