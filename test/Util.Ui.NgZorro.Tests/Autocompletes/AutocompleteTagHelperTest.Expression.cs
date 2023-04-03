using System.Text;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Autocompletes {
    /// <summary>
    /// 自动完成测试 - 表达式解析测试
    /// </summary>
    public partial class AutocompleteTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for - 布尔
        /// </summary>
        [Fact]
        public void TestFor_Bool() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\">" );
            result.Append( "<ng-container *ngIf=\"!x_id.isGroup\">" );
            result.Append( "<nz-auto-option *ngFor=\"let item of x_id.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_id.isGroup\">" );
            result.Append( "<nz-auto-optgroup *ngFor=\"let group of x_id.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-auto-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 布尔  - 多语言
        /// </summary>
        [Fact]
        public void TestFor_Bool_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\" " );
            result.Append( "[data]=\"[{'text':'util.yes','value':true,'sortId':1},{'text':'util.no','value':false,'sortId':2}]\">" );
            result.Append( "<ng-container *ngIf=\"!x_id.isGroup\">" );
            result.Append( "<nz-auto-option *ngFor=\"let item of x_id.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_id.isGroup\">" );
            result.Append( "<nz-auto-optgroup *ngFor=\"let group of x_id.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-auto-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}