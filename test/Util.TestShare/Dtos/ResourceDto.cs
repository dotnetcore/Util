using System;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Trees;

namespace Util.Tests.Dtos {
    /// <summary>
    /// 资源参数
    /// </summary>
    public class ResourceDto : TreeDtoBase<ResourceDto> {
        /// <summary>
        /// 资源标识符
        ///</summary>
        [Display( Name = "资源标识符" )]
        [MaxLength( 300 )]
        public string Uri { get; set; }
        /// <summary>
        /// 资源名称
        ///</summary>
        [Display( Name = "资源名称" )]
        [Required]
        [MaxLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        ///</summary>
        [Display( Name = "备注" )]
        [MaxLength( 500 )]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        ///</summary>
        [Display( Name = "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        ///</summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        ///</summary>
        [Display( Name = "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 版本号
        ///</summary>
        [Display( Name = "版本号" )]
        public byte[] Version { get; set; }

        public override string GetText() {
            return Name;
        }
    }
}