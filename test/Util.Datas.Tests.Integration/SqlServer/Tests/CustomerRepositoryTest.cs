using System;
using Util.Datas.Ef;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Datas.Tests.SqlServer.Confis;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.SqlServer.Tests {
    /// <summary>
    /// 客户仓储测试 - 主要测试审计和查询操作
    /// </summary>
    public class CustomerRepositoryTest : IDisposable {
        /// <summary>
        /// 容器
        /// </summary>
        private readonly Util.DependencyInjection.IContainer _container;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;
        /// <summary>
        /// 客户仓储
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerRepositoryTest() {
            _container = Ioc.CreateContainer( new IocConfig() );
            _unitOfWork = _container.Create<ISqlServerUnitOfWork>();
            _customerRepository = _container.Create<ICustomerRepository>();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _container.Dispose();
        }

        /// <summary>
        /// 测试添加
        /// </summary>
        [Fact]
        public void TestAdd() {
            string id = Id.Create();
            var customer = new Customer( id ) { Name = "util" };
            _customerRepository.Add( customer );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _customerRepository.Single( t => t.Id == id );
            Assert.NotNull( result.CreationTime );
            Assert.NotNull( result.LastModificationTime );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.CreatorId );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.LastModifierId );
        }

        /// <summary>
        /// 测试修改
        /// </summary>
        [Fact]
        public void TestUpdate() {
            string id = Id.Create();
            var customer = new Customer( id ) { Name = "util" };
            _customerRepository.Add( customer );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _customerRepository.Single( t => t.Id == id );
            var creationTime = result.CreationTime;
            var lastModificationTime = result.LastModificationTime;
            Assert.Equal( "util",result.Name );
            result.Name = "utilcore";
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            result = _customerRepository.Single( t => t.Id == id );
            Assert.Equal( "utilcore", result.Name );
            Assert.Equal( creationTime, result.CreationTime );
            Assert.NotEqual( lastModificationTime, result.LastModificationTime );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.CreatorId );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.LastModifierId );
        }
    }
}
