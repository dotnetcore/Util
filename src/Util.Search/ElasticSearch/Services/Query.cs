using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nest;
using Util.Datas.Queries;
using Util.Search.ElasticSearch.Services.Conditions;

namespace Util.Search.ElasticSearch.Services {
    /// <summary>
    /// 查询操作
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class Query<TResult> : ICondition where TResult : class {
        /// <summary>
        /// 搜索条件
        /// </summary>
        private QueryContainer _query;

        /// <summary>
        /// 与联接
        /// </summary>
        /// <param name="condition">查询条件</param>
        public Query<TResult> And( ICondition condition ) {
            if ( condition == null )
                return this;
            return And( condition.GetCondition() );
        }

        /// <summary>
        /// 与联接
        /// </summary>
        /// <param name="condition">查询条件</param>
        public Query<TResult> And( QueryContainer condition ) {
            if ( condition == null )
                return this;
            if ( _query == null ) {
                _query = condition;
                return this;
            }
            _query = _query && condition;
            return this;
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="condition">查询条件</param>
        public Query<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, ICondition condition ) {
            if ( condition == null )
                return this;
            return Nest( path, condition.GetCondition() );
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="condition">查询条件</param>
        public Query<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, QueryContainer condition ) {
            if ( path == null || condition == null )
                return this;
            var result = new NestedQuery {
                Path = new Field( path ),
                Query = condition
            };
            return And( result );
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="action">查询操作</param>
        public Query<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, Action<Query<TResult>> action ) {
            if ( action == null )
                return this;
            var query = new Query<TResult>();
            action( query );
            return Nest( path, query );
        }

        /// <summary>
        /// 精确匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Query<TResult> Term<TProperty>( Expression<Func<TResult, TProperty>> expression, object value ) {
            var condition = new TermQuery {
                Field = new Field( expression ),
                Value = value
            };
            return And( condition );
        }

        /// <summary>
        /// 精确匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Query<TResult> TermIf<TProperty>( Expression<Func<TResult, TProperty>> expression, object value, bool condition ) {
            return condition ? Term( expression, value ) : this;
        }

        /// <summary>
        /// 精确匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Query<TResult> TermIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, object value ) {
            return TermIf( expression, value, value.SafeString().IsEmpty() == false );
        }

        /// <summary>
        /// 精确匹配词条列表
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        public Query<TResult> Terms<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values ) {
            var condition = new TermsQuery {
                Field = new Field( expression ),
                Terms = values
            };
            return And( condition );
        }

        /// <summary>
        /// 精确匹配词条列表
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Query<TResult> TermsIf<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values, bool condition ) {
            return condition ? Terms( expression, values ) : this;
        }

        /// <summary>
        /// 精确匹配词条列表，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        public Query<TResult> TermsIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values ) {
            if ( values == null )
                return this;
            var list = values.ToList();
            return list.Count == 0 ? this : Terms( expression, list );
        }

        /// <summary>
        /// 匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Query<TResult> Match<TProperty>( Expression<Func<TResult, TProperty>> expression, string value ) {
            var condition = new MatchQuery {
                Field = new Field( expression ),
                Query = value
            };
            return And( condition );
        }

        /// <summary>
        /// 匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Query<TResult> MatchIf<TProperty>( Expression<Func<TResult, TProperty>> expression, string value, bool condition ) {
            return condition ? Match( expression, value ) : this;
        }

        /// <summary>
        /// 匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Query<TResult> MatchIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, string value ) {
            return MatchIf( expression, value, value.SafeString().IsEmpty() == false );
        }

        /// <summary>
        /// 多字段匹配词条
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="expressions">字段表达式列表</param>
        public Query<TResult> MultiMatch( string value, params Expression<Func<TResult, object>>[] expressions ) {
            var condition = new MultiMatchQuery {
                Fields = CreateFields( expressions ),
                Query = value
            };
            return And( condition );
        }

        /// <summary>
        /// 创建字段列表
        /// </summary>
        private Fields CreateFields( Expression<Func<TResult, object>>[] expressions ) {
            if ( expressions == null || expressions.Length == 0 )
                return "*";
            return expressions;
        }

        /// <summary>
        /// 多字段匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="expressions">字段表达式列表</param>
        public Query<TResult> MultiMatchIfNotEmpty( string value, params Expression<Func<TResult, object>>[] expressions ) {
            if ( value.IsEmpty() )
                return this;
            return MultiMatch( value, expressions );
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Query<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both ) {
            return And( new LongRangeCondition<TResult, TProperty>( propertyExpression, min, max, boundary ) );
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="condition">为true时才添加条件</param>
        /// <param name="min">最小值</param> 
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Query<TResult> BetweenIf<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, bool condition, int? min, int? max = null, Boundary boundary = Boundary.Both ) {
            return condition ? Between( propertyExpression, min, max, boundary ) : this;
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Query<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, double? min, double? max, Boundary boundary = Boundary.Both ) {
            return And( new DoubleRangeCondition<TResult, TProperty>( propertyExpression, min, max, boundary ) );
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="condition">为true时才添加条件</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Query<TResult> BetweenIf<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, bool condition, double? min, double? max = null, Boundary boundary = Boundary.Both ) {
            return condition ? Between( propertyExpression, min, max, boundary ) : this;
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Time</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public Query<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) {
            if ( includeTime )
                return And( new DateTimeRangeCondition<TResult, TProperty>( propertyExpression, min, max, boundary ?? Boundary.Both ) );
            return And( new DateRangeCondition<TResult, TProperty>( propertyExpression, min, max, boundary ?? Boundary.Left ) );
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public QueryContainer GetCondition() {
            if ( _query == null )
                return new MatchAllQuery();
            return _query;
        }
    }
}
