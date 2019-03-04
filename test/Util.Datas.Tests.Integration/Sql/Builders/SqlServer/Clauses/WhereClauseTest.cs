using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Queries;
using Util.Datas.Sql;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.Sql.Builders.Samples;
using Util.Datas.Tests.XUnitHelpers;
using Util.Properties;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Clauses {
    /// <summary>
    /// Where子句测试
    /// </summary>
    public class WhereClauseTest {

        #region 测试初始化

        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly ParameterManager _parameterManager;
        /// <summary>
        /// 表数据库
        /// </summary>
        private readonly TestTableDatabase _database;
        /// <summary>
        /// Sql生成器
        /// </summary>
        private readonly SqlServerBuilder _builder;
        /// <summary>
        /// Where子句
        /// </summary>
        private WhereClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public WhereClauseTest() {
            _parameterManager = new ParameterManager( new SqlServerDialect() );
            _database = new TestTableDatabase();
            _builder = new SqlServerBuilder( new TestEntityMatedata(), null, _parameterManager );
            _clause = new WhereClause( _builder, new SqlServerDialect(), new EntityResolver(), new EntityAliasRegister(), _parameterManager );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        #endregion

        #region And(连接查询条件)

        /// <summary>
        /// 连接查询条件
        /// </summary>
        [Fact]
        public void TestAnd() {
            _clause.Where( "Age", 1 );
            _clause.And( new LessCondition( "a", "@a" ) );
            Assert.Equal( "Where [Age]=@_p_0 And a<@a", GetSql() );
        }

        #endregion

        #region Or(连接查询条件)

        /// <summary>
        /// Or查询条件
        /// </summary>
        [Fact]
        public void TestOr() {
            _clause.Where( "Age", 1 );
            _clause.Or( new LessCondition( "a", "@a" ) );
            Assert.Equal( "Where ([Age]=@_p_0 Or a<@a)", GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 一个条件
        /// </summary>
        [Fact]
        public void TestOr_2() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Or<Sample>( t => list.Contains( t.Email ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 2个条件
        /// </summary>
        [Fact]
        public void TestOr_3() {
            //结果
            var result = new String();
            result.Append( "Where ([Email] In (@_p_0,@_p_1) Or [Url]=@_p_2)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Or<Sample>( t => list.Contains( t.Email ), t => t.Url == "a" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 2个条件 - 参数值为空时添加条件
        /// </summary>
        [Fact]
        public void TestOr_4() {
            //结果
            var result = new String();
            result.Append( "Where ([Email] In (@_p_0,@_p_1) Or [Url]=@_p_2)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Or<Sample>( t => list.Contains( t.Email ), t => t.Url == "" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - And和Or混合添加条件
        /// </summary>
        [Fact]
        public void TestOr_5() {
            //结果
            var result = new String();
            result.Append( "Where (([Email]=@_p_0 Or " );
            result.Append( "[Email] In (@_p_1,@_p_2)) Or [Url]=@_p_3) " );
            result.Append( "And [Url]=@_p_4" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Where<Sample>( t => t.Email == "b" );
            _clause.Or<Sample>( t => list.Contains( t.Email ), t => t.Url == "a" );
            _clause.Where<Sample>( t => t.Url == "c" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 一个条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_1() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.OrIfNotEmpty<Sample>( t => list.Contains( t.Email ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 2个条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_2() {
            //结果
            var result = new String();
            result.Append( "Where ([Email] In (@_p_0,@_p_1) Or [Url]=@_p_2)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.OrIfNotEmpty<Sample>( t => list.Contains( t.Email ), t => t.Url == "a" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - 2个条件 - 参数值为空时不添加条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_3() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.OrIfNotEmpty<Sample>( t => list.Contains( t.Email ), t => t.Url == "" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// Or查询条件 - lambda - And和Or混合添加条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_4() {
            //结果
            var result = new String();
            result.Append( "Where (([Email]=@_p_0 Or " );
            result.Append( "[Email] In (@_p_1,@_p_2)) Or [Url]=@_p_3) " );
            result.Append( "And [Url]=@_p_4" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Where<Sample>( t => t.Email == "b" );
            _clause.OrIfNotEmpty<Sample>( t => list.Contains( t.Email ), t => t.Url == "a" );
            _clause.Where<Sample>( t => t.Url == "c" );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Where(设置条件)

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            _clause.Where( "Name", "a" );
            Assert.Equal( "Where [Name]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 表别名
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            _clause.Where( "f.Name", "a" );
            Assert.Equal( "Where [f].[Name]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 多个条件
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            _clause.Where( "f.Name", "a" );
            _clause.Where( "s.Age", "a" );
            Assert.Equal( "Where [f].[Name]=@_p_0 And [s].[Age]=@_p_1", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名
        /// </summary>
        [Fact]
        public void TestWhere_4() {
            _clause.Where<Sample>( t => t.Email, "a" );
            Assert.Equal( "Where [Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 设置实体解析器和实体别名注册器
        /// </summary>
        [Fact]
        public void TestWhere_5() {
            _clause = new WhereClause( null, new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister(), new ParameterManager( new SqlServerDialect() ) );
            _clause.Where<Sample>( t => t.Email, "a" );
            Assert.Equal( "Where [as_Sample].[t_Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda表达式设置条件
        /// </summary>
        [Fact]
        public void TestWhere_6() {
            _clause.Where<Sample>( t => t.Email == "a" );
            Assert.Equal( "Where [Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda表达式设置条件
        /// </summary>
        [Fact]
        public void TestWhere_7() {
            _clause = new WhereClause( null, new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister(), new ParameterManager( new SqlServerDialect() ) );
            _clause.Where<Sample>( t => t.Email == "a" );
            Assert.Equal( "Where [as_Sample].[t_Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 不相等
        /// </summary>
        [Fact]
        public void TestWhere_8() {
            _clause.Where<Sample>( t => t.Email != "a" );
            Assert.Equal( "Where [Email]<>@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于
        /// </summary>
        [Fact]
        public void TestWhere_9() {
            _clause.Where<Sample>( t => t.IntValue > 1 );
            Assert.Equal( "Where [IntValue]>@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于
        /// </summary>
        [Fact]
        public void TestWhere_10() {
            _clause.Where<Sample>( t => t.IntValue < 1 );
            Assert.Equal( "Where [IntValue]<@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于等于
        /// </summary>
        [Fact]
        public void TestWhere_11() {
            _clause.Where<Sample>( t => t.IntValue >= 1 );
            Assert.Equal( "Where [IntValue]>=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于等于
        /// </summary>
        [Fact]
        public void TestWhere_12() {
            _clause.Where<Sample>( t => t.IntValue <= 1 );
            Assert.Equal( "Where [IntValue]<=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - Contains
        /// </summary>
        [Fact]
        public void TestWhere_13() {
            _clause.Where<Sample>( t => t.Email.Contains( "a" ) );
            Assert.Equal( "Where [Email] Like @_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - StartsWith
        /// </summary>
        [Fact]
        public void TestWhere_14() {
            _clause.Where<Sample>( t => t.Email.StartsWith( "a" ) );
            Assert.Equal( "Where [Email] Like @_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - EndsWith
        /// </summary>
        [Fact]
        public void TestWhere_15() {
            _clause.Where<Sample>( t => t.Email.EndsWith( "a" ) );
            Assert.Equal( "Where [Email] Like @_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 与连接
        /// </summary>
        [Fact]
        public void TestWhere_16() {
            _clause.Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) );
            Assert.Equal( "Where [Email]=@_p_0 And [StringValue] Like @_p_1", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 或连接
        /// </summary>
        [Fact]
        public void TestWhere_17() {
            //结果
            var result = new String();
            result.Append( "Where ([Email]=@_p_0 And [StringValue] Like @_p_1 Or [IntValue]=@_p_2) " );
            result.Append( "And ([Email]=@_p_3 Or [IntValue]=@_p_4)" );

            //执行
            _clause.Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) || t.IntValue == 1 );
            _clause.Where<Sample>( t => t.Email == "c" || t.IntValue == 2 );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置条件 - Is Null
        /// </summary>
        [Fact]
        public void TestWhere_18() {
            _clause.Where<Sample>( t => t.Email == null );
            Assert.Equal( "Where [Email] Is Null", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 空字符串使用=
        /// </summary>
        [Fact]
        public void TestWhere_19() {
            _clause.Where<Sample>( t => t.Email == "" );
            Assert.Equal( "Where [Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - Is Not Null
        /// </summary>
        [Fact]
        public void TestWhere_20() {
            _clause.Where<Sample>( t => t.Email != null );
            Assert.Equal( "Where [Email] Is Not Null", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 空字符串使用不等号
        /// </summary>
        [Fact]
        public void TestWhere_21() {
            _clause.Where<Sample>( t => t.Email != "" );
            Assert.Equal( "Where [Email]<>@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - In
        /// </summary>
        [Fact]
        public void TestWhere_22() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.Where<Sample>( t => list.Contains( t.Email ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region WhereIfNotEmpty(设置条件)

        /// <summary>
        /// 设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_1() {
            _clause.WhereIfNotEmpty( "Name", "a" );
            Assert.Equal( "Where [Name]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_2() {
            _clause.WhereIfNotEmpty( "Name", "" );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_3() {
            _clause.WhereIfNotEmpty<Sample>( t => t.Email, "a" );
            Assert.Equal( "Where [Email]=@_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_4() {
            _clause.WhereIfNotEmpty<Sample>( t => t.Email, "" );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_5() {
            _clause.WhereIfNotEmpty<Sample>( t => t.Email.Contains( "a" ) );
            Assert.Equal( "Where [Email] Like @_p_0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_6() {
            _clause.WhereIfNotEmpty<Sample>( t => t.Email == "" );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 仅允许设置一个条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_7() {
            Expression<Func<Sample, bool>> condition = t => t.Email.Contains( "a" ) && t.IntValue == 1;
            AssertHelper.Throws<InvalidOperationException>( () => {
                _clause.WhereIfNotEmpty( condition );
            }, string.Format( LibraryResource.OnlyOnePredicate, condition ) );
        }

        #endregion

        #region AppendSql(添加到Where子句)

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        [Fact]
        public void TestAppendSql() {
            _clause.AppendSql( "a" );
            _clause.AppendSql( "b" );
            Assert.Equal( "Where a And b", GetSql() );
        }

        #endregion

        #region IsNull

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        [Fact]
        public void TestIsNull_1() {
            _clause.IsNull( "Name" );
            Assert.Equal( "Where [Name] Is Null", GetSql() );
        }

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        [Fact]
        public void TestIsNull_2() {
            _clause.IsNull<Sample>( t => t.Email );
            Assert.Equal( "Where [Email] Is Null", GetSql() );
        }

        #endregion

        #region IsNotNull

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        [Fact]
        public void TestIsNotNull_1() {
            _clause.IsNotNull( "Name" );
            Assert.Equal( "Where [Name] Is Not Null", GetSql() );
        }

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        [Fact]
        public void TestIsNotNull_2() {
            _clause.IsNotNull<Sample>( t => t.Email );
            Assert.Equal( "Where [Email] Is Not Null", GetSql() );
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsEmpty_1() {
            _clause.IsEmpty( "Name" );
            Assert.Equal( "Where ([Name] Is Null Or [Name]='')", GetSql() );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsEmpty_2() {
            _clause.IsEmpty<Sample>( t => t.Email );
            Assert.Equal( "Where ([Email] Is Null Or [Email]='')", GetSql() );
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsNotEmpty_1() {
            _clause.IsNotEmpty( "Name" );
            Assert.Equal( "Where [Name] Is Not Null And [Name]<>''", GetSql() );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        [Fact]
        public void TestIsNotEmpty_2() {
            _clause.IsNotEmpty<Sample>( t => t.Email );
            Assert.Equal( "Where [Email] Is Not Null And [Email]<>''", GetSql() );
        }

        #endregion

        #region In

        /// <summary>
        /// 设置In条件
        /// </summary>
        [Fact]
        public void TestIn_1() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.In( "user.Email", list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - lambda列名表达式
        /// </summary>
        [Fact]
        public void TestIn_2() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.In<Sample>( t => t.Email, list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - 数组
        /// </summary>
        [Fact]
        public void TestIn_3() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] In (@_p_0,@_p_1)" );

            //执行
            var list = new[] { "a", "b" };
            _clause.In( "user.Email", list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - 子查询
        /// </summary>
        [Fact]
        public void TestIn_4() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );
            result.Append( ")" );

            //执行
            var builder = _builder.New().Select( "a" ).From( "b" );
            _clause.In( "user.Email", builder );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - 子查询 - 属性表达式
        /// </summary>
        [Fact]
        public void TestIn_5() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (" );
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );
            result.Append( ")" );

            //执行
            var builder = _builder.New().Select( "a" ).From( "b" );
            _clause.In<Sample>( t => t.Email, builder );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - 子查询 - 委托
        /// </summary>
        [Fact]
        public void TestIn_6() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] In (" );
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );
            result.Append( ")" );

            //执行
            _clause.In( "user.Email", builder => builder.Select( "a" ).From( "b" ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置In条件 - 子查询 - 委托 - 属性表达式
        /// </summary>
        [Fact]
        public void TestIn_7() {
            //结果
            var result = new String();
            result.Append( "Where [Email] In (" );
            result.AppendLine( "Select [a] " );
            result.Append( "From [b]" );
            result.Append( ")" );

            //执行
            _clause.In<Sample>( t => t.Email, builder => builder.Select( "a" ).From( "b" ) );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region NotIn

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        [Fact]
        public void TestNotIn_1() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.NotIn( "user.Email", list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置Not In条件 - lambda列名表达式
        /// </summary>
        [Fact]
        public void TestNotIn_2() {
            //结果
            var result = new String();
            result.Append( "Where [Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new List<string> { "a", "b" };
            _clause.NotIn<Sample>( t => t.Email, list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 设置Not In条件 - 数组
        /// </summary>
        [Fact]
        public void TestNotIn_3() {
            //结果
            var result = new String();
            result.Append( "Where [user].[Email] Not In (@_p_0,@_p_1)" );

            //执行
            var list = new[] { "a", "b" };
            _clause.NotIn( "user.Email", list );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Between(范围查询)

        /// <summary>
        /// 测试范围查询 - 整型
        /// </summary>
        [Fact]
        public void TestBetween_1() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1, 2, Boundary.Both );

            //验证
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 不包含边界
        /// </summary>
        [Fact]
        public void TestBetween_2() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            _clause.Between( "a.B", 1, 2, Boundary.Neither );

            //验证
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestBetween_3() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            _clause.Between( "a.B", 2, 1, Boundary.Neither );

            //验证
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestBetween_4() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]<=@_p_0" );

            //执行
            _clause.Between( "a.B", null, 2, Boundary.Both );

            //验证
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestBetween_5() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            _clause.Between( "a.B", 1, null, Boundary.Both );

            //验证
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void TestBetween_6() {
            //执行
            _clause.Between( "a.B", null, null, Boundary.Both );

            //验证
            Assert.Empty( _parameterManager.GetParams() );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - double
        /// </summary>
        [Fact]
        public void TestBetween_7() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1.2, 3.4, Boundary.Both );

            //验证
            Assert.Equal( 1.2, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 3.4, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - decimal
        /// </summary>
        [Fact]
        public void TestBetween_8() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            _clause.Between( "a.B", 1.2M, 3.4M, Boundary.Both );

            //验证
            Assert.Equal( 1.2M, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 3.4M, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间
        /// </summary>
        [Fact]
        public void TestBetween_9() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<=@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, true, null );

            //验证
            Assert.Equal( min, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( max, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间
        /// </summary>
        [Fact]
        public void TestBetween_10() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0 And [a].[B]<@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-1" ), _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( DateTime.Parse( "2000-1-3" ), _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 设置边界
        /// </summary>
        [Fact]
        public void TestBetween_11() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>@_p_0 And [a].[B]<@_p_1" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", min, max, true, Boundary.Neither );

            //验证
            Assert.Equal( min, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( max, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 整型 - lambda
        /// </summary>
        [Fact]
        public void TestBetween_12() {
            //结果
            var result = new String();
            result.Append( "Where [IntValue]>=@_p_0 And [IntValue]<=@_p_1" );

            //执行
            _clause.Between<Sample>( t => t.IntValue, 1, 2, Boundary.Both );

            //验证
            Assert.Equal( 1, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( 2, _parameterManager.GetParams()["@_p_1"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间 - 最大值为空
        /// </summary>
        [Fact]
        public void TestBetween_13() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            _clause.Between( "a.B", min, null, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-1" ), _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间  - 最大值为空
        /// </summary>
        [Fact]
        public void TestBetween_14() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]>=@_p_0" );

            //执行
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            _clause.Between( "a.B", min, null, true, null );

            //验证
            Assert.Equal( min, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 不包含时间 - 最小值为空
        /// </summary>
        [Fact]
        public void TestBetween_15() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]<@_p_0" );

            //执行
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", null, max, false, null );

            //验证
            Assert.Equal( DateTime.Parse( "2000-1-3" ), _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        /// <summary>
        /// 测试范围查询 - 日期 - 包含时间 - 最小值为空
        /// </summary>
        [Fact]
        public void TestBetween_16() {
            //结果
            var result = new String();
            result.Append( "Where [a].[B]<=@_p_0" );

            //执行
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            _clause.Between( "a.B", null, max, true, null );

            //验证
            Assert.Equal( max, _parameterManager.GetParams()["@_p_0"] );
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region Clone(复制副本)

        /// <summary>
        /// 复制副本
        /// </summary>
        [Fact]
        public void TestClone() {
            _clause.Where( "Name", "a" );

            //复制副本
            var copy = _clause.Clone( null, null, _parameterManager.Clone() );
            Assert.Equal( "Where [Name]=@_p_0", GetSql() );
            Assert.Equal( "Where [Name]=@_p_0", copy.ToSql() );

            //修改副本
            copy.Where( "Code", 1 );
            Assert.Equal( "Where [Name]=@_p_0", GetSql() );
            Assert.Equal( "Where [Name]=@_p_0 And [Code]=@_p_1", copy.ToSql() );

            //修改原对象
            _clause.Where( "Age", 1 );
            Assert.Equal( "Where [Name]=@_p_0 And [Age]=@_p_1", GetSql() );
            Assert.Equal( "Where [Name]=@_p_0 And [Code]=@_p_1", copy.ToSql() );
        }

        #endregion
    }
}
