using System;
using System.Linq.Expressions;
using Nest;
using Util.Datas.Queries;

namespace Util.Search.ElasticSearch.Services.Conditions {
    /// <summary>
    /// 范围过滤条件
    /// </summary>
    public abstract class RangeConditionBase<TEntity, TProperty, TValue,TQuery> : ICondition where TEntity : class where TValue : struct where TQuery: QueryBase {
        /// <summary>
        /// 字段
        /// </summary>
        private readonly Field _field;
        /// <summary>
        /// 最小值
        /// </summary>
        private TValue? _min;
        /// <summary>
        /// 最大值
        /// </summary>
        private TValue? _max;
        /// <summary>
        /// 包含边界
        /// </summary>
        private readonly Boundary _boundary;

        /// <summary>
        /// 初始化范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        protected RangeConditionBase( Expression<Func<TEntity, TProperty>> propertyExpression, TValue? min, TValue? max, Boundary boundary ) {
            _field = new Field( propertyExpression );
            _min = min;
            _max = max;
            _boundary = boundary;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public QueryContainer GetCondition() {
            if ( _min == null && _max == null )
                return null;
            Adjust( _min, _max );
            var condition = CreateCondition();
            SetField( condition, _field );
            SetLeftOperation( condition );
            SetRightOperation( condition );
            return condition;
        }

        /// <summary>
        /// 当最小值大于最大值时进行校正
        /// </summary>
        private void Adjust( TValue? min, TValue? max ) {
            if ( IsMinGreaterMax( min, max ) == false )
                return;
            _min = max;
            _max = min;
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        protected abstract bool IsMinGreaterMax( TValue? min, TValue? max );

        /// <summary>
        /// 创建查询条件
        /// </summary>
        protected abstract TQuery CreateCondition();

        /// <summary>
        /// 设置字段
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="field">字段</param>
        protected abstract void SetField( TQuery condition, Field field );

        /// <summary>
        /// 设置左操作
        /// </summary>
        private void SetLeftOperation( TQuery condition ) {
            if ( _min == null )
                return;
            if ( _boundary == Boundary.Left || _boundary == Boundary.Both ) {
                SetGreaterEqual( condition, GetMinValue() );
                return;
            }
            SetGreater( condition, GetMinValue() );
        }

        /// <summary>
        /// 设置大于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected abstract void SetGreaterEqual( TQuery condition, TValue? min );

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected virtual TValue? GetMinValue() {
            return _min;
        }

        /// <summary>
        /// 设置大于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected abstract void SetGreater( TQuery condition, TValue? min );

        /// <summary>
        /// 设置右操作
        /// </summary>
        private void SetRightOperation( TQuery condition ) {
            if ( _max == null )
                return;
            if ( _boundary == Boundary.Right || _boundary == Boundary.Both ) {
                SetLessEqual( condition, GetMaxValue() );
                return;
            }
            SetLess( condition, GetMaxValue() );
        }

        /// <summary>
        /// 设置小于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected abstract void SetLessEqual( TQuery condition, TValue? max );

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected virtual TValue? GetMaxValue() {
            return _max;
        }

        /// <summary>
        /// 设置小于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected abstract void SetLess( TQuery condition, TValue? max );
    }
}
