using System.Text;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - Insert子句
    /// </summary>
    public partial class SqlBuilderTest {

        #region Insert

        /// <summary>
        /// 测试插入一行
        /// </summary>
        [Fact]
        public void TestInsert_1() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t]([a],[b]) " );
            result.Append( "Values(@_p_0,@_p_1)" );

            //执行
            _builder.Insert( "a,b","t" )
                .Values( 1,"a" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_1" ) );
        }

        /// <summary>
        /// 测试插入2行
        /// </summary>
        [Fact]
        public void TestInsert_2() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t]([a],[b]) " );
            result.Append( "Values(@_p_0,@_p_1),(@_p_2,@_p_3)" );

            //执行
            _builder.Insert( "a,b", "t" )
                .Values( 1, "a" )
                .Values( 2, "b" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_1" ) );
            Assert.Equal( 2, _builder.GetParam<int>( "@_p_2" ) );
            Assert.Equal( "b", _builder.GetParam<string>( "@_p_3" ) );
        }

        #endregion

        #region AppendInsert

        /// <summary>
        /// 添加到Insert子句
        /// </summary>
        [Fact]
        public void TestAppendInsert() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t]([a],[b]) " );
            result.Append( "Values(@_p_0,@_p_1)" );

            //执行
            _builder.AppendInsert( "[t]([a],[b])" )
                .Values( 1, "a" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
            Assert.Equal( 1, _builder.GetParam<int>( "@_p_0" ) );
            Assert.Equal( "a", _builder.GetParam<string>( "@_p_1" ) );
        }

        #endregion

        #region AppendValues

        /// <summary>
        /// 添加到Values子句
        /// </summary>
        [Fact]
        public void TestAppendValues() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Insert Into [t]([a],[b]) " );
            result.Append( "Values(@_p_0,@_p_1)" );

            //执行
            _builder.Insert( "a,b", "t" )
                .AppendValues( "(@_p_0,@_p_1)" );

            //验证
            Assert.Equal( result.ToString(), _builder.GetSql() );
        }

        #endregion

        #region ClearInsert

        /// <summary>
        /// 测试清空Insert子句
        /// </summary>
        [Fact]
        public void TestClearInsert() {
            //执行
            _builder.Insert( "a,b", "t" )
                .Values( 1, "a" )
                .AppendInsert( "[t]([a],[b])" )
                .AppendValues( "(@_p_0,@_p_1)" )
                .ClearInsert();

            //验证
            Assert.Empty( _builder.GetSql() );
        }

        #endregion
    }
}
