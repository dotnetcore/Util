using Util.Datas.Dapper.MySql;
using Util.Datas.Sql;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Datas.Tests.Sql.Builders.MySql {
    /// <summary>
    /// MySql Sql生成器测试
    /// </summary>
    public class MySqlBuilderTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// MySql Sql生成器
        /// </summary>
        private readonly MySqlBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MySqlBuilderTest( ITestOutputHelper output ) {
            _output = output;
            _builder = new MySqlBuilder();
        }

        /// <summary>
        /// 查询
        /// </summary>
        [Fact]
        public void Test_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select `a` " );
            result.Append( "From `t`" );

            //执行
            _builder.Select( "a" ).From( "t" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 查询 - 表名带.符号
        /// </summary>
        [Fact]
        public void Test_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select `c` " );
            result.Append( "From `a.b`" );

            //执行
            _builder.Select( "c" ).From( "a.b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 内连接
        /// </summary>
        [Fact]
        public void Test_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select `a3`.`a`,`a1`.`b1`,`a2`.`b2` " );
            result.AppendLine( "From `b` As `a2` " );
            result.Append( "Join `t.c` As `a3` On `a2`.`d`=@_p_0" );

            //执行
            _builder.Select( "a,a1.b1,a2.b2", "a3" )
                .From( "b", "a2" )
                .Join( "t.c", "a3" ).On( "a2.d", "e" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 测试CTE
        /// </summary>
        [Fact]
        public void TestWith() {
            //结果
            var result = new String();
            result.AppendLine( "With Recursive `Test` " );
            result.AppendLine( "As (Select `a`,`b` " );
            result.AppendLine( "From `Test2`)" );
            result.AppendLine( "Select `a`,`b` " );
            result.Append( "From `Test`" );

            //执行
            var builder2 = _builder.New().Select( "a,b" ).From( "Test2" );
            _builder.Select( "a,b" ).From( "Test" ).With( "Test", builder2 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }
    }
}
