using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 随机数操作测试
    /// </summary>
    public class RandomTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RandomTest( ITestOutputHelper testOutputHelper ) {
            _testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// 测试从集合中随机获取值
        /// </summary>
        [Fact]
        public void TestGetValue() {
            var list = new List<int>();
            for ( int i = 0; i < 10; i++ ) {
                list.Add( i );
            }
            for ( int i = 0; i < 10; i++ ) {
                var a = Random.GetValue( list );
                var b = Random.GetValue( list );
                if ( a != b )
                    return;
            }
            Assert.Fail( "fail" );
        }

        /// <summary>
        /// 获取随机排序的集合
        /// </summary>
        [Fact]
        public void TestSort() {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var list = Util.Helpers.Random.Sort( input );
            var result = list.Join();
            Assert.Equal( 10, list.Distinct().Count() );
            Assert.NotEqual( "1,2,3,4,5,6,7,8,9,10", result );
            _testOutputHelper.WriteLine( result );
        }
    }
}
