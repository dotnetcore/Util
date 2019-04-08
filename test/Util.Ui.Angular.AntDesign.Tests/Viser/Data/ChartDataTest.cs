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
        private string ToResultJson() {
            return FilterJson( _data.ToResult().ToString() );
        }

        /// <summary>
        /// 获取柱状图Json结果
        /// </summary>
        private string ToColumnResultJson() {
            return FilterJson( _data.ToColumnResult().ToString() );
        }

        /// <summary>
        /// 过滤Json结果
        /// </summary>
        private string FilterJson( string json ) {
            return json.Replace( Common.Line, "" ).Replace( " ", "" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        [Fact]
        public void TestToResult_1() {
            _data.Add( "a", 1 );
            Assert.Equal( "{\"columns\":[\"value\"],\"data\":[{\"name\":\"a\",\"value\":1.0}]}", ToResultJson() );
        }

        /// <summary>
        /// 获取结果 - 2个图表项
        /// </summary>
        [Fact]
        public void TestToResult_2() {
            _data.Add( "a", 1 ).Add( "b", 2 );
            Assert.Equal( "{\"columns\":[\"value\"],\"data\":[{\"name\":\"a\",\"value\":1.0},{\"name\":\"b\",\"value\":2.0}]}", ToResultJson() );
        }

        /// <summary>
        /// 获取结果 - 添加一个点
        /// </summary>
        [Fact]
        public void TestToResult_3() {
            _data.Add( "a", new Point( "b", 1 ) );
            Assert.Equal( "{\"columns\":[\"b\"],\"data\":[{\"name\":\"a\",\"b\":1.0}]}", ToResultJson() );
        }

        /// <summary>
        /// 获取结果 - 添加2个点
        /// </summary>
        [Fact]
        public void TestToResult_4() {
            _data.Add( "a", new Point( "b", 1 ), new Point( "c", 2 ) );
            Assert.Equal( "{\"columns\":[\"b\",\"c\"],\"data\":[{\"name\":\"a\",\"b\":1.0,\"c\":2.0}]}", ToResultJson() );
        }

        /// <summary>
        /// 获取结果 - 添加2个项4个点
        /// </summary>
        [Fact]
        public void TestToResult_5() {
            _data.Add( "a", new Point( "b", 1 ), new Point( "c", 2 ) );
            _data.Add( "d", new Point( "b", 3 ), new Point( "c", 4 ) );
            Assert.Equal( "{\"columns\":[\"b\",\"c\"],\"data\":[{\"name\":\"a\",\"b\":1.0,\"c\":2.0},{\"name\":\"d\",\"b\":3.0,\"c\":4.0}]}", ToResultJson() );
        }

        /// <summary>
        /// 获取柱状图结果
        /// </summary>
        [Fact]
        public void TestToColumnResult_1() {
            _data.Add( "a", 1 );
            Assert.Equal( "{\"columns\":[\"a\"],\"data\":[{\"name\":\"value\",\"a\":1.0}]}", ToColumnResultJson() );
        }

        /// <summary>
        /// 获取柱状图结果 - 2个图表项
        /// </summary>
        [Fact]
        public void TestToColumnResult_2() {
            _data.Add( "a", 1 ).Add( "b", 2 );
            Assert.Equal( "{\"columns\":[\"a\",\"b\"],\"data\":[{\"name\":\"value\",\"a\":1.0,\"b\":2.0}]}", ToColumnResultJson() );
        }

        /// <summary>
        /// 获取柱状图结果 - 添加一个点
        /// </summary>
        [Fact]
        public void TestToColumnResult_3() {
            _data.Add( "a", new Point( "b", 1 ) );
            Assert.Equal( "{\"columns\":[\"a\"],\"data\":[{\"name\":\"b\",\"a\":1.0}]}", ToColumnResultJson() );
        }

        /// <summary>
        /// 获取柱状图结果 - 添加3个项，每项2个点
        /// </summary>
        [Fact]
        public void TestToColumnResult_4() {
            _data.Add( "a1", new Point( "b", 1 ), new Point( "c", 2 ) );
            _data.Add( "a2", new Point( "b", 3 ), new Point( "c", 4 ) );
            _data.Add( "a3", new Point( "b", 5 ), new Point( "c", 6 ) );
            Assert.Equal( "{\"columns\":[\"a1\",\"a2\",\"a3\"],\"data\":[{\"name\":\"b\",\"a1\":1.0,\"a2\":3.0,\"a3\":5.0},{\"name\":\"c\",\"a1\":2.0,\"a2\":4.0,\"a3\":6.0}]}", ToColumnResultJson() );
        }
    }
}
