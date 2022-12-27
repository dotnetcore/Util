using System;
using Util.Domain.Tests.Samples;
using Util.Domain.Tests.XUnitHelpers;
using Util.Exceptions;
using Util.Validation;
using Xunit;

namespace Util.Domain.Tests.Entities {
    /// <summary>
    /// Guid标识实体测试
    /// </summary>
    public class GuidEntityTest {
        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private AggregateRootSample _sample;
        /// <summary>
        /// 聚合根测试样例2
        /// </summary>
        private AggregateRootSample _sample2;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GuidEntityTest() {
            _sample = new AggregateRootSample();
            _sample2 = new AggregateRootSample();
        }

        /// <summary>
        /// 测试实体相等性 - 判空
        /// </summary>
        [Fact]
        public void TestEquals_Null() {
            Assert.False( _sample.Equals( _sample2 ) );
            Assert.False( _sample.Equals( null ) );

            Assert.False( _sample == _sample2 );
            Assert.False( _sample == null );
            Assert.False( null == _sample2 );

            Assert.True( _sample != _sample2 );
            Assert.True( _sample != null );
            Assert.True( null != _sample2 );

            _sample2 = null;
            Assert.True( _sample2 == null );
            Assert.False( _sample.Equals( _sample2 ) );

            _sample = null;
            Assert.True( _sample == _sample2 );
            Assert.True( _sample2 == _sample );
        }

        /// <summary>
        /// 测试实体相等性 - 类型无效
        /// </summary>
        [Fact]
        public void TestEquals_InvalidType() {
            Guid id = Guid.NewGuid();
            _sample = new AggregateRootSample( id );
            AggregateRootSample2 sample2 = new AggregateRootSample2( id );
            Assert.False( _sample.Equals( sample2 ) );
            Assert.True( _sample != sample2 );
            Assert.True( sample2 != _sample );
        }

        /// <summary>
        /// 测试实体相等性 - 当两个实体的标识相同，则实体相同
        /// </summary>
        [Fact]
        public void TestEquals_IdEquals() {
            Guid id = Guid.NewGuid();
            _sample = new AggregateRootSample( id );
            _sample2 = new AggregateRootSample( id );
            Assert.True( _sample.Equals( _sample2 ) );
            Assert.True( _sample == _sample2 );
            Assert.False( _sample != _sample2 );
        }

        /// <summary>
        /// 测试验证 - Id为空，无法通过
        /// </summary>
        [Fact]
        public void TestValidate_IdIsEmpty() {
            AssertHelper.Throws<Warning>( () => {
                _sample = AggregateRootSample.CreateSample( Guid.Empty );
                _sample.Validate();
            }, "标识" );
        }

        /// <summary>
        /// 验证必填项，通过字符串设置错误消息
        /// </summary>
        [Fact]
        public void TestValidate_Required() {
            AssertHelper.Throws<Warning>( () => {
                _sample.Name = null;
                _sample.Validate();
            }, "姓名不能为空" );
        }

        /// <summary>
        /// 测试添加验证规则
        /// </summary>
        [Fact]
        public void TestAddValidationRule() {
            _sample = AggregateRootSample.CreateSample();
            AssertHelper.Throws<Warning>( () => {
                _sample.Name = "abcd";
                _sample.AddValidationRule( new ValidationRuleSample( _sample ) );
                _sample.Validate();
            }, "名称长度不能大于3" );
        }

        /// <summary>
        /// 测试设置验证处理器 - 不进行任何操作，所以不会抛出异常
        /// </summary>
        [Fact]
        public void TestSetValidationHandler() {
            _sample = AggregateRootSample.CreateSample();
            _sample.Name = "abcd";
            _sample.AddValidationRule( new ValidationRuleSample( _sample ) );
            _sample.SetValidationHandler( new NothingHandler() );
            _sample.Validate();
        }
    }
}
