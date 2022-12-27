using Util.Data.Queries;
using Xunit;

namespace Util.Data.Tests.Pages {
    /// <summary>
    /// 分页参数测试
    /// </summary>
    public class PagerTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public PagerTest() {
            _pager = new Pager();
        }

        /// <summary>
        /// 分页参数
        /// </summary>
        private readonly Pager _pager;

        /// <summary>
        /// 测试分页默认值
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Equal( 1, _pager.Page );
            Assert.Equal( 20, _pager.PageSize );
            Assert.Equal( 0, _pager.Total );
            Assert.Equal( 0, _pager.GetPageCount() );
            Assert.Equal( 0, _pager.GetSkipCount() );
            Assert.Equal( "", _pager.Order );
            Assert.Equal( 1, _pager.GetStartNumber() );
            Assert.Equal( 20, _pager.GetEndNumber() );
        }

        /// <summary>
        /// 测试总页数
        /// </summary>
        [Fact]
        public void TestPageCount() {
            _pager.Total = 0;
            Assert.Equal( 0, _pager.GetPageCount() );

            _pager.Total = 100;
            Assert.Equal( 5, _pager.GetPageCount() );

            _pager.Total = 1;
            Assert.Equal( 1, _pager.GetPageCount() );

            _pager.PageSize = 10;
            _pager.Total = 100;
            Assert.Equal( 10, _pager.GetPageCount() );
        }

        /// <summary>
        /// 测试页索引 - 小于1，则修正为1
        /// </summary>
        [Fact]
        public void TestPage() {
            _pager.Page = 0;
            Assert.Equal( 1, _pager.Page );

            _pager.Page = -1;
            Assert.Equal( 1, _pager.Page );
        }

        /// <summary>
        /// 测试跳过的行数
        /// </summary>
        [Fact]
        public void TestSkipCount() {
            _pager.Total = 100;

            _pager.Page = 0;
            Assert.Equal( 0, _pager.GetSkipCount() );

            _pager.Page = 1;
            Assert.Equal( 0, _pager.GetSkipCount() );

            _pager.Page = 2;
            Assert.Equal( 20, _pager.GetSkipCount() );

            _pager.Page = 3;
            Assert.Equal( 40, _pager.GetSkipCount() );

            _pager.Page = 4;
            Assert.Equal( 60, _pager.GetSkipCount() );

            _pager.Page = 5;
            Assert.Equal( 80, _pager.GetSkipCount() );

            _pager.Page = 6;
            Assert.Equal( 100, _pager.GetSkipCount() );

            _pager.Total = 99;

            _pager.Page = 0;
            Assert.Equal( 0, _pager.GetSkipCount() );

            _pager.Page = 1;
            Assert.Equal( 0, _pager.GetSkipCount() );

            _pager.Page = 2;
            Assert.Equal( 20, _pager.GetSkipCount() );

            _pager.Page = 3;
            Assert.Equal( 40, _pager.GetSkipCount() );

            _pager.Page = 4;
            Assert.Equal( 60, _pager.GetSkipCount() );

            _pager.Page = 5;
            Assert.Equal( 80, _pager.GetSkipCount() );

            _pager.Page = 6;
            Assert.Equal( 100, _pager.GetSkipCount() );

            _pager.Total = 0;
            _pager.Page = 1;
            Assert.Equal( 0, _pager.GetSkipCount() );
        }

        /// <summary>
        /// 测试起始和结束行数
        /// </summary>
        [Fact]
        public void TestGetStartNumber() {
            _pager.Page = 2;
            _pager.PageSize = 10;
            Assert.Equal( 11, _pager.GetStartNumber() );
            Assert.Equal( 20, _pager.GetEndNumber() );
        }
    }
}
