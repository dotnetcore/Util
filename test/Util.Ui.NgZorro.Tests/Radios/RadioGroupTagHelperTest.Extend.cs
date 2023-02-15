using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Radios;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Radios {
    /// <summary>
    /// 单选框组合测试 - 指令扩展测试
    /// </summary>
    public partial class RadioGroupTagHelperTest {
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
        /// 测试设置数据源 - 创建单选框,则不自动生成
        /// </summary>
        [Fact]
        public void TestData_2() {
            //设置数据源
            _wrapper.SetContextAttribute( UiConst.Data, "a" );

            //创建单选框
            var radio = new RadioTagHelper().ToWrapper();
            radio.SetContextAttribute( UiConst.Id, "radio1" );
            _wrapper.AppendContent( radio );

            //验证
            var result = new StringBuilder();
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "<label #radio1=\"\" nz-radio=\"\">" );
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