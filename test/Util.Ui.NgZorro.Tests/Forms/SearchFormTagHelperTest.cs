using System.Text;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Components.Grids;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Forms;

/// <summary>
/// 表单测试 - 查询表单
/// </summary>
public class SearchFormTagHelperTest {
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
    public SearchFormTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SearchFormTagHelper().ToWrapper();
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
    /// 测试查询表单 - 2个栅格列 - 1个查询条件,1个查询操作
    /// </summary>
    [Fact]
    public void Test_1() {
        //添加1个查询条件
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"{span:expand?16:16}\" [nzMd]=\"{span:expand?12:12}\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"{span:expand?16:16}\" [nzXs]=\"24\" [nzXXl]=\"{span:expand?18:18}\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试查询表单 - 3个栅格列 - 2个查询条件,1个查询操作
    /// </summary>
    [Fact]
    public void Test_2() {
        //添加2个栅格列
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        var column2 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column2 );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"{span:expand?8:8}\" [nzMd]=\"{span:expand?24:24}\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"{span:expand?8:8}\" [nzXs]=\"24\" [nzXXl]=\"{span:expand?12:12}\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试查询表单 - 4个栅格列 - 3个查询条件,1个查询操作
    /// </summary>
    [Fact]
    public void Test_3() {
        //添加3个栅格列
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        var column2 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column2 );

        var column3 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column3 );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"{span:expand?24:24}\" [nzMd]=\"{span:expand?12:12}\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"{span:expand?24:24}\" [nzXs]=\"24\" [nzXXl]=\"{span:expand?6:6}\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试查询表单 - 5个栅格列 - 4个查询条件,1个查询操作
    /// </summary>
    [Fact]
    public void Test_4() {
        //添加4个栅格列
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        var column2 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column2 );

        var column3 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column3 );

        var column4 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column4 );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"{span:expand?16:24}\" [nzMd]=\"{span:expand?24:12}\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"{span:expand?16:24}\" [nzXs]=\"24\" [nzXXl]=\"{span:expand?24:6}\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试查询表单 - 初始显示2个条件,每行显示6个条件
    /// </summary>
    [Fact]
    public void Test_5() {
        //设置为查询表单
        _wrapper.SetContextAttribute( UiConst.ShowNumber, 2 );
        _wrapper.SetContextAttribute( UiConst.ColumnsNumber, 6 );

        //添加8个条件
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        var column2 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column2 );

        var column3 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column3 );

        var column4 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column4 );

        var column5 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column5 );

        var column6 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column6 );

        var column7 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column7 );

        var column8 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column8 );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div *ngIf=\"expand\" nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"4\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"{span:expand?8:8}\" [nzMd]=\"{span:expand?24:24}\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"{span:expand?8:8}\" [nzXs]=\"24\" [nzXXl]=\"{span:expand?16:16}\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试查询表单 - 手工覆盖操作按钮栅格属性
    /// </summary>
    [Fact]
    public void Test_6() {
        //添加2个栅格列
        var column = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column );

        var column2 = new ColumnTagHelper().ToWrapper();
        _wrapper.AppendContent( column2 );

        //添加查询操作
        var columnAction = new ColumnTagHelper().ToWrapper();
        columnAction.SetContextAttribute( UiConst.Md, "a" );
        columnAction.SetContextAttribute( UiConst.Lg, "a" );
        columnAction.SetContextAttribute( UiConst.Xl, "a" );
        columnAction.SetContextAttribute( UiConst.Xxl, "a" );
        _wrapper.AppendContent( columnAction );

        var result = new StringBuilder();
        result.Append( "<form nz-form=\"\">" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"8\" [nzMd]=\"12\" [nzSm]=\"24\" [nzXl]=\"8\" [nzXs]=\"24\" [nzXXl]=\"6\">" );
        result.Append( "</div>" );
        result.Append( "<div nz-col=\"\" [nzLg]=\"a\" [nzMd]=\"a\" [nzSm]=\"24\" " );
        result.Append( "[nzXl]=\"a\" [nzXs]=\"24\" [nzXXl]=\"a\">" );
        result.Append( "</div>" );
        result.Append( "</form>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}