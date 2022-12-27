using System.Collections.Generic;
using Util.Applications.Dtos;
using Util.Applications.Trees;
using Xunit;

namespace Util.Applications.Tests {
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
        /// 测试获取结果 - 添加一个根节点
        /// </summary>
        [Fact]
        public void TestGetResult_1() {
            //添加一个节点并获取结果
            var list = new List<TreeDto> { GetNode1() };
            var result = new TreeResult( list ).GetResult();

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
            var result = new TreeResult( list ).GetResult();

            //验证
            Assert.Single( result );

            var root = result[0];
            Assert.Equal( Id, root.Id );
            Assert.Single( root.Children );
            Assert.False( root.Leaf );

            var child = root.Children[0];
            Assert.Equal( Id2, child.Id );
            Assert.True( child.Leaf );
        }

        /// <summary>
        /// 测试获取结果 - 添加2个根节点，其中一个有子节点
        /// </summary>
        [Fact]
        public void TestGetResult_3() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3() };
            var result = new TreeResult( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root1 = result[0];
            Assert.Equal( Id, root1.Id );
            Assert.Single( root1.Children );
            Assert.Equal( Id2, root1.Children[0].Id );
            Assert.True( root1.Children[0].Leaf );

            Assert.Equal( Id3, result[1].Id );
            Assert.Empty( result[1].Children );
        }

        /// <summary>
        /// 测试获取结果 - 添加2个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_4() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4() };
            var result = new TreeResult( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root1 = result[0];
            Assert.Equal( Id, root1.Id );
            Assert.Equal( 2, root1.Children.Count );
            Assert.Equal( Id4, root1.Children[0].Id );
            Assert.True( root1.Children[0].Leaf );
            Assert.Equal( Id2, root1.Children[1].Id );
            Assert.True( root1.Children[1].Leaf );

            Assert.Equal( Id3, result[1].Id );
            Assert.True( result[1].Leaf );
        }

        /// <summary>
        /// 添加3级节点
        /// </summary>
        [Fact]
        public void TestGetResult_5() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4(), GetNode5() };
            var result = new TreeResult( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root1 = result[0];
            Assert.Equal( Id, root1.Id );
            Assert.Equal( 2, root1.Children.Count );

            Assert.Equal( Id4, root1.Children[0].Id );
            Assert.False( root1.Children[0].Leaf );

            Assert.Equal( Id2, root1.Children[1].Id );
            Assert.True( root1.Children[1].Leaf );

            Assert.Single( root1.Children[0].Children );
            Assert.Equal( Id5, root1.Children[0].Children[0].Id );
            Assert.True( root1.Children[0].Children[0].Leaf );

            Assert.Equal( Id3, result[1].Id );
        }
    }
}

