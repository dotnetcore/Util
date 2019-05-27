using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;
using Util.Samples.Domain.Models;
using Util.Samples.Domain.Repositories;

namespace Util.Samples.Data.Repositories.Systems {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : TreeRepositoryBase<Role>, IRoleRepository, IRoleStore<Role> {
        /// <summary>
        /// 初始化角色仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RoleRepository( ISampleUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose() {
            UnitOfWork.Dispose();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<IdentityResult> CreateAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            await AddAsync( role, cancellationToken );
            return IdentityResult.Success;
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        private void ValidateRole( Role role, CancellationToken cancellationToken ) {
            role.CheckNull( nameof( role ) );
            cancellationToken.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<IdentityResult> UpdateAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            await UpdateAsync( role );
            return IdentityResult.Success;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<IdentityResult> DeleteAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            await RemoveAsync( role, cancellationToken );
            return IdentityResult.Success;
        }

        /// <summary>
        /// 获取角色编号
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetRoleIdAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            return Task.FromResult( role.Id.SafeString() );
        }

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetRoleNameAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            return Task.FromResult( role.Name );
        }

        /// <summary>
        /// 设置角色名称
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="roleName">角色名</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetRoleNameAsync( Role role, string roleName, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            role.Name = roleName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取标准化角色名称
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetNormalizedRoleNameAsync( Role role, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            return Task.FromResult( role.NormalizedName );
        }

        /// <summary>
        /// 设置标准化角色名称
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="normalizedName">标准化角色名称</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetNormalizedRoleNameAsync( Role role, string normalizedName, CancellationToken cancellationToken ) {
            ValidateRole( role, cancellationToken );
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 通过编号获取角色
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<Role> FindByIdAsync( string roleId, CancellationToken cancellationToken ) {
            cancellationToken.ThrowIfCancellationRequested();
            return await FindAsync( roleId.ToGuid(), cancellationToken );
        }

        /// <summary>
        /// 通过名称获取角色
        /// </summary>
        /// <param name="normalizedRoleName">标准化角色名称</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<Role> FindByNameAsync( string normalizedRoleName, CancellationToken cancellationToken ) {
            cancellationToken.ThrowIfCancellationRequested();
            return await SingleAsync( r => r.NormalizedName == normalizedRoleName, cancellationToken );
        }

        /// <summary>
        /// 获取最大排序号
        /// </summary>
        /// <param name="role">角色</param>
        public async Task<int> GetMaxSortIdAsync( Role role ) {
            var maxSortId = await Find( t => t.ParentId == role.ParentId ).MaxAsync( t => t.SortId );
            return maxSortId.SafeValue() + 1;
        }
    }
}
