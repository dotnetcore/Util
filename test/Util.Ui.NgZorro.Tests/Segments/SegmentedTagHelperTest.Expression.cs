using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Segments {
    /// <summary>
    /// 分段控制器测试 - 表达式解析测试
    /// </summary>
    public partial class SegmentedTagHelperTest {
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
            result.Append( "<nz-segmented #x_id=\"xSegmentedExtend\" (nzValueChange)=\"x_id.handleValueChange($event)\" " );
            result.Append( "name=\"enabled\" x-segmented-extend=\"\" [(ngModel)]=\"x_id.index\" [(value)]=\"model.enabled\" " );
            result.Append( "[data]=\"[{'text':'是','value':true,'sortId':1},{'text':'否','value':false,'sortId':2}]\" " );
            result.Append( "[nzOptions]=\"x_id.options\">" );
            result.Append( "</nz-segmented>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}