using System;
using System.Linq.Expressions;
using Util.Datas.Dapper.SqlServer.Builders;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.XUnitHelpers;
using Util.Helpers;
using Util.Properties;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Dapper.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器测试
    /// </summary>
    public class SqlServerBuilderTest {

        #region 测试初始化

        /// <summary>
        /// Sql Server Sql生成器
        /// </summary>
        private readonly SqlServerBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlServerBuilderTest() {
            _builder = new SqlServerBuilder();
        }

        #endregion

        #region 验证

        /// <summary>
        /// 验证表名为空
        /// </summary>
        [Fact]
        public void TestValidate_TableIsEmpty() {
            _builder.Select( "a" );
            AssertHelper.Throws<InvalidOperationException>( () => _builder.ToSql() );
        }

        /// <summary>
        /// 设置查询条件 - 验证列名为空
        /// </summary>
        [Fact]
        public void TestValidate_Where_NameIsEmpty() {
            AssertHelper.Throws<ArgumentNullException>( () => _builder.Where( "", "a" ) );
        }

        #endregion

        #region Select(设置列)

        /// <summary>
        /// 设置列 - 设置为空会默认使用*
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            _builder.Select( "" ).From( "b" );
            Assert.Equal( $"Select * {Common.Line}From [b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            _builder.Select( "a" ).From( "b" );
            Assert.Equal( $"Select [t].[a] {Common.Line}From [b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 表设置了别名
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            _builder.Select( "a" ).From( "b", "c" );
            Assert.Equal( $"Select [c].[a] {Common.Line}From [b] As [c]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列具有中括号
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            _builder.Select( "[a]" ).From( "b", "c" );
            Assert.Equal( $"Select [c].[a] {Common.Line}From [b] As [c]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 多列
        /// </summary>
        [Fact]
        public void TestSelect_5() {
            _builder.Select( "a,[b]" ).From( "c" );
            Assert.Equal( $"Select [t].[a],[t].[b] {Common.Line}From [c] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_6() {
            _builder.Select<Sample>( t => new object[] { t.Email, t.IntValue } ).From( "b" );
            Assert.Equal( $"Select [t].[Email],[t].[IntValue] {Common.Line}From [b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列具有表别名
        /// </summary>
        [Fact]
        public void TestSelect_7() {
            _builder.Select( "t.a,[b]" ).From( "c", "d" );
            Assert.Equal( $"Select [t].[a],[d].[b] {Common.Line}From [c] As [d]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 多个Select
        /// </summary>
        [Fact]
        public void TestSelect_8() {
            _builder.Select( "a" ).Select( "b" ).From( "c" );
            Assert.Equal( $"Select [t].[a],[t].[b] {Common.Line}From [c] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 每个Select使用不同的别名
        /// </summary>
        [Fact]
        public void TestSelect_9() {
            _builder.Select( "a,b", "j" ).Select( "c,d", "k" ).From( "e" );
            Assert.Equal( $"Select [j].[a],[j].[b],[k].[c],[k].[d] {Common.Line}From [e] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 多个*
        /// </summary>
        [Fact]
        public void TestSelect_10() {
            _builder.Select( "a.*,b.*" ).From( "c" );
            Assert.Equal( $"Select [a].*,[b].* {Common.Line}From [c] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式且设置别名
        /// </summary>
        [Fact]
        public void TestSelect_11() {
            _builder.Select<Sample>( t => new object[] { t.Email, t.IntValue }, "a" )
                .Select<Sample2>( t => new object[] { t.Description, t.Display }, "b" )
                .From( "b" );
            Assert.Equal( $"Select [a].[Email],[a].[IntValue],[b].[Description],[b].[Display] {Common.Line}From [b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名
        /// </summary>
        [Fact]
        public void TestSelect_12() {
            _builder.Select( "t.a As e,[b],f.g", "k" ).Select( "n" ).From( "c", "d" );
            Assert.Equal( $"Select [t].[a] As [e],[k].[b],[f].[g],[d].[n] {Common.Line}From [c] As [d]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名，增加了空格
        /// </summary>
        [Fact]
        public void TestSelect_13() {
            _builder.Select( "t.[a]    As     [e]      ,        b aS          f " ).From( "c", "d" );
            Assert.Equal( $"Select [t].[a] As [e],[d].[b] As [f] {Common.Line}From [c] As [d]", _builder.ToSql() );
        }

        #endregion

        #region From(设置表)

        /// <summary>
        /// 设置表
        /// </summary>
        [Fact]
        public void TestFrom_1() {
            _builder.From( "a" );
            Assert.Equal( $"Select * {Common.Line}From [a] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 别名
        /// </summary>
        [Fact]
        public void TestFrom_2() {
            _builder.From( "a", "b" );
            Assert.Equal( $"Select * {Common.Line}From [a] As [b]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 别名 - 架构
        /// </summary>
        [Fact]
        public void TestFrom_3() {
            _builder.From( "a", "b", "c" );
            Assert.Equal( $"Select * {Common.Line}From [c].[a] As [b]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 带方括号
        /// </summary>
        [Fact]
        public void TestFrom_4() {
            _builder.From( "[a]", "b", "[c]" );
            Assert.Equal( $"Select * {Common.Line}From [c].[a] As [b]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 表名包含架构
        /// </summary>
        [Fact]
        public void TestFrom_5() {
            _builder.From( "a.b" );
            Assert.Equal( $"Select * {Common.Line}From [a].[b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 表名包含别名
        /// </summary>
        [Fact]
        public void TestFrom_6() {
            _builder.From( "a.b as t" );
            Assert.Equal( $"Select * {Common.Line}From [a].[b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 表名中包含的架构和别名生效
        /// </summary>
        [Fact]
        public void TestFrom_7() {
            _builder.From( "a.b as t", "e", "f" );
            Assert.Equal( $"Select * {Common.Line}From [a].[b] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 泛型实体
        /// </summary>
        [Fact]
        public void TestFrom_8() {
            _builder.From<Sample>();
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 泛型实体 - 别名
        /// </summary>
        [Fact]
        public void TestFrom_9() {
            _builder.From<Sample>( "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [a]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 泛型实体 - 别名 - 架构
        /// </summary>
        [Fact]
        public void TestFrom_10() {
            _builder.From<Sample>( "a", "b" );
            Assert.Equal( $"Select * {Common.Line}From [b].[Sample] As [a]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置表 - 泛型实体 - 多次设置From
        /// </summary>
        [Fact]
        public void TestFrom_11() {
            _builder.From<Sample>( "a" ).From<Sample>( "b" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [b]", _builder.ToSql() );
        }

        #endregion

        #region Where(设置条件)

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            _builder.From( "Test" ).Where( "Name", "a" );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Name]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 设置表别名
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            _builder.From( "Test", "d" ).Where( "Name", "a" );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [d] {Common.Line}Where [d].[Name]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 设置表别名
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            _builder.From( "Test" ).Where( "Name", "a", tableAlias: "d" );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [d].[Name]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 设置表别名
        /// </summary>
        [Fact]
        public void TestWhere_4() {
            _builder.From( "Test as test", "test1", "test2" ).Where( "f.Name", "a", tableAlias: "d" );
            Assert.Equal( $"Select * {Common.Line}From [test2].[Test] As [test] {Common.Line}Where [f].[Name]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名
        /// </summary>
        [Fact]
        public void TestWhere_5() {
            _builder.From<Sample>().Where<Sample>( t => t.Email, "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Email]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 设置表别名
        /// </summary>
        [Fact]
        public void TestWhere_6() {
            _builder.From<Sample>().Where<Sample>( t => t.Email, "a", tableAlias: "d" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [d].[Email]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 通过From设置表别名
        /// </summary>
        [Fact]
        public void TestWhere_7() {
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email, "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - Where覆盖From设置的表别名
        /// </summary>
        [Fact]
        public void TestWhere_8() {
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email, "a", tableAlias: "n" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [n].[Email]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 相等
        /// </summary>
        [Fact]
        public void TestWhere_9() {
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email == "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 不相等
        /// </summary>
        [Fact]
        public void TestWhere_10() {
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email != "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email]!=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于
        /// </summary>
        [Fact]
        public void TestWhere_11() {
            _builder.From<Sample>().Where<Sample>( t => t.IntValue > 1 );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[IntValue]>@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( 1, _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于
        /// </summary>
        [Fact]
        public void TestWhere_12() {
            _builder.From<Sample>().Where<Sample>( t => t.IntValue < 1 );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[IntValue]<@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( 1, _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于等于
        /// </summary>
        [Fact]
        public void TestWhere_13() {
            _builder.From<Sample>().Where<Sample>( t => t.IntValue >= 1 );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[IntValue]>=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( 1, _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于等于
        /// </summary>
        [Fact]
        public void TestWhere_14() {
            _builder.From<Sample>().Where<Sample>( t => t.IntValue <= 1 );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[IntValue]<=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( 1, _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - Contains
        /// </summary>
        [Fact]
        public void TestWhere_15() {
            _builder.From<Sample>().Where<Sample>( t => t.Email.Contains( "a" ) );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Email] Like @_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%a%", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - StartsWith
        /// </summary>
        [Fact]
        public void TestWhere_16() {
            _builder.From<Sample>().Where<Sample>( t => t.Email.StartsWith( "a" ) );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Email] Like @_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a%", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - EndsWith
        /// </summary>
        [Fact]
        public void TestWhere_17() {
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email.EndsWith( "a" ) );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email] Like @_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "%a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 多次设置From
        /// </summary>
        [Fact]
        public void TestWhere_18() {
            _builder.From( "Test" ).From<Sample>( "Test2" ).From<Sample>().Where( "Name", "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Name]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 与连接
        /// </summary>
        [Fact]
        public void TestWhere_19() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Sample] As [k] " );
            result.AppendLine( "Where [k].[Email]=@_p__0 And [k].[StringValue]=@_p__1" );

            //执行
            _builder.From<Sample>( "k" ).Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
            Assert.Equal( 2, _builder.GetParams().Count );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
            Assert.Equal( "b", _builder.GetParams()["@_p__1"] );
        }

        #endregion

        #region WhereIf(设置条件)

        /// <summary>
        /// 设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_1() {
            _builder.From( "Test" ).WhereIf( "Name", "a", true );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Name]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_2() {
            _builder.From( "Test" ).WhereIf( "Name", "a", false );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t]", _builder.ToSql() );
            Assert.Empty( _builder.GetParams() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_3() {
            _builder.From<Sample>().WhereIf<Sample>( t => t.Email, "a", true );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Email]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_4() {
            _builder.From<Sample>().WhereIf<Sample>( t => t.Email, "a", false );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t]", _builder.ToSql() );
            Assert.Empty( _builder.GetParams() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_5() {
            _builder.From<Sample>( "k" ).WhereIf<Sample>( t => t.Email == "a", true );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email]=@_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_6() {
            _builder.From<Sample>( "k" ).WhereIf<Sample>( t => t.Email == "a", false );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k]", _builder.ToSql() );
        }

        #endregion

        #region WhereIfNotEmpty(设置条件)

        /// <summary>
        /// 设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_1() {
            _builder.From( "Test" ).WhereIfNotEmpty( "Name", "a" );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Name]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_2() {
            _builder.From( "Test" ).WhereIfNotEmpty( "Name", "" );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t]", _builder.ToSql() );
            Assert.Empty( _builder.GetParams() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_3() {
            _builder.From<Sample>().WhereIfNotEmpty<Sample>( t => t.Email, "a" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t] {Common.Line}Where [t].[Email]=@_p__0", _builder.ToSql() );
            Assert.Single( _builder.GetParams() );
            Assert.Equal( "a", _builder.GetParams()["@_p__0"] );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_4() {
            _builder.From<Sample>().WhereIfNotEmpty<Sample>( t => t.Email, "" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [t]", _builder.ToSql() );
            Assert.Empty( _builder.GetParams() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_5() {
            _builder.From<Sample>( "k" ).WhereIfNotEmpty<Sample>( t => t.Email.Contains( "a" ) );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k] {Common.Line}Where [k].[Email] Like @_p__0", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_6() {
            _builder.From<Sample>( "k" ).WhereIfNotEmpty<Sample>( t => t.Email == "" );
            Assert.Equal( $"Select * {Common.Line}From [Sample] As [k]", _builder.ToSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 仅允许设置一个条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_7() {
            Expression<Func<Sample, bool>> condition = t => t.Email.Contains( "a" ) && t.IntValue == 1;
            AssertHelper.Throws<InvalidOperationException>( () => {
                _builder.WhereIfNotEmpty<Sample>( condition );
            }, string.Format( LibraryResource.OnlyOnePredicate, condition ) );
        }

        #endregion

        #region And(连接查询条件)

        /// <summary>
        /// 连接查询条件 - 创建1个子生成器
        /// </summary>
        [Fact]
        public void TestAnd_1() {
            var newBuilder = _builder.New().Where( "Name", "a" );
            _builder.From( "Test" ).Where( "Age", 1 ).And( newBuilder );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Age]=@_p__0 And [t].[Name]=@_p_1_0", _builder.ToSql() );
        }

        /// <summary>
        /// 连接查询条件 - 创建2个子生成器
        /// </summary>
        [Fact]
        public void TestAnd_2() {
            var builder1 = _builder.New().Where( "Name", "a" );
            var builder2 = _builder.New().Where( "Code", "b" );
            _builder.From( "Test" ).Where( "Age", 1 ).And( builder1 ).And( builder2 );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Age]=@_p__0 And [t].[Name]=@_p_1_0 And [t].[Code]=@_p_2_0", _builder.ToSql() );
        }

        /// <summary>
        /// 连接查询条件 - 创建两级生成器
        /// </summary>
        [Fact]
        public void TestAnd_3() {
            var builder1 = _builder.New().Where( "Name", "a" );
            var builder2 = builder1.New().Where( "Code", "b" );
            _builder.From( "Test" ).Where( "Age", 1 ).And( builder1 ).And( builder2 );
            Assert.Equal( $"Select * {Common.Line}From [Test] As [t] {Common.Line}Where [t].[Age]=@_p__0 And [t].[Name]=@_p_1_0 And [t].[Code]=@_p_11_0", _builder.ToSql() );
        }

        /// <summary>
        /// 连接查询条件 - 多级生成器，多条件
        /// </summary>
        [Fact]
        public void TestAnd_4() {
            //结果
            var result = new String();
            result.AppendLine( "Select * " );
            result.AppendLine( "From [Test] As [t] " );
            result.Append( "Where [t].[a]=@_p__0 And [t].[b]=@_p__1 " );
            result.Append( "And [t].[c]=@_p_1_0 And [t].[d]=@_p_1_1 " );
            result.Append( "And [t].[e]=@_p_2_0 And [t].[f]=@_p_2_1 " );
            result.Append( "And [t].[c1]=@_p_11_0 And [t].[d1]=@_p_11_1 " );
            result.Append( "And [t].[e1]=@_p_21_0 And [t].[f1]=@_p_21_1" );

            //操作
            var builder1 = _builder.New().Where( "c", 3 ).Where( "d", 4 );
            var builder11 = builder1.New().Where( "c1", 31 ).Where( "d1", 41 );
            var builder2 = _builder.New().Where( "e", 5 ).Where( "f", 6 );
            var builder21 = builder2.New().Where( "e1", 51 ).Where( "f1", 61 );
            _builder.From( "Test" ).Where( "a", 1 ).Where( "b", 2 ).And( builder1 ).And( builder2 ).And( builder11 ).And( builder21 );

            //验证
            Assert.Equal( result.ToString(), _builder.ToSql() );
        }

        #endregion
    }
}