using System;
using System.ComponentModel.DataAnnotations;
using Util.Biz.Enums;
using Util.Ui.Attributes;

namespace Util.Samples.Pages.Components.Forms {
    /// <summary>
    /// 基础表单
    /// </summary>
    [Model]
    public class FormModel {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "名称不能为空" )]
        [Display(Name = "姓名" )]
        public string Name { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [Required( ErrorMessage = "请选择民族" )]
        [Display( Name = "民族" )]
        public Nation? Nation { get; set; }
        /// <summary>
        /// 日期时间
        /// </summary>
        [Required( ErrorMessage = "请选择日期时间" )]
        [Display( Name = "日期时间" )]
        public DateTime? DateTime { get; set; }
    }
}
