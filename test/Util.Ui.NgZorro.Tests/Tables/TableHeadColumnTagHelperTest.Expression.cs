using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables; 

/// <summary>
/// 表头单元格测试  - 表达式支持
/// </summary>
public partial class TableHeadColumnTagHelperTest {
    /// <summary>
    /// 测试表达式
    /// </summary>
    [Fact]
    public void TestFor_1() {
        _wrapper.SetExpression( UiConst.For, t => t.Code );
        var result = new StringBuilder();
        result.Append( "<th>code</th>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试表达式 - 多语言
    /// </summary>
    [Fact]
    public void TestFor_2() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetExpression( UiConst.For, t => t.Code );
        var result = new StringBuilder();
        result.Append( "<th>{{'code'|i18n}}</th>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试表达式 - 覆盖标题
    /// </summary>
    [Fact]
    public void TestFor_3() {
        _wrapper.SetExpression( UiConst.For, t => t.Code );
        _wrapper.SetContextAttribute( UiConst.Title, "c" );
        var result = new StringBuilder();
        result.Append( "<th>c</th>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 启用排序
    /// </summary>
    [Fact]
    public void TestFor_4() {
        //启用设置
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableTableSort = true } );
        _wrapper.SetItem( new TableShareConfig() );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //结果
        var result = new StringBuilder();
        result.Append( "<th (nzSortOrderChange)=\"x_id.sortChange('code',$event)\" [nzShowSort]=\"true\" [nzSortFn]=\"true\">code</th>" );

        //验证
        Assert.Equal( result.ToString(), _wrapper.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 启用排序 - 手工覆盖
    /// </summary>
    [Fact]
    public void TestFor_5() {
        //启用设置
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableTableSort = true } );
        _wrapper.SetItem( new TableShareConfig() );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //覆盖排序
        _wrapper.SetContextAttribute( UiConst.Sort, "" );

        //结果
        var result = new StringBuilder();
        result.Append( "<th>code</th>" );

        //验证
        Assert.Equal( result.ToString(), _wrapper.GetResult() );
    }
}