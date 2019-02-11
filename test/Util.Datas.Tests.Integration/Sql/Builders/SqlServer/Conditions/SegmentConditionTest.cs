using Util.Datas.Queries;
using Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Conditions {
    /// <summary>
    /// 范围过滤条件测试
    /// </summary>
    public class SegmentConditionTest {
        /// <summary>
        /// 范围过滤条件
        /// </summary>
        private SegmentCondition _condition;

        /// <summary>
        /// 获取条件 - 包含两边
        /// </summary>
        [Fact]
        public void Test_1() {
            _condition = new SegmentCondition( "a","min","max", Boundary.Both );
            Assert.Equal( "a>=min And a<=max", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 包含左边
        /// </summary>
        [Fact]
        public void Test_2() {
            _condition = new SegmentCondition( "a", "min", "max",Boundary.Left );
            Assert.Equal( "a>=min And a<max", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 包含右边
        /// </summary>
        [Fact]
        public void Test_3() {
            _condition = new SegmentCondition( "a", "min", "max", Boundary.Right );
            Assert.Equal( "a>min And a<=max", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 都不包含
        /// </summary>
        [Fact]
        public void Test_4() {
            _condition = new SegmentCondition( "a", "min", "max", Boundary.Neither );
            Assert.Equal( "a>min And a<max", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 没有最大值
        /// </summary>
        [Fact]
        public void Test_5() {
            _condition = new SegmentCondition( "a", "min", "", Boundary.Both );
            Assert.Equal( "a>=min", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 没有最小值
        /// </summary>
        [Fact]
        public void Test_6() {
            _condition = new SegmentCondition( "a", "", "max", Boundary.Both );
            Assert.Equal( "a<=max", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 验证名称为空
        /// </summary>
        [Fact]
        public void Test_7() {
            _condition = new SegmentCondition( "", "min", "max", Boundary.Both );
            Assert.Null( _condition.GetCondition() );
        }
    }
}
