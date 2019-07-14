using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Zorro.Tables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 文本编辑列生成器测试
    /// </summary>
    public class TextEditColumnBuilderTest {
        /// <summary>
        /// 文本编辑列生成器
        /// </summary>
        private TextEditColumnBuilder _builder;
        /// <summary>
        /// 内容
        /// </summary>
        private readonly TagHelperContent _content;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextEditColumnBuilderTest() {
            _content = new DefaultTagHelperContent();
            _content.AppendHtml( "content" );
        }

        /// <summary>
        /// 列名为空, 内容为空
        /// </summary>
        [Fact]
        public void Test_1() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "", null, null );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 列名不为空,内容不为空
        /// </summary>
        [Fact]
        public void Test_2() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"editTableId.editId !== row.id;else templateId\">" );
            result.Append( "{{row.a}}" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #templateId=\"\">" );
            result.Append( "content" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "a", null, _content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 截断
        /// </summary>
        [Fact]
        public void Test_3() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"editTableId.editId !== row.id;else templateId\" " );
            result.Append( "nz-tooltip=\"\" [nzTitle]=\"(row.a|isTruncate:3)?row.a:''\">" );
            result.Append( "{{row.a|truncate:3}}" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #templateId=\"\">" );
            result.Append( "content" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "a", 3, _content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 列名不为空,内容为空
        /// </summary>
        [Fact]
        public void Test_4() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "{{row.a}}" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "a", null, null );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 列名为空,内容不为空
        /// </summary>
        [Fact]
        public void Test_5() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "content" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "", null, _content );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 不创建显示内容
        /// </summary>
        [Fact]
        public void Test_6() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "<ng-template #templateId=\"\">" );
            result.Append( "content" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "a", null, _content, false );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }

        /// <summary>
        /// 不创建控件
        /// </summary>
        [Fact]
        public void Test_7() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"editTableId.editId !== row.id;else templateId\">" );
            result.Append( "{{row.a}}" );
            result.Append( "</ng-container>" );
            result.Append( "content" );
            result.Append( "</td>" );

            _builder = new TextEditColumnBuilder( "editTableId", "templateId", "a", null, _content, true,false );
            _builder.Init();
            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
