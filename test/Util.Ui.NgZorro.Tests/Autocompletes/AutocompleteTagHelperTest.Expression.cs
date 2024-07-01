using System.Text;
using Util.Ui.Configs;
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
            _wrapper.SetContextAttribute( UiConst.Id, "enabled" );
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #enabled=\"\" #x_enabled=\"xSelectExtend\" x-select-extend=\"\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\">" );
            result.Append( "@if(x_enabled.isGroup){" );
            result.Append( "@for(group of x_enabled.optionGroups;track group.text ){" );
            result.Append( "<nz-auto-optgroup [nzLabel]=\"group.text\">" );
            result.Append( "@for(item of group.value;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "}} @else {" );
            result.Append( "@for(item of x_enabled.options;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}}" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 布尔  - 多语言
        /// </summary>
        [Fact]
        public void TestFor_Bool_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Id, "enabled" );
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #enabled=\"\" #x_enabled=\"xSelectExtend\" x-select-extend=\"\" " );
            result.Append( "[data]=\"[{'text':'util.yes','value':true,'sortId':1},{'text':'util.no','value':false,'sortId':2}]\">" );
            result.Append( "@if(x_enabled.isGroup){" );
            result.Append( "@for(group of x_enabled.optionGroups;track group.text ){" );
            result.Append( "<nz-auto-optgroup [nzLabel]=\"group.text|i18n\">" );
            result.Append( "@for(item of group.value;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "}} @else {" );
            result.Append( "@for(item of x_enabled.options;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}}" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}