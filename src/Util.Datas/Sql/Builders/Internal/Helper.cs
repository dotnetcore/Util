using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Sql.Builders.Core;
using Util.Helpers;

namespace Util.Datas.Sql.Builders.Internal {
    /// <summary>
    /// Sql生成器辅助操作
    /// </summary>
    public class Helper {
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体别名注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;

        /// <summary>
        /// 初始化Sql生成器辅助操作
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="parameterManager">参数管理器</param>
        public Helper( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, IParameterManager parameterManager ) {
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
            _parameterManager = parameterManager;
        }

        /// <summary>
        /// 获取处理后的列名
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="type">实体类型</param>
        public string GetColumn( Expression expression, Type type ) {
            if ( expression == null )
                return null;
            return GetColumn( _resolver.GetColumn( expression, type ), type );
        }

        /// <summary>
        /// 获取处理后的列名
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public string GetColumn<TEntity>( Expression<Func<TEntity, object>> expression ) {
            if ( expression == null )
                return null;
            return GetColumn( _resolver.GetColumn( expression ), typeof( TEntity ) );
        }

        /// <summary>
        /// 获取处理后的列名
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="type">实体类型</param>
        public string GetColumn( string column, Type type ) {
            if ( string.IsNullOrWhiteSpace( column ) )
                return column;
            return new SqlItem( column, _register.GetAlias( type ) ).ToSql( _dialect );
        }

        /// <summary>
        /// 获取处理后的列名
        /// </summary>
        /// <param name="column">列名</param>
        public string GetColumn( string column ) {
            if( string.IsNullOrWhiteSpace( column ) )
                return column;
            return new SqlItem( column ).ToSql( _dialect );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns>表达式</returns>
        public object GetValue( Expression expression ) {
            if ( expression == null )
                return null;
            var result = Lambda.GetValue( expression );
            if ( result == null )
                return null;
            var type = result.GetType();
            if( type.IsEnum )
                return Util.Helpers.Enum.GetValue( type, result );
            return result;
        }

        /// <summary>
        /// 创建查询条件并添加参数
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="type">实体类型</param>
        public ICondition CreateCondition( Expression expression, Type type ) {
            return CreateCondition( GetColumn( expression, type ), GetValue( expression ), Lambda.GetOperator( expression ).SafeValue() );
        }

        /// <summary>
        /// 创建查询条件并添加参数
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public ICondition CreateCondition( string column, object value, Operator @operator ) {
            if( string.IsNullOrWhiteSpace( column ) )
                throw new ArgumentNullException( nameof( column ) );
            if ( _parameterManager == null )
                return null;
            column = GetColumn( column );
            if( IsInCondition( @operator, value ) )
                return CreateInCondition( column, value as IEnumerable );
            if( IsNotInCondition( @operator, value ) )
                return CreateInCondition( column, value as IEnumerable, true );
            var paramName = GenerateParamName( value, @operator );
            _parameterManager.Add( paramName, value, @operator );
            return SqlConditionFactory.Create( column, paramName, @operator );
        }

        /// <summary>
        /// 是否In条件
        /// </summary>
        private bool IsInCondition( Operator @operator, object value ) {
            if( @operator == Operator.In )
                return true;
            if( @operator == Operator.Contains && value != null && Reflection.IsCollection( value.GetType() ) )
                return true;
            return false;
        }

        /// <summary>
        /// 是否Not In条件
        /// </summary>
        private bool IsNotInCondition( Operator @operator, object value ) {
            if( @operator == Operator.NotIn )
                return true;
            return false;
        }

        /// <summary>
        /// 创建In条件
        /// </summary>
        private ICondition CreateInCondition( string column, IEnumerable values, bool notIn = false ) {
            if( values == null )
                return NullCondition.Instance;
            var paramNames = new List<string>();
            foreach( var value in values ) {
                var name = _parameterManager.GenerateName();
                paramNames.Add( name );
                _parameterManager.Add( name, value );
            }
            if( notIn )
                return new NotInCondition( column, paramNames );
            return new InCondition( column, paramNames );
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public string GenerateParamName( object value, Operator @operator ) {
            if ( _parameterManager == null )
                return string.Empty;
            var result = _parameterManager.GenerateName();
            if( value != null )
                return result;
            if( @operator == Operator.Equal || @operator == Operator.NotEqual )
                return null;
            return result;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ICondition Between( string column, object min, object max, Boundary boundary ) {
            column = GetColumn( column );
            string minParamName = null;
            string maxParamName = null;
            if( string.IsNullOrWhiteSpace( min.SafeString() ) == false ) {
                minParamName = _parameterManager.GenerateName();
                _parameterManager.Add( minParamName, min );
            }
            if( string.IsNullOrWhiteSpace( max.SafeString() ) == false ) {
                maxParamName = _parameterManager.GenerateName();
                _parameterManager.Add( maxParamName, max );
            }
            return new SegmentCondition( column, minParamName, maxParamName, boundary );
        }

        /// <summary>
        /// 解析Sql
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="dialect">Sql方言</param>
        public static string ResolveSql( string sql, IDialect dialect ) {
            return sql?.Replace( "[",dialect.OpeningIdentifier ).Replace( "]", dialect.ClosingIdentifier );
        }
    }
}
