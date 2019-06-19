using Util.Datas.Dapper.Oracle;
using Util.Datas.Queries;
using Util.Datas.Sql;
using Util.Datas.Tests.Samples;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Sql.Builders.Oracle {
    /// <summary>
    /// Oracle Sql生成器测试
    /// </summary>
    public class OracleBuilderTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// Oracle Sql生成器
        /// </summary>
        private OracleBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OracleBuilderTest( ITestOutputHelper output ) {
            _output = output;
            _builder = new OracleBuilder();
        }

        /// <summary>
        /// 设置条件 - 属性表达式
        /// </summary>
        [Fact]
        public void TestWhere() {
            //结果
            var result = new String();
            result.AppendLine( "Select \"a\".\"Email\" " );
            result.AppendLine( "From \"Sample\" \"a\" " );
            result.Append( "Where \"a\".\"Email\"<>:p_0" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email } )
                .From<Sample>( "a" )
                .Where<Sample>( t => t.Email, "abc", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "abc", _builder.GetParams()["p_0"] );
        }
    }
}
