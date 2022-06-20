using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// In查询条件
    /// </summary>
    public class InCondition : ISqlCondition {
        /// <summary>
        /// Sql参数管理器
        /// </summary>
        protected readonly IParameterManager ParameterManager;
        /// <summary>
        /// 列名
        /// </summary>
        protected readonly string Column;
        /// <summary>
        /// 列名
        /// </summary>
        protected readonly object Value;
        /// <summary>
        /// 是否参数化
        /// </summary>
        protected readonly bool IsParameterization;

        /// <summary>
        /// 初始化In查询条件
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="isParameterization">是否参数化</param>
        public InCondition( IParameterManager parameterManager, string column, object value, bool isParameterization ) {
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
        public void AppendTo( StringBuilder builder ) {
            if( Value is ISqlBuilder sqlBuilder ) {
                AppendSqlBuilder( builder, Column, sqlBuilder );
                return;
            }
            var values = GetValues();
            if( values.Count == 0 )
                return;
            if ( IsParameterization ) {
                AppendParameterizedCondition( builder,values );
                return;
            }
            AppendNonParameterizedCondition( builder,values );
        }

        /// <summary>
        /// 添加Sql生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        protected virtual void AppendSqlBuilder( StringBuilder builder, string column, ISqlBuilder sqlBuilder ) {
            builder.AppendFormat( "{0} {1} ", column, GetOperator() );
            builder.Append( "(" );
            sqlBuilder.AppendTo( builder );
            builder.Append( ")" );
        }

        /// <summary>
        /// 获取操作符关键字
        /// </summary>
        protected virtual string GetOperator() {
            return "In";
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private List<object> GetValues() {
            var values = Value as IEnumerable;
            if( values == null )
                return null;
            var result = new List<object>();
            foreach ( var value in values ) {
                if ( value == null )
                    continue;
                result.Add( value );
            }
            return result;
        }

        /// <summary>
        /// 添加参数化条件
        /// </summary>
        protected virtual void AppendParameterizedCondition( StringBuilder builder, List<object> values ) {
            builder.AppendFormat( "{0} {1} (", Column, GetOperator() );
            foreach( var value in values ) {
                var paramName = ParameterManager.GenerateName();
                builder.AppendFormat( "{0},", paramName );
                ParameterManager.Add( paramName, value );
            }
            builder.RemoveEnd( "," ).Append( ")" );
        }

        /// <summary>
        /// 添加非参数化条件
        /// </summary>
        protected virtual void AppendNonParameterizedCondition( StringBuilder builder, List<object> values ) {
            builder.AppendFormat( "{0} {1} (", Column, GetOperator() );
            foreach( var value in values ) {
                builder.AppendFormat( "{0},", GetFormattedValue( value ) );
            }
            builder.RemoveEnd( "," ).Append( ")" );
        }

        /// <summary>
        /// 获取格式化后的值
        /// </summary>
        private string GetFormattedValue( object value ) {
            switch ( value.GetType().ToString() ) {
                case "System.String":
                    return $"'{value}'";
                default:
                    return value.ToString();
            }
        }
    }
}