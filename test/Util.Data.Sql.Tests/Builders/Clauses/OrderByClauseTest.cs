using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Clauses {
    /// <summary>
    /// Order By子句测试
    /// </summary>
    public class OrderByClauseTest {

        #region 测试初始化

        /// <summary>
        /// 排序子句
        /// </summary>
        private readonly OrderByClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OrderByClauseTest() {
            _clause = new OrderByClause( new TestSqlBuilder() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql( IOrderByClause clause = null ) {
            clause ??= _clause;
            var builder = new StringBuilder();
            clause.AppendTo( builder );
            return builder.ToString();
        }

        #endregion

        #region  默认输出

        /// <summary>
        /// 默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Empty( GetSql() );
        }

        #endregion

        #region OrderBy

        /// <summary>
        /// 测试排序 - 升序
        /// </summary>
        [Fact]
        public void TestOrderBy_1() {
            _clause.OrderBy( "a.B" );
            Assert.Equal( "Order By [a].[B]", GetSql() );
        }

        /// <summary>
        /// 测试排序 - asc关键字
        /// </summary>
        [Fact]
        public void TestOrderBy_2() {
            _clause.OrderBy( "a.B asc" );
            Assert.Equal( "Order By [a].[B]", GetSql() );
        }

        /// <summary>
        /// 测试排序 - 降序
        /// </summary>
        [Fact]
        public void TestOrderBy_3() {
            _clause.OrderBy( "a.B desc" );
            Assert.Equal( "Order By [a].[B] Desc", GetSql() );
        }

        /// <summary>
        /// 测试排序 - 2个排序列
        /// </summary>
        [Fact]
        public void TestOrderBy_4() {
            _clause.OrderBy( "a.B,c.D desc" );
            Assert.Equal( "Order By [a].[B],[c].[D] Desc", GetSql() );
        }

        /// <summary>
        /// 测试排序 - 2个排序列 - 添加多余空格
        /// </summary>
        [Fact]
        public void TestOrderBy_5() {
            _clause.OrderBy( " a .B, c. D desc " );
            Assert.Equal( "Order By [a].[B],[c].[D] Desc", GetSql() );
        }

        /// <summary>
        /// 测试排序 - 多次调用
        /// </summary>
        [Fact]
        public void TestOrderBy_6() {
            _clause.OrderBy( "a.B,c.D desc" );
            _clause.OrderBy( "[e].F ASC,g.H DESC" );
            Assert.Equal( "Order By [a].[B],[c].[D] Desc,[e].[F],[g].[H] Desc", GetSql() );
        }

        #endregion

        #region AppendSql

        /// <summary>
        /// 测试添加到Order By子句 - 替换[]为特定转义字符
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            var clause = new OrderByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a].[b]", false );
            Assert.Equal( "Order By $a&.$b&", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Order By子句 - 原样添加
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            var clause = new OrderByClause( new TestSqlBuilder( new TestDialect2(), new TestColumnCache( new TestDialect2() ) ) );
            clause.AppendSql( "[a].[b]", true );
            Assert.Equal( "Order By [a].[b]", GetSql( clause ) );
        }

        /// <summary>
        /// 测试添加到Order By子句 - 多次调用
        /// </summary>
        [Fact]
        public void TestAppendSql_3() {
            _clause.OrderBy( "a.b DESC" );
            _clause.OrderBy( "c,D.e desc" );
            _clause.AppendSql( "a", true );
            _clause.AppendSql( "b", true );
            Assert.Equal( "Order By [a].[b] Desc,[c],[D].[e] Desc,ab", GetSql() );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            _clause.OrderBy( "a.b DESC" );
            _clause.OrderBy( "c,D.e desc" );
            _clause.AppendSql( "a", true );
            _clause.AppendSql( "b", true );
            _clause.Clear();
            Assert.Empty( GetSql() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Order By子句
        /// </summary>
        [Fact]
        public void TestClone() {
            //设置排序
            _clause.OrderBy( "a.B" );

            //复制并验证
            var clone = _clause.Clone( new TestSqlBuilder() );
            Assert.Equal( "Order By [a].[B]", GetSql( clone ) );

            //修改原始子句,复制子句不应受影响
            _clause.OrderBy( "c" );
            Assert.Equal( "Order By [a].[B]", GetSql( clone ) );
        }

        #endregion
    }
}
