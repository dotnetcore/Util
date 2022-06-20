using System.Text;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - 参数
    /// </summary>
    public partial class SqlBuilderTest {

        #region AddParam

        /// <summary>
        /// 测试添加Sql参数
        /// </summary>
        [Fact]
        public void TestAddParam() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Where [b].[Name]<>@Test" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendWhere( "[b].[Name]<>@Test" )
                .AddParam("@Test", "abc" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParam<string>( "@Test" ) );
        }

        #endregion

        #region ClearParams

        /// <summary>
        /// 测试清空Sql参数
        /// </summary>
        [Fact]
        public void TestClearParams() {
            //添加参数
            _builder.Select( "a" )
                .From( "b" )
                .Where( "b.Name", "abc", Operator.NotEqual );

            //验证
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParam<string>( "@_p_0" ) );

            //清空参数
            _builder.ClearParams();

            //验证
            Assert.Empty( _builder.GetParams() );
        }

        #endregion
    }
}
