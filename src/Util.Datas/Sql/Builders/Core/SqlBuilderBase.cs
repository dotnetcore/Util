using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Filters;
using Util.Datas.Sql.Matedatas;
using Util.Domains.Repositories;
using Util.Helpers;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public abstract class SqlBuilderBase : ISqlBuilder, IClauseAccessor, IUnionAccessor, ICteAccessor {

        #region 字段

        /// <summary>
        /// 参数管理器
        /// </summary>
        private IParameterManager _parameterManager;
        /// <summary>
        /// Sql方言
        /// </summary>
        private IDialect _dialect;
        /// <summary>
        /// Select子句
        /// </summary>
        private ISelectClause _selectClause;
        /// <summary>
        /// From子句
        /// </summary>
        private IFromClause _fromClause;
        /// <summary>
        /// Join子句
        /// </summary>
        private IJoinClause _joinClause;
        /// <summary>
        /// Where子句
        /// </summary>
        private IWhereClause _whereClause;
        /// <summary>
        /// GroupBy子句
        /// </summary>
        private IGroupByClause _groupByClause;
        /// <summary>
        /// OrderBy子句
        /// </summary>
        private IOrderByClause _orderByClause;
        /// <summary>
        /// 参数字面值解析器
        /// </summary>
        private IParamLiteralsResolver _paramLiteralsResolver;
        /// <summary>
        /// 是否已添加过滤器
        /// </summary>
        private bool _isAddFilters;
        /// <summary>
        /// 已排除过滤器集合
        /// </summary>
        private List<Type> _excludedFilters;
        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="parameterManager">参数管理器</param>
        protected SqlBuilderBase( IEntityMatedata matedata = null,ITableDatabase tableDatabase = null, IParameterManager parameterManager = null ) {
            EntityMatedata = matedata;
            TableDatabase = tableDatabase;
            _parameterManager = parameterManager;
            EntityResolver = new EntityResolver( matedata );
            AliasRegister = new EntityAliasRegister();
            Pager = new Pager();
            UnionItems = new List<BuilderItem>();
            CteItems = new List<BuilderItem>();
            _excludedFilters = new List<Type>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 实体元数据解析器
        /// </summary>
        protected IEntityMatedata EntityMatedata { get; private set; }
        /// <summary>
        /// 表数据库
        /// </summary>
        protected ITableDatabase TableDatabase { get; private set; }
        /// <summary>
        /// 实体解析器
        /// </summary>
        protected IEntityResolver EntityResolver { get; private set; }
        /// <summary>
        /// 实体别名注册器
        /// </summary>
        protected IEntityAliasRegister AliasRegister { get; private set; }
        /// <summary>
        /// 参数管理器
        /// </summary>
        protected IParameterManager ParameterManager => _parameterManager ?? ( _parameterManager = CreateParameterManager() );
        /// <summary>
        /// Sql方言
        /// </summary>
        protected IDialect Dialect => _dialect ?? ( _dialect = GetDialect() );
        /// <summary>
        /// Select子句
        /// </summary>
        public ISelectClause SelectClause => _selectClause ?? ( _selectClause = CreateSelectClause() );
        /// <summary>
        /// From子句
        /// </summary>
        public IFromClause FromClause => _fromClause ?? ( _fromClause = CreateFromClause() );
        /// <summary>
        /// Join子句
        /// </summary>
        public IJoinClause JoinClause => _joinClause ?? ( _joinClause = CreateJoinClause() );
        /// <summary>
        /// Where子句
        /// </summary>
        public IWhereClause WhereClause => _whereClause ?? ( _whereClause = CreatewWhereClause() );
        /// <summary>
        /// GroupBy子句
        /// </summary>
        public IGroupByClause GroupByClause => _groupByClause ?? ( _groupByClause = CreateGroupByClause() );
        /// <summary>
        /// OrderBy子句
        /// </summary>
        public IOrderByClause OrderByClause => _orderByClause ?? ( _orderByClause = CreateOrderByClause() );
        /// <summary>
        /// 参数字面值解析器
        /// </summary>
        protected IParamLiteralsResolver ParamLiteralsResolver => _paramLiteralsResolver ?? ( _paramLiteralsResolver = GetParamLiteralsResolver() );
        /// <summary>
        /// 跳过行数参数名
        /// </summary>
        protected string OffsetParam { get; private set; }
        /// <summary>
        /// 限制行数参数名
        /// </summary>
        protected string LimitParam { get; private set; }
        /// <summary>
        /// 联合操作项集合
        /// </summary>
        public List<BuilderItem> UnionItems { get; private set; }
        /// <summary>
        /// 公用表表达式CTE集合
        /// </summary>
        public List<BuilderItem> CteItems { get; private set; }
        /// <summary>
        /// 分页
        /// </summary>
        public IPager Pager { get; private set; }
        /// <summary>
        /// 是否包含联合操作
        /// </summary>
        public bool IsUnion => UnionItems.Count > 0;
        /// <summary>
        /// 是否包含分组操作
        /// </summary>
        public bool IsGroup => GroupByClause.IsGroup;

        #endregion

        #region 工厂方法

        /// <summary>
        /// 创建参数管理器
        /// </summary>
        protected virtual IParameterManager CreateParameterManager() {
            return new ParameterManager( Dialect );
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected abstract IDialect GetDialect();

        /// <summary>
        /// 创建Select子句
        /// </summary>
        protected virtual ISelectClause CreateSelectClause() {
            return new SelectClause( this, Dialect, EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        protected virtual IFromClause CreateFromClause() {
            return new FromClause( this, Dialect, EntityResolver, AliasRegister, TableDatabase );
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        protected virtual IJoinClause CreateJoinClause() {
            return new JoinClause( this, Dialect, EntityResolver, AliasRegister, ParameterManager,TableDatabase );
        }

        /// <summary>
        /// 创建Where子句
        /// </summary>
        protected virtual IWhereClause CreatewWhereClause() {
            return new WhereClause( this, Dialect, EntityResolver, AliasRegister, ParameterManager );
        }

        /// <summary>
        /// 创建分组子句
        /// </summary>
        protected virtual IGroupByClause CreateGroupByClause() {
            return new GroupByClause( Dialect, EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建排序子句
        /// </summary>
        protected virtual IOrderByClause CreateOrderByClause() {
            return new OrderByClause( Dialect, EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 获取参数字面值解析器
        /// </summary>
        protected virtual IParamLiteralsResolver GetParamLiteralsResolver() {
            return new ParamLiteralsResolver();
        }

        #endregion

        #region Clone(复制Sql生成器)

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        public abstract ISqlBuilder Clone();

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        /// <param name="sqlBuilder">源生成器</param>
        protected void Clone( SqlBuilderBase sqlBuilder ) {
            EntityMatedata = sqlBuilder.EntityMatedata;
            _parameterManager = sqlBuilder._parameterManager?.Clone();
            EntityResolver = sqlBuilder.EntityResolver ?? new EntityResolver( EntityMatedata );
            AliasRegister = sqlBuilder.AliasRegister?.Clone() ?? new EntityAliasRegister();
            _selectClause = sqlBuilder._selectClause?.Clone( this, AliasRegister );
            _fromClause = sqlBuilder._fromClause?.Clone( this, AliasRegister );
            _joinClause = sqlBuilder._joinClause?.Clone( this, AliasRegister, _parameterManager );
            _whereClause = sqlBuilder._whereClause?.Clone( this, AliasRegister, _parameterManager );
            _groupByClause = sqlBuilder._groupByClause?.Clone( AliasRegister );
            _orderByClause = sqlBuilder._orderByClause?.Clone( AliasRegister );
            Pager = sqlBuilder.Pager;
            OffsetParam = sqlBuilder.OffsetParam;
            LimitParam = sqlBuilder.LimitParam;
            UnionItems = sqlBuilder.UnionItems.Select( t => new BuilderItem( t.Name, t.Builder.Clone() ) ).ToList();
            CteItems = sqlBuilder.CteItems.Select( t => new BuilderItem( t.Name, t.Builder.Clone() ) ).ToList();
            _excludedFilters = sqlBuilder._excludedFilters;
        }

        #endregion

        #region Clear(清空)

        /// <summary>
        /// 清空
        /// </summary>
        public ISqlBuilder Clear() {
            AliasRegister = new EntityAliasRegister();
            ClearSelect();
            ClearFrom();
            ClearJoin();
            ClearWhere();
            ClearGroupBy();
            ClearOrderBy();
            ClearSqlParams();
            ClearPageParams();
            ClearUnionBuilders();
            ClearCte();
            return this;
        }

        /// <summary>
        /// 清空Select子句
        /// </summary>
        public ISqlBuilder ClearSelect() {
            _selectClause = CreateSelectClause();
            return this;
        }

        /// <summary>
        /// 清空From子句
        /// </summary>
        public ISqlBuilder ClearFrom() {
            _fromClause = CreateFromClause();
            return this;
        }

        /// <summary>
        /// 清空Join子句
        /// </summary>
        public ISqlBuilder ClearJoin() {
            _joinClause = CreateJoinClause();
            return this;
        }

        /// <summary>
        /// 清空Where子句
        /// </summary>
        public ISqlBuilder ClearWhere() {
            _isAddFilters = false;
            _whereClause = CreatewWhereClause();
            return this;
        }

        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        public ISqlBuilder ClearGroupBy() {
            _groupByClause = CreateGroupByClause();
            return this;
        }

        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        public ISqlBuilder ClearOrderBy() {
            _orderByClause = CreateOrderByClause();
            return this;
        }

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        public ISqlBuilder ClearSqlParams() {
            _parameterManager.Clear();
            return this;
        }

        /// <summary>
        /// 清空分页参数
        /// </summary>
        public ISqlBuilder ClearPageParams() {
            Pager = null;
            OffsetParam = null;
            LimitParam = null;
            return this;
        }

        /// <summary>
        /// 清空联合操作项
        /// </summary>
        public ISqlBuilder ClearUnionBuilders() {
            UnionItems = new List<BuilderItem>();
            return this;
        }

        /// <summary>
        /// 清空公用表表达式
        /// </summary>
        public ISqlBuilder ClearCte() {
            CteItems = new List<BuilderItem>();
            return this;
        }

        #endregion

        #region New(创建Sql生成器)

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public abstract ISqlBuilder New();

        #endregion

        #region ToDebugSql(生成调试Sql语句)

        /// <summary>
        /// 生成调试Sql语句
        /// </summary>
        public virtual string ToDebugSql() {
            return GetDebugSql( ToSql() );
        }

        /// <summary>
        /// 获取调试Sql
        /// </summary>
        private string GetDebugSql( string sql ) {
            var parameters = GetParams();
            foreach( var parameter in parameters )
                sql = Regex.Replace( sql, $@"{parameter.Key}\b", ParamLiteralsResolver.GetParamLiterals( parameter.Value ) );
            return sql;
        }

        #endregion

        #region ToSql(生成Sql语句)

        /// <summary>
        /// 生成Sql语句
        /// </summary>
        public virtual string ToSql() {
            Init();
            Validate();
            var result = new StringBuilder();
            CreateSql( result );
            return result.ToString().Trim();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            OrderByClause.OrderBy( Pager?.Order );
        }

        /// <summary>
        /// 验证
        /// </summary>
        public virtual void Validate() {
            FromClause.Validate();
            OrderByClause.Validate( IsLimit );
        }

        /// <summary>
        /// 是否限制行数
        /// </summary>
        protected bool IsLimit => string.IsNullOrWhiteSpace( LimitParam ) == false;

        /// <summary>
        /// 创建Sql语句
        /// </summary>
        protected virtual void CreateSql( StringBuilder result ) {
            CreateCte( result );
            if( _isAddFilters == false )
                AddFilters();
            if( IsUnion ) {
                CreateSqlByUnion( result );
                return;
            }
            CreateSqlByNoUnion( result );
        }

        /// <summary>
        /// 创建CTE
        /// </summary>
        protected virtual void CreateCte( StringBuilder result ) {
            if( CteItems.Count == 0 )
                return;
            var cte = new StringBuilder();
            cte.Append( $"{GetCteKeyWord()} " );
            foreach( var item in CteItems ) {
                cte.AppendLine( $"{Dialect.SafeName( item.Name )} " );
                cte.AppendLine( $"As ({item.Builder.ToSql()})," );
            }
            result.AppendLine( cte.ToString().RemoveEnd( $",{Common.Line}" ) );
        }

        /// <summary>
        /// 获取CTE关键字
        /// </summary>
        protected virtual string GetCteKeyWord() {
            return "With";
        }

        /// <summary>
        /// 创建Sql语句 - 联合
        /// </summary>
        protected void CreateSqlByUnion( StringBuilder result ) {
            result.Append( "(" );
            AppendSelect( result );
            AppendFrom( result );
            AppendSql( result, JoinClause.ToSql() );
            AppendSql( result, WhereClause.ToSql() );
            AppendSql( result, GroupByClause.ToSql() );
            AppendSql( result, ")" );
            foreach( var operation in UnionItems ) {
                AppendSql( result, operation.Name );
                AppendSql( result, $"({operation.Builder.ToSql()}" );
                AppendSql( result, ")" );
            }
            AppendSql( result, OrderByClause.ToSql() );
            AppendLimit( result );
        }

        /// <summary>
        /// 创建Sql语句
        /// </summary>
        protected void CreateSqlByNoUnion( StringBuilder result ) {
            AppendSelect( result );
            AppendFrom( result );
            AppendSql( result, JoinClause.ToSql() );
            AppendSql( result, WhereClause.ToSql() );
            AppendSql( result, GroupByClause.ToSql() );
            AppendSql( result, OrderByClause.ToSql() );
            AppendLimit( result );
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        protected void AppendSql( StringBuilder result, string sql ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            result.AppendLine( $"{sql} " );
        }

        /// <summary>
        /// 添加Select子句
        /// </summary>
        protected virtual void AppendSelect( StringBuilder result ) {
            var sql = SelectClause.ToSql();
            if( string.IsNullOrWhiteSpace( sql ) )
                throw new InvalidOperationException( "必须设置Select子句" );
            AppendSql( result, sql );
        }

        /// <summary>
        /// 添加From子句
        /// </summary>
        protected virtual void AppendFrom( StringBuilder result ) {
            var sql = FromClause.ToSql();
            if( string.IsNullOrWhiteSpace( sql ) )
                throw new InvalidOperationException( "必须设置From子句" );
            AppendSql( result, sql );
        }

        /// <summary>
        /// 添加过滤器列表
        /// </summary>
        protected void AddFilters() {
            _isAddFilters = true;
            var context = new SqlContext( Dialect, AliasRegister, EntityMatedata, ParameterManager, this );
            SqlFilterCollection.Filters.ForEach(filter => {
                if (_excludedFilters.Count > 0 && _excludedFilters.Exists(x => x == filter.GetType()))
                    return;
                filter.Filter(context);
            });
        }

        /// <summary>
        /// 添加分页Sql
        /// </summary>
        private void AppendLimit( StringBuilder result ) {
            if( IsLimit )
                AppendSql( result, CreateLimitSql() );
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        protected abstract string CreateLimitSql();

        #endregion

        #region AddParam(添加参数)

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public ISqlBuilder AddParam( string name, object value ) {
            ParameterManager.Add( name, value );
            return this;
        }

        #endregion

        #region GetParams(获取参数)

        /// <summary>
        /// 获取参数
        /// </summary>
        public IReadOnlyDictionary<string, object> GetParams() {
            return ParameterManager.GetParams();
        }

        #endregion

        #region GetCondition(获取查询条件)

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return WhereClause.GetCondition();
        }

        #endregion

        #region Page(设置分页)

        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="count">跳过的行数</param>
        public ISqlBuilder Skip( int count ) {
            var param = GetOffsetParam();
            ParameterManager.Add( param, count );
            return this;
        }

        /// <summary>
        /// 获取跳过行数的参数名
        /// </summary>
        protected string GetOffsetParam() {
            if( string.IsNullOrWhiteSpace( OffsetParam ) == false )
                return OffsetParam;
            OffsetParam = ParameterManager.GenerateName();
            ParameterManager.Add( OffsetParam, 0 );
            return OffsetParam;
        }

        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="count">获取的行数</param>
        public ISqlBuilder Take( int count ) {
            var param = GetLimitParam();
            ParameterManager.Add( param, count );
            Pager.PageSize = count;
            return this;
        }

        /// <summary>
        /// 获取限制行数的参数名
        /// </summary>
        protected string GetLimitParam() {
            if( string.IsNullOrWhiteSpace( LimitParam ) == false )
                return LimitParam;
            LimitParam = ParameterManager.GenerateName();
            return LimitParam;
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="pager">分页参数</param>
        public ISqlBuilder Page( IPager pager ) {
            if( pager == null )
                return this;
            Pager = pager;
            Skip( pager.GetSkipCount() ).Take( pager.PageSize );
            return this;
        }

        #endregion

        #region IgnoreFilter(忽略过滤器)

        /// <summary>
        /// 忽略过滤器
        /// </summary>
        /// <typeparam name="TSqlFilter">Sql过滤器类型</typeparam>
        public virtual ISqlBuilder IgnoreFilter<TSqlFilter>() where TSqlFilter : ISqlFilter {
            if (_excludedFilters.Exists(x => x == typeof(TSqlFilter)))
                return this;
            _excludedFilters.Add(typeof(TSqlFilter));
            return this;
        }

        #endregion
    }
}
