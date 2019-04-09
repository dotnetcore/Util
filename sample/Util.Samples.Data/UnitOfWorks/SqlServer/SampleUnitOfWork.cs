using System;
using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace Util.Samples.Data.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISampleUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        /// <param name="serviceProvider">服务提供器</param>
        public SampleUnitOfWork( DbContextOptions options, IUnitOfWorkManager unitOfWorkManager,IServiceProvider serviceProvider ) 
            : base( options, unitOfWorkManager, serviceProvider ) {
        }
    }
}