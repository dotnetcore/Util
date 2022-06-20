using System.Text;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders {
    /// <summary>
    /// Sql生成器测试 - 集合操作
    /// </summary>
    public partial class SqlBuilderTest {

        #region 辅助方法

        /// <summary>
        /// 创建主Sql生成器
        /// </summary>
        private ISqlBuilder CreateMasterSqlBuilder() {
            return new TestSqlBuilder()
                .Select( "a" )
                .From( "b" )
                .Join( "c" ).On( "b.id", "c.id" )
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

        #region Union

        /// <summary>
        /// 测试合并结果集
        /// </summary>
        [Fact]
        public void TestUnion() {
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

            //执行
            var builder = CreateMasterSqlBuilder();
            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            builder.Union( builder2, builder3 );

            //验证
            Assert.Equal( result.ToString(), builder.GetSql() );
        }

        #endregion

        #region UnionAll

        /// <summary>
        /// 测试合并结果集
        /// </summary>
        [Fact]
        public void TestUnionAll() {
            //结果
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

            //执行
            var builder = CreateMasterSqlBuilder();
            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            builder.UnionAll( builder2, builder3 );

            //验证
            Assert.Equal( result.ToString(), builder.GetSql() );
        }

        #endregion

        #region Intersect

        /// <summary>
        /// 测试交集
        /// </summary>
        [Fact]
        public void TestIntersect() {
            //结果
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

            //执行
            var builder = CreateMasterSqlBuilder();
            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            builder.Intersect( builder2, builder3 );

            //验证
            Assert.Equal( result.ToString(), builder.GetSql() );
        }

        #endregion

        #region Except

        /// <summary>
        /// 测试差集
        /// </summary>
        [Fact]
        public void TestExcept() {
            //结果
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

            //执行
            var builder = CreateMasterSqlBuilder();
            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            builder.Except( builder2, builder3 );

            //验证
            Assert.Equal( result.ToString(), builder.GetSql() );
        }

        #endregion

        #region ClearSets

        /// <summary>
        /// 测试清理集合
        /// </summary>
        [Fact]
        public void TestClearSets() {
            //结果
            var result = new StringBuilder();
            result.AppendLine( "Select [a] " );
            result.AppendLine( "From [b] " );
            result.AppendLine( "Join [c] On [b].[id]=[c].[id] " );
            result.AppendLine( "Where [d]=1 " );
            result.AppendLine( "Group By [e] Having Count(f)>1 " );
            result.AppendLine( "Order By [g] " );
            result.Append( "Limit @_p_0 OFFSET @_p_1" );

            //执行
            var builder = CreateMasterSqlBuilder();
            var builder2 = CreateSqlBuilder2();
            var builder3 = CreateSqlBuilder3();
            builder.Union( builder2, builder3 );
            builder.ClearSets();

            //验证
            Assert.Equal( result.ToString(), builder.GetSql() );
        }

        #endregion
    }
}
