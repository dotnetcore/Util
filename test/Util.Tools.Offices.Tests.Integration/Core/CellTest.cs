using System;
using Util.Tools.Offices.Core;
using Xunit;

namespace Util.Tools.Offices.Tests.Integration.Core {
    /// <summary>
    /// 单元格测试
    /// </summary>
    public class CellTest {
        /// <summary>
        /// 单元格
        /// </summary>
        private readonly Cell _cell;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CellTest() {
            _cell = new Cell( "a" ) {
                Row = new Row( 2 )
            };
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            Assert.Equal( "a",_cell.Value.ToString() );
        }

        /// <summary>
        /// 验证行为空时获取行索引
        /// </summary>
        [Fact]
        public void TestRowIndex_Validate_RowIsNull() {
            Assert.Throws<ArgumentNullException>( () => {
                _cell.Row = null;
                var index = _cell.RowIndex;
            } );
        }

        /// <summary>
        /// 测试行索引
        /// </summary>
        [Fact]
        public void TestRowIndex() {
            Assert.Equal( 2, _cell.RowIndex );
        }

        /// <summary>
        /// 测试列索引
        /// </summary>
        [Fact]
        public void TestColumnIndex() {
            Assert.Equal( 0,_cell.ColumnIndex );
        }

        /// <summary>
        /// 测试结束行索引
        /// </summary>
        [Fact]
        public void TestEndRowIndex() {
            Assert.Equal( 2, _cell.EndRowIndex );
            _cell.RowSpan = 2;
            Assert.Equal( 3, _cell.EndRowIndex );
            _cell.RowSpan = 0;
            Assert.Equal( 2, _cell.EndRowIndex );
            _cell.RowSpan = -1;
            Assert.Equal( 2, _cell.EndRowIndex );
        }

        /// <summary>
        /// 测试结束列索引
        /// </summary>
        [Fact]
        public void TestEndColumnIndex() {
            Assert.Equal( 0, _cell.EndColumnIndex );
            _cell.ColumnSpan = 2;
            Assert.Equal( 1, _cell.EndColumnIndex );
            _cell.ColumnSpan = 0;
            Assert.Equal( 0, _cell.EndColumnIndex );
            _cell.ColumnSpan = -1;
            Assert.Equal( 0, _cell.EndColumnIndex );
        }

        /// <summary>
        /// 测试是否需要合并
        /// </summary>
        [Fact]
        public void TestNeedMerge() {
            Assert.False( _cell.NeedMerge );
            _cell.RowSpan = 2;
            Assert.True( _cell.NeedMerge, "RowSpan = 2" );
            _cell.RowSpan = 1;
            _cell.ColumnSpan = 2;
            Assert.True( _cell.NeedMerge, "ColumnSpan = 2" );
            _cell.RowSpan = 2;
            _cell.ColumnSpan = 2;
            Assert.True( _cell.NeedMerge, "RowSpan = 2 && ColumnSpan = 2" );
        }
    }
}
