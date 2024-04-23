using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.TreeSelects {
    /// <summary>
    /// 树选择测试 - 表达式解析测试
    /// </summary>
    public partial class TreeSelectTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_code\">" );
            result.Append( "<nz-tree-select #code=\"\" #v_code=\"xValidationExtend\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nzVirtualHeight=\"300px\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [required]=\"true\">" );
            result.Append( "</nz-tree-select>" );
            result.Append( "<ng-template #vt_code=\"\">" );
            result.Append( "{{v_code.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - url加载
        /// </summary>
        [Fact]
        public void TestFor_2() {
            _wrapper.SetExpression( t => t.Code );
            _wrapper.SetContextAttribute( UiConst.Url,"a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_code\">" );
            result.Append( "<nz-tree-select #code=\"\" #v_code=\"xValidationExtend\" #x_code=\"xTreeExtend\" (nzExpandChange)=\"x_code.expandChange($event)\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nzVirtualHeight=\"300px\" requiredMessage=\"编码不能是空值\" url=\"a\" x-tree-extend=\"\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[loadKeys]=\"model.code\" [maxlength]=\"100\" [minlength]=\"10\" [nzNodes]=\"x_code.dataSource\" [required]=\"true\">" );
            result.Append( "</nz-tree-select>" );
            result.Append( "<ng-template #vt_code=\"\">" );
            result.Append( "{{v_code.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

