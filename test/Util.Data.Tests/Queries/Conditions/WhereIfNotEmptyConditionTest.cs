using System;
using System.Linq.Expressions;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions {
    /// <summary>
    /// WhereIfNotEmpty条件测试
    /// </summary>
    public class WhereIfNotEmptyConditionTest {
        /// <summary>
        /// 测试有效条件
        /// </summary>
        [Fact]
        public void Test_Valid() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == "a";
            var condition = new WhereIfNotEmptyCondition<Sample>( expression );
            Assert.Equal( expression, condition.GetCondition() );
        }

        /// <summary>
        /// 测试忽略条件
        /// </summary>
        [Fact]
        public void Test_Ignore() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == "";
            var condition = new WhereIfNotEmptyCondition<Sample>( expression );
            Assert.Null( condition.GetCondition() );
        }

        /// <summary>
        /// 测试无效条件
        /// </summary>
        [Fact]
        public void Test_Invalid() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == "a" && t.IntValue == 1;
            var condition = new WhereIfNotEmptyCondition<Sample>( expression );
            Assert.Throws<InvalidOperationException>( () => condition.GetCondition() );
        }
    }
}
