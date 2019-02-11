using Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Conditions {
    /// <summary>
    /// And连接条件测试
    /// </summary>
    public class AndConditionTest {
        /// <summary>
        /// 获取条件 - 传入字符串查询条件
        /// </summary>
        [Fact]
        public void Test_1() {
            var condition = new AndCondition( "Name=@Name","Age>@Age" );
            Assert.Equal( "Name=@Name And Age>@Age", condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 传入对象查询条件
        /// </summary>
        [Fact]
        public void Test_2() {
            var condition1 = new SqlCondition( "Name=@Name" );
            var condition2 = new SqlCondition( "Age>@Age" );
            var condition = new AndCondition( condition1, condition2 );
            Assert.Equal( "Name=@Name And Age>@Age", condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 条件1为空
        /// </summary>
        [Fact]
        public void Test_3() {
            var condition2 = new SqlCondition( "Age>@Age" );
            var condition = new AndCondition( null, condition2 );
            Assert.Equal( "Age>@Age", condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 条件2为空
        /// </summary>
        [Fact]
        public void Test_4() {
            var condition1 = new SqlCondition( "Name=@Name" );
            var condition = new AndCondition( condition1, null );
            Assert.Equal( "Name=@Name", condition.GetCondition() );
        }

        /// <summary>
        /// 获取条件 - 条件都为空
        /// </summary>
        [Fact]
        public void Test_5() {
            var condition = new AndCondition( "", "" );
            Assert.Empty( condition.GetCondition() );
        }
    }
}
