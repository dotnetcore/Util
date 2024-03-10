using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格测试 - 自定义列扩展
/// </summary>
public partial class TableTagHelperTest {
    /// <summary>
    /// 测试启用自定义列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_1() {
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_2() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置CellControl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_3() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.CellControl, "c" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"c\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'c'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_4() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "100px" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','width':'100px'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_5() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
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
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - th设置CellControl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_6() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
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
        th.SetContextAttribute( UiConst.CellControl, "c" );
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
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"c\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'c'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - td设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_7() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
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

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "100" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','width':'100'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - th设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_8() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Width, "100" );
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
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','width':'100'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加2列,自动创建表头
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_9() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列1
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Title, "c" );
        column2.SetContextAttribute( UiConst.Column, "d" );
        _wrapper.AppendContent( column2 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "<th nzCellControl=\"c\" [titleAlign]=\"ts_id.getTitleAlign('c')\">c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "<td nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('c')\" [nzEllipsis]=\"ts_id.getEllipsis('c')\">{{row.d}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置acl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_10() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Acl, "c" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th *aclIf=\"'c'\" nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td *aclIf=\"'c'\" nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','acl':'c'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 未设置key,使用id作为key
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_11() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Id, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #a=\"\" [nzBordered]=\"ts_a.bordered\" [nzCustomColumn]=\"ts_a.columns\" [nzScroll]=\"ts_a.scroll\" [nzSize]=\"ts_a.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_a.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_a.getAlign('a')\" [nzEllipsis]=\"ts_a.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_a=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 固定到左侧 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_12() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
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
        th.SetContextAttribute( UiConst.Left, "10px" );
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
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" nzLeft=\"10px\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 固定到右侧 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_13() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
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
        th.SetContextAttribute( UiConst.Right, "10px" );
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
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzRight=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" nzRight=\"10px\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','right':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}