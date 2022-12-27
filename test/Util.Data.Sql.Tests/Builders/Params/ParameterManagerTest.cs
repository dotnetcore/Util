using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Params {
    /// <summary>
    /// Sql参数管理器测试
    /// </summary>
    public class ParameterManagerTest {

        #region 测试初始化

        /// <summary>
        /// Sql参数管理器
        /// </summary>
        private readonly ParameterManager _manager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ParameterManagerTest() {
            _manager = new ParameterManager( TestDialect.Instance );
        }

        #endregion

        #region GenerateName

        /// <summary>
        /// 测试创建参数名
        /// </summary>
        [Fact]
        public void TestGenerateName() {
            Assert.Equal( "@_p_0", _manager.GenerateName() );
            Assert.Equal( "@_p_1", _manager.GenerateName() );
        }

        #endregion

        #region Contains

        /// <summary>
        /// 测试是否包含参数
        /// </summary>
        [Fact]
        public void TestContains_1() {
            _manager.Add( "a", 1 );
            Assert.True( _manager.Contains("a") );
            Assert.True( _manager.Contains( "@a" ) );
            Assert.False( _manager.Contains( "b" ) );
        }

        /// <summary>
        /// 测试是否包含参数
        /// </summary>
        [Fact]
        public void TestContains_2() {
            _manager.Add( "@a", 1 );
            Assert.True( _manager.Contains( "a" ) );
            Assert.True( _manager.Contains( "@a" ) );
            Assert.False( _manager.Contains( "b" ) );
        }

        #endregion

        #region GetParams

        /// <summary>
        /// 测试获取参数列表
        /// </summary>
        [Fact]
        public void TestGetParams() {
            var parameters = _manager.GetParams();
            Assert.Equal( 0, parameters.Count );
        }

        #endregion

        #region Add

        /// <summary>
        /// 测试添加1个参数
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            _manager.Add( "a", 1 );
            var parameters = _manager.GetParams();
            Assert.Equal( 1, parameters.Count );
            Assert.Equal( 1, _manager.GetValue( "a" ) );
        }

        /// <summary>
        /// 测试添加2个参数
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            _manager.Add( "a", 1 );
            _manager.Add( "b", 2 );
            var parameters = _manager.GetParams();
            Assert.Equal( 2, parameters.Count );
            Assert.Equal( 1, _manager.GetValue( "a" ) );
            Assert.Equal( 2, _manager.GetValue( "b" ) );
        }

        /// <summary>
        /// 测试覆盖参数
        /// </summary>
        [Fact]
        public void TestAdd_3() {
            _manager.Add( "a", 1 );
            _manager.Add( "a", 2 );
            var parameters = _manager.GetParams();
            Assert.Equal( 1, parameters.Count );
            Assert.Equal( 2, _manager.GetValue( "a" ) );
        }

        /// <summary>
        /// 测试添加参数 - 参数名为空
        /// </summary>
        [Fact]
        public void TestAdd_4() {
            _manager.Add( "", 1 );
            var parameters = _manager.GetParams();
            Assert.Equal( 0, parameters.Count );
        }

        #endregion

        #region AddDynamicParams

        /// <summary>
        /// 测试添加1个动态参数
        /// </summary>
        [Fact]
        public void TestAddDynamicParams() {
            _manager.AddDynamicParams( new { A = 2 } );
            var parameters = _manager.GetDynamicParams();
            Assert.Equal( 1, parameters.Count );
            Assert.Equal( 2, ( (dynamic)parameters[0] ).A );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清空参数
        /// </summary>
        [Fact]
        public void TestClear() {
            var paramName = _manager.GenerateName();
            _manager.Add( paramName, 1 );
            _manager.Clear();
            var parameters = _manager.GetParams();
            Assert.Equal( 0, parameters.Count );
            Assert.Equal( "@_p_0", _manager.GenerateName() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Sql参数管理器副本 - 参数
        /// </summary>
        [Fact]
        public void TestClone_Param() {
            _manager.Add( "name", "a" );
            var clone = _manager.Clone();
            Assert.Equal( "a", clone.GetValue( "name" ) );
        }

        /// <summary>
        /// 测试复制Sql参数管理器副本 - 动态参数
        /// </summary>
        [Fact]
        public void TestClone_DynamicParam() {
            var parameter = new TestParameter { Code = "1" };
            _manager.AddDynamicParams( parameter );
            var clone = _manager.Clone();
            var result = (TestParameter)clone.GetDynamicParams()[0];
            Assert.Equal( "1", result.Code );
        }

        #endregion
    }
}
