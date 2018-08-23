using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Conditions;
using Util.Datas.Sql.Queries.Builders.Core;
using Util.Helpers;
using Util.Properties;

namespace Util.Datas.Sql.Queries.Builders.Clauses {
    /// <summary>
    /// Where子句
    /// </summary>
    public class WhereClause : IWhereClause {
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// 查询条件
        /// </summary>
        private ICondition _condition;
        /// <summary>
        /// 参数索引
        /// </summary>
        private int _paramIndex;
        /// <summary>
        /// 参数标识
        /// </summary>
        private readonly string _tag;

        /// <summary>
        /// 初始化From子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="parameterManager">参数管理器</param>
        /// <param name="tag">参数标识</param>
        public WhereClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, IParameterManager parameterManager, string tag = null ) {
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
            _parameterManager = parameterManager;
            _tag = tag;
            _paramIndex = 0;
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
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public void Where( string column, object value, Operator @operator = Operator.Equal ) {
            And( GetCondition( column, value, @operator ) );
        }

        /// <summary>
        /// 获取查询条件并添加参数
        /// </summary>
        private ICondition GetCondition( string column, object value, Operator @operator ) {
            if( string.IsNullOrWhiteSpace( column ) )
                throw new ArgumentNullException( nameof( column ) );
            column = GetColumn( column );
            var paramName = GetParamName( value, @operator );
            _parameterManager.Add( paramName, value, @operator );
            return SqlConditionFactory.Create( column, paramName, @operator );
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        private string GetParamName( object value, Operator @operator ) {
            var result = $"{_dialect.GetPrefix()}_p_{_tag}_{_paramIndex++}";
            if( value != null )
                return result;
            if( @operator == Operator.Equal || @operator == Operator.NotEqual )
                return null;
            return result;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        private string GetColumn( string column ) {
            return new SqlItem( column ).ToSql( _dialect );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public void Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            Where( GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) ), value, @operator );
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        private string GetColumn( string column, Type type ) {
            return new SqlItem( column, _register.GetAlias( type ) ).ToSql( _dialect );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        public void Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            if( expression == null )
                throw new ArgumentNullException( nameof( expression ) );
            ICondition result = null;
            var expressions = Lambda.GetGroupPredicates( expression );
            for( int i = 0; i < expressions.Count; i++ ) {
                if( i == 0 ) {
                    result = new AndCondition( result, GetCondition( expressions[i], typeof( TEntity ) ) );
                    continue;
                }
                result = new OrCondition( result, GetCondition( expressions[i], typeof( TEntity ) ) );
            }
            And( result );
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        private ICondition GetCondition( List<Expression> group, Type type ) {
            ICondition condition = null;
            group.ForEach( expression => {
                condition = new AndCondition( condition, GetCondition( expression, type ) );
            } );
            return condition;
        }

        /// <summary>
        /// 获取查询条件并添加参数
        /// </summary>
        private ICondition GetCondition( Expression expression, Type type ) {
            var column = GetColumn( _resolver.GetColumn( expression, type ), type );
            return GetCondition( column, Lambda.GetValue( expression ), Lambda.GetOperator( expression ).SafeValue() );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public void WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal ) {
            if( condition )
                Where( column, value, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public void WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            if( condition )
                Where( expression, value, @operator );
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public void WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            if( condition )
                Where( expression );
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
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendSql( string sql ) {
            And( new SqlCondition( sql ) );
        }

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNull( string column ) {
            Where( column, null );
        }

        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            Where( expression, null );
        }

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNotNull( string column ) {
            column = GetColumn( column );
            And( new IsNotNullCondition( column ) );
        }

        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
            IsNotNull( column );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsEmpty( string column ) {
            column = GetColumn( column );
            And( new OrCondition( new IsNullCondition( column ),new EqualCondition( column,"''" )  ) );
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
            IsEmpty( column );
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        public void IsNotEmpty( string column ) {
            column = GetColumn( column );
            And( new AndCondition( new IsNotNullCondition( column ), new NotEqualCondition( column, "''" ) ) );
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public void IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var column = GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
            IsNotEmpty( column );
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
