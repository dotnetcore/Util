using System.Collections.Generic;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Datas;
using Util.Ui.Tests.Samples;
using Xunit;

namespace Util.Ui.Tests.Prime.TreeTables.Datas {
    /// <summary>
    /// Prime树结果测试
    /// </summary>
    public class PrimeTreeResultTest {
        /// <summary>
        /// 测试获取结果，1个根节点，ParentId为空的是根节点
        /// </summary>
        [Fact]
        public void TestGetResult() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.Null( result[0].Leaf );
            result = treeNodes.ToPrimeResult();
            Assert.Single( result );
        }

        /// <summary>
        /// 测试获取结果 - 异步加载
        /// </summary>
        [Fact]
        public void TestGetResult_Async() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes, true );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.False( result[0].Leaf );
            result = treeNodes.ToPrimeResult();
            Assert.Single( result );
        }

        /// <summary>
        /// 测试获取结果，2个根节点，ParentId为空的是根节点
        /// </summary>
        [Fact]
        public void TestGetResult_2() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2"},
                new TreeNodeSample{Id = "3",ParentId = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Null( result[0].Leaf );
            Assert.Null( result[1].Leaf );
            Assert.Null( result[0].Children[0].Leaf );
            result = treeNodes.ToPrimeResult();
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试获取结果 - 异步加载
        /// </summary>
        [Fact]
        public void TestGetResult_2_Async() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2"},
                new TreeNodeSample{Id = "3",ParentId = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes,true );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.False( result[0].Leaf );
            Assert.False( result[1].Leaf );
            Assert.False( result[0].Children[0].Leaf );
            result = treeNodes.ToPrimeResult();
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试获取结果，1个根节点，ParentId有值，Level最小的是根节点
        /// </summary>
        [Fact]
        public void TestGetResult_3() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "2",ParentId = "1",Level = 1},
                new TreeNodeSample{Id = "3",ParentId = "4",Level = 2}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            result = treeNodes.ToPrimeResult();
            Assert.Single( result );
        }

        /// <summary>
        /// 测试获取结果，1个根节点
        /// </summary>
        [Fact]
        public void TestGetResult_4() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "2",ParentId = "1",Level = 2,Path = "1,2,"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.Equal( "2", result[0].Data.Id );
            Assert.Equal( "1", result[0].Data.ParentId );
            Assert.Equal( 2, result[0].Data.Level );
            Assert.Equal( "1,2,", result[0].Data.Path );
            result = treeNodes.ToPrimeResult();
            Assert.Single( result );
        }

        /// <summary>
        /// 测试获取结果，测试null
        /// </summary>
        [Fact]
        public void TestGetResult_5() {
            var treeResult = new PrimeTreeResult<TreeNodeSample>( null );
            var result = treeResult.GetResult();
            Assert.Empty( result );
        }

        /// <summary>
        /// 测试获取结果
        /// </summary>
        [Fact]
        public void TestGetResult_6() {
            var treeResult = new PrimeTreeResult<TreeNodeSample>( null );
            var result = treeResult.GetResult();
            Assert.Empty( result );
        }

        /// <summary>
        /// 测试获取结果，2级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_7() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Single( result[0].Children );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，2个2级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_8() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3"},
                new TreeNodeSample{Id = "4",ParentId = "3",Expanded = true}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Equal( "3", result[1].Data.Id );
            Assert.Single( result[0].Children );
            Assert.Single( result[1].Children );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Null( result[0].Children[0].Expanded );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
            Assert.Equal( "4", result[1].Children[0].Data.Id );
            Assert.True( result[1].Children[0].Expanded );
            Assert.Equal( "3", result[1].Children[0].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，1个根节点带2个子节点，1个根节点下没子节点
        /// </summary>
        [Fact]
        public void TestGetResult_9() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3"},
                new TreeNodeSample{Id = "4",ParentId = "1"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Equal( "3", result[1].Data.Id );
            Assert.Equal( 2, result[0].Children.Count );
            Assert.Null( result[1].Children );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
            Assert.Equal( "4", result[0].Children[1].Data.Id );
            Assert.Equal( "1", result[0].Children[1].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，3级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_10() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3",ParentId = "2"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Single( result[0].Children );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
            Assert.Single( result[0].Children[0].Children );
            Assert.Equal( "3", result[0].Children[0].Children[0].Data.Id );
            Assert.Equal( "2", result[0].Children[0].Children[0].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，3级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_11() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3",ParentId = "2"},
                new TreeNodeSample{Id = "4"},
                new TreeNodeSample{Id = "5",ParentId = "4"},
                new TreeNodeSample{Id = "6",ParentId = "5"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Single( result[0].Children );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
            Assert.Single( result[0].Children[0].Children );
            Assert.Equal( "3", result[0].Children[0].Children[0].Data.Id );
            Assert.Equal( "2", result[0].Children[0].Children[0].Data.ParentId );
            Assert.Equal( "4", result[1].Data.Id );
            Assert.Single( result[1].Children );
            Assert.Equal( "5", result[1].Children[0].Data.Id );
            Assert.Equal( "4", result[1].Children[0].Data.ParentId );
            Assert.Single( result[1].Children[0].Children );
            Assert.Equal( "6", result[1].Children[0].Children[0].Data.Id );
            Assert.Equal( "5", result[1].Children[0].Children[0].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，5级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_12() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3",ParentId = "2"},
                new TreeNodeSample{Id = "4"},
                new TreeNodeSample{Id = "5",ParentId = "3"},
                new TreeNodeSample{Id = "6",ParentId = "5"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "5", result[0].Children[0].Children[0].Children[0].Data.Id );
            Assert.Equal( "3", result[0].Children[0].Children[0].Children[0].Data.ParentId );
            Assert.Equal( "6", result[0].Children[0].Children[0].Children[0].Children[0].Data.Id );
            Assert.Equal( "5", result[0].Children[0].Children[0].Children[0].Children[0].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，2个2级嵌套节点
        /// </summary>
        [Fact]
        public void TestGetResult_13() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"},
                new TreeNodeSample{Id = "3",ParentId = "1"},
                new TreeNodeSample{Id = "4"},
                new TreeNodeSample{Id = "5",ParentId = "4"},
                new TreeNodeSample{Id = "6",ParentId = "4"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "1", result[0].Data.Id );
            Assert.Equal( "4", result[1].Data.Id );
            Assert.Equal( "2", result[0].Children[0].Data.Id );
            Assert.Equal( "1", result[0].Children[0].Data.ParentId );
            Assert.Equal( "3", result[0].Children[1].Data.Id );
            Assert.Equal( "1", result[0].Children[1].Data.ParentId );
            Assert.Equal( "5", result[1].Children[0].Data.Id );
            Assert.Equal( "4", result[1].Children[0].Data.ParentId );
            Assert.Equal( "6", result[1].Children[1].Data.Id );
            Assert.Equal( "4", result[1].Children[1].Data.ParentId );
        }

        /// <summary>
        /// 测试获取结果，未设置Id
        /// </summary>
        [Fact]
        public void TestGetResult_14() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Name = "a"}
            };
            var treeResult = new PrimeTreeResult<TreeNodeSample>( treeNodes );
            var result = treeResult.GetResult();
            Assert.Single( result );
            Assert.Equal( "a", result[0].Data.Name );
        }

        /// <summary>
        /// 测试获取结果，全部节点展开
        /// </summary>
        [Fact]
        public void TestGetResult_15() {
            var treeNodes = new List<TreeNodeSample> {
                new TreeNodeSample{Id = "1"},
                new TreeNodeSample{Id = "2",ParentId = "1"}
            };
            var result = treeNodes.ToPrimeResult( false, true );
            Assert.Single( result );
            Assert.True( result[0].Expanded );
            Assert.True( result[0].Children[0].Expanded );
        }
    }
}
