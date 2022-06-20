using System;
using System.Collections.Generic;
using System.Text;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Conditions {
    /// <summary>
    /// Not In查询条件测试
    /// </summary>
    public class NotInConditionTest {
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NotInConditionTest() {
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
            var parameters = new List<string> { "b" };
            Assert.Throws<ArgumentNullException>( () => {
                var condition = new NotInCondition( _parameterManager, "", parameters, true );
            } );
        }

        /// <summary>
        /// 测试获取条件 - 参数化 - 1个字符串型参数
        /// </summary>
        [Fact]
        public void TestGetCondition_1() {
            var parameters = new List<string> { "b" };
            var condition = new NotInCondition( _parameterManager, "a", parameters, true );
            Assert.Equal( "a Not In (@_p_0)", GetResult( condition ) );
            Assert.Equal( "b", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试获取条件 - 参数化 - 1个数值型参数
        /// </summary>
        [Fact]
        public void TestGetCondition_2() {
            var parameters = new List<int> { 1 };
            var condition = new NotInCondition( _parameterManager, "a", parameters, true );
            Assert.Equal( "a Not In (@_p_0)", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试获取条件 - 参数化 - 2个参数
        /// </summary>
        [Fact]
        public void TestGetCondition_3() {
            var parameters = new List<string> { "b", "c" };
            var condition = new NotInCondition( _parameterManager, "a", parameters, true );
            Assert.Equal( "a Not In (@_p_0,@_p_1)", GetResult( condition ) );
            Assert.Equal( "b", _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "c", _parameterManager.GetValue( "@_p_1" ) );
        }

        /// <summary>
        /// 测试获取条件 - 参数化 - 0个参数
        /// </summary>
        [Fact]
        public void TestGetCondition_4() {
            var parameters = new List<string>();
            var condition = new NotInCondition( _parameterManager, "a", parameters, true );
            Assert.Empty( GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试获取条件 - 非参数化 - 1个字符串型参数
        /// </summary>
        [Fact]
        public void TestGetCondition_5() {
            var parameters = new List<string> { "b" };
            var condition = new NotInCondition( _parameterManager, "a", parameters, false );
            Assert.Equal( "a Not In ('b')", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试获取条件 - 非参数化 - 1个数值型参数
        /// </summary>
        [Fact]
        public void TestGetCondition_6() {
            var parameters = new List<int> { 1 };
            var condition = new NotInCondition( _parameterManager, "a", parameters, false );
            Assert.Equal( "a Not In (1)", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试获取条件 - 非参数化 - 2个参数
        /// </summary>
        [Fact]
        public void TestGetCondition_7() {
            var parameters = new List<string> { "b", "c" };
            var condition = new NotInCondition( _parameterManager, "a", parameters, false );
            Assert.Equal( "a Not In ('b','c')", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试获取条件 - 值为ISqlBuilder
        /// </summary>
        [Fact]
        public void TestGetCondition_8() {
            var result = new StringBuilder();
            result.Append( "a Not In " );
            result.AppendLine( "(Select [a] " );
            result.Append( "From [b])" );

            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            var condition = new NotInCondition( _parameterManager, "a", builder, true );
            Assert.Equal( result.ToString(), GetResult( condition ) );
        }
    }
}
