using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Applications.Dtos;
using Util.Ui.Attributes;

namespace Util.Samples.Service.Dtos.Systems {
    /// <summary>
    /// 修改角色请求参数
    /// </summary>
    [Model]
    public class UpdateRoleRequest : RequestBase {
        /// <summary>
        /// 角色标识
        /// </summary>
        [Required( ErrorMessage = "角色标识不能为空" )]
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required( ErrorMessage = "角色编码不能为空" )]
        [StringLength( 256, ErrorMessage = "角色编码输入过长，不能超过256位" )]
        [Display( Name = "角色编码" )]
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required( ErrorMessage = "角色名称不能为空" )]
        [StringLength( 256, ErrorMessage = "角色名称输入过长，不能超过256位" )]
        [Display( Name = "角色名称" )]
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>
        [DataMember]
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 父级角色
        /// </summary>
        [Display( Name = "父级角色" )]
        [DataMember]
        public string ParentName { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        [DataMember]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        [Display( Name = "备注" )]
        [DataMember]
        public string Comment { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        [DataMember]
        public Byte[] Version { get; set; }
    }
}
