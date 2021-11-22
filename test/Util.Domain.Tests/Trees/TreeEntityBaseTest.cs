using System;
using Util.Domain.Tests.Samples;
using Xunit;

namespace Util.Domain.Tests.Trees {
    /// <summary>
    /// 树形实体测试
    /// </summary>
    public class TreeEntityBaseTest {
        /// <summary>
        /// 测试初始化路径 - 1级
        /// </summary>
        [Fact]
        public void TestInitPath_1Level() {
            var id = Guid.NewGuid();
            var entity = new TreeEntitySample( id );
            entity.InitPath();
            Assert.Equal( 1, entity.Level );
            Assert.Equal( $"{id},", entity.Path );
        }

        /// <summary>
        /// 测试初始化路径 - 2级
        /// </summary>
        [Fact]
        public void TestInitPath_2Level() {
            var parentId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var parent = new TreeEntitySample( parentId );
            parent.InitPath();
            var child = new TreeEntitySample( id );
            child.InitPath( parent );
            Assert.Equal( 2, child.Level );
            Assert.Equal( $"{parentId},{id},", child.Path );
        }

        /// <summary>
        /// 测试初始化路径 - 3级
        /// </summary>
        [Fact]
        public void TestInitPath_3Level() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();
            var one = new TreeEntitySample( id );
            one.InitPath();
            var two = new TreeEntitySample( id2 );
            two.InitPath( one );
            var three = new TreeEntitySample( id3 );
            three.InitPath( two );
            Assert.Equal( 3, three.Level );
            Assert.Equal( $"{id},{id2},{id3},", three.Path );
        }

        /// <summary>
        /// 测试从路径中获取所有上级节点标识 - 空路径
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData( "" )]
        public void TestGetParentIdsFromPath_Empty( string path ) {
            var entity = new TreeEntitySample( Guid.NewGuid(), path );
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 测试从路径中获取所有上级节点标识  - 1级
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_1Level() {
            var entity = new TreeEntitySample( Guid.NewGuid() );
            entity.InitPath();
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 测试从路径中获取所有上级节点标识 - 2级
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_2Level() {
            var parentId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var parent = new TreeEntitySample( parentId );
            parent.InitPath();
            var entity = new TreeEntitySample( id );
            entity.InitPath( parent );
            Assert.Single( entity.GetParentIdsFromPath());
            Assert.Equal( parentId, entity.GetParentIdsFromPath()[0] );
        }

        /// <summary>
        /// 测试从路径中获取所有上级节点标识 - 忽略大小写
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_IgnoreCase() {
            Guid id = new Guid( "38F7F754-802F-4F54-925D-CC066483F9DA" );
            var entity = new TreeEntitySample( id, "38F7F754-802F-4F54-925D-CC066483F9da" );
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 测试从路径中获取所有上级节点标识 - 包含当前节点
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_ContainsSelf() {
            var entity = new TreeEntitySample( Guid.NewGuid() );
            entity.InitPath();
            Assert.Single( entity.GetParentIdsFromPath( false ));
        }
    }
}
