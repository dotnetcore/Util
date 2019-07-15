using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Zorro.TreeTables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格文本列生成器测试
    /// </summary>
    public class TextColumnBuilderTest {
        /// <summary>
        /// 测试空列
        /// </summary>
        [Fact]
        public void TestEmpty() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "</td>" );

            var builder = new TextColumnBuilder( "", null, null,false,null );
            builder.Init();
            Assert.Equal( result.ToString(), builder.ToString() );
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

            var builder = new TextColumnBuilder( "a", null, null,false, null );
            builder.Init();
            Assert.Equal( result.ToString(), builder.ToString() );
        }

        /// <summary>
        /// 测试设置列名，添加复选框
        /// </summary>
        [Fact]
        public void TestColumn_AddCheckbox() {
            var result = new String();
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"a.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"a.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*20\" " );
            result.Append( "[nzShowExpand]=\"!a.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"a.toggle(row)\" " );
            result.Append( "*ngIf=\"a.isShowCheckbox()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"a.isChecked(row)\" " );
            result.Append( "[nzIndeterminate]=\"a.isIndeterminate(row)\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</label>" );
            result.Append( "<label " );
            result.Append( "(click)=\"$event.stopPropagation()\" " );
            result.Append( "(ngModelChange)=\"a.checkRowOnly(row)\" " );
            result.Append( "*ngIf=\"a.isShowRadio(row)\" name=\"radio_a\" " );
            result.Append( "nz-radio=\"\" " );
            result.Append( "[ngModel]=\"a.isChecked(row)\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</label>" );
            result.Append( "<ng-container *ngIf=\"a.isShowText(row)\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</ng-container>" );
            result.Append( "</td>" );

            var builder = new TextColumnBuilder( "b", null, null, true, "a" );
            builder.Init();
            Assert.Equal( result.ToString(), builder.ToString() );
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

            var builder = new TextColumnBuilder( "a", 3, null,false, null );
            builder.Init();
            Assert.Equal( result.ToString(), builder.ToString() );
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
            var builder = new TextColumnBuilder( "a", null, content,false, null );
            builder.Init();
            Assert.Equal( result.ToString(), builder.ToString() );
        }
    }
}
