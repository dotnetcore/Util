using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Sql.Builders.Internal;
using Util.Helpers;
using Util.Properties;

namespace Util.Datas.Sql.Builders.Clauses {
    /// <summary>
    /// Where子句
    /// </summary>
    public class WhereClause : IWhereClause {
        /// <summary>
        /// Sql生成器
        /// </summary>
        protected readonly ISqlBuilder Builder;
        /// <summary>
        /// 辅助操作
        /// </summary>
        private readonly Helper _helper;
        /// <summary>
        /// 谓词表达式解析器
        /// </summary>
        private readonly PredicateExpressionResolver _expressionResolver;
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 查询条件
        /// </summary>
        private ICondition _condition;

        /// <summary>
        /// 初始化Where子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="parameterManager">参数管理器</param>
        /// <param name="condition">查询条件</param>
        public WhereClause( ISqlBuilder builder, IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, IParameterManager parameterManager, ICondition condition = null ) {
            Builder = builder;
            _dialect = dialect;
            _resolver = resolver;
            _condition = condition;
            _helper = new Helper( dialect, resolver, register, parameterManager );
            _expressionResolver = new PredicateExpressionResolver( dialect, resolver, register, parameterManager );
        }

        /// <summary>
        /// 复制Where子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="parameterManager">参数管理器</param>
        public virtual IWhereClause Clone( ISqlBuilder builder, IEntityAliasRegister register, IParameterManager parameterManager ) {
            return new WhereClause( builder, _dialect, _resolver, register, parameterManager, new SqlCondition( _condition?.GetCondition() ) );
        }

        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public void And( ICondition condition ) {
            _condition = new AndCondition( _condition, condition );
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public void Or( ICondition condition ) {
            _condition = new OrCondition( _condition, condition );
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件</param>
        public void Or<TEntity>( params Expression<Func<TEntity, bool>>[] conditions ) {
            if( conditions == null )
                return;
            foreach( var condition in conditions ) {
                if( condition == null )
                    continue;
                var predicate = _expressionResolver.Resolve( condition );
                if( predicate == null )
                    continue;
                Or( predicate );
            }
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件,如果表达式中的值为空，则忽略该查询条件</param>
        public void OrIfNotEmpty<TEntity>( params Expression<Func<TEntity, bool>>[] conditions ) {
            if( conditions == null )
                return;
            foreach( var condition in conditions ) {
                if( condition == null )
                    continue;
                if( Lambda.GetConditionCount( condition ) > 1 )
                    throw new InvalidOperationException( string.Format( LibraryResource.OnlyOnePredicate, condition ) );
                if( string.IsNullOrWhiteSpace( Lambda.GetValue( condition ).SafeString() ) )
                    continue;
                var predicate = _expressionResolver.Resolve( condition );
                if( predicate == null )
                    continue;
                Or( predicate );
            }
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public void Where( ICondition condition ) {
            And( condition );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public void Where( string column, object value, Operator @operator = Operator.Equal ) {
            And( _helper.CreateCondition( column, value, @operator ) );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public void Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            Where( _helper.GetColumn( expression ), value, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        public void Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            if( expression == null )
                throw new ArgumentNullException( nameof( expression ) );
            var condition = _expressionResolver.Resolve( expression );
            And( condition );
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="builder">子查询Sql生成器</param>
        /// <param name="operator">运算符</param>
        public void Where( string column, ISqlBuilder builder, Operator @operator = Operator.Equal ) {
            if( builder == null )
                return;
            column = _helper.GetColumn( column );
            var sql = $"({builder.ToSql()})";
            And( SqlConditionFactory.Create( column, sql, @operator ) );
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">子查询Sql生成器</param>
        /// <param name="operator">运算符</param>
        public void Where<TEntity>( Expression<Func<TEntity, object>> expression, ISqlBuilder builder, Operator @operator = Operator.Equal ) where TEntity : class {
            Where( _helper.GetColumn( expression ), builder, @operator );
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        /// <param name="operator">运算符</param>
        public void Where( string column, Action<ISqlBuilder> action, Operator @operator = Operator.Equal ) {
            if( action == null )
                return;
            var builder = Builder.New();
            action( builder );
            Where( column, builder, @operator );
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        /// <param name="operator">运算符</param>
        public void Where<TEntity>( Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action, Operator @operator = Operator.Equal ) where TEntity : class {
            Where( _helper.GetColumn( expression ), action, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public void WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal ) {
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return;
            Where( column, value, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public void WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            if( expression == null )
                throw new ArgumentNullException( nameof( expression ) );
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return;
            Where( expression, value, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        public void WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            if( expression == null )
                throw new ArgumentNullException( nameof( expression ) );
            if( Lambda.GetConditionCount( expression ) > 1 )
                throw new InvalidOperationException( string.Format( LibraryResource.OnlyOnePredicate, expression ) );
            if( string.IsNullOrWhiteSpace( Lambda.GetValue( expression ).SafeString() ) )
                return;
            Where( expression );
        }

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNull( string column ) {
            And( _helper.CreateCondition( column, null, Operator.Equal ) );
        }

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            IsNull( _helper.GetColumn( expression ) );
        }

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNotNull( string column ) {
            column = _helper.GetColumn( column );
            And( new IsNotNullCondition( column ) );
        }

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = _helper.GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
            IsNotNull( column );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsEmpty( string column ) {
            column = _helper.GetColumn( column );
            And( new OrCondition( new IsNullCondition( column ), new EqualCondition( column, "''" ) ) );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = _helper.GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
            IsEmpty( column );
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNotEmpty( string column ) {
            column = _helper.GetColumn( column );
            And( new AndCondition( new IsNotNullCondition( column ), new NotEqualCondition( column, "''" ) ) );
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = _helper.GetColumn( expression );
            IsNotEmpty( column );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public void In( string column, IEnumerable<object> values ) {
            Where( column, values, Operator.In );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public void In<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            Where( expression, values, Operator.In );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="builder">Sql生成器</param>
        public void In( string column, ISqlBuilder builder ) {
            AppendSqlBuilder( "In", column, builder );
        }

        /// <summary>
        /// 添加子查询
        /// </summary>
        private void AppendSqlBuilder( string operation, string column, ISqlBuilder builder ) {
            if( string.IsNullOrWhiteSpace( column ) )
                return;
            if( builder == null )
                return;
            var result = $"{_helper.GetColumn( column )} {operation} ({builder.ToSql()})";
            AppendSql( result );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">Sql生成器</param>
        public void In<TEntity>( Expression<Func<TEntity, object>> expression, ISqlBuilder builder ) {
            In( _helper.GetColumn(expression), builder );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        public void In( string column, Action<ISqlBuilder> action ) {
            if( action == null )
                return;
            var builder = Builder.New();
            action( builder );
            In( column, builder );
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        public void In<TEntity>( Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action ) {
            In( _helper.GetColumn( expression ), action );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public void NotIn( string column, IEnumerable<object> values ) {
            Where( column, values, Operator.NotIn );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public void NotIn<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            Where( expression, values, Operator.NotIn );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="builder">Sql生成器</param>
        public void NotIn( string column, ISqlBuilder builder ) {
            AppendSqlBuilder( "Not In", column, builder );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">Sql生成器</param>
        public void NotIn<TEntity>( Expression<Func<TEntity, object>> expression, ISqlBuilder builder ) {
            NotIn( _helper.GetColumn( expression ), builder );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        public void NotIn( string column, Action<ISqlBuilder> action ) {
            if( action == null )
                return;
            var builder = Builder.New();
            action( builder );
            NotIn( column, builder );
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        public void NotIn<TEntity>( Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action ) {
            NotIn( _helper.GetColumn( expression ), action );
        }

        /// <summary>
        /// 设置Exists条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        public void Exists( ISqlBuilder builder ) {
            if( builder == null )
                return;
            var result = $"Exists ({builder.ToSql()})";
            AppendSql( result );
        }

        /// <summary>
        /// 设置Exists条件
        /// </summary>
        /// <param name="action">子查询操作</param>
        public void Exists( Action<ISqlBuilder> action ) {
            if( action == null )
                return;
            var builder = Builder.New();
            action( builder );
            Exists( builder );
        }

        /// <summary>
        /// 设置Not Exists条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        public void NotExists( ISqlBuilder builder ) {
            if( builder == null )
                return;
            var result = $"Not Exists ({builder.ToSql()})";
            AppendSql( result );
        }

        /// <summary>
        /// 设置Not Exists条件
        /// </summary>
        /// <param name="action">子查询操作</param>
        public void NotExists( Action<ISqlBuilder> action ) {
            if( action == null )
                return;
            var builder = Builder.New();
            action( builder );
            NotExists( builder );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between<TEntity>( Expression<Func<TEntity, object>> expression, int? min, int? max, Boundary boundary ) where TEntity : class {
            var column = _helper.GetColumn( expression );
            Between( column, min, max, boundary );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between<TEntity>( Expression<Func<TEntity, object>> expression, double? min, double? max, Boundary boundary ) where TEntity : class {
            var column = _helper.GetColumn( expression );
            Between( column, min, max, boundary );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between<TEntity>( Expression<Func<TEntity, object>> expression, decimal? min, decimal? max, Boundary boundary ) where TEntity : class {
            var column = _helper.GetColumn( expression );
            Between( column, min, max, boundary );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public void Between<TEntity>( Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max, bool includeTime, Boundary? boundary ) where TEntity : class {
            var column = _helper.GetColumn( expression );
            Between( column, min, max, includeTime, boundary );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between( string column, int? min, int? max, Boundary boundary ) {
            if( min > max ) {
                Where( _helper.Between( column, max, min, boundary ) );
                return;
            }
            Where( _helper.Between( column, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between( string column, double? min, double? max, Boundary boundary ) {
            if( min > max ) {
                Where( _helper.Between( column, max, min, boundary ) );
                return;
            }
            Where( _helper.Between( column, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public void Between( string column, decimal? min, decimal? max, Boundary boundary ) {
            if( min > max ) {
                Where( _helper.Between( column, max, min, boundary ) );
                return;
            }
            Where( _helper.Between( column, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public void Between( string column, DateTime? min, DateTime? max, bool includeTime, Boundary? boundary ) {
            Where( _helper.Between( column, GetMin( min, max, includeTime ), GetMax( min, max, includeTime ), GetBoundary( boundary, includeTime ) ) );
        }

        /// <summary>
        /// 获取最小日期
        /// </summary>
        private DateTime? GetMin( DateTime? min, DateTime? max, bool includeTime ) {
            if( min == null )
                return null;
            DateTime? result = min;
            if( min > max )
                result = max;
            if( includeTime )
                return result;
            return result.SafeValue().Date;
        }

        /// <summary>
        /// 获取最大日期
        /// </summary>
        private DateTime? GetMax( DateTime? min, DateTime? max, bool includeTime ) {
            if( max == null )
                return null;
            DateTime? result = max;
            if( min > max )
                result = min;
            if( includeTime )
                return result;
            return result.SafeValue().Date.AddDays( 1 );
        }

        /// <summary>
        /// 获取日期范围查询条件边界
        /// </summary>
        private Boundary GetBoundary( Boundary? boundary, bool includeTime ) {
            if( boundary != null )
                return boundary.SafeValue();
            if( includeTime )
                return Boundary.Both;
            return Boundary.Left;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendSql( string sql ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            sql = Helper.ResolveSql( sql, _dialect );
            And( new SqlCondition( sql ) );
        }

        /// <summary>
        /// 输出Sql
        /// </summary>
        public string ToSql() {
            var condition = GetCondition();
            if( string.IsNullOrWhiteSpace( condition ) )
                return null;
            return $"Where {condition}";
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return _condition?.GetCondition();
        }
    }
}
