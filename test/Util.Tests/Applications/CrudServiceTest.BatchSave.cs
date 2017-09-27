using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Applications {
    /// <summary>
    /// 增删改查服务测试 - 批量删除
    /// </summary>
    public partial class CrudServiceTest {
        /// <summary>
        /// 测试添加空集合操作
        /// </summary>
        [Fact]
        public void TestSave_Add_Empty() {
            _service.Save( DtoSample.EmptyList(), DtoSample.EmptyList(), DtoSample.EmptyList() );
            _repository.DidNotReceive().Add( Arg.Any<EntitySample>() );
        }

        /// <summary>
        /// 过滤新增列表 - 要删除的不需要新增
        /// </summary>
        [Fact]
        public void TestSave_FilterAddListByDeleteList() {
            var input = new List<DtoSample> { new DtoSample { Id = "1" } };
            _service.Save( input, DtoSample.EmptyList(), input );
            _repository.DidNotReceive().Add( Arg.Any<EntitySample>() );
        }

        /// <summary>
        /// 过滤更新列表 - 要删除的不需要更新
        /// </summary>
        [Fact]
        public void TestSave_FilterUpdateListByDeleteList() {
            var input = new List<DtoSample> { new DtoSample { Id = "1" } };
            _service.Save( DtoSample.EmptyList(), input, input );
            _repository.DidNotReceive().Update( Arg.Any<EntitySample>() );
        }

        /// <summary>
        /// 验证重复添加
        /// </summary>
        [Fact]
        public void TestSave_Add_Repeat() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id.ToString()}
            };
            _service.Save( input, DtoSample.EmptyList(), DtoSample.EmptyList() );
            _repository.Received( 1 ).Add( Arg.Any<EntitySample>() );
        }

        /// <summary>
        /// 验证重复更新
        /// </summary>
        [Fact]
        public void TestSave_Update_Repeat() {
            _repository.Find( _id ).Returns( t => new EntitySample( _id ) );
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id.ToString()}
            };
            _service.Save( DtoSample.EmptyList(), input, DtoSample.EmptyList() );
            _repository.Received( 1 ).Update( Arg.Any<EntitySample>() );
        }

        /// <summary>
        /// 验证重复删除
        /// </summary>
        [Fact]
        public void TestSave_Delete_Repeat() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id.ToString()}
            };
            _service.Save( DtoSample.EmptyList(), DtoSample.EmptyList(), input );
            _repository.Received( 1 ).Remove( Arg.Any<Guid>() );
        }

        /// <summary>
        /// 添加1个项
        /// </summary>
        [Fact]
        public void TestSave_Add_1() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()}
            };
            _service.Save( input, DtoSample.EmptyList(), DtoSample.EmptyList() );
            _repository.Received( 1 ).Add( Arg.Any<EntitySample>() );
            _repository.Received().Add( Arg.Is<EntitySample>( t => t.Id == _id ) );
        }

        /// <summary>
        /// 添加2个项
        /// </summary>
        [Fact]
        public void TestSave_Add_2() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id2.ToString()}
            };
            _service.Save( input, DtoSample.EmptyList(), DtoSample.EmptyList() );
            _repository.Received( 2 ).Add( Arg.Any<EntitySample>() );
            _repository.Received().Add( Arg.Is<EntitySample>( t => t.Id == _id ) );
            _repository.Received().Add( Arg.Is<EntitySample>( t => t.Id == _id2 ) );
        }

        /// <summary>
        /// 修改1个项
        /// </summary>
        [Fact]
        public void TestSave_Update_1() {
            _repository.Find( _id ).Returns( t => new EntitySample( _id ) );
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString(),Name = "b"}
            };
            _service.Save( DtoSample.EmptyList(), input, DtoSample.EmptyList() );
            _repository.Received( 1 ).Update( Arg.Any<EntitySample>() );
            _repository.Received().Update( Arg.Is<EntitySample>( t => t.Id == _id && t.Name == "b" ) );
        }

        /// <summary>
        /// 修改2个项
        /// </summary>
        [Fact]
        public void TestSave_Update_2() {
            _repository.Find( _id ).Returns( t => new EntitySample( _id ) );
            _repository.Find( _id2 ).Returns( t => new EntitySample( _id2 ) );
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString(),Name = "b"},
                new DtoSample{Id = _id2.ToString(),Name = "b"}
            };
            _service.Save( DtoSample.EmptyList(), input, DtoSample.EmptyList() );
            _repository.Received( 2 ).Update( Arg.Any<EntitySample>() );
            _repository.Received().Update( Arg.Is<EntitySample>( t => t.Id == _id && t.Name == "b" ) );
            _repository.Received().Update( Arg.Is<EntitySample>( t => t.Id == _id2 && t.Name == "b" ) );
        }

        /// <summary>
        /// 删除1个项
        /// </summary>
        [Fact]
        public void TestSave_Delete_1() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()}
            };
            _service.Save( DtoSample.EmptyList(), DtoSample.EmptyList(), input );
            _repository.Received( 1 ).Remove( Arg.Any<Guid>() );
            _repository.Received().Remove( Arg.Is<Guid>( id => id == _id ) );
        }

        /// <summary>
        /// 删除2个项
        /// </summary>
        [Fact]
        public void TestSave_Delete_2() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id2.ToString()}
            };
            _service.Save( DtoSample.EmptyList(), DtoSample.EmptyList(), input );
            _repository.Received( 2 ).Remove( Arg.Any<Guid>() );
            _repository.Received().Remove( Arg.Is<Guid>( id => id == _id ) );
            _repository.Received().Remove( Arg.Is<Guid>( id => id == _id2 ) );
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Fact]
        public void TestSave() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            var id4 = Guid.NewGuid();
            var id5 = Guid.NewGuid();
            var addList = new List<DtoSample> {
                new DtoSample{Id = id.ToString()},
                new DtoSample{Id = id2.ToString()}
            };
            var updateList = new List<DtoSample> {
                new DtoSample{Id = id3.ToString()},
                new DtoSample{Id = id4.ToString()},
                new DtoSample{Id = id5.ToString()}
            };
            var deleteList = new List<DtoSample> {
                new DtoSample{Id = id3.ToString()}
            };
            var result = _service.Save( addList, updateList, deleteList );
            _repository.Received( 2 ).Add( Arg.Any<EntitySample>() );
            _repository.Received( 2 ).Update( Arg.Any<EntitySample>() );
            _repository.Received( 1 ).Remove( Arg.Is<Guid>( t => t == id3 ) );
            _unitOfWork.Received( 1 ).Commit();
            Assert.Equal( 4, result.Count );
        }

        /// <summary>
        /// 添加1个项
        /// </summary>
        [Fact]
        public async Task TestSaveAsync_Add_1() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()}
            };
            await _service.SaveAsync( input, DtoSample.EmptyList(), DtoSample.EmptyList() );
            await _repository.Received( 1 ).AddAsync( Arg.Any<EntitySample>() );
            await _repository.Received().AddAsync( Arg.Is<EntitySample>( t => t.Id == _id ) );
        }

        /// <summary>
        /// 添加2个项
        /// </summary>
        [Fact]
        public async Task TestSaveAsync_Add_2() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()},
                new DtoSample{Id = _id2.ToString()}
            };
            await _service.SaveAsync( input, DtoSample.EmptyList(), DtoSample.EmptyList() );
            await _repository.Received( 2 ).AddAsync( Arg.Any<EntitySample>() );
            await _repository.Received().AddAsync( Arg.Is<EntitySample>( t => t.Id == _id ) );
            await _repository.Received().AddAsync( Arg.Is<EntitySample>( t => t.Id == _id2 ) );
        }

        /// <summary>
        /// 修改1个项
        /// </summary>
        [Fact]
        public async Task TestSaveAsync_Update_1() {
            _repository.Find( _id ).Returns( t => new EntitySample( _id ) );
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString(),Name = "b"}
            };
            await _service.SaveAsync( DtoSample.EmptyList(), input, DtoSample.EmptyList() );
            await _repository.Received( 1 ).UpdateAsync( Arg.Any<EntitySample>() );
            await _repository.Received().UpdateAsync( Arg.Is<EntitySample>( t => t.Id == _id && t.Name == "b" ) );
        }

        /// <summary>
        /// 修改2个项
        /// </summary>
        [Fact]
        public async Task TestSaveAsync_Update_2() {
            _repository.Find( _id ).Returns( t => new EntitySample( _id ) );
            _repository.Find( _id2 ).Returns( t => new EntitySample( _id2 ) );
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString(),Name = "b"},
                new DtoSample{Id = _id2.ToString(),Name = "b"}
            };
            await _service.SaveAsync( DtoSample.EmptyList(), input, DtoSample.EmptyList() );
            await _repository.Received( 2 ).UpdateAsync( Arg.Any<EntitySample>() );
            await _repository.Received().UpdateAsync( Arg.Is<EntitySample>( t => t.Id == _id && t.Name == "b" ) );
            await _repository.Received().UpdateAsync( Arg.Is<EntitySample>( t => t.Id == _id2 && t.Name == "b" ) );
        }

        /// <summary>
        /// 删除1个项
        /// </summary>
        [Fact]
        public async Task TestSaveAsync_Delete_1() {
            var input = new List<DtoSample> {
                new DtoSample{Id = _id.ToString()}
            };
            await _service.SaveAsync( DtoSample.EmptyList(), DtoSample.EmptyList(), input );
            await _repository.Received( 1 ).RemoveAsync( Arg.Any<Guid>() );
            await _repository.Received().RemoveAsync( Arg.Is<Guid>( id => id == _id ) );
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Fact]
        public async Task TestSaveAsync() {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            var id4 = Guid.NewGuid();
            var id5 = Guid.NewGuid();
            var addList = new List<DtoSample> {
                new DtoSample{Id = id.ToString()},
                new DtoSample{Id = id2.ToString()}
            };
            var updateList = new List<DtoSample> {
                new DtoSample{Id = id3.ToString()},
                new DtoSample{Id = id4.ToString()},
                new DtoSample{Id = id5.ToString()}
            };
            var deleteList = new List<DtoSample> {
                new DtoSample{Id = id3.ToString()}
            };
            var result = await _service.SaveAsync( addList, updateList, deleteList );
            await _repository.Received( 2 ).AddAsync( Arg.Any<EntitySample>() );
            await _repository.Received( 2 ).UpdateAsync( Arg.Any<EntitySample>() );
            await _repository.Received( 1 ).RemoveAsync( Arg.Is<Guid>( t => t == id3 ) );
            await _unitOfWork.Received( 1 ).CommitAsync();
            Assert.Equal( 4, result.Count );
        }
    }
}
