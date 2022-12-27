using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格主体测试 - 自动创建嵌套结构
    /// </summary>
    public partial class TableBodyTagHelperTest {
        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个列,自动创建表格主体行
        /// </summary>
        [Fact]
        public void TestAutoCreate_1() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>a</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加表格主体行和一个列,不自动创建表格主体行
        /// </summary>
        [Fact]
        public void TestAutoCreate_2() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            _wrapper.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>a</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个列,取消自动创建
        /// </summary>
        [Fact]
        public void TestAutoCreate_3() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //取消自动创建
            _wrapper.SetContextAttribute( UiConst.EnableAutoCreate, "false" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<tbody>" );
            result.Append( "<td>a</td>" );
            result.Append( "</tbody>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}