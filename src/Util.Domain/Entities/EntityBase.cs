using System;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Compare;
using Util.Domain.Extending;
using Util.Properties;
using Util.Validation;

namespace Util.Domain.Entities {
    /// <summary>
    /// 领域实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityBase<TEntity> : EntityBase<TEntity, Guid> where TEntity : IEntity<TEntity, Guid> {
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase( Guid id ) : base( id ){
        }
    }

    /// <summary>
    /// 领域实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public abstract class EntityBase<TEntity, TKey> : DomainObjectBase<TEntity>, IEntity<TEntity, TKey> where TEntity : IEntity<TEntity, TKey> {
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase( TKey id ) {
            Id = id;
            ExtraProperties = new ExtraPropertyDictionary();
        }

        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        public TKey Id { get; private set; }

        /// <summary>
        /// 扩展属性集合
        /// </summary>
        protected ExtraPropertyDictionary ExtraProperties { get; set; }

        /// <summary>
        /// 相等运算
        /// </summary>
        public override bool Equals( object other ) {
            return this == ( other as EntityBase<TEntity, TKey> );
        }

        /// <summary>
        /// 获取哈希
        /// </summary>
        public override int GetHashCode() {
            return ReferenceEquals( Id, null ) ? 0 : Id.GetHashCode();
        }

        /// <summary>
        /// 相等比较
        /// </summary>
        public static bool operator ==( EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right ) {
            if( (object)left == null && (object)right == null )
                return true;
            if( !( left is TEntity ) || !( right is TEntity ) )
                return false;
            if( Equals( left.Id, null ) )
                return false;
            if( left.Id.Equals( default( TKey ) ) )
                return false;
            return left.Id.Equals( right.Id );
        }

        /// <summary>
        /// 不相等比较
        /// </summary>
        public static bool operator !=( EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right ) {
            return !( left == right );
        }

        /// <summary>
        /// 创建变更值集合
        /// </summary>
        protected override ChangeValueCollection CreateChangeValueCollection( TEntity newEntity ) {
            var description = Util.Helpers.Reflection.GetDisplayNameOrDescription( newEntity.GetType() );
            return new ChangeValueCollection( newEntity.GetType().ToString(), description,newEntity.Id.SafeString() );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            InitId();
        }

        /// <summary>
        /// 初始化标识
        /// </summary>
        protected virtual void InitId() {
            if( typeof( TKey ) == typeof( int ) || typeof( TKey ) == typeof( long ) )
                return;
            if( string.IsNullOrWhiteSpace( Id.SafeString() ) || Id.Equals( default( TKey ) ) )
                Id = CreateId();
        }

        /// <summary>
        /// 创建标识
        /// </summary>
        protected virtual TKey CreateId() {
            return Util.Helpers.Convert.To<TKey>( Guid.NewGuid() );
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected override void Validate( ValidationResultCollection results ) {
            ValidateId( results );
        }

        /// <summary>
        /// 验证标识
        /// </summary>
        protected virtual void ValidateId( ValidationResultCollection results ) {
            if( typeof( TKey ) == typeof( int ) || typeof( TKey ) == typeof( long ) )
                return;
            if( string.IsNullOrWhiteSpace( Id.SafeString() ) || Id.Equals( default( TKey ) ) )
                results.Add( new ValidationResult( R.IdIsEmpty ) );
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        public virtual TEntity Clone() {
            return this.MapTo<TEntity>();
        }
    }
}
