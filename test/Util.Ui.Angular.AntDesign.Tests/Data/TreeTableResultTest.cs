using System.Collections.Generic;
using Xunit;
using Util.Ui.Data;

namespace Util.Ui.Angular.AntDesign.Tests.Data {
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
        /// 获取节点1
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
        /// 获取节点2
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
        /// 获取节点3
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
        /// 获取节点4
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
        /// 获取节点5
        /// </summary>
        private TreeDto GetNode5() {
            return new TreeDto {
                Id = Id5,
                ParentId = Id4,
                Path = $"{Id},{Id4},{Id5},",
            };
        }

        /// <summary>
        /// 添加一个节点
        /// </summary>
        [Fact]
        public void TestGetResult_1() {
            var list = new List<TreeDto> { GetNode1() };
            var result = new TreeTableResult<TreeDto>( list ).GetResult();
            Assert.Single( result );

            var root = result[0];
            Assert.Equal( Id, root.Id );

            Assert.Single( root.Children );
            Assert.Equal( Id, root.Children[0].Id );
            Assert.True( root.Children[0].Leaf );
        }

        /// <summary>
        /// 添加一个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_2() {
            var list = new List<TreeDto> { GetNode1(), GetNode2() };
            var result = new TreeTableResult<TreeDto>( list ).GetResult();
            Assert.Single( result );

            var root = result[0];
            Assert.Equal( Id, root.Id );

            Assert.Equal( 2, root.Children.Count );

            Assert.Equal( Id, root.Children[0].Id );
            Assert.False( root.Children[0].Leaf );

            Assert.Equal( Id2, root.Children[1].Id );
            Assert.True( root.Children[1].Leaf );
        }

        /// <summary>
        /// 添加2个根节点，其中一个有子节点
        /// </summary>
        [Fact]
        public void TestGetResult_3() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3() };
            var result = new TreeTableResult<TreeDto>( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root = result[0];
            Assert.Equal( Id, root.Id );

            Assert.Equal( 2, root.Children.Count );

            Assert.Equal( Id, root.Children[0].Id );
            Assert.False( root.Children[0].Leaf );

            Assert.Equal( Id2, root.Children[1].Id );
            Assert.True( root.Children[1].Leaf );

            Assert.Equal( Id3, result[1].Id );
            Assert.Single( result[1].Children );
            Assert.Equal( Id3, result[1].Children[0].Id );
            Assert.True( result[1].Children[0].Leaf );
        }

        /// <summary>
        /// 添加2个子节点
        /// </summary>
        [Fact]
        public void TestGetResult_4() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4() };
            var result = new TreeTableResult<TreeDto>( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root = result[0];
            Assert.Equal( Id, root.Id );

            Assert.Equal( 3, root.Children.Count );

            Assert.Equal( Id, root.Children[0].Id );
            Assert.False( root.Children[0].Leaf );

            Assert.Equal( Id4, root.Children[1].Id );
            Assert.True( root.Children[1].Leaf );

            Assert.Equal( Id2, root.Children[2].Id );
            Assert.True( root.Children[2].Leaf );

            Assert.Equal( Id3, result[1].Id );
            Assert.Single( result[1].Children );
            Assert.Equal( Id3, result[1].Children[0].Id );
            Assert.True( result[1].Children[0].Leaf );
        }

        /// <summary>
        /// 添加3级节点
        /// </summary>
        [Fact]
        public void TestGetResult_5() {
            var list = new List<TreeDto> { GetNode1(), GetNode2(), GetNode3(), GetNode4(), GetNode5() };
            var result = new TreeTableResult<TreeDto>( list ).GetResult();
            Assert.Equal( 2, result.Count );

            var root = result[0];
            Assert.Equal( Id, root.Id );

            Assert.Equal( 4, root.Children.Count );

            Assert.Equal( Id, root.Children[0].Id );
            Assert.False( root.Children[0].Leaf );

            Assert.Equal( Id4, root.Children[1].Id );
            Assert.False( root.Children[1].Leaf );

            Assert.Equal( Id5, root.Children[2].Id );
            Assert.True( root.Children[2].Leaf );

            Assert.Equal( Id2, root.Children[3].Id );
            Assert.True( root.Children[3].Leaf );

            Assert.Equal( Id3, result[1].Id );
            Assert.Single( result[1].Children );
            Assert.Equal( Id3, result[1].Children[0].Id );
            Assert.True( result[1].Children[0].Leaf );
        }
    }
}

