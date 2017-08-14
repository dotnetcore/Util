using System;
using System.Threading.Tasks;
using Util.Datas.Ef;
using Util.Datas.Tests.Samples;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Datas.Tests.SqlServer.Confis;
using Util.Exceptions;
using Util.Helpers;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Datas.Tests.SqlServer.Tests {
    /// <summary>
    /// 订单仓储测试
    /// </summary>
    public class OrderRepositoryTest : IDisposable{
        /// <summary>
        /// 容器
        /// </summary>
        private readonly Util.DependencyInjection.IContainer _container;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;
        /// <summary>
        /// 订单仓储
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OrderRepositoryTest() {
            _container = Ioc.CreateContainer( new IocConfig() );
            _unitOfWork = _container.Create<ISqlServerUnitOfWork>();
            _orderRepository = _container.Create<IOrderRepository>();
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
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();

            var result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( id, result.Id );
        }

        /// <summary>
        /// 测试异步添加
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( order );
            await _unitOfWork.CommitAsync();

            var result = await _orderRepository.SingleAsync( t => t.Id == id );
            Assert.Equal( id, result.Id );
        }

        /// <summary>
        /// 测试更新 - 修改方式1：先从仓储中查找出来，直接修改对象属性，提交工作单元
        /// 适用场景: 适合对实体部分属性进行更新
        /// 应用场景: 对于较复杂的业务操作，尽量使用该方法，而不是整体替换实体
        /// 优点：按需更新，生成的更新SQL只更新变更字段
        /// </summary>
        [Fact]
        public void TestUpdate_1() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _orderRepository.Find( id );
            result.Code = "B";
            _unitOfWork.Commit();

            result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新 - 修改方式2：创建出修改对象，调用仓储的Update，内部修改为已更新状态，提交工作单元
        /// 适用场景：当修改前不想获取出数据库中的待修改对象，则使用本方法
        /// 应用场景：通过Http Put方法传入DTO,该DTO包含待修改实体的全部属性，将该DTO转成待更新实体，你可能觉得从数据库中获取原实体浪费资源，希望能够将待更新实体直接保存到数据库
        /// 注意1：创建的更新实体必须包含全部数据，否则导致数据丢失
        /// 注意2：如果在调用Update方法前调用了Find等方法将原对象获取出来，则更新失败
        /// 缺点：整体更新，生成的更新SQL会更新所有字段
        /// </summary>
        [Fact]
        public void TestUpdate_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var order2 = new Order( id ) { Name = "Name", Code = "B",Version = order.Version };
            _orderRepository.Update( order2 );
            _unitOfWork.Commit();

            var result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新 - 修改方式3：从数据库获取出旧实体，创建出待修改的新实体，调用仓储的Update，新实体将替换旧实体，提交工作单元
        /// 适用场景：当修改前需要获取出数据库中的待修改对象，且创建了完整的待修改对象，则使用本方法
        /// 应用场景：通过Http Put方法传入DTO,该DTO包含待修改实体的全部属性，将该DTO转成待更新实体，你可能需要从数据库中获取出原来的实体，例如需要比较哪些属性发生了变化
        /// 优点：按需更新，生成的更新SQL只更新变更字段
        /// </summary>
        [Fact]
        public void TestUpdate_3() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var newEntity = new Order( id ) { Name = "Name", Code = "B", Version = order.Version };
            var oldEntity = _orderRepository.Find( id );
            _orderRepository.Update( newEntity, oldEntity );
            _unitOfWork.Commit();

            var result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新并发 - 使用修改方式2,Version属性未设置
        /// </summary>
        [Fact]
        public void TestUpdate_Concurrency_1() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            AssertHelper.Throws<ConcurrencyException>( () => {
                var order2 = new Order( id ) { Name = "Name", Code = "B" };
                _orderRepository.Update( order2 );
                _unitOfWork.Commit();
            } );
        }

        /// <summary>
        /// 测试更新并发 - 使用修改方式2,Version属性设置为无效
        /// </summary>
        [Fact]
        public void TestUpdate_Concurrency_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            AssertHelper.Throws<ConcurrencyException>( () => {
                var order2 = new Order( id ) { Name = "Name", Code = "B",Version = Guid.NewGuid().ToByteArray() };
                _orderRepository.Update( order2 );
                _unitOfWork.Commit();
            } );
        }

        /// <summary>
        /// 测试更新并发 - 使用修改方式3,Version属性未设置
        /// </summary>
        [Fact]
        public void TestUpdate_Concurrency_3() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            AssertHelper.Throws<ConcurrencyException>( () => {
                var newEntity = new Order( id ) { Name = "Name", Code = "B" };
                var oldEntity = _orderRepository.Find( id );
                _orderRepository.Update( newEntity, oldEntity );
                _unitOfWork.Commit();
            } );
        }

        /// <summary>
        /// 测试更新并发 - 使用修改方式3,Version属性设置为无效
        /// </summary>
        [Fact]
        public void TestUpdate_Concurrency_4() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            AssertHelper.Throws<ConcurrencyException>( () => {
                var newEntity = new Order( id ) { Name = "Name", Code = "B", Version = Guid.NewGuid().ToByteArray() };
                var oldEntity = _orderRepository.Find( id );
                _orderRepository.Update( newEntity, oldEntity );
                _unitOfWork.Commit();
            } );
        }
    }
}
