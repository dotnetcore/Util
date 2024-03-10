using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格测试 - 表格设置启用固定列扩展
/// </summary>
public partial class TableTagHelperTest {
    /// <summary>
    /// 测试启用固定列
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_1() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用固定列 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_2() {
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        headRow.AppendContent( th );

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用固定列 - 固定到左侧
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_3() {
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Left, "true" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用固定列 - 固定到左侧 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_4() {
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.Left, true );
        headRow.AppendContent( th );

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用固定列 - 固定到右侧
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_5() {
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Right, true );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a','right':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用固定列 - 固定到右侧 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_6() {
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.Right, true );
        headRow.AppendContent( th );

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" [enableFixedColumn]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a','right':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}