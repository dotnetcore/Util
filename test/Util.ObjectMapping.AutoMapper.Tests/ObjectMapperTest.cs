using Util.ObjectMapping.AutoMapper.Tests.Samples;
using Xunit;

namespace Util.ObjectMapping.AutoMapper.Tests {
    /// <summary>
    /// 对象映射器测试
    /// </summary>
    public class ObjectMapperTest {
        /// <summary>
        /// 对象映射器
        /// </summary>
        private readonly IObjectMapper _mapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ObjectMapperTest( IObjectMapper mapper ) {
            _mapper = mapper;
        }

        /// <summary>
        /// 测试映射 - Sample -> Sample2 已在配置类中配置映射关系
        /// </summary>
        [Fact]
        public void TestMap_1() {
            var sample = new Sample { StringValue = "a" };
            var sample2 =_mapper.Map<Sample,Sample2>( sample );
            Assert.Equal( "a", sample2.StringValue );
        }

        /// <summary>
        /// 测试映射- Sample -> Sample2 已在配置类中配置映射关系 - 两参数重载
        /// </summary>
        [Fact]
        public void TestMap_2() {
            var sample = new Sample { StringValue = "a" };
            var sample2 = new Sample2();
            _mapper.Map( sample, sample2 );
            Assert.Equal( "a", sample2.StringValue );
        }

        /// <summary>
        /// 测试映射 - Sample2 -> Sample 未在配置类中配置,将自动配置映射
        /// </summary>
        [Fact]
        public void TestMap_3() {
            var sample2 = new Sample2 { StringValue = "a" };
            var sample = _mapper.Map<Sample2, Sample>( sample2 );
            Assert.Equal( "a", sample.StringValue );
        }

        /// <summary>
        /// 测试映射 - 用于重现动态配置后映射之前的配置出现问题
        /// 1. 执行Sample -> Sample2映射,已在配置类中配置映射关系
        /// 2. 执行Sample2 -> Sample映射,未在配置类中配置,将自动配置映射
        /// 3. 重复执行Sample -> Sample2映射
        /// </summary>
        [Fact]
        public void TestMap_4() {
            var sample = new Sample { StringValue = "a" };
            var sample2 = _mapper.Map<Sample, Sample2>( sample );
            Assert.Equal( "a", sample2.StringValue );

            var sample3 = _mapper.Map<Sample2, Sample>( sample2 );
            Assert.Equal( "a", sample3.StringValue );

            var sample4 = _mapper.Map<Sample, Sample2>( sample );
            Assert.Equal( "a", sample4.StringValue );
        }
    }
}
