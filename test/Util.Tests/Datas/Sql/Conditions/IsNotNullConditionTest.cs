using Util.Datas.Sql.Queries.Builders.Conditions;
using Xunit;

namespace Util.Tests.Datas.Sql.Conditions {
    /// <summary>
    /// Is Not Null查询条件测试
    /// </summary>
    public class IsNotNullConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test_1() {
            var condition = new IsNotNullCondition( "Email" );
            Assert.Equal( "Email Is Not Null", condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 验证列为空
        /// </summary>
        [Fact]
        public void Test_2() {
            var condition = new IsNullCondition( "" );
            Assert.Null( condition.GetCondition() );
        }
    }
}
