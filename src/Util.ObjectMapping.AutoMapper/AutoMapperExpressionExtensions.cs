using System;
using System.Linq.Expressions;
using AutoMapper;

namespace Util.ObjectMapping {
    /// <summary>
    /// AutoMapper配置表达式扩展
    /// </summary>
    public static class AutoMapperExpressionExtensions {
        /// <summary>
        /// 忽略属性
        /// </summary>
        public static IMappingExpression<TDestination, TMember> Ignore<TDestination, TMember, TResult>( this IMappingExpression<TDestination, TMember> mappingExpression, Expression<Func<TMember, TResult>> destinationMember ) {
            return mappingExpression.ForMember( destinationMember, options => options.Ignore() );
        }
    }
}
