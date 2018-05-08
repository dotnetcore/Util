using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Applications.Dtos;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树型数据传输对象
    /// </summary>
    [DataContract]
    public abstract class TreeDtoBase : DtoBase, ITreeNode {
        /// <summary>
        /// 父标识
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }
        /// <summary>
        /// 父名称
        /// </summary>
        [DataMember]
        public string ParentName { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [DataMember]
        public string Path { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [DataMember]
        public int? Level { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        [DataMember]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Display( Name = "排序号" )]
        [DataMember]
        public int? SortId { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display( Name = "是否展开" )]
        [DataMember]
        public bool? Expanded { get; set; }
    }
}
