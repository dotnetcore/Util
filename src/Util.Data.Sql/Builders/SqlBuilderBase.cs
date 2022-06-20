using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Builders.Sets;
using Util.Helpers;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public abstract class SqlBuilderBase : ISqlBuilder, ISqlPartAccessor {

        #region 字段

        /// <summary>
        /// Sql方言
        /// </summary>
        private IDialect _dialect;
        /// <summary>
        /// 列缓存
        /// </summary>
        private IColumnCache _columnCache;
        /// <summary>
        /// 参数管理器
        /// </summary>
        private IParameterManager _parameterManager;
        /// <summary>
        /// Sql条件工厂
        /// </summary>
        private IConditionFactory _conditionFactory;
        /// <summary>
        /// 起始子句
        /// </summary>
        private IStartClause _startClause;
        /// <summary>
        /// Insert子句
        /// </summary>
        private IInsertClause _insertClause;
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
        /// 结束子句
        /// </summary>
        private IEndClause _endClause;
        /// <summary>
        /// Sql生成器集合
        /// </summary>
        private ISqlBuilderSet _sqlBuilderSet;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        protected SqlBuilderBase( IParameterManager parameterManager = null ) {
            _parameterManager = parameterManager;
        }

        #endregion

        #region 属性

        /// <summary>
        /// Sql方言
        /// </summary>
        public IDialect Dialect => _dialect ??= CreateDialect();
        /// <summary>
        /// 列缓存
        /// </summary>
        public IColumnCache ColumnCache => _columnCache ??= CreateColumnCache();
        /// <summary>
        /// 参数管理器
        /// </summary>
        public IParameterManager ParameterManager => _parameterManager ??= CreateParameterManager();
        /// <summary>
        /// Sql条件工厂
        /// </summary>
        public IConditionFactory ConditionFactory => _conditionFactory ??= CreateConditionFactory();
        /// <summary>
        /// 起始子句
        /// </summary>
        public IStartClause StartClause => _startClause ??= CreateStartClause();
        /// <summary>
        /// Select子句
        /// </summary>
        public ISelectClause SelectClause => _selectClause ??= CreateSelectClause();
        /// <summary>
        /// From子句
        /// </summary>
        public IFromClause FromClause => _fromClause ??= CreateFromClause();
        /// <summary>
        /// Join子句
        /// </summary>
        public IJoinClause JoinClause => _joinClause ??= CreateJoinClause();
        /// <summary>
        /// Where子句
        /// </summary>
        public IWhereClause WhereClause => _whereClause ??= CreatewWhereClause();
        /// <summary>
        /// GroupBy子句
        /// </summary>
        public IGroupByClause GroupByClause => _groupByClause ??= CreateGroupByClause();
        /// <summary>
        /// OrderBy子句
        /// </summary>
        public IOrderByClause OrderByClause => _orderByClause ??= CreateOrderByClause();
        /// <summary>
        /// Insert子句
        /// </summary>
        public IInsertClause InsertClause => _insertClause ??= CreateInsertClause();
        /// <summary>
        /// 结束子句
        /// </summary>
        public IEndClause EndClause => _endClause ??= CreateEndClause();
        /// <summary>
        /// Sql生成器集合
        /// </summary>
        public ISqlBuilderSet SqlBuilderSet => _sqlBuilderSet ??= CreateSqlBuilderSet();

        #endregion

        #region 工厂方法

        /// <summary>
        /// 创建Sql方言
        /// </summary>
        protected abstract IDialect CreateDialect();

        /// <summary>
        /// 创建列缓存
        /// </summary>
        protected abstract IColumnCache CreateColumnCache();

        /// <summary>
        /// 创建参数管理器
        /// </summary>
        protected virtual IParameterManager CreateParameterManager() {
            return new ParameterManager( Dialect );
        }

        /// <summary>
        /// 创建Sql条件工厂
        /// </summary>
        protected virtual IConditionFactory CreateConditionFactory() {
            return new SqlConditionFactory( ParameterManager );
        }

        /// <summary>
        /// 创建起始子句
        /// </summary>
        protected virtual IStartClause CreateStartClause() {
            return new StartClause( this );
        }

        /// <summary>
        /// 创建Insert子句
        /// </summary>
        protected virtual IInsertClause CreateInsertClause() {
            return new InsertClause( this );
        }

        /// <summary>
        /// 创建Select子句
        /// </summary>
        protected virtual ISelectClause CreateSelectClause() {
            return new SelectClause( this );
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        protected virtual IFromClause CreateFromClause() {
            return new FromClause( this );
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        protected virtual IJoinClause CreateJoinClause() {
            return new JoinClause( this );
        }

        /// <summary>
        /// 创建Where子句
        /// </summary>
        protected virtual IWhereClause CreatewWhereClause() {
            return new WhereClause( this );
        }

        /// <summary>
        /// 创建分组子句
        /// </summary>
        protected virtual IGroupByClause CreateGroupByClause() {
            return new GroupByClause( this );
        }

        /// <summary>
        /// 创建排序子句
        /// </summary>
        protected virtual IOrderByClause CreateOrderByClause() {
            return new OrderByClause( this );
        }

        /// <summary>
        /// 创建结束子句
        /// </summary>
        protected virtual IEndClause CreateEndClause() {
            return new EndClause( this );
        }

        /// <summary>
        /// 创建Sql生成器集合
        /// </summary>
        protected virtual ISqlBuilderSet CreateSqlBuilderSet() {
            return new SqlBuilderSet( this );
        }

        #endregion

        #region Clone(复制Sql生成器)

        /// <inheritdoc />
        public abstract ISqlBuilder Clone();

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        /// <param name="source">源Sql生成器</param>
        protected void Clone( SqlBuilderBase source ) {
            _dialect = source._dialect;
            _columnCache = source._columnCache;
            _parameterManager = source._parameterManager?.Clone();
            _startClause = source._startClause?.Clone( this );
            _insertClause = source._insertClause?.Clone( this );
            _selectClause = source._selectClause?.Clone( this );
            _fromClause = source._fromClause?.Clone( this );
            _joinClause = source._joinClause?.Clone( this );
            _whereClause = source._whereClause?.Clone( this );
            _groupByClause = source._groupByClause?.Clone( this );
            _orderByClause = source._orderByClause?.Clone( this );
            _endClause = source._endClause?.Clone( this );
            _sqlBuilderSet = source._sqlBuilderSet?.Clone( this );
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        public ISqlBuilder Clear() {
            _parameterManager?.Clear();
            _startClause?.Clear();
            _insertClause?.Clear();
            _selectClause?.Clear();
            _fromClause?.Clear();
            _joinClause?.Clear();
            _whereClause?.Clear();
            _groupByClause?.Clear();
            _orderByClause?.Clear();
            _endClause?.Clear();
            _sqlBuilderSet?.Clear();
            return this;
        }

        #endregion

        #region New(创建Sql生成器)

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public abstract ISqlBuilder New();

        #endregion

        #region GetSql(获取Sql语句)

        /// <summary>
        /// 生成Sql语句
        /// </summary>
        public virtual string GetSql() {
            return SqlBuilderSet.ToResult();
        }

        #endregion

        #region AppendTo(添加到字符串生成器)

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            AppendSql( builder, _startClause );
            AppendSql( builder, _insertClause );
            AppendSql( builder, _selectClause );
            AppendSql( builder, _fromClause );
            AppendSql( builder, _joinClause );
            AppendSql( builder, _whereClause );
            AppendSql( builder, _groupByClause );
            AppendSql( builder, _orderByClause );
            AppendSql( builder, _endClause );
            builder.RemoveEnd( $" {Common.Line}" );
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        protected void AppendSql( StringBuilder builder, ISqlClause content ) {
            if ( content == null )
                return;
            if( content.Validate() == false )
                return;
            content.AppendTo( builder );
            builder.AppendLine( " " );
        }

        #endregion
    }
}
