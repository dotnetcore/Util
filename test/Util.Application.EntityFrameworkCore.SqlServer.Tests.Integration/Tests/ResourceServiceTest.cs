using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Services;
using Xunit;

namespace Util.Applications.Tests {
    /// <summary>
    /// 资源服务测试 - 测试树形
    /// </summary>
    public class ResourceServiceTest {

        #region 测试初始化

        /// <summary>
        /// 资源服务
        /// </summary>
        private readonly IResourceService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="service">资源服务</param>
        public ResourceServiceTest( IResourceService service ) {
            _service = service;
        }

        #endregion

        #region CreateAsync

        /// <summary>
        /// 测试创建 - 添加根节点
        /// </summary>
        [Fact]
        public async Task TestCreateAsync_1() {
            //添加资源
            var dto = ResourceDtoFakeService.GetResourceDto();
            dto.Name = "TestCreateAsync_1";
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( $"{id},", result.Path );
            Assert.Equal( 1, result.Level );
        }

        /// <summary>
        /// 测试创建 - 添加2个子节点
        /// </summary>
        [Fact]
        public async Task TestCreateAsync_2() {
            //添加根节点
            var root = ResourceDtoFakeService.GetResourceDto();
            root.Name = "TestCreateAsync_2_Root";
            var rootId = await _service.CreateAsync( root );

            //添加子节点1
            var dto = ResourceDtoFakeService.GetResourceDto();
            dto.Name = "TestCreateAsync_2_Child_1";
            dto.ParentId = rootId;
            var childId = await _service.CreateAsync( dto );

            //添加子节点2
            var dto2 = ResourceDtoFakeService.GetResourceDto();
            dto2.Name = "TestCreateAsync_2_Child_2";
            dto2.ParentId = rootId;
            var childId2 = await _service.CreateAsync( dto2 );

            //验证子节点1
            var result = await _service.GetByIdAsync( childId );
            Assert.Equal( $"{rootId},{childId},", result.Path );
            Assert.Equal( 2, result.Level );

            //验证子节点2
            result = await _service.GetByIdAsync( childId2 );
            Assert.Equal( $"{rootId},{childId2},", result.Path );
            Assert.Equal( 2, result.Level );
        }

        #endregion

        #region UpdateAsync

        /// <summary>
        /// 测试修改 - 1个节点
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync_1() {
            //定义变量
            var name = "TestUpdateAsync_1";

            //添加资源
            var dto = ResourceDtoFakeService.GetResourceDto();
            var id = await _service.CreateAsync( dto );

            //修改
            dto = await _service.GetByIdAsync( id );
            dto.Name = name;
            await _service.UpdateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( name, result.Name );
            Assert.Equal( $"{id},", result.Path );
            Assert.Equal( 1, result.Level );
        }

        /// <summary>
        /// 测试修改 - 3级节点
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync_2() {
            //添加根节点
            var root = ResourceDtoFakeService.GetResourceDto();
            root.Name = "Root";
            var rootId = await _service.CreateAsync( root );

            //添加2级节点A
            var nodeA = ResourceDtoFakeService.GetResourceDto();
            nodeA.Name = "NodeA";
            nodeA.ParentId = rootId;
            var aId = await _service.CreateAsync( nodeA );

            //在A节点下添加A1节点
            var nodeA1 = ResourceDtoFakeService.GetResourceDto();
            nodeA1.Name = "NodeA1";
            nodeA1.ParentId = aId;
            var a1Id = await _service.CreateAsync( nodeA1 );

            //添加2级节点B
            var nodeB = ResourceDtoFakeService.GetResourceDto();
            nodeB.Name = "NodeB";
            nodeB.ParentId = rootId;
            var bId = await _service.CreateAsync( nodeB );

            //在B节点下添加B1节点
            var nodeB1 = ResourceDtoFakeService.GetResourceDto();
            nodeB1.Name = "NodeB1";
            nodeB1.ParentId = bId;
            var b1Id = await _service.CreateAsync( nodeB1 );

            //将A节点移动到B节点下
            nodeA = await _service.GetByIdAsync( aId );
            nodeA.ParentId = bId;
            await _service.UpdateAsync( nodeA );

            //验证A节点
            nodeA = await _service.GetByIdAsync( aId );
            Assert.Equal( $"{rootId},{bId},{aId},", nodeA.Path );
            Assert.Equal( 3, nodeA.Level );

            //验证A1节点
            nodeA1 = await _service.GetByIdAsync( a1Id );
            Assert.Equal( $"{rootId},{bId},{aId},{a1Id},", nodeA1.Path );
            Assert.Equal( 4, nodeA1.Level );

            //验证B1节点
            nodeB1 = await _service.GetByIdAsync( b1Id );
            Assert.Equal( $"{rootId},{bId},{b1Id},", nodeB1.Path );
            Assert.Equal( 3, nodeB1.Level );
        }

        #endregion

        #region EnableAsync

        /// <summary>
        /// 测试启用
        /// </summary>
        [Fact]
        public async Task TestEnableAsync_1() {
            //添加资源1
            var dto = ResourceDtoFakeService.GetResourceDto();
            dto.Enabled = false;
            var id = await _service.CreateAsync( dto );

            //添加资源2
            var dto2 = ResourceDtoFakeService.GetResourceDto();
            dto2.Enabled = false;
            var id2 = await _service.CreateAsync( dto2 );

            //启用资源
            var ids = $"{id},{id2}";
            await _service.EnableAsync( ids );

            //验证
            var result = await _service.GetByIdsAsync( ids );
            Assert.True( result[0].Enabled );
            Assert.True( result[1].Enabled );
        }

        #endregion

        #region DisableAsync

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public async Task TestDisableAsync_1() {
            //添加资源1
            var dto = ResourceDtoFakeService.GetResourceDto();
            dto.Enabled = true;
            var id = await _service.CreateAsync( dto );

            //添加资源2
            var dto2 = ResourceDtoFakeService.GetResourceDto();
            dto2.Enabled = true;
            var id2 = await _service.CreateAsync( dto2 );

            //启用资源
            var ids = $"{id},{id2}";
            await _service.DisableAsync( ids );

            //验证
            var result = await _service.GetByIdsAsync( ids );
            Assert.False( result[0].Enabled );
            Assert.False( result[1].Enabled );
        }

        #endregion
    }
}
