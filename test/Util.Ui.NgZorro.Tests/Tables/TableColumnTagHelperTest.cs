using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试
    /// </summary>
    public partial class TableColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableColumnTagHelperTest( ITestOutputHelper output ) {
            Id.SetId( "id" );
            _output = output;
            _wrapper = new TableColumnTagHelper().ToWrapper<Customer>();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<td></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示复选框
        /// </summary>
        [Fact]
        public void TestShowCheckbox() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
            var result = new StringBuilder();
            result.Append( "<td [nzShowCheckbox]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示复选框
        /// </summary>
        [Fact]
        public void TestBindShowCheckbox() {
            _wrapper.SetContextAttribute( AngularConst.BindShowCheckbox, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzShowCheckbox]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用复选框
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<td [nzDisabled]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用复选框
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzDisabled]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复选框是否中间状态
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            _wrapper.SetContextAttribute( UiConst.Indeterminate, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzIndeterminate]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestChecked() {
            _wrapper.SetContextAttribute( UiConst.Checked, true );
            var result = new StringBuilder();
            result.Append( "<td [nzChecked]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestBindChecked() {
            _wrapper.SetContextAttribute( AngularConst.BindChecked, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzChecked]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestBindonChecked() {
            _wrapper.SetContextAttribute( AngularConst.BindonChecked, "a" );
            var result = new StringBuilder();
            result.Append( "<td [(nzChecked)]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示展开按钮
        /// </summary>
        [Fact]
        public void TestShowExpand() {
            _wrapper.SetContextAttribute( UiConst.ShowExpand, true );
            var result = new StringBuilder();
            result.Append( "<td [nzShowExpand]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示展开按钮
        /// </summary>
        [Fact]
        public void TestBindShowExpand() {
            _wrapper.SetContextAttribute( AngularConst.BindShowExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzShowExpand]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否已展开
        /// </summary>
        [Fact]
        public void TestExpand() {
            _wrapper.SetContextAttribute( UiConst.Expand, true );
            var result = new StringBuilder();
            result.Append( "<td [nzExpand]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否已展开
        /// </summary>
        [Fact]
        public void TestBindExpand() {
            _wrapper.SetContextAttribute( AngularConst.BindExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzExpand]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否展开
        /// </summary>
        [Fact]
        public void TestBindonExpand() {
            _wrapper.SetContextAttribute( AngularConst.BindonExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<td [(nzExpand)]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左侧距离
        /// </summary>
        [Fact]
        public void TestLeft() {
            _wrapper.SetContextAttribute( UiConst.Left, true );
            var result = new StringBuilder();
            result.Append( "<td [nzLeft]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左侧距离
        /// </summary>
        [Fact]
        public void TestBindLeft() {
            _wrapper.SetContextAttribute( AngularConst.BindLeft, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzLeft]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右侧距离
        /// </summary>
        [Fact]
        public void TestRight() {
            _wrapper.SetContextAttribute( UiConst.Right, true );
            var result = new StringBuilder();
            result.Append( "<td [nzRight]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右侧距离
        /// </summary>
        [Fact]
        public void TestBindRight() {
            _wrapper.SetContextAttribute( AngularConst.BindRight, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzRight]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, TableHeadColumnAlign.Left );
            var result = new StringBuilder();
            result.Append( "<td nzAlign=\"left\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestBindAlign() {
            _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzAlign]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否折行显示
        /// </summary>
        [Fact]
        public void TestBreakWord() {
            _wrapper.SetContextAttribute( UiConst.BreakWord, true );
            var result = new StringBuilder();
            result.Append( "<td [nzBreakWord]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否折行显示
        /// </summary>
        [Fact]
        public void TestBindBreakWord() {
            _wrapper.SetContextAttribute( AngularConst.BindBreakWord, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzBreakWord]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动省略
        /// </summary>
        [Fact]
        public void TestEllipsis() {
            _wrapper.SetContextAttribute( UiConst.Ellipsis, true );
            var result = new StringBuilder();
            result.Append( "<td [nzEllipsis]=\"true\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动省略 - 自动设置表格布局
        /// </summary>
        [Fact]
        public void TestEllipsis_2() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题,内容,省略号
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Ellipsis, true );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table nzTableLayout=\"fixed\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td [nzEllipsis]=\"true\">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试自动省略
        /// </summary>
        [Fact]
        public void TestBindEllipsis() {
            _wrapper.SetContextAttribute( AngularConst.BindEllipsis, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzEllipsis]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缩进宽度
        /// </summary>
        [Fact]
        public void TestIndentSize() {
            _wrapper.SetContextAttribute( UiConst.IndentSize, 1 );
            var result = new StringBuilder();
            result.Append( "<td nzIndentSize=\"1\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缩进宽度
        /// </summary>
        [Fact]
        public void TestBindIndentSize() {
            _wrapper.SetContextAttribute( AngularConst.BindIndentSize, "a" );
            var result = new StringBuilder();
            result.Append( "<td [nzIndentSize]=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<td>a</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复选框选中状态变化事件
        /// </summary>
        [Fact]
        public void TestOnCheckedChange() {
            _wrapper.SetContextAttribute( UiConst.OnCheckedChange, "a" );
            var result = new StringBuilder();
            result.Append( "<td (nzCheckedChange)=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开状态变化事件
        /// </summary>
        [Fact]
        public void TestOnExpandChange() {
            _wrapper.SetContextAttribute( UiConst.OnExpandChange, "a" );
            var result = new StringBuilder();
            result.Append( "<td (nzExpandChange)=\"a\"></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}