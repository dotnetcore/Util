using Util.Data.Tests.Samples;
using Xunit;

namespace Util.Data.Tests.Pages {
    /// <summary>
    /// 分页集合测试
    /// </summary>
    public class PagerListTest {
        /// <summary>
        /// 分页集合
        /// </summary>
        private readonly PageList<Sample> _list;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PagerListTest() {
            _list = new PageList<Sample>( 1, 2, 3, "Name" );
            _list.Add( Sample.Create1() );
            _list.Add( Sample.Create2() );
        }

        /// <summary>
        /// 测试集合
        /// </summary>
        [Fact]
        public void TestList() {
            Assert.Equal( 2, _list.Data.Count );
            Assert.Equal( "B", _list[1].StringValue );
        }

        /// <summary>
        /// 测试转换类型
        /// </summary>
        [Fact]
        public void TestConvert() {
            var result = _list.Convert( t => new Sample() );
            Assert.Equal( 2, result.Data.Count );
            Assert.Equal( 1, result.Page );
            Assert.Equal( 2, result.PageSize );
            Assert.Equal( 3, result.Total );
            Assert.Equal( 2, result.PageCount );
            Assert.Equal( "Name", result.Order );
        }
    }
}
