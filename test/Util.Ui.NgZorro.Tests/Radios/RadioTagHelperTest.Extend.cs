using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Radios;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Radios {
    /// <summary>
    /// 单选框测试 - 指令扩展测试
    /// </summary>
    public partial class RadioTagHelperTest {
        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-radio=\"\">a</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签 - 多语言
        /// </summary>
        [Fact]
        public void TestLabel_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-radio=\"\">{{'a'|i18n}}</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-radio=\"\">{{a}}</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令
        /// </summary>
        [Fact]
        public void TestEnableExtend_1() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令 - 不启用
        /// </summary>
        [Fact]
        public void TestEnableExtend_2() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            var result = new StringBuilder();
            result.Append( "<label nz-radio=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试初始化时是否自动加载数据
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [autoLoad]=\"false\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.QueryParam, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [(queryParam)]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" order=\"a\" x-select-extend=\"\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestBindSort() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [order]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestData_1() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置数据源 - 多语言
        /// </summary>
        [Fact]
        public void TestData_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置数据源 - 设置了单选框组合,则不自动生成
        /// </summary>
        [Fact]
        public void TestData_2() {
            var group = new RadioGroupTagHelper().ToWrapper();
            group.SetContextAttribute( UiConst.Id, "group1" );
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            group.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #group1=\"\">" );
            result.Append( "@for(item of x_group1.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            var actual = group.GetResult();
            _output.WriteLine( actual );
            Assert.Equal( result.ToString(), actual );
        }

        /// <summary>
        /// 测试设置数据源 - Name
        /// </summary>
        [Fact]
        public void TestData_3() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            _wrapper.SetContextAttribute( UiConst.Name, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" name=\"b\" nzName=\"b\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置数据源 - BindName
        /// </summary>
        [Fact]
        public void TestData_4() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            _wrapper.SetContextAttribute( AngularConst.BindName, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\" [name]=\"b\" [nzName]=\"b\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置数据源 - OnModelChange
        /// </summary>
        [Fact]
        public void TestData_5() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" (ngModelChange)=\"b\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置Api地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" url=\"a\" x-select-extend=\"\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [url]=\"a\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据加载完成事件
        /// </summary>
        [Fact]
        public void TestOnLoad() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.OnLoad, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" (onLoad)=\"a\" x-select-extend=\"\">" );
            result.Append( "@for(item of x_id.options;track item.value ){" );
            result.Append( "<label nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "}" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
