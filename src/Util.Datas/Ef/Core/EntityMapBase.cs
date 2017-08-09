using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Domains;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 实体映射配置
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityMapBase<TEntity> : IMap where TEntity : class, IEntity {
        /// <summary>
        /// 映射配置
        /// </summary>
        /// <param name="modelBuilder">模型生成器</param>
        public void Map( ModelBuilder modelBuilder ) {
            var builder = modelBuilder.Entity<TEntity>();
            MapTable( builder );
            MapVersion( builder );
            MapProperties( builder );
            MapAssociations( builder );
        }

        /// <summary>
        /// 映射表
        /// </summary>
        protected abstract void MapTable( EntityTypeBuilder<TEntity> builder );

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected virtual void MapVersion( EntityTypeBuilder<TEntity> builder ) {
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected virtual void MapProperties( EntityTypeBuilder<TEntity> builder ) {
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected virtual void MapAssociations( EntityTypeBuilder<TEntity> builder ) {
        }
    }
}
