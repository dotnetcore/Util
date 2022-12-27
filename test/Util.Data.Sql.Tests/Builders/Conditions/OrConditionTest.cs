using System.Text;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Conditions {
    /// <summary>
    /// Or连接条件测试
    /// </summary>
    public class OrConditionTest {
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OrConditionTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
        }

        /// <summary>
        /// 测试或连接条件 - 构造器传入1个条件
        /// </summary>
        [Fact]
        public void Test_1() {
            var result = new StringBuilder();
            var condition1 = new EqualCondition( _parameterManager, "Name", "@Name", false );
            condition1.AppendTo( result );
            var condition2 = new GreaterCondition( _parameterManager, "Age", "@Age", false );
            var orCondition = new OrCondition( condition2 );
            orCondition.AppendTo( result );
            Assert.Equal( "(Name=@Name Or Age>@Age)", result.ToString() );
        }

        /// <summary>
        /// 测试或连接条件 - 构造器传入2个条件
        /// </summary>
        [Fact]
        public void Test_2() {
            var result = new StringBuilder();
            var condition1 = new EqualCondition( _parameterManager, "Name", "@Name", false );
            condition1.AppendTo( result );
            var condition2 = new EqualCondition( _parameterManager, "Code", "@Code", false );
            var condition3 = new GreaterCondition( _parameterManager, "Age", "@Age", false );
            var orCondition = new OrCondition( condition2, condition3 );
            orCondition.AppendTo( result );
            Assert.Equal( "Name=@Name And (Code=@Code Or Age>@Age)", result.ToString() );
        }

        /// <summary>
        /// 测试或连接条件 - 第2个条件为空条件
        /// </summary>
        [Fact]
        public void Test_3() {
            var result = new StringBuilder();
            var condition1 = new EqualCondition( _parameterManager, "Name", "@Name", false );
            condition1.AppendTo( result );
            var condition2 = new EqualCondition( _parameterManager, "Code", "@Code", false );
            var orCondition = new OrCondition( condition2, NullCondition.Instance );
            orCondition.AppendTo( result );
            Assert.Equal( "(Name=@Name Or Code=@Code)", result.ToString() );
        }

        /// <summary>
        /// 测试条件1为空
        /// </summary>
        [Fact]
        public void Test_4() {
            var result = new StringBuilder();
            var condition2 = new GreaterCondition( _parameterManager, "Age", "@Age", false );
            var orCondition = new OrCondition( condition2 );
            orCondition.AppendTo( result );
            Assert.Equal( "Age>@Age", result.ToString() );
        }

        /// <summary>
        /// 测试条件2为空
        /// </summary>
        [Fact]
        public void Test_5() {
            var result = new StringBuilder();
            var condition1 = new EqualCondition( _parameterManager, "Name", "@Name", false );
            condition1.AppendTo( result );
            var orCondition = new OrCondition( null );
            orCondition.AppendTo( result );
            Assert.Equal( "Name=@Name", result.ToString() );
        }

        /// <summary>
        /// 测试条件都为空
        /// </summary>
        [Fact]
        public void Test_6() {
            var result = new StringBuilder();
            var orCondition = new OrCondition( null );
            orCondition.AppendTo( result );
            Assert.Empty( result.ToString() );
        }
    }
}