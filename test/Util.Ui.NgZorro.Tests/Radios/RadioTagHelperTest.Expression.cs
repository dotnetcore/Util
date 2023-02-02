using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Radios {
    /// <summary>
    /// 单选框测试 - 表达式解析测试
    /// </summary>
    public partial class RadioTagHelperTest {
        /// <summary>
        /// 测试属性表达式 - 布尔值
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>" );
            result.Append( "启用" );
            result.Append( "</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" name=\"enabled\" nzName=\"enabled\" x-select-extend=\"\" [(ngModel)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'util.yes'|i18n,'value':true,'sortId':1},{'text':'util.no'|i18n,'value':false,'sortId':2}]\"" );
            result.Append( ">" );
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "</nz-radio-group>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 枚举值
        /// </summary>
        [Fact]
        public void TestFor_2() {
            _wrapper.SetExpression( t => t.Gender );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>" );
            result.Append( "性别" );
            result.Append( "</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-radio-group #x_id=\"xSelectExtend\" name=\"gender\" nzName=\"gender\" x-select-extend=\"\" [(ngModel)]=\"model.gender\" " );
            result.Append( "[data]=\"[{'text':'女','value':1,'sortId':1},{'text':'男','value':2,'sortId':2}]\"" );
            result.Append( ">" );
            result.Append( "<label *ngFor=\"let item of x_id.options\" nz-radio=\"\" [nzDisabled]=\"item.disabled\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</label>" );
            result.Append( "</nz-radio-group>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
