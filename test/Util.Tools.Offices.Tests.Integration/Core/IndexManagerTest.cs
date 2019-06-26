using Util.Tools.Offices.Core;
using Xunit;

namespace Util.Tools.Offices.Tests.Integration.Core {
    /// <summary>
    /// 索引管理器测试
    /// </summary>
    public class IndexManagerTest {
        /// <summary>
        /// 索引管理器
        /// </summary>
        private readonly IndexManager _manager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IndexManagerTest() {
            _manager = new IndexManager();
        }

        /// <summary>
        /// 获取索引
        /// </summary>
        [Fact]
        public void TestGetIndex() {
            Assert.Equal( 0, _manager.GetIndex() );
            Assert.Equal( 1, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [Fact]
        public void TestAddIndex() {
            _manager.AddIndex(1);
            Assert.Equal( 0, _manager.GetIndex() );
            Assert.Equal( 2, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [Fact]
        public void TestAddIndex_2() {
            Assert.Equal( 0, _manager.GetIndex(10) );
            _manager.AddIndex( 15 );
            Assert.Equal( 10, _manager.GetIndex(5) );
            Assert.Equal( 16, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [Fact]
        public void TestAddIndex_3() {
            _manager.AddIndex( 0 );
            _manager.AddIndex( 1 );
            _manager.AddIndex( 2,2 );
            Assert.Equal( 4, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [Fact]
        public void TestAddIndex_4() {
            _manager.AddIndex( 1 );
            _manager.AddIndex( 2, 2 );
            Assert.Equal( 0, _manager.GetIndex() );
        }
    }
}
