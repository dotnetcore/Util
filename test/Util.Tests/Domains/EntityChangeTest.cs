using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Domains {
    /// <summary>
    /// 测试获取变更属性集 - 实体
    /// </summary>
    public class EntityChangeTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public EntityChangeTest() {
            _sample = new AggregateRootSample();
            _sample.StringSample = new StringAggregateRootSample();
            _sample2 = new AggregateRootSample();
            _sample2.StringSample = new StringAggregateRootSample();
        }

        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private readonly AggregateRootSample _sample;
        /// <summary>
        /// 聚合根测试样例2
        /// </summary>
        private readonly AggregateRootSample _sample2;

        /// <summary>
        /// 测试获取变更属性集
        /// </summary>
        [Fact]
        public void TestGetChanges() {
            var changes = _sample.GetChanges( _sample2 );
            Assert.Empty( changes );

            _sample2.Name = "a";
            changes = _sample.GetChanges( _sample2 );
            Assert.Single( changes );
            Assert.Equal( "", changes[0].OldValue );
            Assert.Equal( "a", changes[0].NewValue );

            _sample.Name = "a";
            changes = _sample.GetChanges( _sample2 );
            Assert.Empty( changes );
        }

        /// <summary>
        /// 测试获取变更属性集
        /// </summary>
        [Fact]
        public void TestGetChanges_Lambda_Display() {
            _sample2.MobilePhone = "a";
            var changes = _sample.GetChanges( _sample2 );
            Assert.Single( changes );
            Assert.Equal( "MobilePhone", changes[0].PropertyName );
            Assert.Equal( "手机号", changes[0].Description );
            Assert.Equal( "", changes[0].OldValue );
            Assert.Equal( "a", changes[0].NewValue );
        }

        /// <summary>
        /// 测试获取变更属性集
        /// </summary>
        [Fact]
        public void TestGetChanges_Lambda_Description() {
            _sample2.Tel = 1;
            var changes = _sample.GetChanges( _sample2 );
            Assert.Single( changes );
            Assert.Equal( "Tel", changes[0].PropertyName );
            Assert.Equal( "电话", changes[0].Description );
            Assert.Equal( "0", changes[0].OldValue );
            Assert.Equal( "1", changes[0].NewValue );
        }

        /// <summary>
        /// 测试获取变更属性集 - 导航属性
        /// </summary>
        [Fact]
        public void TestGetChanges_Navigate() {
            _sample2.Name = "a";
            _sample2.StringSample.Name = "b";
            var changes = _sample.GetChanges( _sample2 );
            Assert.Equal( 2, changes.Count );
            Assert.Equal( "姓名", changes[0].Description );
            Assert.Equal( "", changes[0].OldValue );
            Assert.Equal( "a", changes[0].NewValue );
            Assert.Equal( "StringSampleName", changes[1].Description );
            Assert.Equal( "", changes[1].OldValue );
            Assert.Equal( "b", changes[1].NewValue );
        }

        /// <summary>
        /// 测试获取变更属性集 - 导航属性集合
        /// </summary>
        [Fact]
        public void TestGetChanges_NavigateCollection() {
            _sample.IntSamples.Add( new IntAggregateRootSample { Name = "a" } );
            _sample.IntSamples.Add( new IntAggregateRootSample() { Name = "b" } );
            _sample2.IntSamples.Add( new IntAggregateRootSample() { Name = "a2" } );
            _sample2.IntSamples.Add( new IntAggregateRootSample() { Name = "b2" } );
            var changes = _sample.GetChanges( _sample2 );
            Assert.Equal( 2, changes.Count );
            Assert.Equal( "a", changes[0].OldValue );
            Assert.Equal( "a2", changes[0].NewValue );
            Assert.Equal( "b", changes[1].OldValue );
            Assert.Equal( "b2", changes[1].NewValue );
        }
    }
}
