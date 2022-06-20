using System.Text;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - Join子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Join

        /// <summary>
        /// 内连接
        /// </summary>
        [Fact]
        public void TestJoin_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Join [c] As [d]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Join( "c as d" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 内连接 - 子查询
        /// </summary>
        [Fact]
        public void TestJoin_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.Select( "a" )
                .From( "b" )
                .Join( builder, "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 内连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestJoin_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Join( t => t.Select( "a" ).From( "b" ), "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region LeftJoin

        /// <summary>
        /// 左外连接
        /// </summary>
        [Fact]
        public void TestLeftJoin_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Left Join [c] As [d]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .LeftJoin( "c as d" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 左外连接 - 子查询
        /// </summary>
        [Fact]
        public void TestLeftJoin_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Left Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.Select( "a" )
                .From( "b" )
                .LeftJoin( builder, "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 左外连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestLeftJoin_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Left Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .LeftJoin( t => t.Select( "a" ).From( "b" ), "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region RightJoin

        /// <summary>
        /// 右外连接
        /// </summary>
        [Fact]
        public void TestRightJoin_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Right Join [c] As [d]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .RightJoin( "c as d" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 右外连接 - 子查询
        /// </summary>
        [Fact]
        public void TestRightJoin_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Right Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            var builder = new TestSqlBuilder().Select( "a" ).From( "b" );
            _builder.Select( "a" )
                .From( "b" )
                .RightJoin( builder, "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 右外连接 - 子查询 - 内嵌表达式
        /// </summary>
        [Fact]
        public void TestRightJoin_3() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Right Join (Select [a] " );
            result.Append( "From [b]) As [c]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .RightJoin( t => t.Select( "a" ).From( "b" ), "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region On

        /// <summary>
        /// 连接条件
        /// </summary>
        [Fact]
        public void TestOn_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Join [c] As [d] On [b].[Id]<>[d].[Id]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Join( "c as d" ).On( "b.Id", "d.Id", Operator.NotEqual );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendJoin

        /// <summary>
        /// 测试添加到内连接
        /// </summary>
        [Fact]
        public void TestAppendJoin() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Join c" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendJoin( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendLeftJoin

        /// <summary>
        /// 测试添加到左外连接子句
        /// </summary>
        [Fact]
        public void TestAppendLeftJoin() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Left Join c" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendLeftJoin( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendRightJoin

        /// <summary>
        /// 测试添加到右外连接子句
        /// </summary>
        [Fact]
        public void TestAppendRightJoin() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Right Join c" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendRightJoin( "c" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region AppendOn

        /// <summary>
        /// 测试添加到On子句
        /// </summary>
        [Fact]
        public void TestAppendOn() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.Append( "Join c On d" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .AppendJoin( "c" )
                .AppendOn( "d" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearJoin

        /// <summary>
        /// 测试清空Join子句
        /// </summary>
        [Fact]
        public void TestClearJoin() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );

            //执行
            _builder.Select( "a" )
                .From( "b" )
                .Join( "c as d" ).On( "b.Id", "d.Id", Operator.NotEqual )
                .ClearJoin();

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion
    }
}