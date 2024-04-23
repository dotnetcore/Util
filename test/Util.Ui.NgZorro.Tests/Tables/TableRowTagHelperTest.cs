using System.Text;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格行测试
/// </summary>
public class TableRowTagHelperTest {
    /// <summary>
    /// 输出工具
    /// </summary>
    private readonly ITestOutputHelper _output;
    /// <summary>
    /// TagHelper包装器
    /// </summary>
    private readonly TagHelperWrapper _wrapper;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public TableRowTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new TableRowTagHelper().ToWrapper();
        Id.SetId( "id" );
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult() {
        var result = _wrapper.GetResult();
        _output.WriteLine( result );
        return result;
    }

    /// <summary>
    /// 测试默认输出
    /// </summary>
    [Fact]
    public void TestDefault() {
        var result = new StringBuilder();
        result.Append( "<tr></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试当前列是否展开
    /// </summary>
    [Fact]
    public void TestExpand() {
        _wrapper.SetContextAttribute( UiConst.Expand, "a" );
        var result = new StringBuilder();
        result.Append( "<tr [nzExpand]=\"a\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击选中行
    /// </summary>
    [Fact]
    public void TestSelectOnClick() {
        _wrapper.SetContextAttribute( UiConst.SelectOnClick, true );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"x_id.toggleSelect(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击选中行 - 同时设置onclick
    /// </summary>
    [Fact]
    public void TestSelectOnClick_2() {
        _wrapper.SetContextAttribute( UiConst.SelectOnClick, true );
        _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"a;x_id.toggleSelect(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击仅选中一行
    /// </summary>
    [Fact]
    public void TestSelectOnlyOnClick() {
        _wrapper.SetContextAttribute( UiConst.SelectOnlyOnClick, true );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"x_id.selectRowOnly(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击仅选中一行 - 同时设置onclick
    /// </summary>
    [Fact]
    public void TestSelectOnlyOnClick_2() {
        _wrapper.SetContextAttribute( UiConst.SelectOnlyOnClick, true );
        _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"a;x_id.selectRowOnly(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试点击表格行时是否选中复选框或单选框 - 复选框
    /// </summary>
    [Fact]
    public void TestCheckOnClick_1() {
        _wrapper.SetItem(new TableShareConfig { IsShowCheckbox = true });
        _wrapper.SetContextAttribute( UiConst.CheckOnClick, true );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"x_id.toggle(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试点击表格行时是否选中复选框或单选框 - 单选框
    /// </summary>
    [Fact]
    public void TestCheckOnClick_2() {
        _wrapper.SetItem( new TableShareConfig { IsShowRadio = true } );
        _wrapper.SetContextAttribute( UiConst.CheckOnClick, true );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"x_id.checkRowOnly(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试勾选样式
    /// </summary>
    [Fact]
    public void TestEnableTableRowCheckedClass() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableTableRowCheckedClass = true } );
        var result = new StringBuilder();
        result.Append( "<tr [class.table-row-checked]=\"x_id.isChecked(row)\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试行单击事件
    /// </summary>
    [Fact]
    public void TestOnClick() {
        _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
        var result = new StringBuilder();
        result.Append( "<tr (click)=\"a\"></tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<tr>a</tr>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}