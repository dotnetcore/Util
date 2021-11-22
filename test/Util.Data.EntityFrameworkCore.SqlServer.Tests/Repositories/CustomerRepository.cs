using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.UnitOfWorks;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer,int>,ICustomerRepository {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public CustomerRepository( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}