using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格单元格测试 - 表达式解析
/// </summary>
public partial class TableColumnTagHelperTest {
    /// <summary>
    /// 测试属性表达式
    /// </summary>
    [Fact]
    public void TestFor() {
        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>code</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.code}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 布尔类型
    /// </summary>
    [Fact]
    public void TestFor_2() {
        //配置获取表格布尔列内容操作
        var options = new NgZorroOptions();
        NgZorroOptionsService.SetOptions( options );
        options.GetTableColumnBoolContentAction = column => {
            var result = new StringBuilder();
            result.Append( "{{" );
            if ( options.EnableI18n )
                result.Append( $"(row.{column}?'{I18nKeys.Yes}':'{I18nKeys.No}')|i18n" );
            else
                result.Append( $"row.{column}?'是':'否'" );
            result.Append( "}}" );
            return result.ToString();
        };

        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Enabled );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>启用</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.enabled?'是':'否'}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 布尔类型 - 多语言
    /// </summary>
    [Fact]
    public void TestFor_3() {
        //配置获取表格布尔列内容操作
        var options = new NgZorroOptions { EnableI18n = true };
        NgZorroOptionsService.SetOptions( options );
        options.GetTableColumnBoolContentAction = column => {
            var result = new StringBuilder();
            result.Append( "{{" );
            if ( options.EnableI18n )
                result.Append( $"(row.{column}?'{I18nKeys.Yes}':'{I18nKeys.No}')|i18n" );
            else
                result.Append( $"row.{column}?'是':'否'" );
            result.Append( "}}" );
            return result.ToString();
        };

        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Enabled );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>{{'启用'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{(row.enabled?'util.yes':'util.no')|i18n}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 布尔类型
    /// </summary>
    [Fact]
    public void TestFor_4() {
        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Enabled );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>启用</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>" );
        result.AppendLine( "<i *ngIf=\"!row.enabled\" nz-icon nzType=\"close\"></i>" );
        result.AppendLine( "<i *ngIf=\"row.enabled\" nz-icon nzType=\"check\"></i>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 枚举类型
    /// </summary>
    [Fact]
    public void TestFor_5() {
        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Gender );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>性别</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>" );
        result.Append( "<ng-container *ngIf=\"row.gender===1\">util.female</ng-container>" );
        result.Append( "<ng-container *ngIf=\"row.gender===2\">util.male</ng-container>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 枚举类型 - 多语言
    /// </summary>
    [Fact]
    public void TestFor_6() {
        //启用多语言
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Gender );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>{{'性别'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>" );
        result.Append( "<ng-container *ngIf=\"row.gender===1\">{{'util.female'|i18n}}</ng-container>" );
        result.Append( "<ng-container *ngIf=\"row.gender===2\">{{'util.male'|i18n}}</ng-container>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 覆盖标题
    /// </summary>
    [Fact]
    public void TestFor_7() {
        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //设置标题
        _wrapper.SetContextAttribute( UiConst.Title, "c" );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.code}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 启用排序
    /// </summary>
    [Fact]
    public void TestFor_8() {
        //启用设置
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableTableSort = true } );

        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzSortOrderChange)=\"x_id.sortChange('code',$event)\" [nzShowSort]=\"true\" [nzSortFn]=\"true\">code</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.code}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }

    /// <summary>
    /// 测试属性表达式 - 启用排序 - 手工覆盖
    /// </summary>
    [Fact]
    public void TestFor_9() {
        //启用设置
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableTableSort = true } );

        //创建表格
        var table = new TableTagHelper().ToWrapper();

        //添加列
        table.AppendContent( _wrapper );

        //设置表达式
        _wrapper.SetExpression( UiConst.For, t => t.Code );

        //覆盖排序
        _wrapper.SetContextAttribute( UiConst.Sort, false );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>code</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.code}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), table.GetResult() );
    }
}