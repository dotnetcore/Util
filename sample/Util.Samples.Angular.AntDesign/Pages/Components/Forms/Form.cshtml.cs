using System;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;
using Util.Biz.Enums;

namespace Util.Samples.Pages.Components.Forms {
    /// <summary>
    /// 基础表单
    /// </summary>
    public class FormModel : RequestBase {
        /// <summary>
        /// 编码
        /// </summary>
        [Display( Name = "编码" )]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "姓名不能为空" )]
        [StringLength( 10 )]
        [Display( Name = "姓名" )]
        public string Name { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display( Name = "民族" )]
        public Nation? Nation { get; set; }

        /// <summary>
        /// 日期时间
        /// </summary>
        [Display( Name = "日期时间" )]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display( Name = "备注" )]
        public string Comment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display( Name = "备注" )]
        public string Comment2 { get; set; }
    }
}
