using System.Text;
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
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-tree-select #v_id=\"xValidationExtend\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nzVirtualHeight=\"300px\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[loadKeys]=\"model.code\" [maxlength]=\"100\" [minlength]=\"10\" [required]=\"true\">" );
            result.Append( "</nz-tree-select>" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

