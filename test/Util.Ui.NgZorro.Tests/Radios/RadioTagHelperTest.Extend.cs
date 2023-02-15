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
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestData_1() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_group1.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), group.GetResult() );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
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
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "</nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
