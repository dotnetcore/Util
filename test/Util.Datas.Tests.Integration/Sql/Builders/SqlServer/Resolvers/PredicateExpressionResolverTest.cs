using System;
using System.Linq.Expressions;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Resolvers {
    /// <summary>
    /// 谓词表达式解析器测试
    /// </summary>
    public class PredicateExpressionResolverTest {
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly ParameterManager _parameterManager;
        /// <summary>
        /// 谓词表达式解析器
        /// </summary>
        private readonly PredicateExpressionResolver _resolver;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PredicateExpressionResolverTest() {
            _dialect = new SqlServerDialect();
            _parameterManager = new ParameterManager( _dialect );
            _resolver = new PredicateExpressionResolver( _dialect, new EntityResolver(), new EntityAliasRegister(), _parameterManager );
        }

        /// <summary>
        /// 验证空表达式
        /// </summary>
        [Fact]
        public void TestResolve_1() {
            Expression<Func<Sample, bool>> expression = null;
            Assert.Same( NullCondition.Instance, _resolver.Resolve( expression ) );
        }

        /// <summary>
        /// 1个条件
        /// </summary>
        [Fact]
        public void TestResolve_2() {
            Expression<Func<Sample, bool>> expression = t => t.Email == "a";
            Assert.Equal( "[Email]=@_p_0", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
        }

        /// <summary>
        /// 2个条件 - And连接
        /// </summary>
        [Fact]
        public void TestResolve_3() {
            Expression<Func<Sample, bool>> expression = t => t.Email == "a" && t.IntValue == 1;
            Assert.Equal( "[Email]=@_p_0 And [IntValue]=@_p_1", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 2个条件 - Or连接
        /// </summary>
        [Fact]
        public void TestResolve_4() {
            Expression<Func<Sample, bool>> expression = t => t.Email == "a" || t.IntValue == 1;
            Assert.Equal( "([Email]=@_p_0 Or [IntValue]=@_p_1)", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// And和Or连接
        /// </summary>
        [Fact]
        public void TestResolve_5() {
            Expression<Func<Sample, bool>> expression = t => t.Email == "a" && t.IntValue == 1 || t.DisplayValue == "b";
            Assert.Equal( "([Email]=@_p_0 And [IntValue]=@_p_1 Or [DisplayValue]=@_p_2)", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( "b", _parameterManager.GetParams()["@_p_2"] );
        }

        /// <summary>
        /// Or和And连接
        /// </summary>
        [Fact]
        public void TestResolve_6() {
            Expression<Func<Sample, bool>> expression = t => t.Email == "a" || t.IntValue == 1 && t.DisplayValue == "b";
            Assert.Equal( "([Email]=@_p_0 Or [IntValue]=@_p_1 And [DisplayValue]=@_p_2)", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( "b", _parameterManager.GetParams()["@_p_2"] );
        }

        /// <summary>
        /// 加括号
        /// </summary>
        [Fact]
        public void TestResolve_7() {
            Expression<Func<Sample, bool>> expression = t => (t.Email == "a" || t.IntValue == 1) && t.DisplayValue == "b";
            Assert.Equal( "([Email]=@_p_0 Or [IntValue]=@_p_1) And [DisplayValue]=@_p_2", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( "b", _parameterManager.GetParams()["@_p_2"] );
        }

        /// <summary>
        /// 两个括号
        /// </summary>
        [Fact]
        public void TestResolve_8() {
            Expression<Func<Sample, bool>> expression = t => ( t.Email == "a" || t.IntValue == 1 ) || ( t.Email == "b" || t.IntValue == 2 );
            Assert.Equal( "(([Email]=@_p_0 Or [IntValue]=@_p_1) Or ([Email]=@_p_2 Or [IntValue]=@_p_3))", _resolver.Resolve( expression ).GetCondition() );
            Assert.Equal( "a", _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( "b", _parameterManager.GetParams()["@_p_2"] );
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_3"] );
        }
    }
}
