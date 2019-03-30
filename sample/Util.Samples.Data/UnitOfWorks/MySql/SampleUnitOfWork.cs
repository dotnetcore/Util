using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace Util.Samples.Data.UnitOfWorks.MySql {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : Util.Datas.Ef.MySql.UnitOfWork,ISampleUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        public SampleUnitOfWork( DbContextOptions options, IUnitOfWorkManager unitOfWorkManager ) : base( options, unitOfWorkManager ) {
        }
    }
}