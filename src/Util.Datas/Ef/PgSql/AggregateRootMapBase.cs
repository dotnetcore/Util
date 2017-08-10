using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Util.Datas.Ef.Core;
using Util.Domains;

namespace Util.Datas.Ef.PgSql {
    /// <summary>
    /// 聚合根映射配置
    /// </summary>
    /// <typeparam name="TEntity">聚合根类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class AggregateRootMapBase<TEntity, TKey> : EntityMapBase<TEntity>, IMap where TEntity : class, IAggregateRoot<TEntity, TKey> {
        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected override void MapVersion( EntityTypeBuilder<TEntity> builder ) {
            builder.Property( t => t.Version ).IsConcurrencyToken();
        }
    }

    /// <summary>
    /// 聚合根映射
    /// </summary>
    /// <typeparam name="TEntity">聚合根类型</typeparam>
    public abstract class AggregateRootMapBase<TEntity> : AggregateRootMapBase<TEntity, Guid> where TEntity : class, IAggregateRoot<TEntity, Guid> {
    }
}