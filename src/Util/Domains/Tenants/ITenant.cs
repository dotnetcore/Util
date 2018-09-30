using System;

namespace Util.Domains.Tenants
{
    /// <summary>
    /// 租户
    /// </summary>
    public interface ITenant : ITenant<Guid>
    {
    }
    /// <summary>
    /// 租户
    /// </summary>
    public interface ITenant<TKey>
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        TKey TenantId { get; set; }
    }
}