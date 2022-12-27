using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格测试 - 自动创建嵌套结构
    /// </summary>
    public partial class TableTagHelperTest {
        /// <summary>
        /// 测试自动创建嵌套结构 - 仅添加一个列,将自动创建其它嵌套结构
        /// </summary>
        [Fact]
        public void TestAutoCreate_1() {
            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 设置完整结构,不生成
        /// </summary>
        [Fact]
        public void TestAutoCreate_2() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 仅生成表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_3() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 生成表头行和表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_4() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 生成表格主体行
        /// </summary>
        [Fact]
        public void TestAutoCreate_5() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            body.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 生成表格主体行和表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_6() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            body.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 生成表格主体行,表头行,表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_7() {
            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            body.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 生成表头行,表头单元格,表格主体
        /// </summary>
        [Fact]
        public void TestAutoCreate_8() {
            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            row.SetContextAttribute( UiConst.Id, "rowId" );
            _wrapper.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr #rowId=\"\">" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个列,取消自动创建
        /// </summary>
        [Fact]
        public void TestAutoCreate_9() {
            //取消自动创建
            _wrapper.SetContextAttribute( UiConst.EnableAutoCreate, "false" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<td>b</td>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}