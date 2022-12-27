using System;
using System.Collections.Generic;
using AutoMapper;
using Util.Helpers;
using Util.ObjectMapping.AutoMapper.Tests.Samples;
using Xunit;

namespace Util.ObjectMapping.AutoMapper.Tests
{
    /// <summary>
    /// 对象映射器测试
    /// </summary>
    public class ObjectMapperExtensionsTest {
        /// <summary>
        /// 测试映射 - Sample2 -> Sample 未在配置类中配置,将自动配置映射
        /// </summary>
        [Fact]
        public void TestMapTo_1() {
            var sample = new Sample { StringValue = "a" };
            var sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "a", sample2.StringValue );
        }

        /// <summary>
        /// 测试映射 - 映射相同属性名的不同对象
        /// </summary>
        [Fact]
        public void TestMapTo_2() {
            Sample sample = new Sample { Test3 = new Sample3Copy { StringValue = "a" } };
            Sample2 sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "a", sample2.Test3.StringValue );
        }

        /// <summary>
        /// 测试映射 - 映射相同属性名的不同对象集合
        /// </summary>
        [Fact]
        public void TestMapTo_3() {
            Sample sample = new Sample { TestList = new List<Sample3Copy> { new() { StringValue = "a" }, new() { StringValue = "b" } } };
            Sample2 sample2 = sample.MapTo<Sample2>();
            Assert.Equal( 2, sample2.TestList.Count );
            Assert.Equal( "a", sample2.TestList[0].StringValue );
            Assert.Equal( "b", sample2.TestList[1].StringValue );
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapTo_4() {
            List<Sample> sampleList = new List<Sample> { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = new List<Sample2>();
            sampleList.MapTo( sample2List );
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapTo_5() {
            List<Sample> sampleList = new List<Sample> { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapTo<List<Sample2>>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// 并发测试
        /// </summary>
        [Fact]
        public void TestMapTo_6() {
            Thread.ParallelFor( () => {
                var sample = new Sample { StringValue = "a" };
                var sample2 = sample.MapTo<Sample2>();
                Assert.Equal( "a", sample2.StringValue );
            }, 20 );
        }

        /// <summary>
        /// 测试映射 - Sample -> Sample4 已在配置类中配置映射关系
        /// </summary>
        [Fact]
        public void TestMapTo_7() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "a-1", sample4.StringValue );
        }

        /// <summary>
        /// 测试映射- 已在配置类中配置映射关系 - 带参数重载
        /// </summary>
        [Fact]
        public void TestMapTo_8() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = new Sample4();
            sample.MapTo( sample4 );
            Assert.Equal( "a-1", sample4.StringValue );
        }

        /// <summary>
        /// 测试映射 - 多次执行预配置映射
        /// </summary>
        [Fact]
        public void TestMapTo_9() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "a-1", sample4.StringValue );

            sample.StringValue = "b";
            sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "b-1", sample4.StringValue );

            sample.StringValue = "c";
            sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "c-1", sample4.StringValue );
        }

        /// <summary>
        /// 测试映射 - 预配置映射与自动配置映射混合执行
        /// </summary>
        [Fact]
        public void TestMapTo_10() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "a-1", sample4.StringValue );

            sample.StringValue = "b";
            var sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "b", sample2.StringValue );

            sample.StringValue = "c";
            sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "c-1", sample4.StringValue );
        }

        /// <summary>
        /// 测试具有简单循环依赖的场景
        /// </summary>
        [Fact]
        public void TestMapTo_11() {
            var sample = new Sample6() {
                Name = "Sample6",
                Sample51 = new Sample5 {
                    Name = "Sample51",
                    Sample61 = new() { Name = "Sample61",Sample51 = new () {
                            Name = "Sample512"
                        }
                    },
                },
                Sample71 = new Sample7 {
                    Name = "Sample71",
                    Sample75 = new() { Name = "Sample75" }
                }
            };
            var result = sample.MapTo<Sample6to>();
            Assert.Equal( "Sample6", result.Name );
            Assert.Equal( "Sample51", result.Sample51.Name );
            Assert.Equal( "Sample61", result.Sample51.Sample61.Name );
            Assert.Equal( "Sample512", result.Sample51.Sample61.Sample51.Name );
            Assert.Equal( "Sample71", result.Sample71.Name );
            Assert.Equal( "Sample75", result.Sample71.Sample75.Name );
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapToList() {
            List<Sample> sampleList = new List<Sample> { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// 映射集合 - 测试空集合
        /// </summary>
        [Fact]
        public void TestMapToList_2() {
            List<Sample> sampleList = new List<Sample>();
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Empty( sample2List );
        }

        /// <summary>
        /// 映射集合 - 测试数组
        /// </summary>
        [Fact]
        public void TestMapToList_3() {
            Sample[] sampleList = { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// 失败映射抛出异常
        /// </summary>
        [Fact]
        public void TestMapTo_Throw() {
            //成功映射
            var parentId = Guid.NewGuid().SafeString();
            var dto = new TreeEntityDto() {
                Name = "Test1",
                ParentId = parentId
            };
            var entity = dto.MapTo<TreeEntitySample>();
            Assert.Equal( parentId, entity.ParentId.SafeString() );

            //错误数据映射失败,抛出异常
            var parentId2 = "/";
            var dto2 = new TreeEntityDto() {
                Name = "Test2",
                ParentId = parentId2
            };
            Assert.Throws<AutoMapperMappingException>( () => dto2.MapTo<TreeEntitySample>() );

            //成功映射,失败映射不影响之前的映射关系
            var entity3 = dto.MapTo<TreeEntitySample>();
            Assert.Equal( parentId, entity3.ParentId.SafeString() );
        }
    }
}
