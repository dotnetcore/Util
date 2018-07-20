using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Util.Domains.Services;
using Util.Exceptions;
using Util.Security.Identity.Extensions;
using Util.Security.Identity.Models;
using Util.Security.Identity.Repositories;
using Util.Security.Identity.Services.Abstractions;
using Util.Security.Properties;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 角色服务
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TKey">角色标识类型</typeparam>
    /// <typeparam name="TParentId">角色父标识类型</typeparam>
    public abstract class RoleManager<TRole, TKey, TParentId> : DomainServiceBase, IRoleManager<TRole, TKey, TParentId> where TRole : Role<TRole, TKey, TParentId> {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="roleManager">Identity角色服务</param>
        /// <param name="repository">角色仓储</param>
        protected RoleManager( RoleManager<TRole> roleManager, IRoleRepository<TRole, TKey, TParentId> repository ) {
            Manager = roleManager;
            Repository = repository;
        }

        /// <summary>
        /// Identity角色服务
        /// </summary>
        private RoleManager<TRole> Manager { get; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        private IRoleRepository<TRole, TKey, TParentId> Repository { get; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        public virtual async Task CreateAsync( TRole role ) {
            await ValidateCreate( role );
            role.Init();
            var parent = await Repository.FindAsync( role.ParentId );
            role.InitPath( parent );
            role.SortId = await Repository.GenerateSortIdAsync( role.ParentId );
            var result = await Manager.CreateAsync( role );
            result.ThrowIfError();
        }

        /// <summary>
        /// 创建角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected virtual async Task ValidateCreate( TRole role ) {
            role.CheckNull( nameof( role ) );
            if( await Repository.ExistsAsync( t => t.Code == role.Code ) )
                ThrowDuplicateCodeException( role.Code );
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        protected void ThrowDuplicateCodeException( string code ) {
            throw new Warning( string.Format( SecurityResource.DuplicateRoleCode, code ) );
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        public async Task UpdateAsync( TRole role ) {
            role.CheckNull( nameof( role ) );
            await ValidateUpdate( role );
            role.InitPinYin();
            await Repository.UpdatePathAsync( role );
            var result = await Manager.UpdateAsync( role );
            result.ThrowIfError();
        }

        /// <summary>
        /// 修改角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected virtual Task ValidateUpdate( TRole role ) {
            return Task.CompletedTask;
        }
    }
}
