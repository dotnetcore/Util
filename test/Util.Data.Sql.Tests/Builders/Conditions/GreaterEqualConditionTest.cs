using System;
using System.Text;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Conditions {
    /// <summary>
    /// Sql大于等于查询条件测试
    /// </summary>
    public class GreaterEqualConditionTest {
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GreaterEqualConditionTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( ISqlCondition condition ) {
            var result = new StringBuilder();
            condition.AppendTo( result );
            return result.ToString();
        }

        /// <summary>
        /// 测试创建条件 - 验证列名为空
        /// </summary>
        [Fact]
        public void TestCreate_Validate() {
            Assert.Throws<ArgumentNullException>( () => {
                var condition = new GreaterEqualCondition( _parameterManager, "", 1, true );
            } );
        }

        /// <summary>
        /// 测试获取条件 - 参数化
        /// </summary>
        [Fact]
        public void TestGetCondition_1() {
            var condition = new GreaterEqualCondition( _parameterManager, "a", 1, true );
            Assert.Equal( "a>=@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试获取条件 - 非参数化
        /// </summary>
        [Fact]
        public void TestGetCondition_2() {
            var condition = new GreaterEqualCondition( _parameterManager, "a", "b", false );
            Assert.Equal( "a>=b", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试获取条件 - 值为ISqlBuilder
        /// </summary>
        [Fact]
        public void TestGetCondition_3() {
            var result = new StringBuilder();
            result.Append( "a>=" );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b])" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            var condition = new GreaterEqualCondition( _parameterManager, "a", builder, true );
            Assert.Equal( result.ToString(), GetResult( condition ) );
        }
    }
}