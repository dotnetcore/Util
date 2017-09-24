using System.Runtime.Serialization;

namespace Util.Applications.Dtos {
    /// <summary>
    /// 数据传输对象
    /// </summary>
    [DataContract]
    public abstract class DtoBase : RequestBase, IDto {
        /// <summary>
        /// 标识
        /// </summary>
        [DataMember]
        public string Id { get; set; }
    }
}
