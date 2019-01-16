using Util.Reflections;
using Xunit;

namespace Util.Tests.Reflections {
    /// <summary>
    /// 类型查找器测试
    /// </summary>
    public class FinderTest {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;

        /// <summary>
        /// 初始化类型查找器测试
        /// </summary>
        public FinderTest() {
            _finder = new Finder();
        }

        /// <summary>
        /// 查找类型集合
        /// </summary>
        [Fact]
        public void TestFind() {
            var types = _finder.Find<IA>();
            Assert.Single( types );
            Assert.Equal( typeof( A ), types[0] );
        }

        /// <summary>
        /// 查找类型集合
        /// </summary>
        [Fact]
        public void TestFind_2() {
            var types = _finder.Find<IB>();
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( A ), types[0] );
            Assert.Equal( typeof( B ), types[1] );
        }

        /// <summary>
        /// 查找的结果类型包含泛型
        /// </summary>
        [Fact]
        public void TestFind_3() {
            var types = _finder.Find<IC>();
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( B ), types[0] );
            Assert.Equal( typeof( D<> ), types[1] );
        }

        /// <summary>
        /// 查找泛型类型
        /// </summary>
        [Fact]
        public void TestFind_4() {
            var types = _finder.Find<IG<E>>();
            Assert.Single( types );
            Assert.Equal( typeof( E ), types[0] );
        }

        /// <summary>
        /// 查找泛型类型
        /// </summary>
        [Fact]
        public void TestFind_5() {
            var types = _finder.Find( typeof( IG<> ) );
            Assert.Equal( 2, types.Count );
            Assert.Equal( typeof( E ), types[0] );
            Assert.Equal( typeof( F2<> ), types[1] );
        }

        /// <summary>
        /// 测试并发
        /// </summary>
        [Fact]
        public void TestFind_6() {
            Util.Helpers.Thread.ParallelExecute( () => {
                var types = _finder.Find<IA>();
                Assert.Single( types );
                Assert.Equal( typeof( A ), types[0] );
            }, () => {
                var types = _finder.Find<IB>();
                Assert.Equal( 2, types.Count );
                Assert.Equal( typeof( A ), types[0] );
                Assert.Equal( typeof( B ), types[1] );
            }, () => {
                var types = _finder.Find<IC>();
                Assert.Equal( 2, types.Count );
                Assert.Equal( typeof( B ), types[0] );
                Assert.Equal( typeof( D<> ), types[1] );
            } );
        }
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IA {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class A : IA, IB {
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IB {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class B : IB, IC {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public abstract class C : IB, IC {
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IC {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class D<T> : IC {
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IG<T> {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class E : IG<E> {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class F2<T> : IG<T> {
    }
}
