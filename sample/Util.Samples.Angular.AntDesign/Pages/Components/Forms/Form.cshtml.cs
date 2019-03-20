using System.ComponentModel.DataAnnotations;
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
    }
}
