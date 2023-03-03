using System;
using System.Collections.Generic;
using Util.Domain.Compare;
using Util.Domain.Tests.Samples;
using Util.Domain.Tests.XUnitHelpers;
using Xunit;

namespace Util.Domain.Tests.Compare {
    /// <summary>
    /// 列表比较器测试
    /// </summary>
    public class ListComparatorTest {
        /// <summary>
        /// 列表比较器
        /// </summary>
        private readonly ListComparator<AggregateRootSample, Guid> _comparator;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ListComparatorTest() {
            _comparator = new ListComparator<AggregateRootSample, Guid>();
        }

        /// <summary>
        /// 测试列表比较 - 验证集合为空
        /// </summary>
        [Fact]
        public void TestCompare_Validate() {
            var list = new List<AggregateRootSample>();
            AssertHelper.Throws<ArgumentNullException>( () => {
                _comparator.Compare( null, list );
            } );
            AssertHelper.Throws<ArgumentNullException>( () => {
                _comparator.Compare( list, null );
            } );
            AssertHelper.Throws<ArgumentNullException>( () => {
                list.Compare( null );
            } );
        }

        /// <summary>
        /// 测试列表比较 - 获取创建列表
        /// </summary>
        [Fact]
        public void TestCompare_CreateList() {
            var id = Guid.NewGuid();
            var newList = new List<AggregateRootSample> {
                new(id){Name = "a"}
            };
            var result = _comparator.Compare( newList, new List<AggregateRootSample>() );
            Assert.Single( result.CreateList );
            Assert.Equal( "a", result.CreateList[0].Name );
        }

        /// <summary>
        /// 测试列表比较 - 获取删除列表
        /// </summary>
        [Fact]
        public void TestCompare_DeleteList() {
            var id = Guid.NewGuid();
            var oldList = new List<AggregateRootSample> {
                new(id){Name = "a"}
            };
            var result = _comparator.Compare( new List<AggregateRootSample>(), oldList );
            Assert.Empty( result.CreateList );
            Assert.Single( result.DeleteList );
            Assert.Equal( "a", result.DeleteList[0].Name );
        }

        /// <summary>
        /// 测试列表比较 - 获取更新列表
        /// </summary>
        [Fact]
        public void TestCompare_UpdateList() {
            var id = Guid.NewGuid();
            var newList = new List<AggregateRootSample> {
                new(id){Name = "a"}
            };
            var oldList = new List<AggregateRootSample> {
                new(id){Name = "b"}
            };
            var result = _comparator.Compare( newList, oldList );
            Assert.Empty( result.CreateList );
            Assert.Empty( result.DeleteList );
            Assert.Single( result.UpdateList );
            Assert.Equal( "a", result.UpdateList[0].Name );
        }

        /// <summary>
        /// 测试列表比较
        /// </summary>
        [Fact]
        public void TestCompare() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            var id4 = Guid.NewGuid();
            var newList = new List<AggregateRootSample> {
                new(id),
                new(id2),
                new(id3)
            };
            var oldList = new List<AggregateRootSample> {
                new(id2),
                new(id3),
                new(id4)
            };
            var result = newList.Compare( oldList );
            Assert.Single( result.CreateList );
            Assert.Equal( id, result.CreateList[0].Id );

            Assert.Single( result.DeleteList );
            Assert.Equal( id4, result.DeleteList[0].Id );

            Assert.Equal( 2, result.UpdateList.Count );
            Assert.Equal( id2, result.UpdateList[0].Id );
            Assert.Equal( id3, result.UpdateList[1].Id );
        }
    }
}
