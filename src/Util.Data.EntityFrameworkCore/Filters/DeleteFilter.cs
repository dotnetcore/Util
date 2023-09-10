namespace Util.Data.EntityFrameworkCore.Filters; 

/// <summary>
/// 逻辑删除过滤器
/// </summary>
public class DeleteFilter : FilterBase<IDelete> {
    /// <summary>
    /// 获取过滤表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public override Expression<Func<TEntity, bool>> GetExpression<TEntity>( object state ) where TEntity : class {
        var unitOfWork = state as UnitOfWorkBase;
        Expression<Func<TEntity, bool>> expression = entity => !EF.Property<bool>( entity, "IsDeleted" );
        if ( unitOfWork == null )
            return expression;
        Expression<Func<TEntity, bool>> isEnabled = entity => !unitOfWork.IsDeleteFilterEnabled;
        return isEnabled.Or( expression );
    }
}