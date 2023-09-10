using System;
using System.Linq.Expressions;
using Util.Data.EntityFrameworkCore.Filters;

namespace Util.Data.EntityFrameworkCore.Samples;

/// <summary>
/// 测试过滤器1
/// </summary>
public class TestFilter1 : FilterBase<ITest> {
    /// <summary>
    /// 获取过滤表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public override Expression<Func<TEntity, bool>> GetExpression<TEntity>( object state ) where TEntity : class {
        Expression<Func<TEntity, bool>> expression = t => false;
        return expression;
    }
}

/// <summary>
/// 测试过滤器2
/// </summary>
public class TestFilter2 : FilterBase<ITest2> {
    /// <summary>
    /// 获取过滤表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public override Expression<Func<TEntity, bool>> GetExpression<TEntity>( object state ) where TEntity : class {
        Expression<Func<TEntity, bool>> expression = t => true;
        return expression;
    }
}