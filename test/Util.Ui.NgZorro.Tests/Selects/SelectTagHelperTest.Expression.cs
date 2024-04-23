using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选择器测试 - 表达式解析测试
    /// </summary>
    public partial class SelectTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for - 布尔
        /// </summary>
        [Fact]
        public void TestFor_Bool() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>启用</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-select #enabled=\"\" #x_enabled=\"xSelectExtend\" name=\"enabled\" x-select-extend=\"\" [(ngModel)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\">" );
            result.Append( "<ng-container *ngIf=\"!x_enabled.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_enabled.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_enabled.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_enabled.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-select>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
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
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>{{'启用'|i18n}}</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-select #enabled=\"\" #x_enabled=\"xSelectExtend\" name=\"enabled\" x-select-extend=\"\" [(ngModel)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'util.yes','value':true,'sortId':1},{'text':'util.no','value':false,'sortId':2}]\">" );
            result.Append( "<ng-container *ngIf=\"!x_enabled.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_enabled.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_enabled.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_enabled.optionGroups\" [nzLabel]=\"group.text|i18n\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-select>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 覆盖name
        /// </summary>
        [Fact]
        public void TestFor_Name() {
            _wrapper.SetExpression( t => t.Enabled );
            _wrapper.SetContextAttribute( UiConst.Name,"abc" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>启用</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-select #enabled=\"\" #x_enabled=\"xSelectExtend\" name=\"abc\" x-select-extend=\"\" [(ngModel)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\">" );
            result.Append( "<ng-container *ngIf=\"!x_enabled.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_enabled.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_enabled.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_enabled.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-select>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 设置[name]
        /// </summary>
        [Fact]
        public void TestFor_BindName() {
            _wrapper.SetExpression( t => t.Enabled );
            _wrapper.SetContextAttribute( AngularConst.BindName, "abc" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>启用</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-select #enabled=\"\" #x_enabled=\"xSelectExtend\" x-select-extend=\"\" [(ngModel)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\" [name]=\"abc\">" );
            result.Append( "<ng-container *ngIf=\"!x_enabled.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_enabled.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_enabled.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_enabled.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-select>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}