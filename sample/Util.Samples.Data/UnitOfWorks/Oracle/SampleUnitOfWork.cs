using Microsoft.EntityFrameworkCore;

namespace Util.Samples.Data.UnitOfWorks.Oracle {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class SampleUnitOfWork : Util.Datas.Ef.Oracle.UnitOfWork,ISampleUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public SampleUnitOfWork( DbContextOptions<SampleUnitOfWork> options ) : base( options ) {
        }
    }
}