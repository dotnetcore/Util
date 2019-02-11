using Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Conditions {
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
