using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Zorro.Tables.Builders;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 日期列生成器测试
    /// </summary>
    public class DateColumnBuilderTest {
        /// <summary>
        /// 日期列生成器
        /// </summary>
        private DateColumnBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DateColumnBuilderTest() {
            _builder = new DateColumnBuilder( "a","", null );
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

            _builder = new DateColumnBuilder( "","", null );
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
            result.Append( "{{ row.a | date:\"yyyy-MM-dd\" }}" );
            result.Append( "</td>" );

            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 测试设置日期格式
        /// </summary>
        [Fact]
        public void TestFormat() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "{{ row.a | date:\"b\" }}" );
            result.Append( "</td>" );

            _builder = new DateColumnBuilder( "a", "b", null );
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
            _builder = new DateColumnBuilder( "a","b", content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
