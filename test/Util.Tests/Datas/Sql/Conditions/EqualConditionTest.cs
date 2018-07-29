using Util.Datas.Sql.Queries.Builders.Conditions;
using Xunit;

namespace Util.Tests.Datas.Sql.Conditions {
    /// <summary>
    /// Sql相等查询条件测试
    /// </summary>
    public class EqualConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new EqualCondition( "Name", "@Name" );
            Assert.Equal( "Name=@Name", condition.GetCondition() );
        }
    }
}
