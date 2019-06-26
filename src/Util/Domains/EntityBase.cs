﻿using System;
using System.ComponentModel.DataAnnotations;
using Util.Helpers;
using Util.Properties;
using Util.Sessions;
using Util.Validations;

namespace Util.Domains {
    /// <summary>
    /// 领域实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityBase<TEntity> : EntityBase<TEntity, Guid> where TEntity : IEntity {
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
    public abstract class EntityBase<TEntity, TKey> : DomainBase<TEntity>, IEntity<TEntity, TKey> where TEntity : IEntity {
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase( TKey id ) {
            Id = id;
        }

        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        public TKey Id { get; private set; }

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
        /// 用户会话
        /// </summary>
        protected virtual ISession Session => Ioc.Create<ISession>();

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
    }
}
