using System;
using Util.Domain.Auditing;
using Util.Domain.Tests.Samples.Auditing;
using Util.Helpers;
using Xunit;

namespace Util.Domain.Tests.Auditing {
    /// <summary>
    /// 修改操作审计设置器测试
    /// </summary>
    public class ModificationAuditedSetterTest : IDisposable {
        /// <summary>
        /// 日期
        /// </summary>
        private readonly DateTime _date = "2020-1-1 10:10:10".ToDateTime();

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ModificationAuditedSetterTest() {
            Time.SetTime( _date );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试设置Guid修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Guid() {
            var value = Guid.NewGuid().ToString();
            var entity = new GuidAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空Guid修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Guid_Nullable() {
            var value = Guid.NewGuid().ToString();
            var entity = new NullableGuidAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置int修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Int() {
            var value = "1";
            var entity = new IntAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空int修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Int_Nullable() {
            var value = "1";
            var entity = new NullableIntAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置long修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Long() {
            var value = "1";
            var entity = new LongAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置可空long修改人标识
        /// </summary>
        [Fact]
        public void TestSet_Long_Nullable() {
            var value = "1";
            var entity = new NullableLongAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }

        /// <summary>
        /// 测试设置string修改人标识
        /// </summary>
        [Fact]
        public void TestSet_String() {
            var value = "abc";
            var entity = new StringAuditedEntity();
            ModificationAuditedSetter.Set( entity, value );
            Assert.Equal( _date, entity.LastModificationTime );
            Assert.Equal( value, entity.LastModifierId.SafeString() );
        }
    }
}
