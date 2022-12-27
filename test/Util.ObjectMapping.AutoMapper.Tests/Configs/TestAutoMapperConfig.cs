using AutoMapper;
using Util.ObjectMapping.AutoMapper.Tests.Samples;

namespace Util.ObjectMapping.AutoMapper.Tests.Configs {
    /// <summary>
    /// AutoMapper测试配置 - 该配置通过启动器扫描注册
    /// </summary>
    public class TestAutoMapperConfig : IAutoMapperConfig {
        /// <summary>
        /// 配置映射
        /// </summary>
        /// <param name="expression">配置映射表达式</param>
        public void Config( IMapperConfigurationExpression expression ) {
            expression.CreateMap<Sample, Sample4>()
                .ForMember( o => o.StringValue, o => o.MapFrom( ( s, d ) => s.StringValue + "-1" ) );
        }
    }
}
