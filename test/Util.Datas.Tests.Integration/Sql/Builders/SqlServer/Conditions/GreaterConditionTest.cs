using Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Conditions {
    /// <summary>
    /// Sql大于查询条件测试
    /// </summary>
    public class GreaterConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new GreaterCondition( "Age", "@Age" );
            Assert.Equal( "Age>@Age", condition.GetCondition() );
        }
    }
}