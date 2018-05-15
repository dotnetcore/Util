using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using NSubstitute;
using Util.Domains.Trees;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests {
    /// <summary>
    /// 扩展测试 - 树型扩展
    /// </summary>
    public partial class ExtensionTest {
        /// <summary>
        /// 检查空值，不为空则正常执行
        /// </summary>
        [Fact]
        public void TestSwapSort() {
            var entity = Substitute.For<ISortId>();
            var swapEntity = Substitute.For<ISortId>();
            entity.SortId = 1;
            swapEntity.SortId = 2;
            entity.SwapSort( swapEntity );
            Assert.Equal( 2,entity.SortId );
            Assert.Equal( 1, swapEntity.SortId );
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_TreeEntity_1() {
            var id = Guid.NewGuid();
            List<TreeEntitySample> samples = new EditableList<TreeEntitySample> {
                new TreeEntitySample(id,$"{id},")
            };
            var result = samples.GetMissingParentIds<TreeEntitySample,Guid,Guid?>();
            Assert.Empty( result );
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_TreeEntity_2() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            List<TreeEntitySample> samples = new EditableList<TreeEntitySample> {
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id}
            };
            var result = samples.GetMissingParentIds<TreeEntitySample, Guid, Guid?>();
            Assert.Single( result );
            Assert.Equal( id,result[0].ToGuid() );
        }

        /// <summary>
        /// 获取缺失的父标识列表 - 验证null
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_TreeEntity_3() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            List<TreeEntitySample> samples = new EditableList<TreeEntitySample> {
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id},null
            };
            var result = samples.GetMissingParentIds<TreeEntitySample, Guid, Guid?>();
            Assert.Single( result );
            Assert.Equal( id, result[0].ToGuid() );
        }

        /// <summary>
        /// 获取缺失的父标识列表 - 重复的实体
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_TreeEntity_4() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            List<TreeEntitySample> samples = new EditableList<TreeEntitySample> {
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id},
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id}
            };
            var result = samples.GetMissingParentIds<TreeEntitySample, Guid, Guid?>();
            Assert.Single( result );
            Assert.Equal( id, result[0].ToGuid() );
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        [Fact]
        public void TestGetMissingParentIds_TreeEntity_5() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            List<TreeEntitySample> samples = new EditableList<TreeEntitySample> {
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id},
                new TreeEntitySample(id3,$"{id},{id2},{id3}"){ParentId = id2},
                new TreeEntitySample(id2,$"{id},{id2},"){ParentId = id},
                new TreeEntitySample(id3,$"{id},{id2},{id3}"){ParentId = id2}
            };
            var result = samples.GetMissingParentIds<TreeEntitySample, Guid, Guid?>();
            Assert.Single( result );
            Assert.Equal( id, result[0].ToGuid() );
        }
    }
}
