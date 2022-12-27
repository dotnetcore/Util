using System.Collections.Generic;
using System.Linq;
using Util.Ui.NgZorro.Tests.Samples;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Data {
    /// <summary>
    /// 树形结果测试
    /// </summary>
    public class TreeResultTest {
        /// <summary>
        /// 标识
        /// </summary>
        public const string Id = "1";
        /// <summary>
        /// 标识2
        /// </summary>
        public const string Id2 = "2";
        /// <summary>
        /// 标识3
        /// </summary>
        public const string Id3 = "3";
        /// <summary>
        /// 标识4
        /// </summary>
        public const string Id4 = "4";
        /// <summary>
        /// 标识5
        /// </summary>
        public const string Id5 = "5";
        /// <summary>
        /// 标题
        /// </summary>
        public const string Title = "a";
        /// <summary>
        /// 标题2
        /// </summary>
        public const string Title2 = "b";
        /// <summary>
        /// 标题3
        /// </summary>
        public const string Title3 = "c";
        /// <summary>
        /// 标题4
        /// </summary>
        public const string Title4 = "d";
        /// <summary>
        /// 标题5
        /// </summary>
        public const string Title5 = "e";

        /// <summary>
        /// 获取节点1
        /// </summary>
        private TreeDto GetNode1() {
            return new TreeDto {
                Id = Id,
                Text = Title,
                Level = 1,
                Enabled = false,
                Expanded = true,
                Checked = true,
                DisableCheckbox = true,
                Selectable = false,
                Selected = true
            };
        }

        /// <summary>
        /// 获取节点2
        /// </summary>
        private TreeDto GetNode2() {
            return new TreeDto {
                Id = Id2,
                ParentId = Id,
                Text = Title2,
                Level = 2,
                Enabled = false,
                Expanded = true,
                Checked = true,
                DisableCheckbox = true,
                Selectable = false,
                Selected = true
            };
        }

        /// <summary>
        /// 获取节点3
        /// </summary>
        private TreeDto GetNode3() {
            return new TreeDto {
                Id = Id3,
                Text = Title3,
                Icon = "a",
                Level = 1,
                Enabled = false,
                Expanded = true,
                Checked = true,
                DisableCheckbox = true,
                Selectable = false,
                Selected = true
            };
        }

        /// <summary>
        /// 获取节点4
        /// </summary>
        private TreeDto GetNode4() {
            return new TreeDto {
                Id = Id4,
                ParentId = Id,
                Text = Title4,
                Level = 2,
                Enabled = false,
                Expanded = true,
                Checked = true,
                DisableCheckbox = true,
                Selectable = false,
                Selected = true
            };
        }

        /// <summary>
        /// 获取节点5
        /// </summary>
        private TreeDto GetNode5() {
            return new TreeDto {
                Id = Id5,
                ParentId = Id4,
                Text = Title5
            };
        }

        /// <summary>
        /// 添加一个节点
        /// </summary>
        [Fact]
        public void TestGetResult_1() {
            var list = new List<TreeDto> { GetNode1() };
            var result = list.ToTreeResult();
            Assert.Single( result.Nodes );
            var node = result.Nodes.First();
            Assert.Equal( Id, node.Key );
            Assert.Equal( Title, node.Title );
            Assert.True( node.Disabled, "node.IsDisabled" );
            Assert.True( node.Expanded,"node.IsExpanded" );
            Assert.True( node.Checked,"node.IsChecked" );
            Assert.True( node.DisableCheckbox,"node.IsDisableCheckbox" );
            Assert.False( node.Selectable,"node.IsSelectable" );
            Assert.True( node.Selected,"node.IsSelected" );
            Assert.True( node.IsLeaf,"node.IsLeaf" );
        }

        /// <summary>
        /// 添加一个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_2() {
            var list = new List<TreeDto> { GetNode1(), GetNode2() };
            var result = list.ToTreeResult();

            //根节点
            Assert.Single( result.Nodes );
            var root = result.Nodes.First();
            Assert.Equal( Id, root.Key );
            Assert.Equal( Title, root.Title );
            Assert.True( root.Disabled );
            Assert.True( root.Expanded );
            Assert.True( root.Checked );
            Assert.True( root.DisableCheckbox );
            Assert.False( root.Selectable );
            Assert.True( root.Selected );
            Assert.False( root.IsLeaf );

            //子节点
            Assert.Single( root.Children );
            var child = root.Children[0];
            Assert.Equal( Id2, child.Key );
            Assert.Equal( Title2, child.Title );
            Assert.True( child.Disabled );
            Assert.True( child.Expanded );
            Assert.True( child.Checked );
            Assert.True( child.DisableCheckbox );
            Assert.False( child.Selectable );
            Assert.True( child.Selected );
            Assert.True( child.IsLeaf );
        }

        /// <summary>
        /// 添加2个根节点，其中一个有子节点
        /// </summary>
        [Fact]
        public void TestGetResult_3() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3() };
            var result = list.ToTreeResult();

            //根节点1
            Assert.Equal( 2, result.Nodes.Count );
            var root = result.Nodes.First();
            Assert.Equal( Id, root.Key );
            Assert.Equal( Title, root.Title );
            Assert.True( root.Disabled );
            Assert.True( root.Expanded );
            Assert.True( root.Checked );
            Assert.True( root.DisableCheckbox );
            Assert.False( root.Selectable );
            Assert.True( root.Selected );
            Assert.False( root.IsLeaf );

            //根节点2
            var root2 = result.Nodes[1];
            Assert.Equal( Id3, root2.Key );
            Assert.Equal( Title3, root2.Title );
            Assert.Equal( "a", root2.Icon );
            Assert.True( root2.Disabled );
            Assert.True( root2.Expanded );
            Assert.True( root2.Checked );
            Assert.True( root2.DisableCheckbox );
            Assert.False( root2.Selectable );
            Assert.True( root2.Selected );
            Assert.True( root2.IsLeaf );

            //子节点
            Assert.Single( root.Children );
            var child = root.Children[0];
            Assert.Equal( Id2, child.Key );
            Assert.Equal( Title2, child.Title );
            Assert.True( child.Disabled );
            Assert.True( child.Expanded );
            Assert.True( child.Checked );
            Assert.True( child.DisableCheckbox );
            Assert.False( child.Selectable );
            Assert.True( child.Selected );
            Assert.True( child.IsLeaf );
        }

        /// <summary>
        /// 添加2个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_4() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4() };
            var result = list.ToTreeResult();

            //根节点
            Assert.Equal( 2, result.Nodes.Count );
            var root = result.Nodes.First();
            Assert.Equal( Id, root.Key );
            Assert.False( root.IsLeaf );

            //根节点2
            var root2 = result.Nodes[1];
            Assert.Equal( Id3, root2.Key );
            Assert.True( root2.IsLeaf );

            //子节点
            Assert.Equal( 2, root.Children.Count );
            var child = root.Children[0];
            Assert.Equal( Id2, child.Key );
            Assert.True( child.IsLeaf );

            //子节点2
            Assert.Equal( 2, root.Children.Count );
            var child2 = root.Children[1];
            Assert.Equal( Id4, child2.Key );
            Assert.True( child2.IsLeaf );
        }

        /// <summary>
        /// 添加3级节点
        /// </summary>
        [Fact]
        public void TestGetResult_5() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4(), GetNode5() };
            var result = list.ToTreeResult();

            //根节点
            Assert.Equal( 2, result.Nodes.Count );
            var root = result.Nodes.First();
            Assert.Equal( Id, root.Key );
            Assert.False( root.IsLeaf );

            //根节点2
            var root2 = result.Nodes[1];
            Assert.Equal( Id3, root2.Key );
            Assert.True( root2.IsLeaf );

            //子节点
            Assert.Equal( 2, root.Children.Count );
            var child = root.Children[0];
            Assert.Equal( Id2, child.Key );
            Assert.True( child.IsLeaf );

            //子节点2
            Assert.Equal( 2, root.Children.Count );
            var child2 = root.Children[1];
            Assert.Equal( Id4, child2.Key );
            Assert.False( child2.IsLeaf );

            //孙节点
            Assert.Single( child2.Children );
            var child3 = child2.Children[0];
            Assert.Equal( Id5, child3.Key );
            Assert.True( child3.IsLeaf );
        }

        /// <summary>
        /// 测试复选框选中节点的标识列表
        /// </summary>
        [Fact]
        public void TestCheckedKeys() {
            var node2 = GetNode2();
            node2.Checked = false;
            var list = new List<TreeDto> { GetNode1(), node2, GetNode3(), GetNode4(), GetNode5() };
            var result = list.ToTreeResult();

            Assert.Equal( Id, result.CheckedKeys[0] );
            Assert.Equal( Id3, result.CheckedKeys[1] );
            Assert.Equal( Id4, result.CheckedKeys[2] );
        }

        /// <summary>
        /// 测试选中节点的标识列表
        /// </summary>
        [Fact]
        public void TestSelectedKeys() {
            var node2 = GetNode2();
            node2.Selected = false;
            var list = new List<TreeDto> { GetNode1(), node2, GetNode3(), GetNode4(), GetNode5() };
            var result = list.ToTreeResult();

            Assert.Equal( Id, result.SelectedKeys[0] );
            Assert.Equal( Id3, result.SelectedKeys[1] );
            Assert.Equal( Id4, result.SelectedKeys[2] );
        }
    }
}

