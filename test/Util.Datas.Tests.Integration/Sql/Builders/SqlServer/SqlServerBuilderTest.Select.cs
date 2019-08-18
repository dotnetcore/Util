using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql;
using Util.Datas.Sql.Matedatas;
using Util.Datas.Tests.Samples;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器测试 - Select子句
    /// </summary>
    public partial class SqlServerBuilderTest {
        /// <summary>
        /// 设置Distinct
        /// </summary>
        [Fact]
        public void TestDistinct() {
            //结果
            var result = new String();
            result.AppendLine( "Select Distinct [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Distinct().Select( "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        [Fact]
        public void TestCount_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select Count(*) " );
            result.Append( "From [b]" );

            //执行
            _builder.Count()
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求总行数 - 加列别名
        /// </summary>
        [Fact]
        public void TestCount_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select Count([DoubleValue]) As [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Count<Sample>( t => t.DoubleValue, "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求和
        /// </summary>
        [Fact]
        public void TestSum_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select Sum([a]) As [b] " );
            result.Append( "From [c]" );

            //执行
            _builder.Sum( "a", "b" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求和 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSum_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select Sum([DoubleValue]) As [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Sum<Sample>( t => t.DoubleValue, "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        [Fact]
        public void TestAvg_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select Avg([a]) As [b] " );
            result.Append( "From [c]" );

            //执行
            _builder.Avg( "a", "b" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求平均值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestAvg_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select Avg([DoubleValue]) As [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Avg<Sample>( t => t.DoubleValue, "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        [Fact]
        public void TestMax_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select Max([a]) As [b] " );
            result.Append( "From [c]" );

            //执行
            _builder.Max( "a", "b" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求最大值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestMax_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select Max([DoubleValue]) As [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Max<Sample>( t => t.DoubleValue, "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        [Fact]
        public void TestMin_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select Min([a]) As [b] " );
            result.Append( "From [c]" );

            //执行
            _builder.Min( "a", "b" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 求最小值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestMin_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select Min([DoubleValue]) As [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Min<Sample>( t => t.DoubleValue, "a" )
                .From( "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            //结果
            var result = new String();
            result.AppendLine( "Select [b].[a] " );
            result.Append( "From [c]" );

            //执行
            _builder.Select( "a", "b" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            //结果
            var result = new String();
            result.AppendLine( "Select [Email],[IntValue] " );
            result.Append( "From [c]" );

            //执行
            _builder.Select<Sample>( t => new object[] { t.Email, t.IntValue } )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 设置单个列名和列别名
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            //结果
            var result = new String();
            result.AppendLine( "Select [Email] As [e] " );
            result.Append( "From [c]" );

            //执行
            _builder.Select<Sample>( t => t.Email, "e" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            //结果
            var result = new String();
            result.Append( "Select *," );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [Name]=@_p_0) As [testCount] " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.Select( "*" ).Select( builder2, "testCount" ).From( "Test" ).Where( "Age", 1 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置子查询列 - 委托
        /// </summary>
        [Fact]
        public void TestSelect_5() {
            //结果
            var result = new String();
            result.Append( "Select *," );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [Name]=@_p_0) As [testCount] " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where [Age]=@_p_1" );

            //执行
            _builder.Select( "*" ).Select( builder => {
                    builder.Count().From( "Test2" ).Where( "Name", "a" );
                }, "testCount" )
                .From( "Test" ).Where( "Age", 1 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 设置列 - 添加select子句，不进行修改
        /// </summary>
        [Fact]
        public void TestSelect_6() {
            //结果
            var result = new String();
            result.AppendLine( "Select a " );
            result.Append( "From [c]" );

            //执行
            _builder.AppendSelect( "a" )
                .From( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 设置子查询列 - 别名为空
        /// </summary>
        [Fact]
        public void TestSelect_7() {
            //结果
            var result = new String();
            result.Append( "Select *," );
            result.AppendLine( "(Select Count(*) " );
            result.AppendLine( "From [Test2] " );
            result.AppendLine( "Where [Name]=@_p_0) As testCount " );
            result.AppendLine( "From [Test] " );
            result.Append( "Where [Age]=@_p_1" );

            //执行
            var builder2 = _builder.New().Count().From( "Test2" ).Where( "Name", "a" );
            _builder.Select( "*" ).AppendSelect( "(" ).Select( builder2, "" ).AppendSelect( ") As testCount" ).From( "Test" ).Where( "Age", 1 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p_0"] );
            Assert.Equal( 1, _builder.GetParams()["@_p_1"] );
        }

        /// <summary>
        /// 将类型上所有属性设置为列名 - 忽略Ignore特性的属性
        /// </summary>
        [Fact]
        public void TestSelect_8() {
            //结果
            var result = new String();
            result.AppendLine( "Select [s].[StringValue],[s].[IsDeleted] " );
            result.Append( "From [Sample3] As [s]" );

            //执行
            _builder = new SqlServerBuilder( new DefaultEntityMatedata() );
            _builder.Select<Sample3>().From<Sample3>( "s" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        /// <summary>
        /// 覆盖已设置列名
        /// </summary>
        [Fact]
        public void TestSelect_9() {
            //结果
            var result = new String();
            result.AppendLine( "Select [s].[IsDeleted],[s].[StringValue] As [a] " );
            result.Append( "From [Sample3] As [s]" );

            //执行
            _builder = new SqlServerBuilder( new DefaultEntityMatedata() );
            _builder.Select<Sample3>()
                .Select<Sample3>( t => t.StringValue,"a" )
                .From<Sample3>( "s" );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }
    }
}