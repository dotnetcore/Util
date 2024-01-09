using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tags;

/// <summary>
/// 标签测试 - 扩展
/// </summary>
public partial class TagTagHelperTest {

    #region EnableExtend

    /// <summary>
    /// 测试启用扩展指令 - 不启用
    /// </summary>
    [Fact]
    public void TestEnableExtend() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-tag>" );
        result.Append( "</nz-tag>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region AutoLoad

    /// <summary>
    /// 测试初始化时是否自动加载数据
    /// </summary>
    [Fact]
    public void TestAutoLoad() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [autoLoad]=\"false\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region QueryParam

    /// <summary>
    /// 测试查询参数
    /// </summary>
    [Fact]
    public void TestQueryParam() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.QueryParam, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [(queryParam)]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region AllSelected

    /// <summary>
    /// 测试全部选中
    /// </summary>
    [Fact]
    public void TestAllSelected() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.AllSelected, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [(allSelected)]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region SelectedText

    /// <summary>
    /// 测试选中标签文本
    /// </summary>
    [Fact]
    public void TestSelectedText() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.SelectedText, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [(selectedText)]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region SelectedValue

    /// <summary>
    /// 测试选中标签文本
    /// </summary>
    [Fact]
    public void TestSelectedValue() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.SelectedValue, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [(selectedValue)]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region Url

    /// <summary>
    /// 测试Api地址
    /// </summary>
    [Fact]
    public void TestUrl_1() {
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" url=\"a\" x-tag-extend=\"\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试Api地址
    /// </summary>
    [Fact]
    public void TestBindUrl() {
        _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [url]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region Data

    /// <summary>
    /// 测试数据源
    /// </summary>
    [Fact]
    public void TestData() {
        _wrapper.SetContextAttribute( UiConst.Data, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [data]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试数据源
    /// </summary>
    [Fact]
    public void TestData_2() {
        _wrapper.SetContextAttribute( UiConst.Data, "a" );
        _wrapper.AppendContent( "b" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [data]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "b" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试数据源 - 多语言
    /// </summary>
    [Fact]
    public void TestData_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.Data, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [data]=\"a\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text|i18n}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region OnLoad

    /// <summary>
    /// 测试数据加载完成事件
    /// </summary>
    [Fact]
    public void TestOnLoad() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.OnLoad, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" (onLoad)=\"a\" x-tag-extend=\"\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region OnSelectedTextChange

    /// <summary>
    /// 测试选中文本变更事件
    /// </summary>
    [Fact]
    public void TestOnSelectedTextChange() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.OnSelectedTextChange, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" (selectedTextChange)=\"a\" x-tag-extend=\"\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region OnSelectedValueChange

    /// <summary>
    /// 测试选中值变更事件
    /// </summary>
    [Fact]
    public void TestOnSelectedValueChange() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.OnSelectedValueChange, "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" (selectedValueChange)=\"a\" x-tag-extend=\"\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region Checked

    /// <summary>
    /// 测试选中状态
    /// </summary>
    [Fact]
    public void TestCheckable_Checked() {
        _wrapper.SetContextAttribute( UiConst.Data, "a" );
        _wrapper.SetContextAttribute( UiConst.Mode, "checkable" );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" [data]=\"a\">" );
        result.Append( "<nz-tag (nzCheckedChange)=\"x_id.selectItem($event,item.text)\" *ngFor=\"let item of x_id.data\" nzMode=\"checkable\" [nzChecked]=\"item.selected\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion
}