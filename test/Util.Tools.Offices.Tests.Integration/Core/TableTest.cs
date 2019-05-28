using Util.Tools.Offices.Core;
using Xunit;

namespace Util.Tools.Offices.Tests.Integration.Core {
    /// <summary>
    /// 表格测试
    /// </summary>
    public class TableTest {
        /// <summary>
        /// 表格
        /// </summary>
        private readonly Table _table;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableTest() {
            _table = new Table();
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [Fact]
        public void Test_Default() {
            Assert.True( _table.GetHeader().Count == 0 );
            Assert.True( _table.GetBody().Count == 0 );
            Assert.Equal( 0, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumnNumber_1() {
            _table.AddBodyRow( "a" );
            Assert.Equal( 1, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumnNumber_2() {
            _table.AddBodyRow( "a", 2 );
            Assert.Equal( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumnNumber_3() {
            _table.AddHeadRow( "a" );
            Assert.Equal( 1, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumnNumber_4() {
            _table.AddHeadRow( "a", "b" );
            Assert.Equal( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumnNumber_5() {
            _table.AddHeadRow( "a", "b" );
            _table.AddBodyRow( "a", 2 );
            Assert.Equal( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [Fact]
        public void TestFirstRow_1() {
            _table.AddHeadRow( "a" );
            Assert.Equal( 1, _table.GetHeader()[0].ColumnNumber );
            _table.AddHeadRow( "b", "c" );
            Assert.Equal( 2, _table.GetHeader()[0].ColumnNumber );
        }

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [Fact]
        public void TestFirstRow_2() {
            _table.AddHeadRow( "a", "b" );
            Assert.Equal( 2, _table.GetHeader()[0].ColumnNumber );
            _table.AddHeadRow( "c", "d" );
            Assert.Equal( 2, _table.GetHeader()[0].ColumnNumber );
        }

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [Fact]
        public void TestFirstRow_3() {
            _table.AddHeadRow( "a" );
            Assert.Equal( 1, _table.GetHeader()[0].ColumnNumber );
            _table.AddBodyRow( "c", "d" );
            Assert.Equal( 2, _table.GetHeader()[0].ColumnNumber );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_1() {
            _table.AddHeadRow( "a" );
            Assert.True( _table.GetHeader().Count == 1 );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
            Assert.Equal( 1, _table.GetHeader()[0][0].ColumnSpan );
            Assert.Equal( 1, _table.GetHeader()[0][0].RowSpan );
            Assert.Equal( 0, _table.GetHeader()[0][0].RowIndex );
            Assert.Equal( 0, _table.GetHeader()[0][0].ColumnIndex );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_2() {
            _table.AddHeadRow( "a", "b" );
            Assert.True( _table.GetHeader().Count == 1, _table.GetHeader().Count.ToString() );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
            Assert.Equal( "b", _table.GetHeader()[0][1].Value );
            Assert.Equal( 1, _table.GetHeader()[0][1].ColumnSpan );
            Assert.Equal( 1, _table.GetHeader()[0][1].RowSpan );
            Assert.Equal( 0, _table.GetHeader()[0][1].RowIndex );
            Assert.Equal( 1, _table.GetHeader()[0][1].ColumnIndex );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_3() {
            _table.AddHeadRow( "a", "b" );
            _table.AddHeadRow( "c", "d" );
            Assert.True( _table.GetHeader().Count == 2, _table.GetHeader().Count.ToString() );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
            Assert.Equal( "b", _table.GetHeader()[0][1].Value );
            Assert.Equal( "c", _table.GetHeader()[1][0].Value );
            Assert.Equal( "d", _table.GetHeader()[1][1].Value );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_4() {
            _table.AddHeadRow( new Cell( "a" ) );
            Assert.True( _table.GetHeader().Count == 1 );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_5() {
            _table.AddHeadRow( "a" );
            _table.AddHeadRow( "a", "b" );
            Assert.True( _table.GetHeader().Count == 2 );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
            Assert.Equal( 2, _table.GetHeader()[0][0].ColumnSpan );
            Assert.Equal( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [Fact]
        public void TestAddHeadRow_6() {
            _table.AddHeadRow( new Cell( "a" ) );
            _table.AddHeadRow( new Cell( "a" ), new Cell( "b", 2 ) );
            Assert.True( _table.GetHeader().Count == 2 );
            Assert.Equal( "a", _table.GetHeader()[0][0].Value );
            Assert.Equal( 3, _table.GetHeader()[0][0].ColumnSpan );
            Assert.Equal( 3, _table.ColumnNumber );
        }

        /// <summary>
        /// 当设置行跨度时，将为受影响的行添加占位单元格
        /// </summary>
        [Fact]
        public void TestAddHeadRow_7() {
            _table.AddHeadRow( new Cell( "a", 1, 2 ) );
            Assert.True( _table.GetHeader().Count == 2, "==2" );
            Assert.Equal( 0, _table.GetHeader()[1][0].ColumnIndex );
            Assert.True( _table.GetHeader()[1][0].IsNull() );
        }

        /// <summary>
        /// 为受影响的行添加占位单元格
        /// </summary>
        [Fact]
        public void TestAddHeadRow_8() {
            _table.AddHeadRow( new Cell( "a", 1, 3 ), new Cell( "b", 1, 3 ), new Cell( "c", 1, 3 ), new Cell( "d", 2, 2 ) );
            _table.AddHeadRow( new Cell( "e", 2 ) );
            Assert.True( _table.GetHeader().Count == 3, "==3" );
            Assert.Equal( "e", _table.GetHeader()[1][4].Value.ToString() );
            Assert.Equal( 5, _table.GetHeader()[1][4].ColumnIndex );
        }

        /// <summary>
        /// 测试表头行数
        /// </summary>
        [Fact]
        public void TestHeadRowCount() {
            Assert.Equal( 0, _table.HeadRowCount );
            _table.AddHeadRow( "a", "b" );
            Assert.Equal( 1, _table.HeadRowCount );
            _table.AddHeadRow( "a", "b" );
            Assert.Equal( 2, _table.HeadRowCount );
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        [Fact]
        public void TestAddBodyRow() {
            Assert.Empty( _table.GetBody());
            _table.AddBodyRow( "a", 1 );
            Assert.Single( _table.GetBody());
            Assert.Equal( "a", _table.GetBody()[0][0].Value.ToString() );
            Assert.Equal( "1", _table.GetBody()[0][1].Value.ToString() );
            _table.AddBodyRow( "b" );
            Assert.Equal( 2, _table.GetBody().Count );
        }

        /// <summary>
        /// 测试总标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            Assert.Equal( "", _table.Title );
            _table.AddBodyRow( "a" );
            Assert.Equal( "", _table.Title );
            _table.AddHeadRow( "a", "b" );
            Assert.Equal( "", _table.Title );
            _table.ClearHeader();
            _table.AddHeadRow( "a" );
            Assert.Equal( "a", _table.Title );
            _table.AddHeadRow( "c", "d" );
            Assert.Equal( "a", _table.Title );
        }
    }
}
