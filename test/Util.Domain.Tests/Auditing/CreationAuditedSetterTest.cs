using System;
using Util.Domain.Auditing;
using Util.Domain.Tests.Samples.Auditing;
using Util.Helpers;
using Xunit;

namespace Util.Domain.Tests.Auditing {
    /// <summary>
    /// 创建操作审计设置器测试
    /// </summary>
    public class CreationAuditedSetterTest : IDisposable {
        /// <summary>
        /// 日期
        /// </summary>
        private readonly DateTime _date = "2020-1-1 10:10:10".ToDateTime();

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CreationAuditedSetterTest() {
            Time.SetTime( _date );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试设置Guid创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Guid() {
            var value = Guid.NewGuid().ToString();
            var entity = new GuidAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空Guid创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Guid_Nullable() {
            var value = Guid.NewGuid().ToString();
            var entity = new NullableGuidAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置int创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Int() {
            var value = "1";
            var entity = new IntAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空int创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Int_Nullable() {
            var value = "1";
            var entity = new NullableIntAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置long创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Long() {
            var value = "1";
            var entity = new LongAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空long创建人标识
        /// </summary>
        [Fact]
        public void TestSet_Long_Nullable() {
            var value = "1";
            var entity = new NullableLongAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }

        /// <summary>
        /// 测试设置string创建人标识
        /// </summary>
        [Fact]
        public void TestSet_String() {
            var value = "abc";
            var entity = new StringAuditedEntity();
            CreationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.CreationTime );
            Assert.Equal( value, entity.CreatorId.SafeString() );
        }
    }
}
