using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Util.Datas.Matedatas;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Clauses;
using Util.Datas.Sql.Queries.Builders.Filters;
using Util.Domains.Repositories;
using Util.Helpers;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public abstract class SqlBuilderBase : ISqlBuilder {

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

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="parameterManager">参数管理器</param>
        protected SqlBuilderBase( IEntityMatedata matedata = null, IParameterManager parameterManager = null ) {
            EntityMatedata = matedata;
            _parameterManager = parameterManager;
            EntityResolver = new EntityResolver( matedata );
            AliasRegister = new EntityAliasRegister();
            Pager = new Pager();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 实体元数据解析器
        /// </summary>
        protected IEntityMatedata EntityMatedata { get; private set; }
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
        protected ISelectClause SelectClause => _selectClause ?? ( _selectClause = CreateSelectClause() );
        /// <summary>
        /// From子句
        /// </summary>
        protected IFromClause FromClause => _fromClause ?? ( _fromClause = CreateFromClause() );
        /// <summary>
        /// Join子句
        /// </summary>
        protected IJoinClause JoinClause => _joinClause ?? ( _joinClause = CreateJoinClause() );
        /// <summary>
        /// Where子句
        /// </summary>
        protected IWhereClause WhereClause => _whereClause ?? ( _whereClause = CreatewWhereClause() );
        /// <summary>
        /// GroupBy子句
        /// </summary>
        protected IGroupByClause GroupByClause => _groupByClause ?? ( _groupByClause = CreateGroupByClause() );
        /// <summary>
        /// OrderBy子句
        /// </summary>
        protected IOrderByClause OrderByClause => _orderByClause ?? ( _orderByClause = CreateOrderByClause() );
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
        /// 分页
        /// </summary>
        public IPager Pager { get; private set; }
        /// <summary>
        /// 是否分组
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
            return new FromClause( this, Dialect, EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        protected virtual IJoinClause CreateJoinClause() {
            return new JoinClause( this, Dialect, EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建Where子句
        /// </summary>
        protected virtual IWhereClause CreatewWhereClause() {
            return new WhereClause( Dialect, EntityResolver, AliasRegister, ParameterManager );
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
            _fromClause = sqlBuilder._fromClause?.Clone( AliasRegister );
            _joinClause = sqlBuilder._joinClause?.Clone( this, AliasRegister );
            _whereClause = sqlBuilder._whereClause?.Clone( AliasRegister, _parameterManager );
            _groupByClause = sqlBuilder._groupByClause?.Clone( AliasRegister );
            _orderByClause = sqlBuilder._orderByClause?.Clone( AliasRegister );
            Pager = sqlBuilder.Pager;
            OffsetParam = sqlBuilder.OffsetParam;
            LimitParam = sqlBuilder.LimitParam;
        }

        #endregion

        #region Clear(清空)

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            AliasRegister = new EntityAliasRegister();
            ClearSelect();
            ClearFrom();
            ClearJoin();
            ClearWhere();
            ClearGroupBy();
            ClearOrderBy();
            ClearSqlParams();
            ClearPageParams();
        }

        /// <summary>
        /// 清空Select子句
        /// </summary>
        public void ClearSelect() {
            _selectClause = CreateSelectClause();
        }

        /// <summary>
        /// 清空From子句
        /// </summary>
        public void ClearFrom() {
            _fromClause = CreateFromClause();
        }

        /// <summary>
        /// 清空Join子句
        /// </summary>
        public void ClearJoin() {
            _joinClause = CreateJoinClause();
        }

        /// <summary>
        /// 清空Where子句
        /// </summary>
        public void ClearWhere() {
            _isAddFilters = false;
            _whereClause = CreatewWhereClause();
        }

        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        public void ClearGroupBy() {
            _groupByClause = CreateGroupByClause();
        }

        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        public void ClearOrderBy() {
            _orderByClause = CreateOrderByClause();
        }

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        public void ClearSqlParams() {
            _parameterManager.Clear();
        }

        /// <summary>
        /// 清空分页参数
        /// </summary>
        public void ClearPageParams() {
            Pager = null;
            OffsetParam = null;
            LimitParam = null;
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
            AppendSelect( result );
            AppendFrom( result );
            AppendSql( result, GetJoin() );
            AppendSql( result, GetWhere() );
            AppendSql( result, GetGroupBy() );
            AppendSql( result, GetOrderBy() );
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
            var sql = GetSelect();
            if( string.IsNullOrWhiteSpace( sql ) )
                throw new InvalidOperationException( "必须设置Select子句" );
            AppendSql( result, sql );
        }

        /// <summary>
        /// 添加From子句
        /// </summary>
        protected virtual void AppendFrom( StringBuilder result ) {
            var sql = GetFrom();
            if( string.IsNullOrWhiteSpace( sql ) )
                throw new InvalidOperationException( "必须设置From子句" );
            AppendSql( result, sql );
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
        public void AddParam( string name, object value ) {
            ParameterManager.Add( name, value );
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

        #region Select(设置列名)

        /// <summary>
        /// 获取Select语句
        /// </summary>
        public virtual string GetSelect() {
            return SelectClause.ToSql();
        }

        /// <summary>
        /// 过滤重复记录
        /// </summary>
        public virtual ISqlBuilder Distinct() {
            SelectClause.Distinct();
            return this;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Count( string columnAlias = null ) {
            SelectClause.Count( columnAlias );
            return this;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Count( string column, string columnAlias ) {
            SelectClause.Count( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Count<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            SelectClause.Count( expression, columnAlias );
            return this;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Sum( string column, string columnAlias = null ) {
            SelectClause.Sum( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Sum<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            SelectClause.Sum( expression, columnAlias );
            return this;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Avg( string column, string columnAlias = null ) {
            SelectClause.Avg( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Avg<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            SelectClause.Avg( expression, columnAlias );
            return this;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Max( string column, string columnAlias = null ) {
            SelectClause.Max( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Max<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            SelectClause.Max( expression, columnAlias );
            return this;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Min( string column, string columnAlias = null ) {
            SelectClause.Min( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Min<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            SelectClause.Min( expression, columnAlias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        public virtual ISqlBuilder Select( string columns, string tableAlias = null ) {
            SelectClause.Select( columns, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public virtual ISqlBuilder Select<TEntity>( Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class {
            SelectClause.Select( columns, propertyAsAlias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class {
            SelectClause.Select( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendSelect( string sql ) {
            SelectClause.AppendSql( sql );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder AppendSelect( ISqlBuilder builder, string columnAlias ) {
            SelectClause.AppendSql( builder, columnAlias );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        public virtual ISqlBuilder AppendSelect( Action<ISqlBuilder> action, string columnAlias ) {
            SelectClause.AppendSql( action, columnAlias );
            return this;
        }

        #endregion

        #region From(设置表名)

        /// <summary>
        /// 获取From语句
        /// </summary>
        public virtual string GetFrom() {
            return FromClause.ToSql();
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public virtual ISqlBuilder From( string table, string alias = null ) {
            FromClause.From( table, alias );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public virtual ISqlBuilder From<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            FromClause.From<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendFrom( string sql ) {
            FromClause.AppendSql( sql );
            return this;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendFrom( ISqlBuilder builder, string alias ) {
            FromClause.AppendSql( builder, alias );
            return this;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendFrom( Action<ISqlBuilder> action, string alias ) {
            FromClause.AppendSql( action, alias );
            return this;
        }

        #endregion

        #region Join(设置连接)

        /// <summary>
        /// 获取Join语句
        /// </summary>
        public virtual string GetJoin() {
            return JoinClause.ToSql();
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public virtual ISqlBuilder Join( string table, string alias = null ) {
            JoinClause.Join( table, alias );
            return this;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public virtual ISqlBuilder Join<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            JoinClause.Join<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendJoin( string sql ) {
            JoinClause.AppendJoin( sql );
            return this;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendJoin( ISqlBuilder builder, string alias ) {
            JoinClause.AppendJoin( builder, alias );
            return this;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendJoin( Action<ISqlBuilder> action, string alias ) {
            JoinClause.AppendJoin( action, alias );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public virtual ISqlBuilder LeftJoin( string table, string alias = null ) {
            JoinClause.LeftJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public virtual ISqlBuilder LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            JoinClause.LeftJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendLeftJoin( string sql ) {
            JoinClause.AppendLeftJoin( sql );
            return this;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendLeftJoin( ISqlBuilder builder, string alias ) {
            JoinClause.AppendLeftJoin( builder, alias );
            return this;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendLeftJoin( Action<ISqlBuilder> action, string alias ) {
            JoinClause.AppendLeftJoin( action, alias );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public virtual ISqlBuilder RightJoin( string table, string alias = null ) {
            JoinClause.RightJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public virtual ISqlBuilder RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            JoinClause.RightJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendRightJoin( string sql ) {
            JoinClause.AppendRightJoin( sql );
            return this;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public virtual ISqlBuilder AppendRightJoin( ISqlBuilder builder, string alias ) {
            JoinClause.AppendRightJoin( builder, alias );
            return this;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public ISqlBuilder AppendRightJoin( Action<ISqlBuilder> action, string alias ) {
            JoinClause.AppendRightJoin( action, alias );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public virtual ISqlBuilder On( string left, string right, Operator @operator = Operator.Equal ) {
            JoinClause.On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public virtual ISqlBuilder On<TLeft, TRight>( Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal )
            where TLeft : class where TRight : class {
            JoinClause.On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式</param>
        public virtual ISqlBuilder On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            JoinClause.On( expression );
            return this;
        }

        #endregion

        #region Where(设置查询条件)

        /// <summary>
        /// 获取Where语句
        /// </summary>
        public virtual string GetWhere() {
            if( _isAddFilters == false )
                AddFilters();
            return WhereClause.ToSql();
        }

        /// <summary>
        /// 添加过滤器列表
        /// </summary>
        private void AddFilters() {
            _isAddFilters = true;
            var context = new SqlQueryContext( AliasRegister, WhereClause, EntityMatedata );
            SqlFilterCollection.Filters.ForEach( filter => filter.Filter( context ) );
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return WhereClause.GetCondition();
        }

        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlBuilder And( ICondition condition ) {
            WhereClause.And( condition );
            return this;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlBuilder Or( ICondition condition ) {
            WhereClause.Or( condition );
            return this;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件</param>
        public ISqlBuilder Or<TEntity>( params Expression<Func<TEntity, bool>>[] conditions ) {
            WhereClause.Or( conditions );
            return this;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件,如果表达式中的值为空，则忽略该查询条件</param>
        public ISqlBuilder OrIfNotEmpty<TEntity>( params Expression<Func<TEntity, bool>>[] conditions ) {
            WhereClause.OrIfNotEmpty( conditions );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlBuilder Where( ICondition condition ) {
            WhereClause.Where( condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder Where( string column, object value, Operator @operator = Operator.Equal ) {
            WhereClause.Where( column, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            WhereClause.Where( expression, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        public ISqlBuilder Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            WhereClause.Where( expression );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal ) {
            WhereClause.WhereIf( column, value, condition, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            WhereClause.WhereIf( expression, value, condition, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public ISqlBuilder WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            WhereClause.WhereIf( expression, condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal ) {
            WhereClause.WhereIfNotEmpty( column, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public ISqlBuilder WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            WhereClause.WhereIfNotEmpty( expression, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        public ISqlBuilder WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            WhereClause.WhereIfNotEmpty( expression );
            return this;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Equal( string column, object value ) {
            return Where( column, value );
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Equal<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value );
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder NotEqual( string column, object value ) {
            return Where( column, value, Operator.NotEqual );
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder NotEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.NotEqual );
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Greater( string column, object value ) {
            return Where( column, value, Operator.Greater );
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Greater<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.Greater );
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Less( string column, object value ) {
            return Where( column, value, Operator.Less );
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Less<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.Less );
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder GreaterEqual( string column, object value ) {
            return Where( column, value, Operator.GreaterEqual );
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder GreaterEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.GreaterEqual );
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder LessEqual( string column, object value ) {
            return Where( column, value, Operator.LessEqual );
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder LessEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.LessEqual );
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Contains( string column, object value ) {
            return Where( column, value, Operator.Contains );
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Contains<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.Contains );
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Starts( string column, object value ) {
            return Where( column, value, Operator.Starts );
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Starts<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.Starts );
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlBuilder Ends( string column, object value ) {
            return Where( column, value, Operator.Ends );
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlBuilder Ends<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            return Where( expression, value, Operator.Ends );
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlBuilder IsNull( string column ) {
            WhereClause.IsNull( column );
            return this;
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlBuilder IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            WhereClause.IsNull( expression );
            return this;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlBuilder IsNotNull( string column ) {
            WhereClause.IsNotNull( column );
            return this;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlBuilder IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            WhereClause.IsNotNull( expression );
            return this;
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlBuilder IsEmpty( string column ) {
            WhereClause.IsEmpty( column );
            return this;
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlBuilder IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            WhereClause.IsEmpty( expression );
            return this;
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlBuilder IsNotEmpty( string column ) {
            WhereClause.IsNotEmpty( column );
            return this;
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlBuilder IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            WhereClause.IsNotEmpty( expression );
            return this;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public ISqlBuilder In( string column, IEnumerable<object> values ) {
            WhereClause.In( column, values );
            return this;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public ISqlBuilder In<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            WhereClause.In( expression, values );
            return this;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public ISqlBuilder NotIn( string column, IEnumerable<object> values ) {
            WhereClause.NotIn( column, values );
            return this;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public ISqlBuilder NotIn<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            WhereClause.NotIn( expression, values );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            WhereClause.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, double? min, double? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            WhereClause.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            WhereClause.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where TEntity : class {
            WhereClause.Between( expression, min, max, includeTime, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between( string column, int? min, int? max, Boundary boundary = Boundary.Both ) {
            WhereClause.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between( string column, double? min, double? max, Boundary boundary = Boundary.Both ) {
            WhereClause.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between( string column, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) {
            WhereClause.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public ISqlBuilder Between( string column, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) {
            WhereClause.Between( column, min, max, includeTime, boundary );
            return this;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlBuilder AppendWhere( string sql ) {
            WhereClause.AppendSql( sql );
            return this;
        }

        #endregion

        #region GroupBy(分组)

        /// <summary>
        /// 获取分组语句
        /// </summary>
        public virtual string GetGroupBy() {
            return GroupByClause.ToSql();
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="columns">分组字段</param>
        /// <param name="having">分组条件</param>
        public ISqlBuilder GroupBy( string columns, string having = null ) {
            GroupByClause.GroupBy( columns, having );
            return this;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        public ISqlBuilder GroupBy<TEntity>( params Expression<Func<TEntity, object>>[] columns ) {
            GroupByClause.GroupBy( columns );
            return this;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段</param>
        /// <param name="having">分组条件</param>
        public ISqlBuilder GroupBy<TEntity>( Expression<Func<TEntity, object>> column, string having = null ) {
            GroupByClause.GroupBy( column, having );
            return this;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlBuilder AppendGroupBy( string sql ) {
            GroupByClause.AppendSql( sql );
            return this;
        }

        #endregion

        #region OrderBy(设置排序)

        /// <summary>
        /// 获取排序语句
        /// </summary>
        public virtual string GetOrderBy() {
            return OrderByClause.ToSql();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表</param>
        /// <param name="tableAlias">表别名</param>
        public virtual ISqlBuilder OrderBy( string order, string tableAlias = null ) {
            OrderByClause.OrderBy( order, tableAlias );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列</param>
        /// <param name="desc">是否倒排</param>
        public virtual ISqlBuilder OrderBy<TEntity>( Expression<Func<TEntity, object>> column, bool desc = false ) {
            OrderByClause.OrderBy( column, desc );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public virtual ISqlBuilder AppendOrderBy( string sql ) {
            OrderByClause.AppendSql( sql );
            return this;
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
            if ( pager == null )
                return this;
            Pager = pager;
            Skip( pager.GetSkipCount() ).Take( pager.PageSize );
            return this;
        }

        #endregion
    }
}
