using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头测试 - 自动创建嵌套结构
    /// </summary>
    public partial class TableHeadTagHelperTest {
        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个表头单元格,自动创建表头行
        /// </summary>
        [Fact]
        public void TestAutoCreate_1() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //创建表头单元格
            var column = new TableHeadColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个列,自动创建表头行和表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_2() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig{Columns = { new ColumnInfo{Title = "a"} }} );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加表头行和一个表头单元格,不自动创建
        /// </summary>
        [Fact]
        public void TestAutoCreate_3() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //创建表头行
            var row = new TableRowTagHelper().ToWrapper();
            _wrapper.AppendContent( row );

            //创建表头单元格
            var column = new TableHeadColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加表头行和一个列,自动创建表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_4() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig { Columns = { new ColumnInfo { Title = "a" } } } );

            //创建表头行
            var row = new TableRowTagHelper().ToWrapper();
            _wrapper.AppendContent( row );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加一个表头单元格,取消自动创建表头行
        /// </summary>
        [Fact]
        public void TestAutoCreate_5() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig() );

            //取消自动创建
            _wrapper.SetContextAttribute( UiConst.EnableAutoCreate, "false" );

            //创建表头单元格
            var column = new TableHeadColumnTagHelper().ToWrapper();
            column.AppendContent( "a" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<th>a</th>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加表头行和一个列,取消自动创建表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_6() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig { Columns = { new ColumnInfo { Title = "a" } } } );

            //取消自动创建
            _wrapper.SetContextAttribute( UiConst.EnableAutoCreate, "false" );

            //创建表头行
            var row = new TableRowTagHelper().ToWrapper();
            _wrapper.AppendContent( row );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 添加表头行和一个列,取消自动创建表头单元格
        /// </summary>
        [Fact]
        public void TestAutoCreate_7() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig { Columns = { new ColumnInfo { Title = "a" } } } );

            //创建表头行
            var row = new TableRowTagHelper().ToWrapper();
            _wrapper.AppendContent( row );

            //取消表头行自动创建
            row.SetContextAttribute( UiConst.EnableAutoCreate, "false" );

            //结果
            var result = new StringBuilder();
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}