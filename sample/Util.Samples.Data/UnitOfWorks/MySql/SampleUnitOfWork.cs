using Microsoft.EntityFrameworkCore;

namespace Util.Samples.Data.UnitOfWorks.MySql {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : Util.Datas.Ef.MySql.UnitOfWork,ISampleUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public SampleUnitOfWork( DbContextOptions<SampleUnitOfWork> options ) : base( options ) {
        }
    }
}