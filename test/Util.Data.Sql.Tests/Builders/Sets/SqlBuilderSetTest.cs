using System.Text;
using Util.Data.Sql.Builders.Sets;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Sets {
    /// <summary>
    /// Sql生成器集合测试
    /// </summary>
    public class SqlBuilderSetTest {

        #region 测试初始化

        /// <summary>
        /// Sql生成器集合
        /// </summary>
        private readonly SqlBuilderSet _set;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlBuilderSetTest() {
            var builder = CreateMasterSqlBuilder();
            _set = new SqlBuilderSet( builder );
        }

        /// <summary>
        /// 创建主Sql生成器
        /// </summary>
        private TestSqlBuilder CreateMasterSqlBuilder() {
            return new TestSqlBuilder()
                .Select( "a" )
                .From( "b" )
                .Join( "c" ).On( "b.id","c.id" )
                .AppendWhere( "[d]=1" )
                .GroupBy( "e" ).AppendHaving( "Count(f)>1" )
                .OrderBy( "g" )
                .Take( 10 );
        }

        /// <summary>
        /// 创建测试Sql生成器
        /// </summary>
        private ISqlBuilder CreateSqlBuilder2() {
            return new TestSqlBuilder()
                .Select( "a1" )
                .From( "b1" )
                .Join( "c1" ).On( "b1.id", "c1.id" )
                .AppendWhere( "[d1]=1" )
                .GroupBy( "e1" ).AppendHaving( "Count(f1)>1" )
                .OrderBy( "g1" )
                .Take( 20 );
        }

        /// <summary>
        /// 创建测试Sql生成器
        /// </summary>
        private ISqlBuilder CreateSqlBuilder3() {
            return new TestSqlBuilder()
                .Select( "a2" )
                .From( "b2" )
                .Join( "c2" ).On( "b2.id", "c2.id" )
                .AppendWhere( "[d2]=1" )
                .GroupBy( "e2" ).AppendHaving( "Count(f2)>1" )
                .OrderBy( "g2" )
                .Take( 30 );
        }

        #endregion

        #region ToResult

        /// <summary>
        /// 测试获取Sql - 只有主Sql生成器
        /// </summary>
        [Fact]
        public void TestToResult() {
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );
            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region Union

        /// <summary>
        /// 测试联合操作 - 合并1个查询
        /// </summary>
        [Fact]
        public void TestUnion_1() {
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            _set.Union( builder2 );

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        /// <summary>
        /// 测试联合操作 - 合并2个查询
        /// </summary>
        [Fact]
        public void TestUnion_2() {
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a2] " );
            result.AppendLine( "From [b2] " );
            result.AppendLine( "Join [c2] On [b2].[id]=[c2].[id] " );
            result.AppendLine( "Where [d2]=1 " );
            result.AppendLine( "Group By [e2] Having Count(f2)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            _set.Union( builder2, builder3 );

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region UnionAll

        /// <summary>
        /// 测试联合操作
        /// </summary>
        [Fact]
        public void TestUnionAll() {
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union All " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union All " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a2] " );
            result.AppendLine( "From [b2] " );
            result.AppendLine( "Join [c2] On [b2].[id]=[c2].[id] " );
            result.AppendLine( "Where [d2]=1 " );
            result.AppendLine( "Group By [e2] Having Count(f2)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            _set.UnionAll( builder2, builder3 );

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region Intersect

        /// <summary>
        /// 测试交集
        /// </summary>
        [Fact]
        public void TestIntersect() {
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Intersect " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Intersect " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a2] " );
            result.AppendLine( "From [b2] " );
            result.AppendLine( "Join [c2] On [b2].[id]=[c2].[id] " );
            result.AppendLine( "Where [d2]=1 " );
            result.AppendLine( "Group By [e2] Having Count(f2)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            _set.Intersect( builder2, builder3 );

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region Except

        /// <summary>
        /// 测试差集
        /// </summary>
        [Fact]
        public void TestExcept() {
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Except " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Except " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a2] " );
            result.AppendLine( "From [b2] " );
            result.AppendLine( "Join [c2] On [b2].[id]=[c2].[id] " );
            result.AppendLine( "Where [d2]=1 " );
            result.AppendLine( "Group By [e2] Having Count(f2)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            _set.Except( builder2, builder3 );

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清理
        /// </summary>
        [Fact]
        public void TestClear() {
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            var builder2 = CreateSqlBuilder2();
            _set.Union( builder2 );
            _set.Clear();

            Assert.Equal( result.ToString(), _set.ToResult() );
        }

        #endregion

        #region Clone

        /// <summary>
        /// 测试复制Sql生成器集合
        /// </summary>
        [Fact]
        public void TestClone() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "(" );
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Union " );
            result.AppendLine( "(" );
            result.AppendLine( "Select [a1] " );
            result.AppendLine( "From [b1] " );
            result.AppendLine( "Join [c1] On [b1].[id]=[c1].[id] " );
            result.AppendLine( "Where [d1]=1 " );
            result.AppendLine( "Group By [e1] Having Count(f1)>1 " );
            result.AppendLine( ")" );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            //合并一个Sql集合
            var builder2 = CreateSqlBuilder2();
            _set.Union( builder2 );

            //复制并验证
            var clone = _set.Clone( CreateMasterSqlBuilder() );
            Assert.Equal( result.ToString(), clone.ToResult() );

            //修改原始集合,复制集合不应受影响
            var builder3 = CreateSqlBuilder3();
            _set.Union( builder3 );
            Assert.Equal( result.ToString(), clone.ToResult() );
        }

        #endregion
    }
}
