using System;
using Microsoft.EntityFrameworkCore;

namespace Util.Samples.Data.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISampleUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public SampleUnitOfWork( DbContextOptions<SampleUnitOfWork> options, IServiceProvider serviceProvider ) 
            : base( options, serviceProvider ) {
        }
    }
}