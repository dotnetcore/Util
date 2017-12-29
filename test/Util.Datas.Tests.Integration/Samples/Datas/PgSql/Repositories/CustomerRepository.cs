using Util.Datas.Ef.Core;
using Util.Datas.Tests.Samples.Datas.PgSql.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;

namespace Util.Datas.Tests.Samples.Datas.PgSql.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer,string>, ICustomerRepository {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public CustomerRepository( IPgSqlUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
