using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.Sql.Builders.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Clauses {
    /// <summary>
    /// Group By子句测试
    /// </summary>
    public class GroupByClauseTest {
        /// <summary>
        /// 分组子句
        /// </summary>
        private GroupByClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GroupByClauseTest() {
            _clause = new GroupByClause( new SqlServerDialect(), new EntityResolver(), new EntityAliasRegister() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 默认输出空
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 测试分组
        /// </summary>
        [Fact]
        public void TestGroupBy_1() {
            _clause.GroupBy( "a" );
            Assert.Equal( "Group By [a]", GetSql() );
        }

        /// <summary>
        /// 测试分组
        /// </summary>
        [Fact]
        public void TestGroupBy_2() {
            _clause.GroupBy( "a.B,c.D" );
            Assert.Equal( "Group By [a].[B],[c].[D]", GetSql() );
        }

        /// <summary>
        /// 测试分组 - 验证分组字段为空
        /// </summary>
        [Fact]
        public void TestGroupBy_3() {
            _clause.GroupBy( "" );
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 测试分组 - 分组条件
        /// </summary>
        [Fact]
        public void TestGroupBy_4() {
            _clause.GroupBy( "a","b" );
            Assert.Equal( "Group By [a] Having b", GetSql() );
        }

        /// <summary>
        /// 测试分组 - lambda
        /// </summary>
        [Fact]
        public void TestGroupBy_5() {
            _clause.GroupBy<Sample>( t => t.Email, "b" );
            Assert.Equal( "Group By [Email] Having b", GetSql() );
        }

        /// <summary>
        /// 测试分组 - 别名
        /// </summary>
        [Fact]
        public void TestGroupBy_6() {
            _clause = new GroupByClause( new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister() );
            _clause.GroupBy<Sample>( t => t.Email, "b" );
            Assert.Equal( "Group By [as_Sample].[t_Email] Having b", GetSql() );
        }

        /// <summary>
        /// 测试分组 - 多个GroupBy
        /// </summary>
        [Fact]
        public void TestGroupBy_7() {
            _clause.GroupBy( "a", "b" );
            _clause.GroupBy<Sample>( t => t.Email, "c" );
            Assert.Equal( "Group By [a],[Email] Having c", GetSql() );
        }

        /// <summary>
        /// 测试分组 - Append
        /// </summary>
        [Fact]
        public void TestGroupBy_8() {
            _clause.GroupBy( "a" );
            _clause.GroupBy( "b" );
            _clause.AppendSql( "c" );
            _clause.AppendSql( "d" );
            Assert.Equal( "Group By [a],[b],c,d", GetSql() );
        }
    }
}
