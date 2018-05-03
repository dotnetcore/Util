using System;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Domains.Trees {
    /// <summary>
    /// 测试树型实体
    /// </summary>
    public class TreeEntityBaseTest {
        /// <summary>
        /// 初始化一级节点，Guid标识
        /// </summary>
        [Fact]
        public void TestInitPath_1Level() {
            var id = Guid.NewGuid();
            var treeObject = new TreeEntitySample( id );
            treeObject.InitPath();
            Assert.Equal( 1, treeObject.Level );
            Assert.Equal( $"{id},", treeObject.Path );
        }

        /// <summary>
        /// 设置父节点
        /// </summary>
        [Fact]
        public void TestParent() {
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
        /// 设置父节点 - 3级
        /// </summary>
        [Fact]
        public void TestParent_3Level() {
            Guid oneId = Guid.NewGuid();
            Guid twoId = Guid.NewGuid();
            Guid threeId = Guid.NewGuid();
            var one = new TreeEntitySample( oneId );
            one.InitPath();
            var two = new TreeEntitySample( twoId );
            two.InitPath( one );
            var three = new TreeEntitySample( threeId );
            three.InitPath( two );
            Assert.Equal( 3, three.Level );
            Assert.Equal( $"{oneId},{twoId},{threeId},", three.Path );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData( "" )]
        public void TestGetParentIdsFromPath_Empty( string path ) {
            var entity = new TreeEntitySample( Guid.NewGuid(), path );
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_1Level() {
            var entity = new TreeEntitySample( Guid.NewGuid() );
            entity.InitPath();
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
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
        /// 忽略大小写
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_IgnoreCase() {
            Guid id = new Guid( "38F7F754-802F-4F54-925D-CC066483F9DA" );
            var entity = new TreeEntitySample( id, "38F7F754-802F-4F54-925D-CC066483F9da" );
            Assert.Empty( entity.GetParentIdsFromPath());
        }

        /// <summary>
        /// 包含当前节点
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_ContainsSelf() {
            Guid oneLevelId = Guid.NewGuid();
            var entity = new TreeEntitySample( oneLevelId );
            entity.InitPath();
            Assert.Single( entity.GetParentIdsFromPath( false ));
        }

        /// <summary>
        /// 测试初始化路径
        /// </summary>
        [Fact]
        public void TestInitPath() {
            var parentId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var parent = new TreeEntitySample( parentId );
            parent.InitPath();
            var child = new TreeEntitySample( id );
            child.InitPath( parent );
            Assert.Equal( 2, child.Level );
            Assert.Equal( $"{parentId},{id},", child.Path );
        }
    }
}
