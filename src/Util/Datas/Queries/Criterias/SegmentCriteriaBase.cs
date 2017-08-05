using System;
using System.Linq.Expressions;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Expressions;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 范围过滤条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    /// <typeparam name="TValue">值类型</typeparam>
    public abstract class SegmentCriteriaBase<TEntity, TProperty, TValue> : ICriteria<TEntity>
        where TEntity : class, IAggregateRoot
        where TValue : struct {
        /// <summary>
        /// 初始化范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        protected SegmentCriteriaBase( Expression<Func<TEntity, TProperty>> propertyExpression, TValue? min, TValue? max ) {
            Builder = new PredicateExpressionBuilder<TEntity>();
            PropertyExpression = propertyExpression;
            Min = min;
            Max = max;
            if ( IsMinGreaterMax( min, max ) ) {
                Min = max;
                Max = min;
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        protected abstract bool IsMinGreaterMax( TValue? min, TValue? max );

        /// <summary>
        /// 属性表达式
        /// </summary>
        public Expression<Func<TEntity, TProperty>> PropertyExpression { get; set; }

        /// <summary>
        /// 表达式生成器
        /// </summary>
        private PredicateExpressionBuilder<TEntity> Builder { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public TValue? Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public TValue? Max { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<TEntity, bool>> GetPredicate() {
            CreateLeftExpression();
            CreateRightExpression();
            return Builder.ToLambda();
        }

        /// <summary>
        /// 创建左操作数，即 t => t.Property >= Min
        /// </summary>
        private void CreateLeftExpression() {
            if( Min == null )
                return;
            Builder.Append( PropertyExpression, Operator.GreaterEqual, GetMinValue() );
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected virtual TValue? GetMinValue() {
            return Min;
        }

        /// <summary>
        /// 创建右操作数，即 t => t.Property &lt;= Max
        /// </summary>
        private void CreateRightExpression() {
            if ( Max == null )
                return;
            Builder.Append( PropertyExpression, GetMaxOperator(), GetMaxValue() );
        }

        /// <summary>
        /// 获取最大值相关的运算符
        /// </summary>
        protected virtual Operator GetMaxOperator() {
            return Operator.LessEqual;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected virtual TValue? GetMaxValue() {
            return Max;
        }
    }
}
