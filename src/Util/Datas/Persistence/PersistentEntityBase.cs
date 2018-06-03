using System;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Util.Datas.Persistence {
    /// <summary>
    /// 持久化对象
    /// </summary>
    public abstract class PersistentEntityBase : PersistentEntityBase<Guid> {
    }

    /// <summary>
    /// 持久化对象
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public abstract class PersistentEntityBase<TKey> : IKey<TKey> {
        /// <summary>
        /// 标识
        /// </summary>
        [Key]
        public TKey Id { get; set; }

        /// <summary>
        /// 相等运算
        /// </summary>
        public override bool Equals( object other ) {
            return this == (PersistentEntityBase<TKey>)other;
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
        public static bool operator ==( PersistentEntityBase<TKey> left, PersistentEntityBase<TKey> right ) {
            if( (object)left == null && (object)right == null )
                return true;
            if( (object)left == null || (object)right == null )
                return false;
            if( left.GetType() != right.GetType() )
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
        public static bool operator !=( PersistentEntityBase<TKey> left, PersistentEntityBase<TKey> right ) {
            return !( left == right );
        }
    }
}
