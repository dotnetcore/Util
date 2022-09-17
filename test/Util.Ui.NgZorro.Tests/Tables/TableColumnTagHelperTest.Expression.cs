using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试 - 表达式解析
    /// </summary>
    public partial class TableColumnTagHelperTest {
        /// <summary>
        /// 测试属性表达式
        /// </summary>
        [Fact]
        public void TestFor() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Code );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>编码</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>{{row.code}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }
    }
}