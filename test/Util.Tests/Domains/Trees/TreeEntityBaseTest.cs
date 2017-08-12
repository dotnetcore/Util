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
            var child = new TreeEntitySample( id ) { Parent = parent };
            Assert.Same( parent, child.Parent );
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
            var two = new TreeEntitySample( twoId ) { Parent = one };
            var three = new TreeEntitySample( threeId ) { Parent = two };
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
            Assert.Equal( 0, entity.GetParentIdsFromPath().Count );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_1Level() {
            var entity = new TreeEntitySample( Guid.NewGuid() );
            entity.InitPath();
            Assert.Equal( 0, entity.GetParentIdsFromPath().Count );
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
            var entity = new TreeEntitySample( id ) { Parent = parent };
            Assert.Equal( 1, entity.GetParentIdsFromPath().Count );
            Assert.Equal( parentId, entity.GetParentIdsFromPath()[0] );
        }

        /// <summary>
        /// 忽略大小写
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_IgnoreCase() {
            Guid id = new Guid( "38F7F754-802F-4F54-925D-CC066483F9DA" );
            var entity = new TreeEntitySample( id, "38F7F754-802F-4F54-925D-CC066483F9da" );
            Assert.Equal( 0, entity.GetParentIdsFromPath().Count );
        }

        /// <summary>
        /// 包含当前节点
        /// </summary>
        [Fact]
        public void TestGetParentIdsFromPath_ContainsSelf() {
            Guid oneLevelId = Guid.NewGuid();
            var entity = new TreeEntitySample( oneLevelId );
            entity.InitPath();
            Assert.Equal( 1, entity.GetParentIdsFromPath( false ).Count );
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
            Assert.Null( child.Parent );
            Assert.Equal( 2, child.Level );
            Assert.Equal( $"{parentId},{id},", child.Path );
        }
    }
}
