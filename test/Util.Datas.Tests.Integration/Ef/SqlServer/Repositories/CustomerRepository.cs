using Util.Datas.Ef.Core;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;

namespace Util.Datas.Tests.Ef.SqlServer.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer,string>, ICustomerRepository {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public CustomerRepository( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
