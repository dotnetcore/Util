using System;
using System.Linq.Expressions;
using System.Text;
using Util.Datas.Queries;
using Util.Datas.Queries.Criterias;
using Util.Properties;
using Util.Tests.Samples;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Datas.Queries {
    /// <summary>
    /// 查询对象测试
    /// </summary>
    public class QueryTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public QueryTest() {
            _query = new Query<AggregateRootSample>();
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        private IQuery<AggregateRootSample> _query;

        /// <summary>
        /// 测试获取分页
        /// </summary>
        [Fact]
        public void TestGetPager() {
            QueryParameterSample sample = new QueryParameterSample() {
                Order = "A",
                Page = 2,
                PageSize = 30,
                TotalCount = 40
            };
            _query = new Query<AggregateRootSample>( sample );
            _query.OrderBy( "B", true );
            var pager = _query.GetPager();
            Assert.Equal( 2, pager.Page );
            Assert.Equal( 30, pager.PageSize );
            Assert.Equal( 40, pager.TotalCount );
            Assert.Equal( "A,B desc", pager.Order );
        }

        /// <summary>
        /// 测试添加查询条件- 当值为空时，不会被忽略
        /// </summary>
        [Fact]
        public void TestWhere() {
            _query.Where( t => t.Name == "A" );
            Assert.Equal( "t => (t.Name == \"A\")", _query.GetPredicate().SafeString() );

            _query.Where( t => t.Tel == 1 );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().SafeString() );

            _query = new Query<AggregateRootSample>();
            _query.Where( t => t.Name == "A" && t.Tel == 1 );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().SafeString() );

            _query = new Query<AggregateRootSample>();
            _query.Where( t => t.Name == "" );
            Assert.NotNull( _query.GetPredicate() );
        }

        /// <summary>
        /// 测试添加查询条件 - 添加规约对象,当值为空时，不会被忽略
        /// </summary>
        [Fact]
        public void TestWhere_Criteria() {
            _query.Where( new CriteriaSample() );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().ToString() );

            _query = new Query<AggregateRootSample>();
            _query.Where( new DefaultCriteria<AggregateRootSample>( t => t.Name == null ) );
            Assert.NotNull( _query.GetPredicate() );
        }

        /// <summary>
        /// 测试添加查询条件 - 当第二个参数为false表示不添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_False() {
            _query.WhereIf( t => t.Name == "A", false );
            Assert.Null( _query.GetPredicate() );

            _query.WhereIf( t => t.Name == "A", true );
            Assert.Equal( "t => (t.Name == \"A\")", _query.GetPredicate().SafeString() );
        }

        /// <summary>
        /// 测试添加查询条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty() {
            _query.WhereIfNotEmpty( t => t.Name == "" );
            Assert.Null( _query.GetPredicate() );

            _query.WhereIfNotEmpty( t => t.Name == null );
            Assert.Null( _query.GetPredicate() );

            _query.WhereIfNotEmpty( t => t.Name == "A" );
            Assert.Equal( "t => (t.Name == \"A\")", _query.GetPredicate().ToString() );

            _query.WhereIfNotEmpty( d => d.Tel == 1 );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试添加查询条件 - 同时添加2个查询条件，抛出异常
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_2Condition_Throw() {
            AssertHelper.Throws<InvalidOperationException>( () => {
                _query.WhereIfNotEmpty( t => t.Name == "A" && t.Tel == 1 );
            }, string.Format( LibraryResource.OnlyOnePredicate, "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))" ) );
        }

        /// <summary>
        /// 添加范围查询条件 - 整型
        /// </summary>
        [Fact]
        public void TestBetween_Int() {
            _query.Between( t => t.Tel, 1, 10, Boundary.Left );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel < 10))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 添加范围查询条件 - double
        /// </summary>
        [Fact]
        public void TestBetween_Double() {
            _query.Between( t => t.DoubleValue, 1.1, 10.1, Boundary.Right );
            Assert.Equal( "t => ((t.DoubleValue > 1.1) AndAlso (t.DoubleValue <= 10.1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 添加范围查询条件 - decimal
        /// </summary>
        [Fact]
        public void TestBetween_Decimal() {
            _query.Between( t => t.DecimalValue, 1.1M, 10.1M, Boundary.Neither );
            Assert.Equal( "t => ((t.DecimalValue > 1.1) AndAlso (t.DecimalValue < 10.1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 添加范围查询条件 - 日期  - 不包含时间
        /// </summary>
        [Fact]
        public void TestBetween_Date() {
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/1 0:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 0:00:00\"), DateTime)))" );

            _query.Between( t => t.DateValue, min, max, false );
            Assert.Equal( result.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 添加范围查询条件 - 日期  - 包含时间
        /// </summary>
        [Fact]
        public void TestBetween_DateTime() {
            var min = DateTime.Parse( "2000-1-1 10:10:10" );
            var max = DateTime.Parse( "2000-1-2 10:10:10" );
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/1 10:10:10\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue <= Convert(Parse(\"2000/1/2 10:10:10\"), DateTime)))" );

            _query.Between( t => t.DateValue, min, max );
            Assert.Equal( result.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestOrderBy() {
            QueryParameterSample sample = new QueryParameterSample { Order = "Name" };
            _query = new Query<AggregateRootSample>( sample );
            Assert.Equal( "Name", _query.GetOrder() );

            _query.OrderBy( "Age", true );
            Assert.Equal( "Name,Age desc", _query.GetOrder() );

            _query.OrderBy( t => t.Tel, true );
            Assert.Equal( "Name,Age desc,Tel desc", _query.GetOrder() );
        }

        /// <summary>
        /// 测试与连接
        /// </summary>
        [Fact]
        public void TestAnd() {
            Expression<Func<AggregateRootSample, bool>> expression = null;
            _query.And( expression );
            _query.And( t => t.Name == "A" );
            Assert.Equal( "t => (t.Name == \"A\")", _query.GetPredicate().ToString() );

            _query.And( t => t.Tel == 1 );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试与连接 - 连接查询对象
        /// </summary>
        [Fact]
        public void TestAnd_Query() {
            var query = new Query<AggregateRootSample>();
            query.Where( t => t.Name == "A" );
            query.OrderBy( t => t.Name );
            _query.And( query );
            Assert.Equal( "t => (t.Name == \"A\")", _query.GetPredicate().ToString() );
            Assert.Equal( "Name", _query.GetOrder() );

            query = new Query<AggregateRootSample>();
            query.Where( t => t.Tel == 1 );
            query.OrderBy( t => t.Tel, true );
            _query.And( query );
            Assert.Equal( "t => ((t.Name == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().ToString() );
            Assert.Equal( "Name,Tel desc", _query.GetOrder() );
        }

        /// <summary>
        /// 测试或连接
        /// </summary>
        [Fact]
        public void TestOr() {
            Expression<Func<AggregateRootSample, bool>> expression = null;
            _query.Or( expression );

            _query.Where( t => t.Name == "A" );
            var query = new Query<AggregateRootSample>();
            query.Where( t => t.Tel == 1 );
            _query.Or( query );
            Assert.Equal( "t => ((t.Name == \"A\") OrElse (t.Tel == 1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试或连接
        /// </summary>
        [Fact]
        public void TestOr_2() {
            _query.Or( t => t.Name == "A", t => t.Name == "", t => t.Tel == 1 );
            Assert.Equal( "t => ((t.Name == \"A\") OrElse (t.Tel == 1))", _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试或连接 - 连接查询对象
        /// </summary>
        [Fact]
        public void TestOr_Query() {
            _query.OrderBy( t => t.Name );
            _query.Where( t => t.Name == "A" );
            _query.Where( t => t.EnglishName == "A" );

            var query2 = new Query<AggregateRootSample>();
            query2.OrderBy( t => t.Age, true );
            query2.Where( t => t.Name == "B" );
            query2.Where( t => t.Age == 1 );
            _query.Or( query2 );

            var query3 = new Query<AggregateRootSample>();
            query3.OrderBy( t => t.Tel );
            query3.Where( t => t.Name == "C" );
            query3.Where( t => t.Age > 10 );
            _query.And( query3 );

            Expression<Func<AggregateRootSample, bool>> expected = t => ( ( t.Name == "A" && t.EnglishName == "A" )
                || ( t.Name == "B" && t.Age == 1 ) ) && ( t.Name == "C" && t.Age > 10 );
            Assert.Equal( expected.ToString(), _query.GetPredicate().ToString() );
            Assert.Equal( "Name,Age desc,Tel", _query.GetOrder() );
        }
    }
}
