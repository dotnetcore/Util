using System.Threading;
using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Data.EntityFrameworkCore.Migrations {
    /// <summary>
    /// 迁移服务
    /// </summary>
    public interface IMigrationService : ITransientDependency {
        /// <summary>
        /// 设置数据上下文项目根目录绝对路径
        /// </summary>
        /// <param name="path">数据上下文项目根目录绝对路径,范例: D:\\Test\\src\\Test.Data.SqlServer</param>
        IMigrationService DbContextRootPath( string path );
        /// <summary>
        /// 设置数据上下文
        /// </summary>
        /// <param name="dbcontext">数据上下文实例</param>
        IMigrationService DbContext( IUnitOfWork dbcontext );
        /// <summary>
        /// 设置迁移名称
        /// </summary>
        /// <param name="name">迁移名称,范例: init</param>
        IMigrationService MigrationName( string name );
        /// <summary>
        /// 是否移除所有外键,将删除迁移文件中的外键设置
        /// </summary>
        IMigrationService RemoveForeignKeys();
        /// <summary>
        /// 执行迁移
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        Task MigrateAsync( CancellationToken cancellationToken = default );
    }
}
