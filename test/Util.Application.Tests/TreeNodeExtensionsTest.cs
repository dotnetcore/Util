using System.Collections.Generic;
using Util.Applications.Trees;
using Xunit;

namespace Util.Applications {
    /// <summary>
    /// 树形节点扩展测试
    /// </summary>
    public class TreeNodeExtensionsTest {
        /// <summary>
        /// 测试获取缺失的父标识列表 - 1个根节点,不缺失
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_1() {
            var nodes = new List<ITreeNode> {
                new TreeNode1()
            };
            var result = nodes.GetMissingParentIds();
            Assert.Empty( result );
        }

        /// <summary>
        /// 测试获取缺失的父标识列表 - 1个2级节点,缺失根节点标识
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_2() {
            var nodes = new List<ITreeNode> {
                new TreeNode2()
            };
            var result = nodes.GetMissingParentIds();
            Assert.Single( result );
            Assert.Equal( "1", result[0] );
        }

        /// <summary>
        /// 测试获取缺失的父标识列表 - 2个节点,不缺失
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_3() {
            var nodes = new List<ITreeNode> {
                new TreeNode1(),
                new TreeNode2()
            };
            var result = nodes.GetMissingParentIds();
            Assert.Empty( result );
        }

        /// <summary>
        /// 测试获取缺失的父标识列表 - 1个3级节点,缺失
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_4() {
            var nodes = new List<ITreeNode> {
                new TreeNode3()
            };
            var result = nodes.GetMissingParentIds();
            Assert.Equal( 2,result.Count );
            Assert.Equal( "1", result[0] );
            Assert.Equal( "2", result[1] );
        }

        /// <summary>
        /// 测试获取缺失的父标识列表 - 1个4级节点,缺失
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_5() {
            var nodes = new List<ITreeNode> {
                new TreeNode5()
            };
            var result = nodes.GetMissingParentIds();
            Assert.Equal( 3, result.Count );
            Assert.Equal( "1", result[0] );
            Assert.Equal( "2", result[1] );
            Assert.Equal( "4", result[2] );
        }
    }
}
