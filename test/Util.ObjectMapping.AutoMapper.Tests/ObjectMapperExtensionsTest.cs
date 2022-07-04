using System;
using System.Collections.Generic;
using AutoMapper;
using Util.Helpers;
using Util.ObjectMapping.AutoMapper.Tests.Samples;
using Xunit;

namespace Util.ObjectMapping.AutoMapper.Tests {
    /// <summary>
    /// ����ӳ��������
    /// </summary>
    public class ObjectMapperExtensionsTest {
        /// <summary>
        /// ����ӳ�� - Sample2 -> Sample δ��������������,���Զ�����ӳ��
        /// </summary>
        [Fact]
        public void TestMapTo_1() {
            var sample = new Sample { StringValue = "a" };
            var sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "a", sample2.StringValue );
        }

        /// <summary>
        /// ����ӳ�� - ӳ����ͬ�������Ĳ�ͬ����
        /// </summary>
        [Fact]
        public void TestMapTo_2() {
            Sample sample = new Sample { Test3 = new Sample3Copy { StringValue = "a" } };
            Sample2 sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "a", sample2.Test3.StringValue );
        }

        /// <summary>
        /// ����ӳ�� - ӳ����ͬ�������Ĳ�ͬ���󼯺�
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
        /// ����ӳ�伯��
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
        /// ����ӳ�伯��
        /// </summary>
        [Fact]
        public void TestMapTo_5() {
            List<Sample> sampleList = new List<Sample> { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapTo<List<Sample2>>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// ��������
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
        /// ����ӳ�� - Sample -> Sample4 ����������������ӳ���ϵ
        /// </summary>
        [Fact]
        public void TestMapTo_7() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = sample.MapTo<Sample4>();
            Assert.Equal( "a-1", sample4.StringValue );
        }

        /// <summary>
        /// ����ӳ��- ����������������ӳ���ϵ - ����������
        /// </summary>
        [Fact]
        public void TestMapTo_8() {
            var sample = new Sample { StringValue = "a" };
            var sample4 = new Sample4();
            sample.MapTo( sample4 );
            Assert.Equal( "a-1", sample4.StringValue );
        }

        /// <summary>
        /// ����ӳ�� - ���ִ��Ԥ����ӳ��
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
        /// ����ӳ�� - Ԥ����ӳ�����Զ�����ӳ����ִ��
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
        /// ����ӳ�伯��
        /// </summary>
        [Fact]
        public void TestMapToList() {
            List<Sample> sampleList = new List<Sample> { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// ӳ�伯�� - ���Կռ���
        /// </summary>
        [Fact]
        public void TestMapToList_2() {
            List<Sample> sampleList = new List<Sample>();
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Empty( sample2List );
        }

        /// <summary>
        /// ӳ�伯�� - ��������
        /// </summary>
        [Fact]
        public void TestMapToList_3() {
            Sample[] sampleList = { new() { StringValue = "a" }, new() { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal( 2, sample2List.Count );
            Assert.Equal( "a", sample2List[0].StringValue );
        }

        /// <summary>
        /// ʧ��ӳ���׳��쳣
        /// </summary>
        [Fact]
        public void TestMapTo_Throw() {
            //�ɹ�ӳ��
            var parentId = Guid.NewGuid().SafeString();
            var dto = new TreeEntityDto() {
                Name = "Test1",
                ParentId = parentId
            };
            var entity = dto.MapTo<TreeEntitySample>();
            Assert.Equal( parentId, entity.ParentId.SafeString() );

            //��������ӳ��ʧ��,�׳��쳣
            var parentId2 = "/";
            var dto2 = new TreeEntityDto() {
                Name = "Test2",
                ParentId = parentId2
            };
            Assert.Throws<AutoMapperMappingException>( () => dto2.MapTo<TreeEntitySample>() );

            //�ɹ�ӳ��,ʧ��ӳ�䲻Ӱ��֮ǰ��ӳ���ϵ
            var entity3 = dto.MapTo<TreeEntitySample>();
            Assert.Equal( parentId, entity3.ParentId.SafeString() );
        }
    }
}
