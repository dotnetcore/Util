using System;
using System.Linq.Expressions;
using Util.Data;
using Util.Helpers;

namespace Util.Expressions {
    /// <summary>
    /// 谓词表达式生成器
    /// </summary>
    public class PredicateExpressionBuilder<TEntity> {
        /// <summary>
        /// 参数
        /// </summary>
        private readonly ParameterExpression _parameter;
        /// <summary>
        /// 结果表达式
        /// </summary>
        private Expression _result;

        /// <summary>
        /// 初始化谓词表达式生成器
        /// </summary>
        public PredicateExpressionBuilder() {
            _parameter = Lambda.CreateParameter<TEntity>();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        public ParameterExpression GetParameter() {
            return _parameter;
        }

        /// <summary>
        /// 添加表达式
        /// </summary>
        /// <param name="property">属性表达式</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        public void Append<TProperty>( Expression<Func<TEntity, TProperty>> property, Operator @operator, object value ) {
            _result = _result.And( _parameter.Property( Lambda.GetMember( property ) ).Operation( @operator, value ) );
        }

        /// <summary>
        /// 添加表达式
        /// </summary>
        /// <param name="property">属性表达式</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        public void Append<TProperty>( Expression<Func<TEntity, TProperty>> property, Operator @operator, Expression value ) {
            _result = _result.And( _parameter.Property( Lambda.GetMember( property ) ).Operation( @operator, value ) );
        }

        /// <summary>
        /// 添加表达式
        /// </summary>
        /// <param name="property">属性名</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        public void Append( string property, Operator @operator, object value ) {
            _result = _result.And( _parameter.Property( property ).Operation( @operator, value ) );
        }

        /// <summary>
        /// 添加表达式
        /// </summary>
        /// <param name="property">属性名</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        public void Append( string property, Operator @operator, Expression value ) {
            _result = _result.And( _parameter.Property( property ).Operation( @operator, value ) );
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            _result = null;
        }

        /// <summary>
        /// 转换为Lambda表达式
        /// </summary>
        public Expression<Func<TEntity, bool>> ToLambda() {
            return _result.ToLambda<Func<TEntity, bool>>( _parameter );
        }
    }
}
