using Util.Helpers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 测试反射操作
    /// </summary>
    public class ReflectionTest {
        /// <summary>
        /// 测试查找实现类型列表 - 测试类型中只有一个类实现IA接口
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_1() {
            var types = Reflection.FindImplementTypes<IA>( this.GetType().Assembly );
            Assert.Single( types );
            Assert.Equal( typeof( A ), types[0] );
        }

        /// <summary>
        /// 测试查找实现类型列表 - 抽象类和接口被排除
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_2() {
            var types = Reflection.FindImplementTypes<IB>( this.GetType().Assembly );
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( A ), types[0] );
            Assert.Equal( typeof( B ), types[1] );
        }

        /// <summary>
        /// 测试查找实现类型列表 - 泛型实现 
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_3() {
            var types = Reflection.FindImplementTypes<IC>( this.GetType().Assembly );
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( B ), types[0] );
            Assert.Equal( typeof( D<> ), types[1] );
        }

        /// <summary>
        /// 测试查找实现类型列表 - 泛型参数为E
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_4() {
            var types = Reflection.FindImplementTypes<IG<E>>( this.GetType().Assembly );
            Assert.Single( types );
            Assert.Equal( typeof( E ), types[0] );
        }

        /// <summary>
        /// 测试查找实现类型列表 - 泛型参数为空
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_5() {
            var types = Reflection.FindImplementTypes( typeof( IG<> ), this.GetType().Assembly );
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( E ), types[0] );
            Assert.Equal( typeof( F<> ), types[1] );
        }

        /// <summary>
        /// 测试查找实现类型列表 - 测试并发
        /// </summary>
        [Fact]
        public void TestFindImplementTypes_6() {
            Util.Helpers.Thread.ParallelInvoke( () => {
                var types = Reflection.FindImplementTypes<IA>( this.GetType().Assembly );
                Assert.Single( types );
                Assert.Equal( typeof( A ), types[0] );
            }, () => {
                var types = Reflection.FindImplementTypes<IB>( this.GetType().Assembly );
                Assert.Equal( 2, types.Count );
                Assert.Equal( typeof( A ), types[0] );
                Assert.Equal( typeof( B ), types[1] );
            }, () => {
                var types = Reflection.FindImplementTypes<IC>( this.GetType().Assembly );
                Assert.Equal( 2, types.Count );
                Assert.Equal( typeof( B ), types[0] );
                Assert.Equal( typeof( D<> ), types[1] );
            } );
        }
    }
}
