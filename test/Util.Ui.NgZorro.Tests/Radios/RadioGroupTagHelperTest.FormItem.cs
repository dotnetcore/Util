using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Checkboxes;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Radios {
    /// <summary>
    /// 单选框组合测试 - 表单项扩展测试
    /// </summary>
    public partial class RadioGroupTagHelperTest {
        /// <summary>
        /// 测试表单容器属性
        /// </summary>
        [Fact]
        public void TestFormContainer() {
            var checkbox = new CheckboxTagHelper().ToWrapper();
            checkbox.SetContextAttribute( UiConst.LabelText, "b" );
            _wrapper.AppendContent( checkbox );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>b</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-radio-group>" );
            result.Append( "<label nz-checkbox=\"\"></label>" );
            result.Append( "</nz-radio-group>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}