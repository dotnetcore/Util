using System.Collections.Generic;
using Util.Applications.Dtos;
using Util.Applications.Trees;
using Xunit;

namespace Util.Applications.Tests {
    /// <summary>
    /// 树形表格结果测试
    /// </summary>
    public class TreeTableResultTest {
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
        /// 标识6
        /// </summary>
        public const string Id6 = "6";
        /// <summary>
        /// 标识7
        /// </summary>
        public const string Id7 = "7";
        /// <summary>
        /// 标识8
        /// </summary>
        public const string Id8 = "8";

        /// <summary>
        /// 获取根节点1
        /// </summary>
        private TreeDto GetNode1() {
            return new TreeDto {
                Id = Id,
                Path = $"{Id},",
                Level = 1,
                Expanded = true,
                SortId = 1
            };
        }

        /// <summary>
        /// 获取子节点2,父节点为根节点1
        /// </summary>
        private TreeDto GetNode2() {
            return new TreeDto {
                Id = Id2,
                ParentId = Id,
                Path = $"{Id},{Id2},",
                Level = 2,
                Expanded = true,
                SortId = 2
            };
        }

        /// <summary>
        /// 获取根节点3
        /// </summary>
        private TreeDto GetNode3() {
            return new TreeDto {
                Id = Id3,
                Path = $"{Id3},",
                Level = 1,
                Expanded = true,
                SortId = 2
            };
        }

        /// <summary>
        /// 获取子节点4,父节点为根节点1
        /// </summary>
        private TreeDto GetNode4() {
            return new TreeDto {
                Id = Id4,
                ParentId = Id,
                Level = 2,
                Path = $"{Id},{Id4},",
                SortId = 1,
                Expanded = true
            };
        }

        /// <summary>
        /// 获取子节点5,父节点为节点4
        /// </summary>
        private TreeDto GetNode5() {
            return new TreeDto {
                Id = Id5,
                ParentId = Id4,
                Path = $"{Id},{Id4},{Id5},",
            };
        }

        /// <summary>
        /// 获取子节点6,父节点为根节点1
        /// </summary>
        private TreeDto GetNode6() {
            return new TreeDto {
                Id = Id6,
                ParentId = Id,
                Path = $"{Id},{Id6},",
                Level = 2,
                Expanded = true,
                SortId = 2
            };
        }

        /// <summary>
        /// 获取子节点7,父节点为节点6
        /// </summary>
        private TreeDto GetNode7() {
            return new TreeDto {
                Id = Id7,
                ParentId = Id6,
                Path = $"{Id},{Id6},{Id7},",
                Level = 3,
                Hide = true,
                SortId = 3
            };
        }

        /// <summary>
        /// 获取子节点8,父节点为节点6
        /// </summary>
        private TreeDto GetNode8() {
            return new TreeDto {
                Id = Id8,
                ParentId = Id6,
                Path = $"{Id},{Id6},{Id8},",
                Level = 3,
                Hide = true,
                SortId = 4
            };
        }

        /// <summary>
        /// 测试获取结果 - 添加一个根节点
        /// </summary>
        [Fact]
        public void TestGetResult_1() {
            //添加一个节点并获取结果
            var list = new List<TreeDto> { GetNode1() };
            var result = new TestTreeTableResult( list ).GetResult();

            //验证
            Assert.Single( result );
            var root = result[0];
            Assert.Equal( Id, root.Id );
            Assert.Empty( root.Children );
            Assert.True( root.Leaf );
        }

        /// <summary>
        /// 测试获取结果 - 添加一个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_2() {
            //添加根节点和它的子节点
            var list = new List<TreeDto> { GetNode1(), GetNode2() };
            var result = new TestTreeTableResult( list ).GetResult();

            //验证
            Assert.Equal( 2,result.Count );

            var root = result[0];
            Assert.Equal( Id, root.Id );
            Assert.Empty( root.Children );
            Assert.False( root.Leaf );

            var child = result[1];
            Assert.Equal( Id2, child.Id );
            Assert.True( child.Leaf );
        }

        /// <summary>
        /// 测试获取结果 - 添加2个根节点，其中一个有子节点
        /// </summary>
        [Fact]
        public void TestGetResult_3() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3() };
            var result = new TestTreeTableResult( list ).GetResult();
            Assert.Equal( 3, result.Count );

            var node1 = result[0];
            Assert.Equal( Id, node1.Id );

            var node2 = result[1];
            Assert.Equal( Id2, node2.Id );

            var node3 = result[2];
            Assert.Equal( Id3, node3.Id );
        }

        /// <summary>
        /// 添加2个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_4() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4() };
            var result = new TestTreeTableResult( list ).GetResult();
            Assert.Equal( 4, result.Count );

            var node1 = result[0];
            Assert.Equal( Id, node1.Id );

            var node4 = result[1];
            Assert.Equal( Id4, node4.Id );

            var node2 = result[2];
            Assert.Equal( Id2, node2.Id );

            var node3 = result[3];
            Assert.Equal( Id3, node3.Id );
        }

        /// <summary>
        /// 添加3级节点
        /// </summary>
        [Fact]
        public void TestGetResult_5() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4(), GetNode5() };
            var result = new TestTreeTableResult( list ).GetResult();
            Assert.Equal( 5, result.Count );

            var node1 = result[0];
            Assert.Equal( Id, node1.Id );

            var node4 = result[1];
            Assert.Equal( Id4, node4.Id );

            var node5 = result[2];
            Assert.Equal( Id5, node5.Id );

            var node2 = result[3];
            Assert.Equal( Id2, node2.Id );

            var node3 = result[4];
            Assert.Equal( Id3, node3.Id );
        }

        /// <summary>
        /// 测试隐藏属性 - 下级节点全部隐藏时,应设置为叶节点
        /// </summary>
        [Fact]
        public void TestGetResult_6() {
            var list = new List<TreeDto> { GetNode1(), GetNode6(), GetNode7(), GetNode8() };
            var result = new TestTreeTableResult( list ).GetResult();

            var node6 = result[1];
            Assert.Equal( Id6,node6.Id );
            Assert.True( node6.Leaf );
        }
    }
}

