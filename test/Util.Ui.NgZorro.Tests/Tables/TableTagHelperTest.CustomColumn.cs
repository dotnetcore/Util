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
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );
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
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':180}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置CellControl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_3() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.CellControl, "c" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"c\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"c\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'c','default':true,'width':180}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_4() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "100" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':100}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置宽度 - px
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_5() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "100px" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':100}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置宽度 - %
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_6() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Width, "10%" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':100}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_7() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

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
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':180}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - th设置CellControl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_8() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

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
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"c\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"c\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'c','default':true,'width':180}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - td设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_9() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

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
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':100}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,设置完整结构 - th设置宽度
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_10() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

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
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':100}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加2列,自动创建表头
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_11() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

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
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "<th nzCellControl=\"c\">c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "<td nzCellControl=\"c\">{{row.d}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':180},{'value':'c','default':true,'width':180}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 添加1列,自动创建表头 - 设置acl
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_12() {
        //启用自定义列
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Acl, "c" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzCustomColumn]=\"ts_id.columns\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th *aclIf=\"'c'\" nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td *aclIf=\"'c'\" nzCellControl=\"a\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" customColumnKey=\"a\" " );
        result.Append( "[initColumns]=\"[{'value':'a','default':true,'width':180,'acl':'c'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}