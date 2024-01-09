using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tags;

/// <summary>
/// 标签测试 - 表达式支持
/// </summary>
public partial class TagTagHelperTest {
    /// <summary>
    /// 测试数据源
    /// </summary>
    [Fact]
    public void TestFor() {
        _wrapper.SetExpression( t => t.Gender );
        var result = new StringBuilder();
        result.Append( "<ng-container #x_id=\"xTagExtend\" x-tag-extend=\"\" " );
        result.Append( "[data]=\"[{'text':'util.female','value':1,'sortId':1},{'text':'util.male','value':2,'sortId':2}]\">" );
        result.Append( "<nz-tag *ngFor=\"let item of x_id.data\">" );
        result.Append( "{{item.text}}" );
        result.Append( "</nz-tag>" );
        result.Append( "</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}