using AutoMapper;

namespace Util.ObjectMapping {
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public interface IAutoMapperConfig {
        /// <summary>
        /// 配置映射
        /// </summary>
        /// <param name="expression">配置映射表达式</param>
        void Config( IMapperConfigurationExpression expression );
    }
}
