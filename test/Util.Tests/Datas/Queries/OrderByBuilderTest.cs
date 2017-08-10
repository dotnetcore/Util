using Util.Datas.Queries;
using Xunit;

namespace Util.Tests.Datas.Queries {
    /// <summary>
    /// 测试排序生成器
    /// </summary>
    public class OrderByBuilderTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public OrderByBuilderTest() {
            _builder = new OrderByBuilder();
        }

        /// <summary>
        /// 排序生成器
        /// </summary>
        private readonly OrderByBuilder _builder;

        /// <summary>
        /// 测试生成排序
        /// </summary>
        [Fact]
        public void TestGenerate() {
            Assert.Equal( "", _builder.Generate() );
            _builder.Add( "" );
            _builder.Add( "A" );
            _builder.Add( "B", true );
            _builder.Add( "C.D", true );
            Assert.Equal( "A,B desc,C.D desc", _builder.Generate() );
        }
    }
}
