using System.Text;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Conditions {
    /// <summary>
    /// Not Exists查询条件测试
    /// </summary>
    public class NotExistsConditionTest {
        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( ISqlCondition condition ) {
            var result = new StringBuilder();
            condition.AppendTo( result );
            return result.ToString();
        }

        /// <summary>
        /// 测试Not Exists查询条件
        /// </summary>
        [Fact]
        public void Test() {
            //结果
            var result = new StringBuilder();
            result.Append( "Not Exists (" );
            result.AppendLine( "Select [Name] " );
            result.Append( "From [t]" );
            result.Append( ")" );

            //子查询
            var subBuilder = new TestSqlBuilder();
            subBuilder.Select( "Name" ).From( "t" );

            //创建条件
            var condition = new NotExistsCondition( subBuilder );

            //验证
            Assert.Equal( result.ToString(), GetResult( condition ) );
        }
    }
}
