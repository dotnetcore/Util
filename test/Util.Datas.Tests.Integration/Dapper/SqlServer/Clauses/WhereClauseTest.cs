using System;
using System.Linq.Expressions;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Queries.Builders.Clauses;
using Util.Datas.Sql.Queries.Builders.Conditions;
using Util.Datas.Sql.Queries.Builders.Core;
using Util.Datas.Tests.Dapper.SqlServer.Samples;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.XUnitHelpers;
using Util.Properties;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Datas.Tests.Dapper.SqlServer.Clauses {
    /// <summary>
    /// Where子句测试
    /// </summary>
    public class WhereClauseTest {

        #region 测试初始化

        /// <summary>
        /// Where子句
        /// </summary>
        private WhereClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public WhereClauseTest() {
            _clause = new WhereClause( new SqlServerDialect(), new EntityResolver(), new EntityAliasRegister(),new ParameterManager() );
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
            Assert.Equal( "Where [Age]=@_p__0 And a<@a", GetSql() );
        }

        #endregion

        #region Or(连接查询条件)

        /// <summary>
        /// 连接查询条件
        /// </summary>
        [Fact]
        public void TestOr() {
            _clause.Where( "Age", 1 );
            _clause.Or( new LessCondition( "a", "@a" ) );
            Assert.Equal( "Where ([Age]=@_p__0 Or a<@a)", GetSql() );
        }

        #endregion

        #region Where(设置条件)

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            _clause.Where( "Name", "a" );
            Assert.Equal( "Where [Name]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 表别名
        /// </summary>
        [Fact]
        public void TestWhere_2() {
            _clause.Where( "f.Name", "a" );
            Assert.Equal( "Where [f].[Name]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 多个条件
        /// </summary>
        [Fact]
        public void TestWhere_3() {
            _clause.Where( "f.Name", "a" );
            _clause.Where( "s.Age", "a" );
            Assert.Equal( "Where [f].[Name]=@_p__0 And [s].[Age]=@_p__1", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名
        /// </summary>
        [Fact]
        public void TestWhere_4() {
            _clause.Where<Sample>( t => t.Email, "a" );
            Assert.Equal( "Where [Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 设置实体解析器和实体别名注册器
        /// </summary>
        [Fact]
        public void TestWhere_5() {
            _clause = new WhereClause( new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister(), new ParameterManager() );
            _clause.Where<Sample>( t => t.Email, "a" );
            Assert.Equal( "Where [as_Sample].[t_Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda表达式设置条件
        /// </summary>
        [Fact]
        public void TestWhere_6() {
            _clause.Where<Sample>( t => t.Email == "a" );
            Assert.Equal( "Where [Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda表达式设置条件
        /// </summary>
        [Fact]
        public void TestWhere_7() {
            _clause = new WhereClause( new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister(),new ParameterManager() );
            _clause.Where<Sample>( t => t.Email == "a" );
            Assert.Equal( "Where [as_Sample].[t_Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 不相等
        /// </summary>
        [Fact]
        public void TestWhere_8() {
            _clause.Where<Sample>( t => t.Email != "a" );
            Assert.Equal( "Where [Email]!=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于
        /// </summary>
        [Fact]
        public void TestWhere_9() {
            _clause.Where<Sample>( t => t.IntValue > 1 );
            Assert.Equal( "Where [IntValue]>@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于
        /// </summary>
        [Fact]
        public void TestWhere_10() {
            _clause.Where<Sample>( t => t.IntValue < 1 );
            Assert.Equal( "Where [IntValue]<@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 大于等于
        /// </summary>
        [Fact]
        public void TestWhere_11() {
            _clause.Where<Sample>( t => t.IntValue >= 1 );
            Assert.Equal( "Where [IntValue]>=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 小于等于
        /// </summary>
        [Fact]
        public void TestWhere_12() {
            _clause.Where<Sample>( t => t.IntValue <= 1 );
            Assert.Equal( "Where [IntValue]<=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - Contains
        /// </summary>
        [Fact]
        public void TestWhere_13() {
            _clause.Where<Sample>( t => t.Email.Contains( "a" ) );
            Assert.Equal( "Where [Email] Like @_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - StartsWith
        /// </summary>
        [Fact]
        public void TestWhere_14() {
            _clause.Where<Sample>( t => t.Email.StartsWith( "a" ) );
            Assert.Equal( "Where [Email] Like @_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - EndsWith
        /// </summary>
        [Fact]
        public void TestWhere_15() {
            _clause.Where<Sample>( t => t.Email.EndsWith( "a" ) );
            Assert.Equal( "Where [Email] Like @_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 与连接
        /// </summary>
        [Fact]
        public void TestWhere_16() {
            _clause.Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) );
            Assert.Equal( "Where [Email]=@_p__0 And [StringValue] Like @_p__1", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置条件 - 设置多个条件 - 或连接
        /// </summary>
        [Fact]
        public void TestWhere_17() {
            //结果
            var result = new String();
            result.Append( "Where ([Email]=@_p__0 And [StringValue] Like @_p__1 Or [IntValue]=@_p__2) " );
            result.Append( "And ([Email]=@_p__3 Or [IntValue]=@_p__4)" );

            //执行
            _clause.Where<Sample>( t => t.Email == "a" && t.StringValue.Contains( "b" ) || t.IntValue == 1 );
            _clause.Where<Sample>( t => t.Email == "c" || t.IntValue == 2 );

            //验证
            Assert.Equal( result.ToString(), GetSql() );
        }

        #endregion

        #region WhereIf(设置条件)

        /// <summary>
        /// 设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_1() {
            _clause.WhereIf( "Name", "a", true );
            Assert.Equal( "Where [Name]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_2() {
            _clause.WhereIf( "Name", "a", false );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_3() {
            _clause.WhereIf<Sample>( t => t.Email, "a", true );
            Assert.Equal( "Where [Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名  - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_4() {
            _clause.WhereIf<Sample>( t => t.Email, "a", false );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_5() {
            _clause.WhereIf<Sample>( t => t.Email == "a", true );
            Assert.Equal( "Where [Email]=@_p__0", GetSql() );
        }

        /// <summary>
        /// 设置条件 - 通过lambda设置列名 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIf_6() {
            _clause.WhereIf<Sample>( t => t.Email == "a", false );
            Assert.Null( GetSql() );
        }

        #endregion

        #region WhereIfNotEmpty(设置条件)

        /// <summary>
        /// 设置条件 - 添加条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_1() {
            _clause.WhereIfNotEmpty( "Name", "a" );
            Assert.Equal( "Where [Name]=@_p__0", GetSql() );
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
            Assert.Equal( "Where [Email]=@_p__0", GetSql() );
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
            Assert.Equal( "Where [Email] Like @_p__0", GetSql() );
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
            _clause.AppendSql( "a");
            _clause.AppendSql( "b" );
            Assert.Equal( "Where a And b", GetSql() );
        }

        #endregion
    }
}
