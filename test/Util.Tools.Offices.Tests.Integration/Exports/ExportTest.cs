using System.Collections.Generic;
using Util.Tools.Offices.Npoi;
using Xunit;

namespace Util.Tools.Offices.Tests.Integration.Exports {
    /// <summary>
    /// Npoi导出测试
    /// </summary>
    public class ExportTest {
        /// <summary>
        /// 导出
        /// </summary>
        private readonly IExport _export;
        /// <summary>
        /// 列表
        /// </summary>
        private readonly IList<OfficeTest> _list;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ExportTest() {
            _export = ExportFactory.CreateExcel2007Export();
            _list = OfficeTest.CreateList();
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test_1() {
            _export.Body( _list )
                .Write( @"d:\" );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test_2() {
            _export.Head( "测试报表" )
                .Body( _list )
                .Write( @"d:\", "Test_2" );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test_3() {
            _export.Head( "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Body( _list )
                .Write( @"d:\", "Test_3" );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test_4() {
            _export.Head( "测试报表" )
                .Head( "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Body( _list )
                .Write( @"d:\", "Test_4" );
        }

        /// <summary>
        /// 测试自动设置属性列表
        /// </summary>
        [Fact]
        public void Test_5() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 11 ) )
                .Head( new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试",3 ) )
                .Head( "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Body( _list )
                .Write( @"d:\", "Test_5" );
        }

        /// <summary>
        /// 测试设置Lambda属性列表
        /// </summary>
        [Fact]
        public void Test_6() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 11 ) )
                .Head( new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 3 ) )
                .Head( "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Body( _list, t => new object[] { t.Test16, t.Test15, t.Test14, t.Test13, t.Test12, t.Test11, t.Test10, t.Test9, t.Test8, t.Test7, t.Test6, t.Test5, t.Test4, t.Test3, t.Test2, t.Test1 } )
                .Write( @"d:\", "Test_6" );
        }

        /// <summary>
        /// 测试设置字符串属性列表
        /// </summary>
        [Fact]
        public void Test_7() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 2 ) )
                .Head( new Cell( "测试", 2 ) )
                .Head( "测试", "测试", "测试", "测试" )
                .Body( _list, "Test1", "Test2", "Test3", "Test10", "Test11", "Test15", "Test4" )
                .Write( @"d:\", "Test_7" );
        }

        /// <summary>
        /// 测试设置页脚
        /// </summary>
        [Fact]
        public void Test_8() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 2 ) )
                .Head( new Cell( "测试", 2 ) )
                .Head( "测试", "测试", "测试", "测试" )
                .Body( _list, "Test1", "Test2", "Test3", "Test10", "Test11", "Test15", "Test4" )
                .Foot( "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Write( @"d:\", "Test_8" );
        }

        /// <summary>
        /// 测试设置页脚,带合并单元格
        /// </summary>
        [Fact]
        public void Test_9() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 2 ) )
                .Head( new Cell( "测试", 2 ) )
                .Head( "测试", "测试", "测试", "测试" )
                .Body( _list, "Test1", "Test2", "Test3", "Test10", "Test11", "Test15", "Test4" )
                .Foot( new Cell("合计",2,2),new Cell(100),new Cell(100),new Cell(100),new Cell(100,2) )
                .Foot( "测试", "测试", "测试", "测试", "测试" )
                .Write( @"d:\", "Test_9" );
        }
    }
}
