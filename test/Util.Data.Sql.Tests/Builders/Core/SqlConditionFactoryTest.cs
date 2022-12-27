using System;
using System.Collections.Generic;
using System.Text;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Core {
    /// <summary>
    /// Sql条件工厂测试
    /// </summary>
    public class SqlConditionFactoryTest {
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// Sql条件工厂
        /// </summary>
        private readonly SqlConditionFactory _conditionFactory;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlConditionFactoryTest() {
            _parameterManager = new ParameterManager( TestDialect.Instance );
            _conditionFactory = new SqlConditionFactory( _parameterManager );
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
                _conditionFactory.Create( "", 1, Operator.Equal );
            } );
        }

        /// <summary>
        /// 测试创建条件 - 相等
        /// </summary>
        [Fact]
        public void TestCreate_1() {
            var condition = _conditionFactory.Create( "a", 1, Operator.Equal );
            Assert.Equal( "a=@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 不相等
        /// </summary>
        [Fact]
        public void TestCreate_2() {
            var condition = _conditionFactory.Create( "a", 1, Operator.NotEqual );
            Assert.Equal( "a<>@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - is null
        /// </summary>
        [Fact]
        public void TestCreate_3() {
            var condition = _conditionFactory.Create( "a", null, Operator.Equal );
            Assert.Equal( "a Is Null", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试创建条件 - is not null
        /// </summary>
        [Fact]
        public void TestCreate_4() {
            var condition = _conditionFactory.Create( "a", null, Operator.NotEqual );
            Assert.Equal( "a Is Not Null", GetResult( condition ) );
            Assert.Equal( 0, _parameterManager.GetParams().Count );
        }

        /// <summary>
        /// 测试创建条件 - 大于
        /// </summary>
        [Fact]
        public void TestCreate_5() {
            var condition = _conditionFactory.Create( "a", 1, Operator.Greater );
            Assert.Equal( "a>@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 大于等于
        /// </summary>
        [Fact]
        public void TestCreate_6() {
            var condition = _conditionFactory.Create( "a", 1, Operator.GreaterEqual );
            Assert.Equal( "a>=@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 小于
        /// </summary>
        [Fact]
        public void TestCreate_7() {
            var condition = _conditionFactory.Create( "a", 1, Operator.Less );
            Assert.Equal( "a<@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 小于等于
        /// </summary>
        [Fact]
        public void TestCreate_8() {
            var condition = _conditionFactory.Create( "a", 1, Operator.LessEqual );
            Assert.Equal( "a<=@_p_0", GetResult( condition ) );
            Assert.Equal( 1, _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 模糊匹配
        /// </summary>
        [Fact]
        public void TestCreate_9() {
            var condition = _conditionFactory.Create( "a", "abc", Operator.Contains );
            Assert.Equal( "a Like @_p_0", GetResult( condition ) );
            Assert.Equal( "%abc%", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 头匹配
        /// </summary>
        [Fact]
        public void TestCreate_10() {
            var condition = _conditionFactory.Create( "a", "abc", Operator.Starts );
            Assert.Equal( "a Like @_p_0", GetResult( condition ) );
            Assert.Equal( "abc%", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - 尾匹配
        /// </summary>
        [Fact]
        public void TestCreate_11() {
            var condition = _conditionFactory.Create( "a", "abc", Operator.Ends );
            Assert.Equal( "a Like @_p_0", GetResult( condition ) );
            Assert.Equal( "%abc", _parameterManager.GetValue( "@_p_0" ) );
        }

        /// <summary>
        /// 测试创建条件 - in
        /// </summary>
        [Fact]
        public void TestCreate_12() {
            var list = new List<string> { "1", "2" };
            var condition = _conditionFactory.Create( "a", list, Operator.In );
            Assert.Equal( "a In (@_p_0,@_p_1)", GetResult( condition ) );
            Assert.Equal( 2, _parameterManager.GetParams().Count );
            Assert.Equal( "1", _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "2", _parameterManager.GetValue( "@_p_1" ) );
        }

        /// <summary>
        /// 测试创建条件 - not in
        /// </summary>
        [Fact]
        public void TestCreate_13() {
            var list = new List<string> { "1", "2" };
            var condition = _conditionFactory.Create( "a", list, Operator.NotIn );
            Assert.Equal( "a Not In (@_p_0,@_p_1)", GetResult( condition ) );
            Assert.Equal( 2, _parameterManager.GetParams().Count );
            Assert.Equal( "1", _parameterManager.GetValue( "@_p_0" ) );
            Assert.Equal( "2", _parameterManager.GetValue( "@_p_1" ) );
        }
    }
}
