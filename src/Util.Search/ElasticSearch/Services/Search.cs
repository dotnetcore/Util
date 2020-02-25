using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nest;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Util.Search.ElasticSearch.Services {
    /// <summary>
    /// 搜索操作
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class Search<TResult> where TResult : class {
        /// <summary>
        /// ElasticSearch客户端
        /// </summary>
        private readonly ElasticClient _client;
        /// <summary>
        /// 查询参数
        /// </summary>
        private readonly IQueryParameter _queryParam;
        /// <summary>
        /// 索引
        /// </summary>
        private string _index;
        /// <summary>
        /// 分页大小
        /// </summary>
        private int? _size;
        /// <summary>
        /// 起始行数
        /// </summary>
        private int? _from;
        /// <summary>
        /// 排序列表
        /// </summary>
        private readonly List<ISort> _sorts;
        /// <summary>
        /// 包含字段集合
        /// </summary>
        private readonly List<Field> _includeFields;
        /// <summary>
        /// 排除字段集合
        /// </summary>
        private readonly List<Field> _excludeFields;
        /// <summary>
        /// 折叠字段
        /// </summary>
        private Field _collapseField;
        /// <summary>
        /// 搜索条件
        /// </summary>
        private readonly Query<TResult> _query;

        /// <summary>
        /// 初始化搜索操作
        /// </summary>
        /// <param name="search">搜索操作</param>
        /// <param name="query">查询参数</param>
        public Search( IElasticSearch search, IQueryParameter query ) {
            search.CheckNull( nameof( search ) );
            query.CheckNull( nameof( query ) );
            _client = search.GetClient();
            _queryParam = query;
            _sorts = new List<ISort>();
            _includeFields = new List<Field>();
            _excludeFields = new List<Field>();
            _query = new Query<TResult>();
        }

        /// <summary>
        /// 设置索引名称或别名
        /// </summary>
        /// <param name="index">索引名称，也可以是别名</param>
        public Search<TResult> Index( string index ) {
            _index = index;
            return this;
        }

        /// <summary>
        /// 搜索全部索引
        /// </summary>
        public Search<TResult> AllIndex() {
            _index = "_all";
            return this;
        }

        /// <summary>
        /// 获取当前查询对象
        /// </summary>
        public Query<TResult> GetQuery() {
            return _query;
        }

        /// <summary>
        /// 创建新的查询对象
        /// </summary>
        public Query<TResult> NewQuery() {
            return new Query<TResult>();
        }

        /// <summary>
        /// 设置起始行数，从0开始
        /// </summary>
        /// <param name="from">起始行数</param>
        public Search<TResult> From( int from ) {
            _from = from;
            return this;
        }

        /// <summary>
        /// 设置分页大小
        /// </summary>
        /// <param name="size">分页大小</param>
        public Search<TResult> Size( int size ) {
            _size = size;
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression">排序字段表达式</param>
        /// <param name="desc">是否降序</param>
        public Search<TResult> OrderBy<TProperty>( Expression<Func<TResult, TProperty>> expression, bool desc = false ) {
            _sorts.Add( new FieldSort { Field = new Field( expression ), Order = GetOrder( desc ) } );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression">排序字段表达式</param>
        /// <param name="desc">是否降序</param>
        /// <param name="condition">当值为true时添加排序</param>
        public Search<TResult> OrderByIf<TProperty>( Expression<Func<TResult, TProperty>> expression, bool desc, bool condition ) {
            return condition ? OrderBy( expression, desc ) : this;
        }

        /// <summary>
        /// 获取排序方向
        /// </summary>
        private SortOrder GetOrder( bool desc ) {
            return desc ? SortOrder.Descending : SortOrder.Ascending;
        }

        /// <summary>
        /// 设置包含字段列表
        /// </summary>
        /// <param name="fields">字段列表</param>
        public Search<TResult> IncludeFields( string fields ) {
            Fields fieldList = fields;
            _includeFields.AddRange( fieldList.ToArray() );
            return this;
        }

        /// <summary>
        /// 设置包含字段
        /// </summary>
        /// <param name="expression">字段表达式</param>
        public Search<TResult> IncludeField<TProperty>( Expression<Func<TResult, TProperty>> expression ) {
            var field = new Field( expression );
            _includeFields.Add( field );
            return this;
        }

        /// <summary>
        /// 设置排除字段列表
        /// </summary>
        /// <param name="fields">字段列表</param>
        public Search<TResult> ExcludeFields( string fields ) {
            Fields fieldList = fields;
            _excludeFields.AddRange( fieldList.ToArray() );
            return this;
        }

        /// <summary>
        /// 设置排除字段
        /// </summary>
        /// <param name="expression">字段表达式</param>
        public Search<TResult> ExcludeField<TProperty>( Expression<Func<TResult, TProperty>> expression ) {
            var field = new Field( expression );
            _excludeFields.Add( field );
            return this;
        }

        /// <summary>
        /// 设置折叠字段
        /// </summary>
        /// <param name="expression">字段表达式</param>
        public Search<TResult> Collapse<TProperty>( Expression<Func<TResult, TProperty>> expression ) {
            _collapseField = new Field( expression );
            return this;
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="condition">查询条件</param>
        public Search<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, ICondition condition ) {
            _query.Nest( path, condition );
            return this;
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="condition">查询条件</param>
        public Search<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, QueryContainer condition ) {
            _query.Nest( path, condition );
            return this;
        }

        /// <summary>
        /// 嵌套查询
        /// </summary>
        /// <param name="path">嵌套字段</param>
        /// <param name="action">查询操作</param>
        public Search<TResult> Nest<TProperty>( Expression<Func<TResult, TProperty>> path, Action<Query<TResult>> action ) {
            _query.Nest( path, action );
            return this;
        }

        /// <summary>
        /// 精确匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Search<TResult> Term<TProperty>( Expression<Func<TResult, TProperty>> expression, object value ) {
            _query.Term( expression, value );
            return this;
        }

        /// <summary>
        /// 精确匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Search<TResult> TermIf<TProperty>( Expression<Func<TResult, TProperty>> expression, object value, bool condition ) {
            _query.TermIf( expression, value, condition );
            return this;
        }

        /// <summary>
        /// 精确匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Search<TResult> TermIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, object value ) {
            _query.TermIfNotEmpty( expression, value );
            return this;
        }

        /// <summary>
        /// 精确匹配词条列表
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        public Search<TResult> Terms<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values ) {
            _query.Terms( expression, values );
            return this;
        }

        /// <summary>
        /// 精确匹配词条列表
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Search<TResult> TermsIf<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values, bool condition ) {
            _query.TermsIf( expression, values, condition );
            return this;
        }

        /// <summary>
        /// 精确匹配词条列表，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="values">值</param>
        public Search<TResult> TermsIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, IEnumerable<object> values ) {
            _query.TermsIfNotEmpty( expression, values );
            return this;
        }

        /// <summary>
        /// 匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Search<TResult> Match<TProperty>( Expression<Func<TResult, TProperty>> expression, string value ) {
            _query.Match( expression, value );
            return this;
        }

        /// <summary>
        /// 匹配词条
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">为true时才添加条件</param>
        public Search<TResult> MatchIf<TProperty>( Expression<Func<TResult, TProperty>> expression, string value, bool condition ) {
            _query.MatchIf( expression, value, condition );
            return this;
        }

        /// <summary>
        /// 匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="expression">字段表达式</param>
        /// <param name="value">值</param>
        public Search<TResult> MatchIfNotEmpty<TProperty>( Expression<Func<TResult, TProperty>> expression, string value ) {
            _query.MatchIfNotEmpty( expression, value );
            return this;
        }

        /// <summary>
        /// 多字段匹配词条
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="expressions">字段表达式列表</param>
        public Search<TResult> MultiMatch( string value, params Expression<Func<TResult, object>>[] expressions ) {
            _query.MultiMatch( value, expressions );
            return this;
        }

        /// <summary>
        /// 多字段匹配词条，当值为空时忽略条件
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="expressions">字段表达式列表</param>
        public Search<TResult> MultiMatchIfNotEmpty( string value, params Expression<Func<TResult, object>>[] expressions ) {
            _query.MultiMatchIfNotEmpty( value, expressions );
            return this;
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Search<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, int? min, int? max = null, Boundary boundary = Boundary.Both ) {
            _query.Between( propertyExpression, min, max, boundary );
            return this;
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
        public Search<TResult> BetweenIf<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, bool condition, int? min, int? max = null, Boundary boundary = Boundary.Both ) {
            _query.BetweenIf( propertyExpression, condition, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 匹配范围
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public Search<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, double? min, double? max = null, Boundary boundary = Boundary.Both ) {
            _query.Between( propertyExpression, min, max, boundary );
            return this;
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
        public Search<TResult> BetweenIf<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, bool condition, double? min, double? max = null, Boundary boundary = Boundary.Both ) {
            _query.BetweenIf( propertyExpression, condition, min, max, boundary );
            return this;
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
        public Search<TResult> Between<TProperty>( Expression<Func<TResult, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) {
            _query.Between( propertyExpression, min, max, includeTime, boundary );
            return this;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public async Task<PagerList<TResult>> GetResultAsync() {
            var result = await GetEsResultAsync();
            return CreateResult( result );
        }

        /// <summary>
        /// 获取ElasticSearch结果
        /// </summary>
        public async Task<ISearchResponse<TResult>> GetEsResultAsync() {
            var request = new SearchRequest<TResult>( GetIndex() ) {
                From = GetFrom(),
                Size = GetSize(),
                Sort = _sorts,
                Source = GetSource(),
                Collapse = GetCollapse(),
                Query = GetCondition()
            };
            return await _client.SearchAsync<TResult>( request );
        }

        /// <summary>
        /// 获取索引
        /// </summary>
        private string GetIndex() {
            return Extensions.GetIndex<TResult>( _index );
        }

        /// <summary>
        /// 获取起始行数
        /// </summary>
        private int GetFrom() {
            if ( _from > 0 )
                return _from.SafeValue();
            return _queryParam.GetStartNumber() - 1;
        }

        /// <summary>
        /// 获取分页大小
        /// </summary>
        private int GetSize() {
            if ( _size > 0 )
                return _size.SafeValue();
            return _queryParam.PageSize;
        }

        /// <summary>
        /// 获取源过滤器
        /// </summary>
        private SourceFilter GetSource() {
            return new SourceFilter {
                Includes = GetIncludeFields(),
                Excludes = GetExcludeFields()
            };
        }

        /// <summary>
        /// 获取包含字段
        /// </summary>
        private Fields GetIncludeFields() {
            if ( _includeFields.Count == 0 )
                return "*";
            return _includeFields.ToArray();
        }

        /// <summary>
        /// 获取排除字段
        /// </summary>
        private Fields GetExcludeFields() {
            return _excludeFields.ToArray();
        }

        /// <summary>
        /// 获取折叠
        /// </summary>
        private IFieldCollapse GetCollapse() {
            if ( _collapseField == null )
                return null;
            return new FieldCollapse {
                Field = _collapseField
            };
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        private QueryContainer GetCondition() {
            return _query.GetCondition();
        }

        /// <summary>sg
        /// 创建分页结果
        /// </summary>
        private PagerList<TResult> CreateResult( ISearchResponse<TResult> result ) {
            _queryParam.TotalCount = Convert.ToInt32( result.Total );
            return new PagerList<TResult>( _queryParam, result.Documents.ToList() );
        }
    }
}
