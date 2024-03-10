using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格测试 - 拖动调整列宽
/// </summary>
public partial class TableTagHelperTest {
    /// <summary>
    /// 测试启用拖动调整列宽 - 在单元格启用
    /// </summary>
    [Fact]
    public void TestEnableResizable_1() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.EnableResizable, true );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 在单元格启用 - 设置初始宽度
    /// </summary>
    [Fact]
    public void TestEnableResizable_2() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "100px" );
        column.SetContextAttribute( UiConst.EnableResizable, true );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a','100px')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a','width':'100px'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 在表头单元格启用
    /// </summary>
    [Fact]
    public void TestEnableResizable_3() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.EnableResizable, true );
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
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 在表头单元格启用 - 设置初始宽度
    /// </summary>
    [Fact]
    public void TestEnableResizable_4() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.Width, "100px" );
        th.SetContextAttribute( UiConst.EnableResizable, true );
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
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a','100px')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a','width':'100px'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 在表格启用
    /// </summary>
    [Fact]
    public void TestEnableResizable_5() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 在表格启用 - 多个列时最后一列不设置调整宽度手柄
    /// </summary>
    [Fact]
    public void TestEnableResizable_6() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Title, "c" );
        column2.SetContextAttribute( UiConst.Column, "d" );
        _wrapper.AppendContent( column2 );

        //创建列3
        var column3 = new TableColumnTagHelper().ToWrapper();
        column3.SetContextAttribute( UiConst.Title, "e" );
        column3.SetContextAttribute( UiConst.Column, "f" );
        _wrapper.AppendContent( column3 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'c')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('c')\" [titleAlign]=\"ts_id.getTitleAlign('c')\">" );
        result.Append( "c" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th [titleAlign]=\"ts_id.getTitleAlign('e')\">e</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('c')\" [nzEllipsis]=\"ts_id.getEllipsis('c')\">{{row.d}}</td>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('e')\" [nzEllipsis]=\"ts_id.getEllipsis('e')\">{{row.f}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'},{'title':'e'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 在表格启用 - 手工创建表头单元格
    /// </summary>
    [Fact]
    public void TestEnableResizable_7() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 在表格启用 - 手工创建表头单元格 - 多个列时最后一列不设置调整宽度手柄
    /// </summary>
    [Fact]
    public void TestEnableResizable_8() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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

        //创建表头单元格2
        var th2 = new TableHeadColumnTagHelper().ToWrapper();
        th2.SetContextAttribute( UiConst.Title, "c" );
        headRow.AppendContent( th2 );

        //创建表头单元格3
        var th3 = new TableHeadColumnTagHelper().ToWrapper();
        th3.SetContextAttribute( UiConst.Title, "e" );
        headRow.AppendContent( th3 );

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

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Column, "d" );
        row.AppendContent( column2 );

        //创建列3
        var column3 = new TableColumnTagHelper().ToWrapper();
        column3.SetContextAttribute( UiConst.Column, "f" );
        row.AppendContent( column3 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'c')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('c')\" [titleAlign]=\"ts_id.getTitleAlign('c')\">" );
        result.Append( "c" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th [titleAlign]=\"ts_id.getTitleAlign('e')\">e</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('c')\" [nzEllipsis]=\"ts_id.getEllipsis('c')\">{{row.d}}</td>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('e')\" [nzEllipsis]=\"ts_id.getEllipsis('e')\">{{row.f}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'},{'title':'e'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 在表格启用 - 同时启用自定义列
    /// </summary>
    [Fact]
    public void TestEnableResizable_9() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Title, "c" );
        column2.SetContextAttribute( UiConst.Column, "d" );
        _wrapper.AppendContent( column2 );

        //创建列3
        var column3 = new TableColumnTagHelper().ToWrapper();
        column3.SetContextAttribute( UiConst.Title, "e" );
        column3.SetContextAttribute( UiConst.Column, "f" );
        _wrapper.AppendContent( column3 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'c')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"c\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('c')\">" );
        result.Append( "c" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'e')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"e\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('e')\">" );
        result.Append( "e" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "<td nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('c')\" [nzEllipsis]=\"ts_id.getEllipsis('c')\">{{row.d}}</td>" );
        result.Append( "<td nzCellControl=\"e\" [nzAlign]=\"ts_id.getAlign('e')\" [nzEllipsis]=\"ts_id.getEllipsis('e')\">{{row.f}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'},{'title':'e'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 在表格启用 - 手工创建表头单元格 - 同时启用自定义列
    /// </summary>
    [Fact]
    public void TestEnableResizable_10() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

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

        //创建表头单元格2
        var th2 = new TableHeadColumnTagHelper().ToWrapper();
        th2.SetContextAttribute( UiConst.Title, "c" );
        headRow.AppendContent( th2 );

        //创建表头单元格3
        var th3 = new TableHeadColumnTagHelper().ToWrapper();
        th3.SetContextAttribute( UiConst.Title, "e" );
        headRow.AppendContent( th3 );

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

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Column, "d" );
        row.AppendContent( column2 );

        //创建列3
        var column3 = new TableColumnTagHelper().ToWrapper();
        column3.SetContextAttribute( UiConst.Column, "f" );
        row.AppendContent( column3 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'c')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"c\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('c')\">" );
        result.Append( "c" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'e')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"e\" nzPreview=\"\" [titleAlign]=\"ts_id.getTitleAlign('e')\">" );
        result.Append( "e" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "<td nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('c')\" [nzEllipsis]=\"ts_id.getEllipsis('c')\">{{row.d}}</td>" );
        result.Append( "<td nzCellControl=\"e\" [nzAlign]=\"ts_id.getAlign('e')\" [nzEllipsis]=\"ts_id.getEllipsis('e')\">{{row.f}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'},{'title':'e'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 修改表格设置组件名称
    /// </summary>
    [Fact]
    public void TestEnableResizable_11() {
        //配置表格设置组件标签
        NgZorroOptionsService.SetOptions( new NgZorroOptions { TableSettingsTag = "table-set" } );

        //设置存储键
        _wrapper.SetContextAttribute( UiConst.Key, "k" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.EnableResizable, true );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<table-set #ts_id=\"\" key=\"k\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</table-set>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}