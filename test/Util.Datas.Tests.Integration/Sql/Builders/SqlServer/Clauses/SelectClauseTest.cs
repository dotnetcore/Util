using System.Collections.Generic;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.Sql.Builders.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.SqlServer.Clauses {
    /// <summary>
    /// Select子句测试
    /// </summary>
    public class SelectClauseTest {
        /// <summary>
        /// Select子句
        /// </summary>
        private SelectClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectClauseTest() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new EntityResolver(), new EntityAliasRegister() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 复制副本
        /// </summary>
        [Fact]
        public void TestClone() {
            _clause.Select( "a" );
            var copy = _clause.Clone( null, null );
            copy.Select( "b" );
            Assert.Equal( "Select [a]", GetSql() );
            Assert.Equal( "Select [a],[b]", copy.ToSql() );
        }

        /// <summary>
        /// 设置Distinct
        /// </summary>
        [Fact]
        public void TestDistinct() {
            _clause.Distinct();
            _clause.Select( "a" );
            Assert.Equal( "Select Distinct [a]", GetSql() );
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        [Fact]
        public void TestCount_1() {
            _clause.Count();
            Assert.Equal( "Select Count(*)", GetSql() );
        }

        /// <summary>
        /// 求总行数 - 加列别名
        /// </summary>
        [Fact]
        public void TestCount_2() {
            _clause.Count( "a" );
            Assert.Equal( "Select Count(*) As [a]", GetSql() );
        }

        /// <summary>
        /// 求总行数 - 加列别名 - 加列名
        /// </summary>
        [Fact]
        public void TestCount_3() {
            _clause.Count( "a", "b" );
            Assert.Equal( "Select Count([a]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求总行数 - lambda表达式
        /// </summary>
        [Fact]
        public void TestCount_4() {
            _clause.Count<Sample>( t => t.DoubleValue, "b" );
            Assert.Equal( "Select Count([DoubleValue]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求和
        /// </summary>
        [Fact]
        public void TestSum_1() {
            _clause.Sum( "a" );
            Assert.Equal( "Select Sum([a])", GetSql() );
        }

        /// <summary>
        /// 求和 - 加列别名
        /// </summary>
        [Fact]
        public void TestSum_2() {
            _clause.Sum( "a", "b" );
            Assert.Equal( "Select Sum([a]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求和 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSum_3() {
            _clause.Sum<Sample>( t => t.DoubleValue, "b" );
            Assert.Equal( "Select Sum([DoubleValue]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求和 - 同时求行数
        /// </summary>
        [Fact]
        public void TestSum_4() {
            _clause.Sum( "a", "b" );
            _clause.Count( "c" );
            Assert.Equal( "Select Sum([a]) As [b],Count(*) As [c]", GetSql() );
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        [Fact]
        public void TestAvg_1() {
            _clause.Avg( "a" );
            Assert.Equal( "Select Avg([a])", GetSql() );
        }

        /// <summary>
        /// 求平均值 - 加列别名
        /// </summary>
        [Fact]
        public void TestAvg_2() {
            _clause.Avg( "a", "b" );
            Assert.Equal( "Select Avg([a]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求平均值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestAvg_3() {
            _clause.Avg<Sample>( t => t.DoubleValue, "b" );
            Assert.Equal( "Select Avg([DoubleValue]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        [Fact]
        public void TestMax_1() {
            _clause.Max( "a" );
            Assert.Equal( "Select Max([a])", GetSql() );
        }

        /// <summary>
        /// 求最大值 - 加列别名
        /// </summary>
        [Fact]
        public void TestMax_2() {
            _clause.Max( "a", "b" );
            Assert.Equal( "Select Max([a]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求最大值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestMax_3() {
            _clause.Max<Sample>( t => t.DoubleValue, "b" );
            Assert.Equal( "Select Max([DoubleValue]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        [Fact]
        public void TestMin_1() {
            _clause.Min( "a" );
            Assert.Equal( "Select Min([a])", GetSql() );
        }

        /// <summary>
        /// 求最小值 - 加列别名
        /// </summary>
        [Fact]
        public void TestMin_2() {
            _clause.Min( "a", "b" );
            Assert.Equal( "Select Min([a]) As [b]", GetSql() );
        }

        /// <summary>
        /// 求最小值 - lambda表达式
        /// </summary>
        [Fact]
        public void TestMin_3() {
            _clause.Min<Sample>( t => t.DoubleValue, "b" );
            Assert.Equal( "Select Min([DoubleValue]) As [b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 默认使用*
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            Assert.Equal( "Select *", GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            _clause.Select( "a" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 设置表别名
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            _clause.Select( "a", "b" );
            Assert.Equal( "Select [b].[a]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列带前缀
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            _clause.Select( "a.b" );
            Assert.Equal( "Select [a].[b]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列具有中括号
        /// </summary>
        [Fact]
        public void TestSelect_5() {
            _clause.Select( "[a]" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列
        /// </summary>
        [Fact]
        public void TestSelect_6() {
            _clause.Select( "a,[b]" );
            Assert.Equal( "Select [a],[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列 - 设置表别名
        /// </summary>
        [Fact]
        public void TestSelect_7() {
            _clause.Select( "a,[b]", "c" );
            Assert.Equal( "Select [c].[a],[c].[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列 - 设置表别名 - 列带前缀
        /// </summary>
        [Fact]
        public void TestSelect_8() {
            _clause.Select( "d.a,[b]", "c" );
            Assert.Equal( "Select [d].[a],[c].[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_9() {
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            Assert.Equal( "Select [Email],[IntValue]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多个Select
        /// </summary>
        [Fact]
        public void TestSelect_10() {
            _clause.Select( "a" );
            _clause.Select( "b" );
            Assert.Equal( "Select [a],[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 每个Select使用不同的别名
        /// </summary>
        [Fact]
        public void TestSelect_11() {
            _clause.Select( "a,b", "j" );
            _clause.Select( "c,d", "k" );
            Assert.Equal( "Select [j].[a],[j].[b],[k].[c],[k].[d]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多个*
        /// </summary>
        [Fact]
        public void TestSelect_12() {
            _clause.Select( "a.*,b.*" );
            Assert.Equal( "Select [a].*,[b].*", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_13() {
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            _clause.Select<Sample2>( t => new object[] { t.Description, t.Display } );
            Assert.Equal( "Select [Email],[IntValue],[Description],[Display]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名
        /// </summary>
        [Fact]
        public void TestSelect_14() {
            _clause.Select( "t.a As e,[b],f.g", "k" );
            _clause.Select( "n" );
            Assert.Equal( "Select [t].[a] As [e],[k].[b],[f].[g],[n]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名，增加了空格
        /// </summary>
        [Fact]
        public void TestSelect_15() {
            _clause.Select( "t.a    As     [e]      ,        b aS          f ", "d" );
            Assert.Equal( "Select [t].[a] As [e],[d].[b] As [f]", GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_17() {
            _clause.Select( "a.b,c,d", "o" );
            _clause.AppendSql( "e=1," );
            _clause.Select( "f" );
            _clause.AppendSql( "g" );
            _clause.Select( "h" );
            Assert.Equal( "Select [a].[b],[o].[c],[o].[d],e=1,[f],g[h]", GetSql() );
        }

        /// <summary>
        /// 测试实体解析器
        /// </summary>
        [Fact]
        public void TestSelect_18() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new TestEntityResolver(), new EntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            Assert.Equal( "Select [t_Email],[t_IntValue]", GetSql() );
        }

        /// <summary>
        /// 测试实体别名注册器
        /// </summary>
        [Fact]
        public void TestSelect_19() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            var result = _clause.ToSql();
            Assert.Equal( "Select [as_Sample].[t_Email],[as_Sample].[t_IntValue]", result );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 设置单个列名
        /// </summary>
        [Fact]
        public void TestSelect_20() {
            _clause.Select<Sample>( t => t.Email );
            Assert.Equal( "Select [Email]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 设置单个列名和列别名
        /// </summary>
        [Fact]
        public void TestSelect_21() {
            _clause.Select<Sample>( t => t.Email, "e" );
            Assert.Equal( "Select [Email] As [e]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 以字典方式设置单个列名和列别名
        /// </summary>
        [Fact]
        public void TestSelect_22() {
            _clause.Select<Sample>( t => new Dictionary<object, string> { { t.Email, "e" } } );
            Assert.Equal( "Select [Email] As [e]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 以字典方式设置多个列名和列别名
        /// </summary>
        [Fact]
        public void TestSelect_23() {
            _clause.Select<Sample>( t => new Dictionary<object, string> { { t.Email, "e" }, { t.Url, "u" } } );
            Assert.Equal( "Select [Email] As [e],[Url] As [u]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 以字典方式设置多个列名和列别名 - 元数据解析
        /// </summary>
        [Fact]
        public void TestSelect_24() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new EntityResolver( new TestEntityMatedata() ), new TestEntityAliasRegister() );
            _clause.Select<Sample>( t => new Dictionary<object, string> { { t.Email, "e" }, { t.Url, "u" } } );
            var result = _clause.ToSql();
            Assert.Equal( "Select [as_Sample].[Sample_Email] As [e],[as_Sample].[Sample_Url] As [u]", result );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 将属性名映射为列别名
        /// </summary>
        [Fact]
        public void TestSelect_25() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new EntityResolver( new TestEntityMatedata() ), new TestEntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue }, true );
            var result = _clause.ToSql();
            Assert.Equal( "Select [as_Sample].[Sample_Email] As [Email],[as_Sample].[Sample_IntValue] As [IntValue]", result );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 将属性名映射为列别名 - 如果属性名和列名相同，不会生成As
        /// </summary>
        [Fact]
        public void TestSelect_26() {
            _clause = new SelectClause( new SqlServerBuilder(), new SqlServerDialect(), new EntityResolver( new TestEntityMatedata() ), new TestEntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.DecimalValue }, true );
            var result = _clause.ToSql();
            Assert.Equal( "Select [as_Sample].[Sample_Email] As [Email],[as_Sample].[DecimalValue]", result );
        }

        /// <summary>
        /// 添加select子句
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            _clause.AppendSql( "a" );
            Assert.Equal( "Select a", GetSql() );
        }

        /// <summary>
        /// 添加select子句 - 带方括号
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            _clause.AppendSql( "[a].[b]" );
            Assert.Equal( "Select [a].[b]", GetSql() );
        }
    }
}
