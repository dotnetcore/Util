using Util.Helpers;
using Util.Ui.Viser.Data;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Viser.Data {
    /// <summary>
    /// 图表数据测试
    /// </summary>
    public class ChartDataTest {
        /// <summary>
        /// 图表数据
        /// </summary>
        private readonly ChartData _data;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ChartDataTest() {
            _data = new ChartData();
        }

        /// <summary>
        /// 获取Json结果
        /// </summary>
        private string ToJson() {
            return _data.ToResult().ToString().Replace( Common.Line, "" ).Replace( " ", "" );
        }

        /// <summary>
        /// 添加图表项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            _data.Add( "a", 1 );
            Assert.Equal( "{\"columns\":[\"value\"],\"data\":[{\"name\":\"a\",\"value\":1}]}", ToJson() );
        }

        /// <summary>
        /// 添加图表项 - 2个图表项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            _data.Add( "a", 1 ).Add( "b", 2 );
            Assert.Equal( "{\"columns\":[\"value\"],\"data\":[{\"name\":\"a\",\"value\":1},{\"name\":\"b\",\"value\":2}]}", ToJson() );
        }

        /// <summary>
        /// 添加图表项 - 添加一个点
        /// </summary>
        [Fact]
        public void TestAdd_3() {
            _data.Add( "a", new Point( "b", 1 ) );
            Assert.Equal( "{\"columns\":[\"b\"],\"data\":[{\"name\":\"a\",\"b\":1}]}", ToJson() );
        }

        /// <summary>
        /// 添加图表项 - 添加2个点
        /// </summary>
        [Fact]
        public void TestAdd_4() {
            _data.Add( "a", new Point( "b", 1 ), new Point( "c", 2 ) );
            Assert.Equal( "{\"columns\":[\"b\",\"c\"],\"data\":[{\"name\":\"a\",\"b\":1,\"c\":2}]}", ToJson() );
        }
    }
}
