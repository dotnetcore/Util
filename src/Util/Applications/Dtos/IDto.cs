using Util.Validations;

namespace Util.Applications.Dtos {
    /// <summary>
    /// 数据传输对象
    /// </summary>
    public interface IDto : IValidation {
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set; }
    }
}
