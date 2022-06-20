using System;
using System.Text;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Sql查询条件
    /// </summary>
    public abstract class SqlConditionBase : ISqlCondition {
        /// <summary>
        /// Sql参数管理器
        /// </summary>
        protected readonly IParameterManager ParameterManager;
        /// <summary>
        /// 列名
        /// </summary>
        protected readonly string Column;
        /// <summary>
        /// 值
        /// </summary>
        protected readonly object Value;
        /// <summary>
        /// 是否参数化
        /// </summary>
        protected readonly bool IsParameterization;

        /// <summary>
        /// 初始化Sql查询条件
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="isParameterization">是否参数化</param>
        protected SqlConditionBase( IParameterManager parameterManager, string column, object value, bool isParameterization ) {
            ParameterManager = parameterManager ?? throw new ArgumentNullException( nameof( parameterManager ) );
            if( string.IsNullOrWhiteSpace( column ) )
                throw new ArgumentNullException( nameof( column ) );
            Column = column;
            Value = value;
            IsParameterization = isParameterization;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public virtual void AppendTo( StringBuilder builder ) {
            if ( Value is ISqlBuilder sqlBuilder ) {
                AppendSqlBuilder( builder,Column, sqlBuilder );
                return;
            }
            if ( IsParameterization ) {
                AppendParameterizedCondition( builder );
                return;
            }
            AppendNonParameterizedCondition( builder );
        }

        /// <summary>
        /// 添加Sql生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        protected virtual void AppendSqlBuilder( StringBuilder builder, string column, ISqlBuilder sqlBuilder ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加参数化条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        protected virtual void AppendParameterizedCondition( StringBuilder builder ) {
            var paramName = GenerateParamName();
            var value = GetValue();
            ParameterManager.Add( paramName, value );
            AppendCondition( builder, Column, paramName );
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        protected virtual string GenerateParamName() {
            return ParameterManager.GenerateName();
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        protected virtual object GetValue() {
            return Value;
        }

        /// <summary>
        /// 添加Sql条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        protected abstract void AppendCondition( StringBuilder builder,string column, object value );

        /// <summary>
        /// 添加非参数化条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        protected virtual void AppendNonParameterizedCondition( StringBuilder builder ) {
            AppendCondition( builder, Column, GetValue() );
        }
    }
}
