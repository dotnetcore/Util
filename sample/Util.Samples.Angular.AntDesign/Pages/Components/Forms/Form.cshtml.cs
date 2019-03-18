using System.ComponentModel.DataAnnotations;
using Util.Ui.Pages;

namespace Util.Samples.Pages.Components.Forms {
    /// <summary>
    /// 基础表单
    /// </summary>
    public class FormModel : PageModelBase {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "名称不能为空" )]
        public string Name { get; set; }
    }
}
